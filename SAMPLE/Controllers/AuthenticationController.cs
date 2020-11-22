using SAMPLE.Helpers;
using SAMPLE.Helpers.Attributes;
using SAMPLE.Models.Entities;
using SAMPLE.Services;
using SAMPLE.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static SAMPLE.Helpers.Routes;

namespace SAMPLE.Controllers
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