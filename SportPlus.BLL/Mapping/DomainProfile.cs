﻿using AutoMapper;
using SportPlus.BLL.ModelVM.Account;
using SportPlus.BLL.ModelVM.User;
using SportPlus.BLL.Service.Abstraction;



//using SportPlus.DAL
//using SportPlus.BLL.ModelVM.Category;
//using SportPlus.BLL.ModelVM.ItemVM;
//using SportPlus.BLL.ModelVM.OrderVM;
//using SportPlus.BLL.ModelVM.UserVM;
using SportPlus.DAL.Entities;
namespace SportPlus.BLL.Mapping
{
	public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // User Mapper
            CreateMap<User, RegistrationVM>().ReverseMap();     
            CreateMap<LoginVM, User>().ReverseMap();
            CreateMap<User, UserProfileVM>().ReverseMap();
            CreateMap<User, EditUserVM>().ReverseMap();
            CreateMap<UserProfileVM, User>().ReverseMap();
        }
    }
}
