using System.Collections.Generic;
using System.Threading.Tasks;
using THSR.Repository.Models;

namespace THSR.Repository.Interfaces
{
    public interface IStationRepository
    {
        Task<List<RailStation>> GetStation();
    }
}