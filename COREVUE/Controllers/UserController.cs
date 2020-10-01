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
    [Route(ControllerRoutes.UserController), ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;

        public UserController(IRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet, Route(CRUDRoutes.GetAll)]
        public IEnumerable<User> GetAll()
        {
            return userRepository.Get().ToList();
        }

        [HttpGet, Route(CRUDRoutes.GetById)]
        public User GetById(int id)
        {
            return userRepository.Get().FirstOrDefault(u => u.Id == id);
        }

        [HttpPost, Route(CRUDRoutes.Create)]
        public void Create(UserModel userModel)
        {
            var user = mapper.Map(userModel, new User());
            userRepository.Create(user);
        }

        [HttpPut, Route(CRUDRoutes.Update)]
        public void Update(UserModel userModel)
        {
            var user = userRepository.Get().FirstOrDefault(u => u.Id == userModel.Id);
            user = mapper.Map(userModel, user);
            userRepository.Update(user);
            userRepository.Save();
        }

        [HttpDelete, Route(CRUDRoutes.Delete)]
        public void Delete(int id)
        {
            var user = userRepository.Get().FirstOrDefault(u => u.Id == id);
            userRepository.Delete(user);
            userRepository.Save();
        }
    }
}