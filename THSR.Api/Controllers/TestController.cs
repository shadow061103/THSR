using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THSR.Repository.Interfaces;
using THSR.Repository.Models.PTX;
using THSR.Service.Interface;

namespace THSR.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IWsTHSRRepository _stationRepository;

        private ITimetableService _timetableService;

        public TestController(IWsTHSRRepository stationRepository, ITimetableService timetableService)
        {
            _stationRepository = stationRepository;
            _timetableService = timetableService;
        }

        [HttpGet]
        public async Task<IEnumerable<HSRailStationPTXModel>> GetStation()
        {
            var model = await _stationRepository.GetStationAsync();
            return model;
        }

        [HttpGet]
        public async Task<IEnumerable<HSRailFarePTXModel>> GetFare()
        {
            var model = await _stationRepository.GetFareAsync();
            return model;
        }
    }
}