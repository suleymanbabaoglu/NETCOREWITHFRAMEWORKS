using SAMPLE.Models.Entities;
using SAMPLE.Repositories;
using System.Linq;

namespace SAMPLE.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IRepository<Settings> settingsRepository;

        public SettingsService(IRepository<Settings> settingsRepository) => this.settingsRepository = settingsRepository;
        public Settings Get() => settingsRepository.Get().FirstOrDefault();
        public void Update(Settings settings)
        {
            settingsRepository.Update(settings);
            settingsRepository.Save();
        }
    }
}
