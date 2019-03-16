using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalR.NetCore.SignalR
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string userName, string content)
            => await Clients.All.SendAsync("ReceiveMessage", userName, content);
    }
}
