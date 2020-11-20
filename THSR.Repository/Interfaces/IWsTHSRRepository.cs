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
        Task<IEnumerable<RailGeneralTimetablePTXModel>> GetGeneralTimetable();
    }
}