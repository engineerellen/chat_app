using chat_test.Models;
using System.Threading.Tasks;

namespace chat_test.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> ValidateUserData(string username, string email);
    }
}