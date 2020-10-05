using System.Collections.Generic;
using COREVUE.Models.Entities;

namespace COREVUE.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public void Create(User user);
        public void Update(User user);
        public void Delete(int id);

    }
}
