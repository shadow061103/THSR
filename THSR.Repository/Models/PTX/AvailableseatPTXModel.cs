using System;
using System.Collections.Generic;

namespace THSR.Repository.Models.PTX
{
    public class AvailableseatPTXModel
    {
        /// <summary>
        /// 車次號碼
        /// </summary>
        public string TrainNo { get; set; }

        /// <summary>
        /// 方向 : [0:'南下',1:'北上']
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// 查詢車站代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 查詢車站名稱
        /// </summary>
        public StationNamePTXModel StationName { get; set; }

        /// <summary>
        /// 發車時間(格式: HH:mm)
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// 終點車站代碼
        /// </summary>
        public string EndingStationID { get; set; }

        /// <summary>
        ///終點車站名稱
        /// </summary>
        public StationNamePTXModel EndingStationName { get; set; }

        /// <summary>
        /// 車次停靠站點組合
        /// </summary>
        public IEnumerable<StopstationPTXModel> StopStations { get; set; }

        /// <summary>
        /// 來源端平台接收時間
        /// </summary>
        public DateTime SrcRecTime { get; set; }

        /// <summary>
        /// 本平台資料更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}