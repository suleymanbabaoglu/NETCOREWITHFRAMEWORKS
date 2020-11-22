using SAMPLE.Models.Entities;
using SAMPLE.Repositories;

namespace SAMPLE.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> userRepository;

        public AccountService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Register(User user)
        {
            userRepository.Create(user);
            userRepository.Save();
        }
    }
}
