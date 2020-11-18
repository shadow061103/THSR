using System.Collections.Generic;
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

        private IMapper _mapper;

        private IProxyRepository _proxyRepository;

        public FareService(IMapper mapper, IWsTHSRRepository wsRepository, IProxyRepository proxyRepository)
        {
            _mapper = mapper;
            _wsRepository = wsRepository;
            _proxyRepository = proxyRepository;
        }

        /// <summary>
        /// 新增票價資料
        /// </summary>
        public async Task InsertASync()
        {
            var source = await _wsRepository.GetFareAsync();

            var fares = this._mapper.Map<IEnumerable<Fare>>(source);

            await _proxyRepository.GetRepository<Fare>().AddRangeAsync(fares);

            await _proxyRepository.SaveChangesAsync();
        }
    }
}