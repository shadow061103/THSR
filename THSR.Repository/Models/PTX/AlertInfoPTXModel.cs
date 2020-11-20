using System;

namespace THSR.Repository.Models.PTX
{
    public class AlertInfoPTXModel
    {
        /// <summary>
        /// 動態事件影響等級 [1:'全線正常運行',2:'有異常狀況']
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 營運狀態 = ['空白: 正常' or '▲: 其他的異常狀態' or 'X: 全線停止運行']
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 標題
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 事件簡易描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 影響狀態
        /// </summary>
        public string Effects { get; set; }

        /// <summary>
        /// 運行方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 影響區間
        /// </summary>

        public string EffectedSection { get; set; }

        /// <summary>
        /// 發生日期時間
        /// </summary>
        public DateTime OccuredTime { get; set; }

        /// <summary>
        /// 訊息發布日期時間
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 來源端平台資料更新時間
        /// </summary>
        public DateTime SrcUpdateTime { get; set; }

        /// <summary>
        /// 本平台資料更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}