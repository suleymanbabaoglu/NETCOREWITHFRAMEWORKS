using SAMPLE.Helpers.Sha512Hash;
using SAMPLE.Models.Entities;
using SAMPLE.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace SAMPLE.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> userRepository;

        private IConfiguration Configuration;

        public AuthService(IRepository<User> userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            Configuration = configuration;
        }

        public User Login(string email, string password)
        {
            var user = userRepository.Get().FirstOrDefault(s => s.Email == email && s.Password == Sha512Encryptor.SHA_512_Encrypting(password));

            if (user == null)
            {
                return new User();
            }

            CreateToken(ref user);
            CreateRefreshToken(ref user);

            var responseUser = new User();
            responseUser.Token = user.Token;
            responseUser.RefreshToken = user.RefreshToken;
            responseUser.TokenExpire = user.TokenExpire;
            return responseUser;
        }

        public User LoginByRefreshToken(string refreshToken)
        {
            if (refreshToken == null)
            {
                return new User();
            }

            var user = userRepository.Get().FirstOrDefault(s => s.RefreshToken == refreshToken);

            if (user == null)
            {
                return new User();
            }
            if (user.RefreshTokenExpire < DateTime.Now)
            {
                return new User();
            }

            CreateToken(ref user);


            var responseUser = new User();
            responseUser.Token = user.Token;
            responseUser.TokenExpire = user.TokenExpire;
            return responseUser;
        }

        public string Logout(int id)
        {
            var user = userRepository.Get().FirstOrDefault(s => s.Id == id);

            if (user == null)
            {
                return "User Not Found";
            }

            user.Token = null;
            user.TokenExpire = null;
            user.RefreshToken = null;
            user.RefreshTokenExpire = null;

            userRepository.Update(user);
            bool result = userRepository.Save();
            return result ? "Success" : "Failed";
        }

        private void CreateToken(ref User user)
        {
            var tokenExpiration = GetTokenExpiration();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = GetSigningCredentials(),
                NotBefore = DateTime.UtcNow,
                Expires = tokenExpiration,
                Subject = new ClaimsIdentity(GetClaims(user)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);
            user.TokenExpire = tokenExpiration;

            userRepository.Update(user);
            userRepository.Save();
        }
        private string CreateRefreshToken(ref User user)
        {
            var numberByte = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(numberByte);

            var refreshToken = Convert.ToBase64String(numberByte);
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpire = GetRefreshTokenExpiration();

            userRepository.Update(user);
            userRepository.Save();
            return refreshToken;
        }
        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return claims;
        }
        private SigningCredentials GetSigningCredentials()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecurityKey"]));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
        private DateTime GetTokenExpiration()
        {
            return DateTime.UtcNow.AddDays(Convert.ToDouble(Configuration["Jwt:TokenExpirationDays"]));
        }
        private DateTime GetRefreshTokenExpiration()
        {
            return DateTime.UtcNow.AddDays(Convert.ToDouble(Configuration["Jwt:RefreshTokenExpirationDays"]));
        }
    }
}
