using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ErbiumCapstone.SignalR.Hubs
{
    public class ChatHub : Hub //hub class manages connections, groups, and messaging
    { 
        public async Task SendMessage(string user, string message)
        {   //can be called by a connected client to send a message to all clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
