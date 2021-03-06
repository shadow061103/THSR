﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace THSR.Repository.Models
{
    /// <summary>
    /// 車次靠站順序
    /// </summary>
    public partial class RailStopTime
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int Sn { get; set; }
        /// <summary>
        /// 車次代碼
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 車站代碼
        /// </summary>
        public string StationID { get; set; }
        /// <summary>
        /// 跑法站序(由1開始) 
        /// </summary>
        public int? StopSequence { get; set; }
        /// <summary>
        /// 到站時間
        /// </summary>
        public string ArrivalTime { get; set; }
        /// <summary>
        /// 離站時間
        /// </summary>
        public string DepartureTime { get; set; }

        public virtual GeneralTimetable TrainNoNavigation { get; set; }
    }
}