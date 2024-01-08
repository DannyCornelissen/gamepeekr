using GamepeekrReviewManagement.Classes;
using Microsoft.AspNetCore.SignalR;

namespace GamePeekr.Hubs
{
    public class MessageHub: Hub
    {
        private readonly ISignalrService _signalrService;

        public MessageHub(ISignalrService signalrService)
        {
            _signalrService = signalrService;
        }


        public async Task SendMessageFromCode(string message)
        {
            await _signalrService.SendMessageToAllClients(message);
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("Connected");
        }
    }
}
