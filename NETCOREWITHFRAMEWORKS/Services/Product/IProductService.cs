using NETCOREWITHFRAMEWORKS.Models.Entities;
using System.Collections.Generic;

namespace NETCOREWITHFRAMEWORKS.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void Create(Product product);
        public void Update(Product product);
        public void Delete(int id);

    }
}
