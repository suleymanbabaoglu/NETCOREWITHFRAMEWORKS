using COREVUE.Helpers.Sha512Hash;
using COREVUE.Models.Entities;
using COREVUE.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace COREVUE.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<User> GetAll() => userRepository.Get().ToList();
        public User GetById(int id) => userRepository.Get(u => u.Id == id);
        public void Create(User user)
        {
            user.Password = Sha512Encryptor.SHA_512_Encrypting(user.Password);
            userRepository.Create(user);
            userRepository.Save();
        }
        public void Update(User user)
        {
            user.Password = Sha512Encryptor.SHA_512_Encrypting(user.Password);
            userRepository.Update(user);
            userRepository.Save();
        }
        public void Delete(int id)
        {
            var user = userRepository.Get(u => u.Id == id);
            userRepository.Delete(user);
            userRepository.Save();
        }
    }
}
