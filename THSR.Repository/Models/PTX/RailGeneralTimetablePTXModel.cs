namespace THSR.Repository.Models.PTX
{
    public class RailGeneralTimetablePTXModel
    {
        /// <summary>
        /// 發布時間
        /// </summary>
        public string UpdateTime { get; set; }

        /// <summary>
        /// 有效日期
        /// </summary>
        public string EffectiveDate { get; set; }

        /// <summary>
        /// 結束日期
        /// </summary>
        public string ExpiringDate { get; set; }

        /// <summary>
        /// 資料版本編號
        /// </summary>
        public int VersionID { get; set; }

        /// <summary>
        /// 定期時刻表資料
        /// </summary>
        public GeneraltimetablePTXModel GeneralTimetable { get; set; }
    }
}