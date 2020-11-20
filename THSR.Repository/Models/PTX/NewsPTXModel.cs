using System;

namespace THSR.Repository.Models.PTX
{
    public class NewsPTXModel
    {
        /// <summary>
        /// 消息編號
        /// </summary>
        public string NewsID { get; set; }

        /// <summary>
        /// 消息類別
        /// </summary>
        public string NewsCategory { get; set; }

        /// <summary>
        /// 消息標題
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 消息網址連結
        /// </summary>
        public string NewsUrl { get; set; }

        /// <summary>
        ///開始時間
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 消息發布日期時間
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 本平台資料更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}