using NETCOREWITHFRAMEWORKS.Repositories;
using Microsoft.AspNetCore.Mvc;
using static NETCOREWITHFRAMEWORKS.Helpers.Routes;

namespace NETCOREWITHFRAMEWORKS.Controllers
{
    [Route(ControllerRoutes.MainController), ApiController]
    public class MainController : ControllerBase
    {
        public MainController()
        {

        }
    }
}