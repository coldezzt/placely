using System.Globalization;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.SignalR;
using Placely.Data.Abstractions.Services;
using Placely.Data.Dtos;
using Placely.Data.Entities;
using Placely.Data.Models;
using SignalRSwaggerGen.Attributes;

namespace Placely.Main.Controllers.Hubs;

[SignalRHub("/api/hubs/chat", tag: "Chat hub")]
public class ChatHub(
    IChatService chatService,
    IMessageService messageService,
    IMapper mapper,
    IValidator<MessageDto> validator) : Hub
{
    public async Task LoadHistory(long chatId)
    {
        var claimId = GetClaim(CustomClaimTypes.UserId);
        if (claimId is null)
        {
            await Clients.Caller.SendAsync("Unauthorized", "Вы не авторизованы!");
            return;
        }

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
        {
            await Clients.Caller.SendAsync("BadRequest", "Ошибка в запросе!");
            return;
        }

        var dbChat = await chatService.GetByIdAsync(chatId);
        if (dbChat.FirstUserId != id && dbChat.SecondUserId != id)
        {
            await Clients.Caller.SendAsync("Forbidden", "Вы не состоите в этом чате!");
            return;
        }
        
        var messages = await messageService.GetMessagesAsync(chatId);
        await Clients.Caller.SendAsync("LoadHistory", messages);
    }
    
    public async Task SendMessage(MessageDto dto)
    {
        var claimId = GetClaim(CustomClaimTypes.UserId);
        if (claimId is null)
        {
            await Clients.Caller.SendAsync("Unauthorized", "Вы не авторизованы!");
            return;
        }

        if (!long.TryParse(claimId, NumberStyles.Any, CultureInfo.InvariantCulture, out var id))
        {
            await Clients.Caller.SendAsync("BadRequest", "Ошибка в запросе!");
            return;
        }

        var dbChat = await chatService.GetByIdAsync(dto.ChatId);
        if (dbChat.FirstUserId != id && dbChat.SecondUserId != id)
        {
            await Clients.Caller.SendAsync("Forbidden", "Вы не состоите в этом чате!");
            return;
        }
        
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            await Clients.Caller.SendAsync("InvalidMessage", validationResult.Errors);
            return;
        }
        
        var message = mapper.Map<Message>(dto);
        await messageService.AddMessageAsync(message);
        await Clients.All.SendAsync("ReceiveMessage", dto);
    }
    
    private string? GetClaim(string type)
    {
        return Context.User?.Claims.FirstOrDefault(c => c.Type == type)?.Value;
    }
}