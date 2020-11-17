using System.Threading.Tasks;

namespace THSR.Service.Interface
{
    public interface IStationService
    {
        /// <summary>
        /// 新增高鐵車站資料
        /// </summary>
        Task InsertAsync();
    }
}