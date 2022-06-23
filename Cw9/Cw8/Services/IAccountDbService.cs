using Cw8.Models.DTOs;
using System.Threading.Tasks;

namespace Cw8.Services
{
    public interface IAccountDbService
    {
        public Task Register(AccountDTO account);
        public Task<string[]> Login(AccountDTO account);
        public Task<string> GetNewAccessToken(RefreshTokenDTO refreshToken);

        
    }
}
