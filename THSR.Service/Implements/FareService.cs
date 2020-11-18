using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using THSR.Repository.Interfaces;
using THSR.Repository.Models.Entities;
using THSR.Service.Interface;

namespace THSR.Service.Implements
{
    public class FareService : IFareService
    {
        private IWsTHSRRepository _wsRepository;

        private IFareRepository _fareRepository;

        private IMapper _mapper;

        public FareService(IMapper mapper, IWsTHSRRepository wsRepository, IFareRepository fareRepository)
        {
            _mapper = mapper;
            _wsRepository = wsRepository;
            _fareRepository = fareRepository;
        }

        /// <summary>
        /// 新增票價資料
        /// </summary>
        public async Task InsertASync()
        {
            var source = await _wsRepository.GetFareAsync();

            //南下跟北上票價是相同
            var fares = this._mapper.Map<IEnumerable<Fare>>(source.Where(x => x.Direction == 1));

            await _fareRepository.InsertAsync(fares);
        }
    }
}