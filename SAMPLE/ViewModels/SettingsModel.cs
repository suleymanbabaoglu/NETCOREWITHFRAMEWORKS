using System.ComponentModel.DataAnnotations;

namespace SAMPLE.ViewModels
{
    public class SettingsModel
    {
        [Key]
        public int Id { get; set; }
        public int ClientApp { get; set; }
        public string Title { get; set; }
        public int SidebarVariant { get; set; }
        public int NavbarVariant { get; set; }
    }
}
