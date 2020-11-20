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
        public async Task<IEnumerable<HSRailStationPTXModel>> GetStationAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/Station?$top=50&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<HSRailStationPTXModel>>(url);
        }

        /// <summary>
        /// 取得起訖站票價資料.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HSRailFarePTXModel>> GetFareAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/ODFare?$top=500&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<HSRailFarePTXModel>>(url);
        }

        /// <summary>
        /// 取得所有車次定期時刻表資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RailGeneralTimetablePTXModel>> GetGeneralTimetableAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/GeneralTimetable?$top=250&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<RailGeneralTimetablePTXModel>>(url);
        }
    }
}