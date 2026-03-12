using Microsoft.AspNetCore.SignalR;
using ChatSupport.API.Application.Services;
using ChatSupport.API.Domain.Entities;

namespace ChatSupport.API.Hubs;

public class ChatHub : Hub
{
    private readonly ChatService _chatService;

    public ChatHub(ChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task JoinAgentPanel()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "agents");
    }


    public async Task<Chat> CreateChat(string userName, string email)
    {
        var chat = await _chatService.CreateChatAsync(userName, email);

        await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id);

        await Clients.Group("agents")
            .SendAsync("NewChatCreated", chat);

      return chat;      
    }

    public async Task JoinChat(string chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
    }

    public async Task SendMessage(string chatId, string sender, string message)
    {
          Console.WriteLine($"Mensaje recibido -> Chat:{chatId} Sender:{sender} Text:{message}");
          
        await _chatService.SaveMessageAsync(chatId, sender, message);

        await Clients.Group(chatId)
            .SendAsync("ReceiveMessage", sender, message);
    }

    public async Task LoadChatHistory(string chatId)
    {
        var messages = await _chatService.GetChatMessagesAsync(chatId);

        await Clients.Caller.SendAsync("ChatHistory", messages);
    }

    public async Task GetActiveChats()
    {
        var chats = await _chatService.GetActiveChatsAsync();

        await Clients.Caller.SendAsync("ActiveChats", chats);
    }

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }


    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }

}