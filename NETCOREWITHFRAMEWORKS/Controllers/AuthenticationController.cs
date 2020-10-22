using NETCOREWITHFRAMEWORKS.Helpers;
using NETCOREWITHFRAMEWORKS.Helpers.Attributes;
using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.Services;
using NETCOREWITHFRAMEWORKS.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static NETCOREWITHFRAMEWORKS.Helpers.Routes;

namespace NETCOREWITHFRAMEWORKS.Controllers
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
        public User LoginByRefreshToken([FromBody] string refreshToken)
        {
            return authService.LoginByRefreshToken(refreshToken);
        }

        [HttpGet, Route(AuthRoutes.Logout), MyAuthorize]
        public string Logout()
        {
            var userId = this.GetUserId();
            return authService.Logout(userId);
        }
    }
}