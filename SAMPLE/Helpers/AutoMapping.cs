using AutoMapper;
using SAMPLE.Models.Entities;
using SAMPLE.ViewModels;

namespace SAMPLE.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<ProductModel, Product>();
            CreateMap<UserModel, User>();
            CreateMap<SettingsModel, Settings>();
        }
    }
}
