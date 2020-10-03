using COREVUE.Helpers;
using COREVUE.Models.Entities;
using COREVUE.Services;
using COREVUE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static COREVUE.Helpers.Routes;

namespace COREVUE.Controllers
{
    [Route(ControllerRoutes.AuthenticationController), ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthenticationController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost, Route(AuthRoutes.Login)]
        public User Login(AuthModel authModel)
        {
            return authService.Login(authModel.Email, authModel.Password);
        }

        [HttpPost, Route(AuthRoutes.LoginByRefreshToken)]
        public User LoginByRefreshToken([FromBody]string refreshToken)
        {
            return authService.LoginByRefreshToken(refreshToken);
        }

        [HttpGet, Route(AuthRoutes.Logout), Authorize]
        public string Logout()
        {
            var userId = this.GetId();
            return authService.Logout(userId);
        }
    }
}