using System.Threading.Tasks;

namespace THSR.Service.Interface
{
    public interface ITimetableService
    {
        /// <summary>
        /// 新增列車時刻表資料
        /// </summary>
        Task InsertAsync();
    }
}