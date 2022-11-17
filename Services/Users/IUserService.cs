using chat_test.DTO;
using chat_test.DTO.Users;
using chat_test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace chat_test.Services.Users
{
    public interface IUserService
    {
        public Task<List<GetUserDto>> GetAllUsers();
        public Task<GetUserDto> GetUserById(int id);
        public Task<List<GetUserDto>> AddUser(AddUserDto user);
    }
}
