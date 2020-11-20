namespace THSR.Repository.Models.PTX
{
    public class StopstationPTXModel
    {
        /// <summary>
        /// 跑法站序
        /// </summary>
        public int StopSequence { get; set; }

        /// <summary>
        /// 車站代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 車站名稱
        /// </summary>
        public StationNamePTXModel StationName { get; set; }

        /// <summary>
        /// 標準席剩餘座位狀態 = ['O: 尚有座位' or 'L: 座位有限' or 'X: 已無座位']
        /// </summary>
        public string StandardSeatStatus { get; set; }

        /// <summary>
        /// 商務席剩餘座位狀態 = ['O: 尚有座位' or 'L: 座位有限' or 'X: 已無座位']
        /// </summary>
        public string BusinessSeatStatus { get; set; }
    }
}