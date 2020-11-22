using SAMPLE.Models.Entities;

namespace SAMPLE.Services
{
    public interface ISettingsService
    {
        public Settings Get();
        public void Update(Settings settings);
    }
}
