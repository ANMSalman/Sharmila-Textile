using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sharmila_Textile_WebApp.Models;
using Sharmila_Textile_WebApp.ViewModel;

namespace Sharmila_Textile_WebApp.AutoMapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<StaffViewModel, Staff>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<CustomerViewModel, Customer>().ReverseMap();
            CreateMap<SupplierViewModel, Supplier>().ReverseMap();
            CreateMap<OwnChequeViewModel, OwnCheque>().ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.StatusId)).ReverseMap();
            CreateMap<ChequeStatusViewModel, ChequeStatus>().ReverseMap();
            CreateMap<ThirdPartyChequeViewModel, ThirdPartyCheque>().ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.StatusId)).ReverseMap();
            CreateMap<SupplierPaymentViewModel, SupplierPayment>().ReverseMap();
            CreateMap<Collection, CollectionViewModel>().ReverseMap();
            CreateMap<CustomerAccount, CustomerAccountViewModel>().ReverseMap();
            CreateMap<SupplierAccount, SupplierAccountViewModel>().ReverseMap();
        }
    }
}
