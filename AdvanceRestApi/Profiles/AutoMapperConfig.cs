using AdvanceRestApi.DTO_s;
using AdvanceRestApi.Models;
using AutoMapper;

namespace AdvanceRestApi.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }   
    }
}
