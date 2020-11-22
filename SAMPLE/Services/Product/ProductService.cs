using SAMPLE.Models.Entities;
using SAMPLE.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SAMPLE.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> GetAll() => productRepository.Get().ToList();
        public Product GetById(int id) => productRepository.Get(u => u.Id == id);
        public void Create(Product product)
        {

            productRepository.Create(product);
            productRepository.Save();
        }
        public void Update(Product product)
        {
            productRepository.Update(product);
            productRepository.Save();
        }
        public void Delete(int id)
        {
            var product = productRepository.Get(u => u.Id == id);
            productRepository.Delete(product);
            productRepository.Save();
        }

        public int Count() => productRepository.Table.Count();

    }
}
