using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using THSR.Repository.Interfaces;
using THSR.Service.Interface;
using THSR.Service.Models.Station;

namespace THSR.Service.Implements
{
    public class StationService : IStationService
    {
        private IMapper _mapper;

        private IWsTHSRRepository _wsRepository;

        public StationService(IMapper mapper, IWsTHSRRepository wsRepository)
        {
            _mapper = mapper;
            _wsRepository = wsRepository;
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        public async Task InsertAsync()
        {
            var source = await _wsRepository.GetStation();

            var stationDto = this._mapper.Map<IEnumerable<HSRailStationDto>>(source);
        }
    }
}