using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Infrastructure.Helpers;
using THSR.Repository.Interfaces;
using THSR.Repository.Models;

namespace THSR.Repository.Implements
{
    public class StationRepository : IStationRepository
    {
        private readonly IApiHelper _apiHelper;

        public StationRepository(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<RailStation>> GetStation()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/Station?$top=30&$format=JSON";
            return await _apiHelper.GetPTXAsync<List<RailStation>>(url);
        }
    }
}