using AutoMapper;
using CreditApp.Infrastructure.Entities;
using CreditApp.Shared.Services.Common.Dtos;
using CreditApp.Shared.Services.Common.Helpers;

namespace CreditApp.Shared.Services.Common.ProfilesConfig
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {

            CreateMap<CustomerDto, Customer>()
            .ForMember(dest => dest.CreationDate, opts => opts.MapFrom(src => DelegateHelper.DateHandler(src.CreationDate)))
            .ForMember(dest => dest.BirthDate, opts => opts.MapFrom(src => DelegateHelper.DateHandler(src.BirthDate)))
            .ForMember(dest => dest.DeletedDate, opts => opts.MapFrom(src => DelegateHelper.DateHandler(src.DeletedDate)))
            .ForMember(dest => dest.Addresses,
                opts => opts.MapFrom(src => new List<Address>()
                {
                    new Address
                    {
                        City = src.City,
                        Region = src.Region,
                        Street = src.Address,
                        CreationDate = DelegateHelper.DateHandler(src.CreationDate),
                        DeletedDate = DelegateHelper.DateHandler(src.DeletedDate),
                        IsDeleted = src.IsDeleted
                    }
                }))
            .ForMember(dest => dest.Identifications,
                opts => opts.MapFrom(src => new List<Identification>
                {
                   new Identification
                   {
                       Value = src.Identification,
                       Doctype = src.Identification == "CED" ? Doctype.CED : Doctype.PASSPORT,
                       CreationDate = DelegateHelper.DateHandler(src.CreationDate)
                   }
                }));
        }
    }
}
