using GamePeekr.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace GamePeekr
{
    public class SignalrService : ISignalrService
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public SignalrService(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendMessageToAllClients(string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
