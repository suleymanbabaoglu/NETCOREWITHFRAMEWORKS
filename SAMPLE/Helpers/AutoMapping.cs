using AutoMapper;
using NETCOREWITHFRAMEWORKS.Models.Entities;
using NETCOREWITHFRAMEWORKS.ViewModels;

namespace NETCOREWITHFRAMEWORKS.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<ProductModel, Product>();
            CreateMap<UserModel, User>();
        }
    }
}
