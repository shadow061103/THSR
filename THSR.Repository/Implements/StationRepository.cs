using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Interfaces;
using THSR.Repository.Models;
using THSR.Repository.Models.Context;

namespace THSR.Repository.Implements
{
    public class StationRepository : IStationRepository
    {
        private readonly THSRContext _context;

        public StationRepository(THSRContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 新增高鐵車站基本資料
        /// </summary>
        /// <param name="stations">The stations.</param>
        public async Task InsertAsync(IEnumerable<Station> stations)
        {
            await _context.Station.AddRangeAsync(stations);
            await _context.SaveChangesAsync();
        }
    }
}