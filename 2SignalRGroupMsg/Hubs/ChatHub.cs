using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System.Threading;

namespace _2SignalRGroupMsg.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        // Number of connected clients
        private static int connectionCount = 0;

        public void Send(string name, string message)
        {
            // Append the current date
            name = DateTime.Now.ToString() + " " + name;
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public override Task OnConnected()
        {
            // Increase the number of connections
            Interlocked.Increment(ref connectionCount);

            // Update the number of the connected users
            Clients.All.reportConnections(connectionCount);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            // Decrease the number of connections
            Interlocked.Decrement(ref connectionCount);

            // Update the number of the connected users
            Clients.All.reportConnections(connectionCount);
            return base.OnDisconnected(stopCalled);
        }
    }

}