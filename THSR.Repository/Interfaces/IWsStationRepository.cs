using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Models.PTX;

namespace THSR.Repository.Interfaces
{
    public interface IWsStationRepository
    {
        /// <summary>
        /// 取得高鐵車站基本資料
        /// </summary>
        /// <returns></returns>
        Task<List<HSRailStationPTXModel>> GetStation();
    }
}