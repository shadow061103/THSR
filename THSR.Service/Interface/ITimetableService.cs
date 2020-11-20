using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Models;

namespace THSR.Service.Interface
{
    public interface ITimetableService
    {
        /// <summary>
        /// 新增列車時刻表資料
        /// </summary>
        Task InsertAsync();

        Task<IEnumerable<GeneralTimetable>> GetAsync();
    }
}