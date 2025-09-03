using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        CreateMap<Address, AddressViewModel>().ReverseMap();

        CreateMap<Product, ProductViewModel>()
            .ForMember(to => to.SupplierName, opt => opt.MapFrom(src => src.Supplier.Name));

        CreateMap<ProductViewModel, Product>();
    }
}
