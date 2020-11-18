namespace THSR.Repository.Models.PTX
{
    public class FarePTXModel
    {
        /// <summary>
        /// 票種名稱
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// 收費價格
        /// </summary>
        public decimal Price { get; set; }
    }
}