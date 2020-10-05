using COREVUE.Models.Entities;
using System.Collections.Generic;

namespace COREVUE.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAll();
        public Customer GetById(int id);
        public void Create(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);

    }
}
