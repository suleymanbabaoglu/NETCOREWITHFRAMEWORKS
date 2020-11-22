using AutoMapper;
using SAMPLE.Helpers.Attributes;
using SAMPLE.Models.Entities;
using SAMPLE.Services;
using SAMPLE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static SAMPLE.Helpers.Routes;

namespace SAMPLE.Controllers
{
    [Route(ControllerRoutes.ProductController), ApiController, MyAuthorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet, Route(GeneralRoutes.GetAll)]
        public IEnumerable<Product> GetAll() => productService.GetAll();

        [HttpGet, Route(GeneralRoutes.GetById)]
        public Product GetById(int id) => productService.GetById(id);

        [HttpPost, Route(GeneralRoutes.Create)]
        public void Create(ProductModel productModel)
        {
            var product = mapper.Map(productModel, new Product());
            productService.Create(product);
        }

        [HttpPut, Route(GeneralRoutes.Update)]
        public void Update(ProductModel productModel)
        {
            var product = mapper.Map(productModel, new Product());
            productService.Update(product);
        }

        [HttpDelete, Route(GeneralRoutes.Delete)]
        public void Delete(int id) => productService.Delete(id);

        [HttpGet, Route(GeneralRoutes.Count)]
        public int Count() => productService.Count();
    }
}