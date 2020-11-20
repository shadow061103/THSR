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
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/Station?$top=99999&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<HSRailStationPTXModel>>(url);
        }

        /// <summary>
        /// 取得起訖站票價資料.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HSRailFarePTXModel>> GetFareAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/ODFare?$top=99999&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<HSRailFarePTXModel>>(url);
        }

        /// <summary>
        /// 取得所有車次定期時刻表資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RailGeneralTimetablePTXModel>> GetGeneralTimetableAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/GeneralTimetable?$top=99999&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<RailGeneralTimetablePTXModel>>(url);
        }

        /// <summary>
        /// 取得動態對號座剩餘座位資訊看板資料
        /// </summary>
        /// <returns></returns>
        public async Task<AvaliableSeatStatusPTXModel> GetAvailableSeatStatusAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/AvailableSeatStatusList?$top=99999&$format=JSON";
            return await _apiHelper.GetPTXAsync<AvaliableSeatStatusPTXModel>(url);
        }

        /// <summary>
        ///取得動態指定車站對號座剩餘座位資訊看板資料
        /// </summary>
        /// <param name="stationId">車站代碼</param>
        /// <returns></returns>
        public async Task<AvaliableSeatStatusPTXModel> GetAvailableSeatStatusAsync(string stationId)
        {
            var url = $"https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/AvailableSeatStatusList/{stationId}?$top=1000&$format=JSON";
            return await _apiHelper.GetPTXAsync<AvaliableSeatStatusPTXModel>(url);
        }

        /// <summary>
        /// 取得高鐵最新消息資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<NewsPTXModel>> GetNewsAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/News?$top=100&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<NewsPTXModel>>(url);
        }

        /// <summary>
        /// 取得即時通阻事件資料
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AlertInfoPTXModel>> GetAlertInfoAsync()
        {
            var url = "https://ptx.transportdata.tw/MOTC/v2/Rail/THSR/AlertInfo?$top=100&$format=JSON";
            return await _apiHelper.GetPTXAsync<IEnumerable<AlertInfoPTXModel>>(url);
        }
    }
}