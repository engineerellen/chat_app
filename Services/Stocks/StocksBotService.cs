using chat_test.Entities;
using chat_test.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace chat_test.Services.Stocks
{
    public class TestBotService : ITestBotService
    {
        private HttpClient _client;
        public TestBotService(HttpClient client)
        {
            _client = client;
        }
        public BotResponse BotCommand(string code)
        {
            try
            {
                if(code.ToLower().Contains("/stock="))
                {
                    string stockCode = code.Replace("/stock=", "");
                    using (HttpResponseMessage response = _client.GetAsync($"https://localhost:44326/TestBot/GetStock?stockCode={stockCode}").Result)
                    using (HttpContent stockContent = response.Content)
                    {
                        var stockResponse = stockContent.ReadAsStringAsync().Result;
                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            return new BotResponse { Detected = true, IsSuccessful = false, ErrorMessage = response.StatusCode.ToString() };
                        var stock = JsonConvert.DeserializeObject<Stock>(stockResponse);
                        return new BotResponse { Detected = true, IsSuccessful = true, Symbol = stock.Symbol, Close = stock.Close.ToString() };
                    }

                }
                return new BotResponse { Detected = false };
            }
            catch(Exception e)
            {
                return new BotResponse { Detected = true, IsSuccessful = false, ErrorMessage = e.Message };
            }
        }
    }
}
