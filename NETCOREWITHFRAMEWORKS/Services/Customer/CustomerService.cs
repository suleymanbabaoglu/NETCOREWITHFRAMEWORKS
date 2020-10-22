using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace NETCOREWITHFRAMEWORKS.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IEnumerable<Customer> GetAll() => customerRepository.Get().Include(c => c.User).ToList();
        public Customer GetById(int id) => customerRepository.Get().Include(c => c.User).FirstOrDefault(u => u.Id == id);
        public void Create(Customer customer)
        {
            customerRepository.Create(customer);
            customerRepository.Save();
        }
        public void Update(Customer customer)
        {
            customerRepository.Update(customer);
            customerRepository.Save();
        }
        public void Delete(int id)
        {
            var customer = customerRepository.Get(u => u.Id == id);
            customerRepository.Delete(customer);
            customerRepository.Save();
        }
    }
}
