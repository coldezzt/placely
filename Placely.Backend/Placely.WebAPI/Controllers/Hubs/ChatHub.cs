using System.ComponentModel;
using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.SignalR;
using Placely.Application.Common.Models;
using Placely.Domain.Entities;
using Placely.Domain.Interfaces.Services;
using Placely.WebAPI.Dto;
using SignalRSwaggerGen.Attributes;
using SignalRSwaggerGen.Enums;

namespace Placely.WebAPI.Controllers.Hubs;

[SignalRHub("/api/hubs/chat", tag: "Chat")]
public class ChatHub(
    IChatService chatService, 
    IMessageService messageService, 
    IMapper mapper,
    IValidator<MessageDto> validator) : Hub
{
    [SignalRMethod(summary: "Загружает историю чата пользователя", description: 
        """
        !**НЕ МОЖЕТ БЫТЬ ПРОВЕРЕН В SwaggerUI**!

        SwaggerUI не поддерживает протокол, по которому передаются данные в SignalR.

        Возвращает ответ вызывающему.
        """, operation: Operation.Get)]
    [return: SignalRReturn(typeof(List<MessageDto>), 200,
        """
        Список сообщений.

        Вызывает 'LoadHistory' у клиента. Передаёт список сообщений.
        """)]
    [return: SignalRReturn(typeof(string), 401, 
        """
        Пользователь не авторизован.

        Вызывает 'Unauthorized' у клиента.
        """)]
    [return: SignalRReturn(typeof(string), 403, 
        """
        Попытка получить историю сообщения чужого чата.

        Вызывает 'Forbidden' у клиента.
        """)]
    public async Task LoadHistory(
        [DefaultValue(1)] [SignalRParam("Идентификатор чата.", typeof(long))] long chatId)
    {
        // Выполняем проверки
        var claimId = Context.User?.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null ||
            !long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var clientId))
        {
            await Clients.Caller.SendAsync("Unauthorized");
            return;
        }

        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.Participants.Any(p => p.Id == clientId)) 
        {
            await Clients.Caller.SendAsync("Forbidden");
            return;
        }

        // Закидываем пользователя в группу с id чата
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
        
        // Возвращаем историю сообщений
        var messages = await messageService.GetListAsync(chatId);
        var response = messages.Select(mapper.Map<MessageDto>);
        await Clients.Caller.SendAsync("LoadHistory", response);
    }

    [SignalRMethod(summary: "Отправляет сообщение всем участникам чата (включая владельца)", description: 
        """
        !**НЕ МОЖЕТ БЫТЬ ПРОВЕРЕН В SwaggerUI**!

        SwaggerUI не поддерживает протокол, по которому передаются данные в SignalR.

        Отправляет ответ ВСЕМ участникам чата.
        """)]
    [return: SignalRReturn(typeof(MessageDto), 200, 
        """
        Отправленное сообщение.

        Вызывает 'ReceiveMessage' у ВСЕХ участников чата. Передаёт сообщение.
        """)]
    [return: SignalRReturn(typeof(string), 401, 
        """
        Пользователь не авторизован.

        Вызывает 'Unauthorized' у клиента.
        """)]
    [return: SignalRReturn(typeof(string), 403, 
        """
        Попытка получить историю сообщения чужого чата.

        Вызывает 'Forbidden' у клиента.
        """)]
    [return: SignalRReturn(typeof(List<ValidationErrorModel>), 422, 
        """
        Данные не прошли валидацию.

        Вызывает 'UnprocessableEntity' у клиента. Передаёт список ошибок.
        """)]
    public async Task SendMessage([SignalRParam("Данные сообщения.", typeof(MessageDto))] MessageDto dto)
    {
        // Выполняем проверки
        var claimId = Context.User?.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null 
            || !long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var cliendId))
        {
            await Clients.Caller.SendAsync("Unauthorized");
            return;
        }
        
        var dbChat = await chatService.GetByIdAsync(dto.ChatId);
        if (dbChat.Participants.Any(p => p.Id == cliendId)) 
        {
            await Clients.Caller.SendAsync("Forbidden");
            return;
        }

        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            await Clients.Caller.SendAsync("UnprocessableEntity",
                validationResult.Errors.Select(mapper.Map<ValidationErrorModel>));
            return;
        }
        
        
        var message = mapper.Map<Message>(dto);
        var dbMessage = await messageService.AddAsync(message);
        var response = mapper.Map<MessageDto>(dbMessage);
        
        // Отправляем сообщение только в группу подключений к этому чату
        await Clients.Group(dto.ChatId.ToString()).SendAsync("ReceiveMessage", response);
    }
}