using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THSR.Repository.Interfaces;

namespace THSR.Repository.Implements
{
    public class ProxyRepository : IProxyRepository, IDisposable
    {
        private DbContext _context;

        private Hashtable _repositories;

        private bool disposed = false;

        public ProxyRepository(DbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 取得泛型 Repository
        /// </summary>
        /// <typeparam name="TEntity">實體</typeparam>
        /// <returns></returns>
        public IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (this._repositories == null)
            {
                this._repositories = new Hashtable();
            }

            var type = typeof(TEntity);
            if (!this._repositories.ContainsKey(type))
            {
                this._repositories[type] = new EntityRepository<TEntity>(this._context);
            }
            return (IEntityRepository<TEntity>)this._repositories[type];
        }

        /// <summary>
        /// 儲存資料變更
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        /// only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}