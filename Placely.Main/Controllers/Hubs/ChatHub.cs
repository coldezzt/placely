using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.SignalR;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using SignalRSwaggerGen.Attributes;
using SignalRSwaggerGen.Enums;

namespace Placely.Main.Controllers.Hubs;

[SignalRHub("/api/hubs/chat", tag: "Chat")]
public class ChatHub(
    IChatService chatService,
    IMessageService messageService,
    IMapper mapper,
    IValidator<MessageDto> validator) : Hub
{
    [SignalRMethod(
        summary: "Загружает историю чата пользователя",
        description: """
                     !**НЕ МОЖЕТ БЫТЬ ПРОВЕРЕН В SwaggerUI**!

                     SwaggerUI не поддерживает протокол, по которому передаются данные в SignalR.

                     Возвращает ответ вызывающему.
                     """,
        operation: Operation.Get)]
    [return: SignalRReturn(
        statusCode: 200,
        description: """
                     Список сообщений.

                     Вызывает 'LoadHistory' у клиента. Передаёт список сообщений.
                     """,
        returnType: typeof(List<MessageDto>))]
    [return: SignalRReturn(
        statusCode: 401,
        description: """
                     Пользователь не авторизован.

                     Вызывает 'Unauthorized' у клиента.
                     """,
        returnType: typeof(string))]
    [return: SignalRReturn(
        statusCode: 403,
        description: """
                     Попытка получить историю сообщения чужого чата.

                     Вызывает 'Forbidden' у клиента.
                     """,
        returnType: typeof(string))]
    public async Task LoadHistory(
        [SignalRParam(
            description: "Идентификатор чата.",
            paramType: typeof(long))]
        long chatId)
    {
        var claimId = Context.User?.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null
            || !long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var clientId))
        {
            await Clients.Caller.SendAsync("Unauthorized");
            return;
        }

        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != clientId && dbChat.SecondUserId != clientId)
        {
            await Clients.Caller.SendAsync("Forbidden");
            return;
        }
        
        var messages = await messageService.GetMessagesAsync(chatId);
        var response = messages.Select(mapper.Map<MessageDto>);
        await Clients.Caller.SendAsync("LoadHistory", response);
    }
    
    [SignalRMethod(
        summary: "Отправляет сообщение всем участникам чата (включая владельца)",
        description: """
                     !**НЕ МОЖЕТ БЫТЬ ПРОВЕРЕН В SwaggerUI**!

                     SwaggerUI не поддерживает протокол, по которому передаются данные в SignalR.

                     Отправляет ответ ВСЕМ участникам чата.
                     """)]
    [return: SignalRReturn(
        statusCode: 200,
        description: """
                     Отправленное сообщение.

                     Вызывает 'ReceiveMessage' у ВСЕХ участников чата. Передаёт сообщение.
                     """,
        returnType: typeof(MessageDto))]
    [return: SignalRReturn(
        statusCode: 401,
        description: """
                     Пользователь не авторизован.

                     Вызывает 'Unauthorized' у клиента.
                     """,
        returnType: typeof(string))]
    [return: SignalRReturn(
        statusCode: 403,
        description: """
                     Попытка получить историю сообщения чужого чата.

                     Вызывает 'Forbidden' у клиента.
                     """,
        returnType: typeof(string))]
    [return: SignalRReturn(
        statusCode: 422,
        description: """
                     Данные не прошли валидацию.

                     Вызывает 'UnprocessableEntity' у клиента. Передаёт список ошибок.
                     """,
        returnType: typeof(List<ValidationError>))]
    public async Task SendMessage(
        [SignalRParam(
            description: "Данные сообщения.",
            paramType: typeof(MessageDto))]  
        MessageDto dto)
    {
        var claimId = Context.User?.FindFirstValue(CustomClaimTypes.UserId);
        if (claimId is null 
            || !long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
        {
            await Clients.Caller.SendAsync("Unauthorized");
            return;
        }

        var dbChat = await chatService.GetByIdAsync(dto.ChatId);
        if (dbChat.FirstUserId != id && dbChat.SecondUserId != id)
        {
            await Clients.Caller.SendAsync("Forbidden");
            return;
        }
        
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            await Clients.Caller.SendAsync("UnprocessableEntity", validationResult.Errors.Select(mapper.Map<ValidationError>));
            return;
        }
        
        var message = mapper.Map<Message>(dto);
        var dbMessage = await messageService.AddMessageAsync(message);
        var response = mapper.Map<MessageDto>(dbMessage);
        await Clients.All.SendAsync("ReceiveMessage", response);
    }
}