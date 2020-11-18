using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Models.Entities;

namespace THSR.Repository.Interfaces
{
    public interface IFareRepository
    {
        /// <summary>
        ///新增高鐵票價資料
        /// </summary>
        /// <param name="stations">The stations.</param>
        Task InsertAsync(IEnumerable<Fare> stations);
    }
}