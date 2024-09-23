using AutoMapper;
using TOPCustomOrders.API.Models.Domain;
using TOPCustomOrders.API.Models.DTO;

namespace TOPCustomOrders.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();

            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();

            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
        }
    }
}
