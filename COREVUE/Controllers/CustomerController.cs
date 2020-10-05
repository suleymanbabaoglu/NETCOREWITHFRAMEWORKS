using AutoMapper;
using COREVUE.Helpers.Attributes;
using COREVUE.Models.Entities;
using COREVUE.Services;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
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
    }
}