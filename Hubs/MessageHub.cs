using chat_test.Entities;
using chat_test.Models;
using chat_test.Services.Stocks;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace chat_test.Hubs
{
    public class MessageHub : Hub
    {
        private readonly ITestBotService _TestBotService;
        public MessageHub(ITestBotService TestBotService)
        {
            _TestBotService = TestBotService;
        }
        public async Task NewMessage(Message msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
            BotResponse botResponse = _TestBotService.BotCommand(msg.Text);
            if (botResponse.Detected)
                if (botResponse.IsSuccessful)
                    await Clients.All.SendAsync("MessageReceived", BotMessage($"{botResponse.Symbol} quote is {botResponse.Close} per share."));
                else
                    await Clients.All.SendAsync("MessageReceived", BotMessage($"There was a problem with the request. {botResponse.ErrorMessage}"));
        }

        internal Message BotMessage(string msg)
        {
            return new Message
            {
                Text = msg,
                Date = DateTime.Now
            };
        }
    }
}
