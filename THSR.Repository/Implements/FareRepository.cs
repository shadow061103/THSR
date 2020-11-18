using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Interfaces;
using THSR.Repository.Models.Context;
using THSR.Repository.Models.Entities;

namespace THSR.Repository.Implements
{
    public class FareRepository : IFareRepository
    {
        private readonly THSRContext _context;

        public FareRepository(THSRContext context)
        {
            _context = context;
        }

        /// <summary>
        ///新增高鐵票價資料
        /// </summary>
        /// <param name="stations">The stations.</param>
        public async Task InsertAsync(IEnumerable<Fare> stations)
        {
            await _context.Fare.AddRangeAsync(stations);
            await _context.SaveChangesAsync();
        }
    }
}