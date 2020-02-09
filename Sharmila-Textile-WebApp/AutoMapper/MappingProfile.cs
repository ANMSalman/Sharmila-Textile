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
        }
    }
}
