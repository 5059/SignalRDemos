using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using _2SignalRGroupMsg.Hubs;
using System;
using System.Threading;

namespace _2SignalRGroupMsg
{
    public class ServerTimestamp
    {
        // Singleton instance. This is the only instance that can be created because the constructor is private.
        // Lazy initialization of an object means that its creation is deferred until it is first used.
        // Pass a delegate in the Lazy<T> constructor that invokes a specific constructor overload on the wrapped type at creation time
        private readonly static Lazy<ServerTimestamp> _instance =
            new Lazy<ServerTimestamp>(() => new ServerTimestamp(GlobalHost.ConnectionManager.GetHubContext<ServerBroadcastHub>().Clients));

        private readonly Timer _timer;

        private ServerTimestamp(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;

            // Start up a timer that sends the timestamp to the connected clients
            _timer = new Timer(UpdateServerTimeStamp, null, 2000, 1000);
        }

        public static ServerTimestamp Instance
        {
            get { return _instance.Value; }
        }

        private IHubConnectionContext<dynamic> Clients { get; set; }

        /// <summary>
        /// Timer callback function
        /// </summary>
        /// <param name="state"></param>
        private void UpdateServerTimeStamp(object state)
        {
            // Call the broadcastTimestamp method to update all clients.
            Clients.All.broadcastTimestamp(DateTime.Now.ToString());
        }
    }
}