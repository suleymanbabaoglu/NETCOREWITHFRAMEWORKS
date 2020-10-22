using AutoMapper;
using NETCOREWITHFRAMEWORKS.Helpers.Attributes;
using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.Services;
using NETCOREWITHFRAMEWORKS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static NETCOREWITHFRAMEWORKS.Helpers.Routes;
using NETCOREWITHFRAMEWORKS.Models.Entities.ManyToMany;
using System.Linq;

namespace NETCOREWITHFRAMEWORKS.Controllers
{
    [Route(ControllerRoutes.CustomerController), ApiController, MyAuthorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this.customerService = customerService;
            this.mapper = mapper;
        }

        [HttpGet, Route(CRUDRoutes.GetAll)]
        public IEnumerable<Customer> GetAll() => customerService.GetAll();

        [HttpGet, Route(CRUDRoutes.GetById)]
        public Customer GetById(int id) => customerService.GetById(id);

        [HttpPost, Route(CRUDRoutes.Create)]
        public void Create(CustomerModel customerModel)
        {
            var customer = mapper.Map<Customer>(customerModel);
            customerService.Create(customer);
        }

        [HttpPut, Route(CRUDRoutes.Update)]
        public void Update(CustomerModel customerModel)
        {
            var customer = mapper.Map<Customer>(customerModel);
            customerService.Update(customer);
        }

        [HttpDelete, Route(CRUDRoutes.Delete)]
        public void Delete(int id) => customerService.Delete(id);

        [HttpGet, Route(CustomerRoutes.GetProducts)]
        public IEnumerable<Customer_Product> GetProducts(int customerId) => customerService.GetProducts(customerId);

        [HttpGet, Route(CustomerRoutes.AddProduct)]
        public void AddProduct(int customerId, int productId) => customerService.AddProduct(customerId, productId);

        [HttpGet, Route(CustomerRoutes.RemoveProduct)]
        public void RemoveProduct(int customerId, int productId) => customerService.RemoveProduct(customerId, productId);
    }
}