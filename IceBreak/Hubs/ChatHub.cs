using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IceBreak.Hubs
{
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendSort(string user, string[] list)
        {
            await Clients.All.SendAsync("ReceiveSort", user, list);
        }

        public async Task CreateYNRoom()
        {
            var rand = new Random();
            int roomId = rand.Next(0, 100000);
            await Clients.All.SendAsync("ReceiveYNRoomId", roomId);
        }

        public async Task EnterYN(int roomId)
        {
            await Clients.All.SendAsync("EnterYN", roomId);
        }

        public async Task CleanYNResult(int roomId)
        {
            await Clients.All.SendAsync("CleanYNResult", roomId);
        }

        public async Task SendYN(int roomId,bool yn)
        {
            await Clients.All.SendAsync("SendYN", roomId,yn);
        }
    }
}
