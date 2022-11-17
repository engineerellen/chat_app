using AutoMapper;
using chat_test.Data;
using chat_test.DTO;
using chat_test.DTO.Users;
using chat_test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chat_test.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;
        public UserService(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetUserDto>> AddUser(AddUserDto newUser)
        {
            User user = _mapper.Map<User>(newUser);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return (_context.Users.Select(u => _mapper.Map<GetUserDto>(u))).ToList();
        }

        public async Task<List<GetUserDto>> GetAllUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return (_context.Users.Select(u => _mapper.Map<GetUserDto>(u))).ToList();
        }

        public async Task<GetUserDto> GetUserById(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<GetUserDto>(user);
        }
    }
}
