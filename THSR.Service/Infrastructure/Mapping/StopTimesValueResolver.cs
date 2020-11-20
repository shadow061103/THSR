using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using THSR.Repository.Models;
using THSR.Repository.Models.PTX;

namespace THSR.Service.Infrastructure.Mapping
{
    public class StopTimesValueResolver : IValueResolver<GeneraltimetablePTXModel, GeneralTimetable, ICollection<RailStopTime>>
    {
        private IMapper _mapper;

        public StopTimesValueResolver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ICollection<RailStopTime> Resolve(GeneraltimetablePTXModel source, GeneralTimetable destination, ICollection<RailStopTime> destMember, ResolutionContext context)
        {
            var data = source.StopTimes.Select(c =>
             {
                 var dest = _mapper.Map<RailStopTime>(c);
                 dest.TrainNo = source.GeneralTrainInfo.TrainNo;
                 return dest;
             }).ToList();

            return data;
        }
    }
}