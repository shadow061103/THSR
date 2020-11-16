using System;

namespace THSR.Service.Models.Station
{
    public class HSRailStationDto
    {
        /// <summary>
        /// 車站唯一識別代碼
        /// </summary>
        public string StationUID { get; set; }

        /// <summary>
        ///車站代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 車站簡碼(訂票系統用)
        /// </summary>
        public string StationCode { get; set; }

        /// <summary>
        /// 車站名稱
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 車站英文名稱
        /// </summary>
        public string StationEnName { get; set; }

        /// <summary>
        /// 車站地址
        /// </summary>
        public string StationAddress { get; set; }

        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public string OperatorID { get; set; }

        /// <summary>
        /// 本平台資料更新時間(ISO8601格式:yyyy-MM-ddTHH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 資料版本編號
        /// </summary>
        public int VersionID { get; set; }

        /// <summary>
        /// 位置緯度
        /// </summary>
        public float PositionLat { get; set; }

        /// <summary>
        /// 位置經度
        /// </summary>
        public float PositionLon { get; set; }

        /// <summary>
        ///車站位置所屬縣市
        /// </summary>
        public string LocationCity { get; set; }

        /// <summary>
        /// 車站位置所屬縣市代碼
        /// </summary>
        public string LocationCityCode { get; set; }

        /// <summary>
        /// 車站位置所屬鄉鎮
        /// </summary>
        public string LocationTown { get; set; }

        /// <summary>
        /// 車站位置所屬鄉鎮代碼
        /// </summary>
        public string LocationTownCode { get; set; }
    }
}