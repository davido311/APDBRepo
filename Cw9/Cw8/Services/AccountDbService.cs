using Cw8.Models;
using Cw8.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cw8.Services
{
    public class AccountDbService : IAccountDbService
    {
        private readonly MainDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountDbService(MainDbContext context , IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<string> GetNewAccessToken(RefreshTokenDTO refreshToken)
        {
            var logAccount = await _context.Accounts.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken.RefreshToken);
                if(logAccount == null)
                throw new Exception("Account not found");

            var token = GenerateToken();

            logAccount.RefreshToken = Guid.NewGuid().ToString();

            await _context.SaveChangesAsync();

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token).ToString(); 




        }

        public async Task<string[]> Login(AccountDTO account)
        {
            var logAccount = await _context.Accounts.FirstOrDefaultAsync(e=>e.Login == account.Login);
            if (logAccount == null)
                throw new Exception("There is no account with this login");

            if (logAccount.Password != PasswordService.GetHashedPassword(account.Password, logAccount.Salt))
                throw new Exception("Wrong password");

            var token = GenerateToken();

            logAccount.RefreshToken = Guid.NewGuid().ToString();

            await _context.SaveChangesAsync();
            var newToken = new JwtSecurityTokenHandler();
           string returnToken= newToken.WriteToken(token).ToString();

            return new string[] { returnToken, logAccount.RefreshToken };
        }

        public async Task Register(AccountDTO account)
        {
            if (account.Password.Length < 5)
                throw new Exception("Password too short");

            var activeAccount = await _context.Accounts.FirstOrDefaultAsync(e=>e.Login == account.Login);
            if (activeAccount != null)
                throw new Exception("This login already exists");

            var hashedPassword = PasswordService.HashPassword(account.Password);
            
            var newAccount = new Account
            {
                Login = account.Login,
                Password = hashedPassword[0],
                Salt = hashedPassword[1],
                RefreshToken = Guid.NewGuid().ToString(),
            };
            
            await _context.Accounts.AddAsync(newAccount);
           
                await _context.SaveChangesAsync();
           

            
        }

        public JwtSecurityToken GenerateToken()
        {
            Claim[] userClaims = new[]
            {
                new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Role, "client")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost",
                audience: "http://localhost",
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);

            return token;
        }
    }
}
