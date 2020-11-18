using System.Threading.Tasks;

namespace THSR.Service.Interface
{
    public interface IFareService
    {
        /// <summary>
        /// 新增票價資料
        /// </summary>
        Task InsertASync();
    }
}