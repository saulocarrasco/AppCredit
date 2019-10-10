using AppCredit.Api.Dtos;
using AppCredit.Api.Helpers;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCredit.Api.ProfilesConfig
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
                opts => opts.MapFrom(src => new Address
                {
                    City = src.City,
                    Region = src.Region,
                    Street = src.Address,
                    CreationDate = DelegateHelper.DateHandler(src.CreationDate),
                    DeletedDate = DelegateHelper.DateHandler(src.DeletedDate),
                    IsDeleted = src.IsDeleted
                }))
            .ForMember(dest => dest.Identifications,
                opts => opts.MapFrom(src => new List<Identification>
                {
                   new Identification
                   {
                       Value = src.Identification,
                       Doctype = src.Identification == "CED" ? Doctype.CED : Doctype.PASSPORT
                   }
                }));
        }
    }
}
