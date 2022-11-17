 using chat_test.Entities;

namespace chat_test.Services.Stocks
{
    public interface ITestBotService
    {
        public BotResponse BotCommand(string code);
    }
}