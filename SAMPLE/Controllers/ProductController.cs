using AutoMapper;
using NETCOREWITHFRAMEWORKS.Helpers.Attributes;
using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.Services;
using NETCOREWITHFRAMEWORKS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static NETCOREWITHFRAMEWORKS.Helpers.Routes;

namespace NETCOREWITHFRAMEWORKS.Controllers
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

        [HttpGet, Route(CRUDRoutes.GetAll)]
        public IEnumerable<Product> GetAll() => productService.GetAll();

        [HttpGet, Route(CRUDRoutes.GetById)]
        public Product GetById(int id) => productService.GetById(id);

        [HttpPost, Route(CRUDRoutes.Create)]
        public void Create(ProductModel productModel)
        {
            var product = mapper.Map(productModel, new Product());
            productService.Create(product);
        }

        [HttpPut, Route(CRUDRoutes.Update)]
        public void Update(ProductModel productModel)
        {
            var product = mapper.Map(productModel, new Product());
            productService.Update(product);
        }

        [HttpDelete, Route(CRUDRoutes.Delete)]
        public void Delete(int id) => productService.Delete(id);
    }
}