using AutoMapper;
using COREVUE.Models.Entities;
using COREVUE.ViewModels;

namespace COREVUE.Helpers
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
