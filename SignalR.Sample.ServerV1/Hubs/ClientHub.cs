using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Sample.ServerV1.Hubs
{
    public class ClientHub : Hub
    {
        public async Task SendMessageToAllClients(string message)
        {
            string callerConnectionId = Context.ConnectionId;
            await Clients.AllExcept(callerConnectionId).SendAsync("newMessage", "Message from Server", message);
        }

        public string GetClientConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
