using AutoMapper;
using COREVUE.Models.Entities;
using COREVUE.Repositories;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
{
    [Route(ControllerRoutes.ProductController), ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMapper mapper;

        public ProductController(IRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet, Route(CRUDRoutes.GetAll)]
        public IEnumerable<Product> GetAll()
        {
            return productRepository.Get().ToList();
        }

        [HttpGet, Route(CRUDRoutes.GetById)]
        public Product GetById(int id)
        {
            return productRepository.Get().FirstOrDefault(s => s.Id == id);
        }

        [HttpPost, Route(CRUDRoutes.Create)]
        public void Create(ProductModel productModel)
        {
            var product = mapper.Map(productModel, new Product());
            productRepository.Create(product);
        }

        [HttpPut, Route(CRUDRoutes.Update)]
        public void Update(ProductModel productModel)
        {
            var product = productRepository.Get().FirstOrDefault(p => p.Id == productModel.Id);
            product = mapper.Map(productModel, product);
            productRepository.Update(product);
            productRepository.Save();
        }

        [HttpDelete, Route(CRUDRoutes.Delete)]
        public void Delete(int id)
        {
            var product = productRepository.Get().FirstOrDefault(p => p.Id == id);
            productRepository.Delete(product);
            productRepository.Save();
        }
    }
}