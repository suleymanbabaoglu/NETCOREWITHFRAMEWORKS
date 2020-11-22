using SAMPLE.Repositories;
using Microsoft.AspNetCore.Mvc;
using static SAMPLE.Helpers.Routes;

namespace SAMPLE.Controllers
{
    [Route(ControllerRoutes.MainController), ApiController]
    public class MainController : ControllerBase
    {
        public MainController()
        {

        }
    }
}