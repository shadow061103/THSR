namespace THSR.Repository.Models.PTX
{
    public class StoptimePTXModel
    {
        /// <summary>
        /// 跑法站序(由1開始)
        /// </summary>
        public int StopSequence { get; set; }

        /// <summary>
        /// 車站代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        ///車站名稱
        /// </summary>
        public StationNamePTXModel StationName { get; set; }

        /// <summary>
        /// 到站時間(格式: HH:mm:ss)
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// 離站時間(格式: HH:mm:ss)
        /// </summary>
        public string ArrivalTime { get; set; }
    }
}