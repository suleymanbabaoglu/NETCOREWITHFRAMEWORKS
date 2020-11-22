using SAMPLE.Models.Entities;

namespace SAMPLE.Services
{
    public interface IAuthService
    {
        public User Login(string email, string password);
        public User LoginByRefreshToken(string refreshToken);
        public string Logout(int id);
    }
}
