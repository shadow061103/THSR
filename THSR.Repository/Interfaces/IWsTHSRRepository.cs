using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Models.PTX;

namespace THSR.Repository.Interfaces
{
    public interface IWsTHSRRepository
    {
        /// <summary>
        /// 取得高鐵車站基本資料
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        Task<IEnumerable<HSRailStationPTXModel>> GetStationAsync();

        /// <summary>
        /// 取得起訖站票價資料.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<HSRailFarePTXModel>> GetFareAsync();

        /// <summary>
        /// 取得所有車次定期時刻表資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<RailGeneralTimetablePTXModel>> GetGeneralTimetableAsync();

        /// <summary>
        /// 取得動態對號座剩餘座位資訊看板資料
        /// </summary>
        /// <returns></returns>
        Task<AvaliableSeatStatusPTXModel> GetAvailableSeatStatusAsync();

        /// <summary>
        ///取得動態指定車站對號座剩餘座位資訊看板資料
        /// </summary>
        /// <param name="stationId">車站代碼</param>
        /// <returns></returns>
        Task<AvaliableSeatStatusPTXModel> GetAvailableSeatStatusAsync(string stationId);

        /// <summary>
        /// 取得高鐵最新消息資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NewsPTXModel>> GetNewsAsync();

        /// <summary>
        /// 取得即時通阻事件資料
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AlertInfoPTXModel>> GetAlertInfoAsync();
    }
}