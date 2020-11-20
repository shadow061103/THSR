namespace THSR.Repository.Models.PTX
{
    public class ServicedayPTXModel
    {
        /// <summary>
        /// 星期一是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Monday { get; set; }

        /// <summary>
        /// 星期二是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Tuesday { get; set; }

        /// <summary>
        ///星期三是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Wednesday { get; set; }

        /// <summary>
        /// 星期四是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Thursday { get; set; }

        /// <summary>
        /// 星期五是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Friday { get; set; }

        /// <summary>
        /// 星期六是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Saturday { get; set; }

        /// <summary>
        ///星期日是否營運 : [0:'否',1:'是']
        /// </summary>
        public int Sunday { get; set; }
    }
}