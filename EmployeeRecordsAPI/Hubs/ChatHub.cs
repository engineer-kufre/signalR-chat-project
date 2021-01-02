using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EmployeeRecordsAPI.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string to, string message)
        {
            string toClient = to;
            if (toClient == string.Empty)
            {
                await Clients.All.SendAsync("ReceiveMessage", user, message);
            }
            else
            {
                await Clients.Client(toClient).SendAsync("ReceiveMessage", user, message);
            }
        }

        public override Task OnConnectedAsync()
        {
            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConnID", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
