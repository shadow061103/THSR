using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Infrastructure.Helpers;
using THSR.Repository.Interfaces;
using THSR.Repository.Models.PTX;

namespace THSR.Repository.Implements
{
    public class WsTHSRRepository : IWsTHSRRepository
    {
        private readonly IApiHelper _apiHelper;

        public WsTHSRRepository(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        /// <summary>
        /// 取得高鐵車站基本資料
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IEnumerable<HSRailStationPTXModel>> GetStation()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/Station?$top=50&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<HSRailStationPTXModel>>(url);
        }
    }
}