using System;
using System.Collections.Generic;

namespace THSR.Repository.Models.PTX
{
    public class GeneraltimetablePTXModel
    {
        /// <summary>
        /// 定期車次資料
        /// </summary>
        public GeneraltraininfoPTXModel GeneralTrainInfo { get; set; }

        /// <summary>
        /// 停靠時間資料
        /// </summary>
        public IEnumerable<StoptimePTXModel> StopTimes { get; set; }

        /// <summary>
        /// 營運日型態
        /// </summary>
        public ServicedayPTXModel ServiceDay { get; set; }

        /// <summary>
        /// 來源端平台資料更新時間
        /// </summary>
        public DateTime SrcUpdateTime { get; set; }
    }
}