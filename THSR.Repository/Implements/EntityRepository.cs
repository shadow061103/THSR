using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THSR.Repository.Interfaces;

namespace THSR.Repository.Implements
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        private DbContext _dbContext;

        /// <summary>
        /// 資料表實體
        /// </summary>
        public DbSet<TEntity> Entity { get; }

        public EntityRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Entity = _dbContext.Set<TEntity>();
        }

        /// <summary>
        /// 新增實體
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            await this.Entity.AddAsync(entity);
        }

        /// <summary>
        /// 新增多筆實體
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.Entity.AddRangeAsync(entities);
        }

        /// <summary>
        /// 刪除實體
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Remove(TEntity entity)
        {
            this.Entity.Remove(entity);
        }

        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Entity.RemoveRange(entities);
        }

        /// <summary>
        /// 更新實體
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(TEntity entity)
        {
            this.Entity.Update(entity);
        }

        /// <summary>
        /// 更新多筆實體
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            this.Entity.UpdateRange(entities);
        }
    }
}