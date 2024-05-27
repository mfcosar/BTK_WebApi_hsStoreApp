using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HouseDtoForUpdate, House>().ReverseMap();
            CreateMap<House, HouseDto>(); // source, destination
            CreateMap<HouseDtoForInsertion, House>();
            CreateMap<UserForRegistrationDto, User>();
        }
        


    }
}
