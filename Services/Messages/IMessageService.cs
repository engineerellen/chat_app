using chat_test.DTO;
using chat_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_test.Services.Messages
{
    public interface IMessageService
    {
        public Task<List<Message>> GetMessages();
        public Task<List<Message>> AddMessage(Message msg);
        public void AddMessageFromHub(Message msg);
    }
}
