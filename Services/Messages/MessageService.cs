﻿using chat_test.Data;
using chat_test.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using chat_test.Models;
using System.Linq;

namespace chat_test.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;
        public MessageService(IMapper mapper, BaseContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Message>> AddMessage(Message msg)
        {
            await _context.Message.AddAsync(msg);
            await _context.SaveChangesAsync();

            return (_context.Message.Select(m => _mapper.Map<Message>(m))).ToList();
        }

        public async Task<List<Message>> GetMessages()
        {
            List<Message> messages = await _context.Message.OrderBy(m => m.Date).Take(50).ToListAsync();
            return messages;
        }

        public async void AddMessageFromHub(Message msg)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == msg.User.Id);
            await _context.Message.AddAsync(msg);
            await _context.SaveChangesAsync();
        }
    }
}
