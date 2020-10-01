using AutoMapper;
using COREVUE.Models.Entities;
using COREVUE.Repositories;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
{
    [Route(ControllerRoutes.CustomerController), ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IMapper mapper;

        public CustomerController(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet, Route(CRUDRoutes.GetAll)]
        public IEnumerable<Customer> GetAll()
        {
            return customerRepository.Get().Include(c => c.User).ToList();
        }

        [HttpGet, Route(CRUDRoutes.GetById)]
        public Customer GetById(int id)
        {
            return customerRepository.Get().Include(c=>c.User).FirstOrDefault(c => c.Id == id);
        }

        [HttpPost, Route(CRUDRoutes.Create)]
        public void Create(CustomerModel customerModel)
        {
            var customer = mapper.Map<Customer>(customerModel);
            customerRepository.Create(customer);
        }

        [HttpPut, Route(CRUDRoutes.Update)]
        public void Update(CustomerModel customerModel)
        {
            var customer = customerRepository.Get().FirstOrDefault(c => c.Id == customerModel.Id);
            customer = mapper.Map<Customer>(customerModel);
            customerRepository.Update(customer);
            customerRepository.Save();
        }

        [HttpDelete, Route(CRUDRoutes.Delete)]
        public void Delete(int id)
        {
            var customer = customerRepository.Get().FirstOrDefault(c => c.Id == id);
            customerRepository.Delete(customer);
            customerRepository.Save();
        }
    }
}