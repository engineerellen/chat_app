using chat_test.DTO;
using chat_test.Models;
using chat_test.Services.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            return Ok(await _messageService.GetMessages());
        }
        [HttpPost]
        public async Task<IActionResult> AddMessage(Message message)
        {
            return Ok(await _messageService.AddMessage(message));
        }
    }
}
