namespace THSR.Repository.Models.PTX
{
    public class GeneraltraininfoPTXModel
    {
        /// <summary>
        /// 車次代碼
        /// </summary>
        public string TrainNo { get; set; }

        /// <summary>
        ///行駛方向 : [0:'南下',1:'北上']
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        ///列車起點車站代號
        /// </summary>
        public string StartingStationID { get; set; }

        /// <summary>
        /// 列車起點車站名稱
        /// </summary>
        public StationNamePTXModel StartingStationName { get; set; }

        /// <summary>
        /// 列車終點車站代號
        /// </summary>
        public string EndingStationID { get; set; }

        /// <summary>
        ///列車終點車站名稱
        /// </summary>
        public StationNamePTXModel EndingStationName { get; set; }

        /// <summary>
        /// 附註說明
        /// </summary>
        public NotePTXModel NotePtxModel { get; set; }
    }
}