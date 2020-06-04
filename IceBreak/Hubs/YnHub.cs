using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace IceBreak.Hubs
{
    public class YnHub : Hub
    {

        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task CreateYNRoom()
        {
            var rand = new Random();
            int roomId = rand.Next(0, 100000);
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Groups(roomId.ToString()).SendAsync("ReceiveYNRoomId", roomId);
        }

        //public async Task EnterYN(int roomId)
        //{
        //    await Clients.All.SendAsync("EnterYN", roomId);
        //}

        public async Task CleanYNResult(string roomId)
        {
            await Clients.Groups(roomId).SendAsync("ReceiveCleanYNResult");
        }

        public async Task SendYN(string roomId, string yn)
        {
            await Clients.Groups(roomId).SendAsync("ReceiveYNResult",yn);
        }
    }
}
