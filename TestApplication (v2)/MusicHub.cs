

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication__v2_
{
    public class MusicHub : Hub
    {
        public Task TrackUpdate(string id, string rating)
        {
            return Clients.All.SendAsync("TrackUpdate", id, rating);
        }

        
      
    }
}
