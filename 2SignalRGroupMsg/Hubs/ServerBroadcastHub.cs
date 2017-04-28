using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace _2SignalRGroupMsg.Hubs
{
    [HubName("serverBroadcastHub")]
    public class ServerBroadcastHub : Hub
    {
        private readonly ServerTimestamp _serverTimeStamp;

        /// <summary>
        /// The constructor invokes another constructor in the same object by using the 'this' keyword
        /// </summary>
        public ServerBroadcastHub() : this(ServerTimestamp.Instance) { }

        public ServerBroadcastHub(ServerTimestamp serverTimeStamp)
        {
            _serverTimeStamp = serverTimeStamp;
        }
    }
}