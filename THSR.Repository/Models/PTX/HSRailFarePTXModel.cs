using System;

namespace THSR.Repository.Models.PTX
{
    public class HSRailFarePTXModel
    {
        /// <summary>
        /// 起點車站代碼
        /// </summary>
        public string OriginStationID { get; set; }

        /// <summary>
        /// 起點車站名稱
        /// </summary>
        public StationNamePTXModel OriginStationName { get; set; }

        /// <summary>
        /// 迄點車站代碼
        /// </summary>
        public string DestinationStationID { get; set; }

        /// <summary>
        /// 迄點車站名稱
        /// </summary>
        public StationNamePTXModel DestinationStationName { get; set; }

        /// <summary>
        /// 行駛方向 : [0:'南下',1:'北上']
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// 票價收費資訊
        /// </summary>
        public FarePTXModel[] Fares { get; set; }

        /// <summary>
        /// 來源端平台資料更新時間
        /// </summary>
        public DateTime SrcUpdateTime { get; set; }

        /// <summary>
        /// 本平台資料更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary> 資料版本編號

        /// </summary>
        public int VersionID { get; set; }
    }
}