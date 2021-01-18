using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErbiumCapstone.Models;
using Microsoft.AspNetCore.SignalR;
using System.Web;
using System.Web.Providers.Entities;

namespace ErbiumCapstone.SignalR.Hubs
{
    public class ChatHub : Hub //hub class manages connections, groups, and messaging
    { 

        public async Task SendMessage(string user, string message)
        {   //can be called by a connected client to send a message to all clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        //sends message back to caller
        public Task SendMessageToCaller(string user, string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }

        
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();

            //string userName = Context.User.Identity.Name;
            //string connectionId = Context.ConnectionId;


        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }

        public Task SendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }
    }
}
