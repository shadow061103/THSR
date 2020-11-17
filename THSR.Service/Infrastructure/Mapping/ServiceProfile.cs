using AutoMapper;
using THSR.Repository.Models.PTX;
using THSR.Service.Models.Station;

namespace THSR.Service.Infrastructure.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<HSRailStationPTXModel, HSRailStationDto>()
                .ForMember(dest => dest.StationName, opt => opt.MapFrom(c => c.StationName.Zh_tw))
                .ForMember(dest => dest.StationEnName, opt => opt.MapFrom(c => c.StationName.En))
                .ForMember(dest => dest.PositionLat, opt => opt.MapFrom(c => c.StationPosition.PositionLat))
                .ForMember(dest => dest.PositionLon, opt => opt.MapFrom(c => c.StationPosition.PositionLon));
        }
    }
}