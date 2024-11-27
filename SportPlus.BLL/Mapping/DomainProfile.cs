using AutoMapper;
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
            CreateMap<User, RegisterVM>();
            CreateMap<RegisterVM, User>();
            CreateMap<LoginVM, User>();
            CreateMap<User, LoginVM>();
            CreateMap<User, GetUserVM>();
            CreateMap<User, DeleteUserVM>();
            CreateMap<DeleteUserVM, User>();
            CreateMap<User, EditUserVM>();
            CreateMap<GetUserVM, User>();

            //User Mapper
            CreateMap<User, DeleteUserVM>();
            CreateMap<User, EditUserVM>();
            CreateMap<User, GetUserVM>();
            CreateMap<User, LoginVM>();
            CreateMap<User, RegisterVM>();
            CreateMap<User, UpdateRoleVM>();
        }
    }
}
