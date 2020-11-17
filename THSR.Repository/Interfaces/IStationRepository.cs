using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Models;

namespace THSR.Repository.Interfaces
{
    public interface IStationRepository
    {
        /// <summary>
        /// 新增高鐵車站基本資料
        /// </summary>
        /// <param name="stations">The stations.</param>
        Task InsertAsync(IEnumerable<Station> stations);
    }
}