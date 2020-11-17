using System.ComponentModel;
using Hangfire.Server;

namespace THSR.Task.Interfaces
{
    public interface ITHSRInitialJob
    {
        /// <summary>
        /// 排程工作 資料表初始建立資料
        /// </summary>
        /// <param name="context">The context.</param>
        [DisplayName("排程工作 資料表初始建立資料")]
        System.Threading.Tasks.Task DataBaseDataInitialCreate(PerformContext context);
    }
}