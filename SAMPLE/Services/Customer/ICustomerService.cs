using SAMPLE.Models.Entities;
using SAMPLE.Models.Entities.ManyToMany;
using System.Collections.Generic;

namespace SAMPLE.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAll();
        public Customer GetById(int id);
        public void Create(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);
        public IEnumerable<Customer_Product> GetProducts(int customerId);
        public void AddProduct(int customerId, int productId);
        public void RemoveProduct(int customerId, int productId);
        public int Count();

    }
}
