using AdvanceRestApi.DTO_s;
using AdvanceRestApi.Models;
using AutoMapper;

namespace AdvanceRestApi.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            //Template
            //CreateMap<{source}, {destination}>();
            //CreateMap<{destination}, {source}>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, AddUserDtoRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();
        }   
    }
}
