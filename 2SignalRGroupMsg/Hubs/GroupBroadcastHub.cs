using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace _2SignalRGroupMsg.Hubs
{
    [HubName("groupBroadcastHub")]
    public class GroupBroadcastHub : Hub
    {
        public void SendToGroup(string message)
        {
            // Send the message to the clients that belong to the same group
            message = string.Format("Group name: {0}, message: {1}", Context.ConnectionId, message);
            // Clients.Group(Context.ConnectionId).broadcastGroupMessage(message);
            Clients.Group("Test").broadcastGroupMessage(message);
        }

        public override Task OnConnected()
        {
            // Add the connection id to the group. The name of the group is the connection id.
            // Groups.Add(Context.ConnectionId, Context.ConnectionId);
            Groups.Add(Context.ConnectionId, "Test");
            return base.OnConnected();
        }
    }
}