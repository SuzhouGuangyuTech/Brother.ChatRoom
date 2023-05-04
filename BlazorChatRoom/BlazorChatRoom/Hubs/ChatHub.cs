using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using BlazorChatRoom.Data;
using Microsoft.AspNetCore.Identity;

namespace BlazorChatRoom.Hubs
{
    public class ChatHub : Hub
    {
        public static string HubPath = "/chatroom";

        private readonly UserManager<IdentityUser> _userManager;

        public ChatHub(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} Connected!");

            return base.OnConnectedAsync(); //Connected to the main hub
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"{Context.ConnectionId} Disconnected!");
            await base.OnDisconnectedAsync(exception); //Disconnected from the main hub
        }

        // 登录将当前客户端 Id 赋值给 UserManager
        public async Task Online(MessageModel message)
        {
            var user = await _userManager.FindByNameAsync(message.LoginName);
            if (user != null)
            {
                // 这边把序列化名字更改为唯一的客户端连接 Id
                user.PhoneNumber = this.Context.ConnectionId;
                await _userManager.UpdateAsync(user);
                await Clients.All.SendAsync("ReceiveMessage", message);
            }
            else
            {
                Console.WriteLine("未查询到此用户");
            }
        }

        // 向所有客户端发送消息
        public async Task SendMessage(MessageModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        // 私发消息给指定用户
        public async Task SendPrivateMsg(MessageModel message, string to)
        {
            Console.WriteLine($"{message} {to}");
            var user = await _userManager.FindByNameAsync(to);
            if (user != null)
            {
                var destUserId = user.PhoneNumber;
                await Clients.Caller.SendAsync("ReceiveMessage", message);
                await Clients.Client(destUserId).SendAsync("ReceiveMessage", message);
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveMessage", "发送失败，请重试！");
            }
        }
    }
}
