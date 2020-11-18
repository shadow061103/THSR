using System.Threading.Tasks;

namespace THSR.Repository.Interfaces
{
    public interface IProxyRepository
    {
        /// <summary>
        /// 取得泛型 Repository
        /// </summary>
        /// <typeparam name="TEntity">實體</typeparam>
        /// <returns></returns>
        IEntityRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        /// <summary>
        /// 儲存資料變更
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}