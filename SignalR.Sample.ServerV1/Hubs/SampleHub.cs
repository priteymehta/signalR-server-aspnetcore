using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Server.Hubs
{
    public class SampleHub : Hub
    {
        public int GetNumber(int number)
        {
            return number + 1;
        }
    }
}
