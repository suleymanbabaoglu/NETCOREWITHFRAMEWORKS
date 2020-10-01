using AutoMapper;
using COREVUE.Models.Entities;
using COREVUE.Repositories;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Miracle.Api.Services.Helpers.Sha512Hash;
using System;
using System.Linq;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
{
    [Route(ControllerRoutes.AccountController), ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;

        public AccountController(IRepository<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost, Route(AccountRoutes.Register)]
        public void Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var exist = userRepository.Get().FirstOrDefault(u => u.Email == userModel.Email);
                if (exist!=null)
                    throw new Exception();

                var user = new User();
                user = mapper.Map(userModel, user);
                user.Password = Sha512Encryptor.SHA_512_Encrypting(userModel.Password);

                userRepository.Create(user);
                userRepository.Save();
            }
        }
    }
}