using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using THSR.Repository.Interfaces;
using THSR.Repository.Models;
using THSR.Service.Interface;

namespace THSR.Service.Implements
{
    public class TimetableService : ITimetableService
    {
        private IMapper _mapper;

        private IWsTHSRRepository _wsRepository;

        private IProxyRepository _proxyRepository;

        public TimetableService(IMapper mapper, IWsTHSRRepository wsRepository, IProxyRepository proxyRepository)
        {
            _mapper = mapper;
            _wsRepository = wsRepository;
            _proxyRepository = proxyRepository;
        }

        /// <summary>
        /// 新增列車時刻表資料
        /// </summary>
        public async Task InsertAsync()
        {
            var source = await _wsRepository.GetGeneralTimetableAsync();

            var timetables = _mapper.Map<IEnumerable<GeneralTimetable>>(source.Select(c => c.GeneralTimetable));

            await _proxyRepository.GetRepository<GeneralTimetable>().AddRangeAsync(timetables);

            await _proxyRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GeneralTimetable>> GetAsync()
        {
            var source = await _wsRepository.GetGeneralTimetableAsync();

            var timetables = _mapper.Map<IEnumerable<GeneralTimetable>>(source.Select(c => c.GeneralTimetable));

            return timetables;
        }
    }
}