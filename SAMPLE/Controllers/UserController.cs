using AutoMapper;
using SAMPLE.Helpers.Attributes;
using SAMPLE.Models.Entities;
using SAMPLE.Repositories;
using SAMPLE.Services;
using SAMPLE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using static SAMPLE.Helpers.Routes;

namespace SAMPLE.Controllers
{
    [Route(ControllerRoutes.UserController), ApiController, MyAuthorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet, Route(GeneralRoutes.GetAll)]
        public IEnumerable<User> GetAll() => userService.GetAll();

        [HttpGet, Route(GeneralRoutes.GetById)]
        public User GetById(int id) => userService.GetById(id);

        [HttpPost, Route(GeneralRoutes.Create)]
        public void Create(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = mapper.Map(userModel, new User());
                userService.Create(user);
            }
        }

        [HttpPut, Route(GeneralRoutes.Update)]
        public void Update(UserModel userModel)
        {
            var user = userService.GetById(userModel.Id);
            user = mapper.Map(userModel, user);
            userService.Update(user);
        }

        [HttpDelete, Route(GeneralRoutes.Delete)]
        public void Delete(int id) => userService.Delete(id);

        [HttpGet, Route(GeneralRoutes.Count)]
        public int Count() => userService.Count();
    }
}