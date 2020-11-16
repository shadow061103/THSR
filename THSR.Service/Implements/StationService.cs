using AutoMapper;
using THSR.Service.Interface;

namespace THSR.Service.Implements
{
    public class StationService : IStationService
    {
        private IMapper _mapper;

        public StationService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}