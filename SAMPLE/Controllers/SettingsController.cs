using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SAMPLE.Helpers.Attributes;
using SAMPLE.Models.Entities;
using SAMPLE.Services;
using SAMPLE.ViewModels;
using static SAMPLE.Helpers.Routes;

namespace SAMPLE.Controllers
{
    [Route(ControllerRoutes.SettingsController), ApiController, MyAuthorize]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService settingsService;
        private readonly IMapper mapper;

        public SettingsController(ISettingsService settingsService, IMapper mapper)
        {
            this.settingsService = settingsService;
            this.mapper = mapper;
        }

        [HttpGet, Route(SettingsRoutes.Get)]
        public Settings Get() => settingsService.Get();

        [HttpPut, Route(GeneralRoutes.Update)]
        public void Update(SettingsModel settingsModel)
        {
            var settings = settingsService.Get();
            settings = mapper.Map(settingsModel, settings);
            settingsService.Update(settings);
        }
    }
}
