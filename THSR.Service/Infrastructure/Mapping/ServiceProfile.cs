using System;
using System.Linq;
using AutoMapper;
using THSR.Repository.Models;
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
                .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(c => DateTime.Now));

            CreateMap<StoptimePTXModel, RailStopTime>();

            CreateMap<GeneraltimetablePTXModel, GeneralTimetable>()
                .ForMember(dest => dest.TrainNo, opt => opt.MapFrom(c => c.GeneralTrainInfo.TrainNo))
                .ForMember(dest => dest.Direction, opt => opt.MapFrom(c => c.GeneralTrainInfo.Direction))
                .ForMember(dest => dest.StartingStationID,
                    opt => opt.MapFrom(c => c.GeneralTrainInfo.StartingStationID))
                .ForMember(dest => dest.EndingStationID, opt => opt.MapFrom(c => c.GeneralTrainInfo.EndingStationID))
                .ForMember(dest => dest.ServiceMonday, opt => opt.MapFrom(c => c.ServiceDay.Monday))
                .ForMember(dest => dest.ServiceTuesday, opt => opt.MapFrom(c => c.ServiceDay.Tuesday))
                .ForMember(dest => dest.ServiceWednesday, opt => opt.MapFrom(c => c.ServiceDay.Wednesday))
                .ForMember(dest => dest.ServiceThursday, opt => opt.MapFrom(c => c.ServiceDay.Thursday))
                .ForMember(dest => dest.ServiceFriday, opt => opt.MapFrom(c => c.ServiceDay.Friday))
                .ForMember(dest => dest.ServiceSaturday, opt => opt.MapFrom(c => c.ServiceDay.Saturday))
                .ForMember(dest => dest.ServiceSunday, opt => opt.MapFrom(c => c.ServiceDay.Saturday))
                .ForMember(dest => dest.RailStopTime, opt => opt.MapFrom<StopTimesValueResolver>())
                .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(c => DateTime.Now));
        }
    }
}