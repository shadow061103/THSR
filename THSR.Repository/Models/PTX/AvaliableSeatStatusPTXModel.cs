using System;
using System.Collections.Generic;

namespace THSR.Repository.Models.PTX
{
    public class AvaliableSeatStatusPTXModel
    {
        /// <summary>
        ///更新日期時間
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 對號座位狀態資訊(依高鐵規定若營運狀態有異常狀況時，剩餘座位資訊將停留在最後正常運行時間之狀態不做更新，實際資料請參考高鐵各車站現場對號座剩餘座位資訊看板)
        /// </summary>
        public IEnumerable<AvailableseatPTXModel> AvailableSeats { get; set; }
    }
}