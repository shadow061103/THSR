using System.Collections.Generic;
using System.Threading.Tasks;

namespace THSR.Repository.Interfaces
{
    public interface IEntityRepository<TEntity>
    {
        /// <summary>
        /// 新增實體
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// 新增多筆實體
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 刪除實體
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Remove(TEntity entity);

        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新實體
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// 更新多筆實體
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}