﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using THSR.Repository.Interfaces;
using THSR.Repository.Models.Entities;
using THSR.Service.Interface;

namespace THSR.Service.Implements
{
    public class StationService : IStationService
    {
        private IMapper _mapper;

        private IWsTHSRRepository _wsRepository;

        private IProxyRepository _proxyRepository;

        public StationService(IMapper mapper, IWsTHSRRepository wsRepository, IProxyRepository proxyRepository)
        {
            _mapper = mapper;
            _wsRepository = wsRepository;
            _proxyRepository = proxyRepository;
        }

        /// <summary>
        /// 新增高鐵車站資料
        /// </summary>
        public async Task InsertAsync()
        {
            var source = await _wsRepository.GetStationAsync();

            var stations = this._mapper.Map<IEnumerable<Station>>(source);

            await _proxyRepository.GetRepository<Station>().AddRangeAsync(stations);

            await _proxyRepository.SaveChangesAsync();
        }
    }
}