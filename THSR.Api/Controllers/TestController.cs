using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using THSR.Repository.Interfaces;
using THSR.Repository.Models.PTX;

namespace THSR.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly IWsTHSRRepository _stationRepository;

        public TestController(IWsTHSRRepository stationRepository)
        {
            _stationRepository = stationRepository;
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