using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using NETCOREWITHFRAMEWORKS.Models.Entities.ManyToMany;
using System;

namespace NETCOREWITHFRAMEWORKS.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IRepository<Customer_Product> customerProductRepository;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Customer_Product> customerProductRepository)
        {
            this.customerRepository = customerRepository;
            this.customerProductRepository = customerProductRepository;
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
            var customer = customerRepository.Get(c => c.Id == id);
            customerRepository.Delete(customer);
            customerRepository.Save();
        }

        public IEnumerable<Customer_Product> GetProducts(int customerId) => customerProductRepository.Where(cp => cp.CustomerId == customerId).Include(cp => cp.Product).ToList();

        public void AddProduct(int customerId, int productId)
        {
            var product = customerProductRepository.Where(cp => cp.CustomerId == customerId && cp.ProductId == productId).FirstOrDefault();
            if (product != null)
                customerProductRepository.Delete(product);

            customerProductRepository.Create(new Customer_Product() { CustomerId = customerId, ProductId = productId, PurchaseDate = DateTime.Now });
            customerProductRepository.Save();
        }
        public void RemoveProduct(int customerId, int productId)
        {
            var product = customerProductRepository.Where(cp => cp.CustomerId == customerId && cp.ProductId == productId).FirstOrDefault();
            if (product != null)
            {
                customerProductRepository.Delete(product);
                customerProductRepository.Save();
            }
        }
    }
}
