using AutoMapper;
using COREVUE.Helpers.Sha512Hash;
using COREVUE.Models.Entities;
using COREVUE.Services;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
{
    [Route(ControllerRoutes.AccountController), ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpPost, Route(AccountRoutes.Register)]
        public void Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user = mapper.Map(userModel, user);

                userService.Create(user);
            }
        }

        [HttpPost, Route(AccountRoutes.PasswordReset)]
        public void PasswordReset(PasswordModel passwordModel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetById(passwordModel.UserId);
                user.Password = passwordModel.Password;

                userService.Update(user);
            }
        }
    }
}