using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessor {
	public interface IRepositorioBase<TEntity> where TEntity : class {
          Task<IList<TEntity>> GetAllAsync();
          Task<TEntity> GetByIDAsync<T>(T pID);
          Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> pMatch);

          Task<TEntity> InsertAsync(TEntity pEntity, bool pSaveChanges = false);
          Task DeleteAsync<T>(T pID, bool pSaveChanges = false);
          Task DeleteAsync(TEntity pEntity, bool pSaveChanges = false);
          Task UpdateAsync(TEntity pEntity, bool pSaveChanges = false);
          Task<TEntity> UpdateAsync<T>(TEntity pEntity, T pKey, bool pSaveChanges = false);
          Task CommitAsync();

          void Dispose();
     }
}
