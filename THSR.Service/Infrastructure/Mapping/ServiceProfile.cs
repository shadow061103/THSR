using System;
using System.Linq;
using AutoMapper;
using THSR.Repository.Models.Entities;
using THSR.Repository.Models.PTX;

namespace THSR.Service.Infrastructure.Mapping
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<HSRailStationPTXModel, Station>()
                .ForMember(dest => dest.StationName, opt => opt.MapFrom(c => c.StationName.Zh_tw))
                .ForMember(dest => dest.StationEnName, opt => opt.MapFrom(c => c.StationName.En))
                .ForMember(dest => dest.PositionLat, opt => opt.MapFrom(c => c.StationPosition.PositionLat))
                .ForMember(dest => dest.PositionLon, opt => opt.MapFrom(c => c.StationPosition.PositionLon))
                .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(c => DateTime.Now));

            CreateMap<HSRailFarePTXModel, Fare>()
                .ForMember(dest => dest.BusinessFare, opt => opt.MapFrom(c => c.Fares.FirstOrDefault(x => x.TicketType == "商務").Price))
                .ForMember(dest => dest.StandardFare, opt => opt.MapFrom(c => c.Fares.FirstOrDefault(x => x.TicketType == "標準").Price))
                .ForMember(dest => dest.FreeFare, opt => opt.MapFrom(c => c.Fares.FirstOrDefault(x => x.TicketType == "自由").Price))
                .ForMember(dest => dest.OriginStationName, opt => opt.MapFrom(c => c.OriginStationName.Zh_tw))
                .ForMember(dest => dest.DestinationStationID, opt => opt.MapFrom(c => c.DestinationStationName.Zh_tw))
                .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}