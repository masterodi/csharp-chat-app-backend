using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public ChatHub() { }

    public async Task JoinChat(UserConnection conn)
    {
        await Clients.All.SendAsync("JoinChat", "admin", $"{conn.Username} has joined");
    }

    public async Task JoinSpecificChatRoom(UserConnection conn)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
        await Clients
            .Group(conn.ChatRoom)
            .SendAsync(
                "JoinSpecificChatRoom",
                "admin",
                $"User [{conn.Username}] has joined Chat Room [{conn.ChatRoom}]"
            );
    }
}
