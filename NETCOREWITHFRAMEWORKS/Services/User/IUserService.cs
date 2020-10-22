using System.Collections.Generic;
using NETCOREWITHFRAMEWORKS.Models.Entities;

namespace NETCOREWITHFRAMEWORKS.Services
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
