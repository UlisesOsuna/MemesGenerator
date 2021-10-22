using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccessor {
	public class cRepositorioBase<TEntity>:
		IRepositorioBase<TEntity> where TEntity: class {

          private bool iDisposed;
          private DbSet<TEntity> iDbSet;

          private DbContext iContext {
               get;
               set;
          }

          public cRepositorioBase(DbContext pContext) {
               iContext = pContext;
               iDisposed = false;
          }

          protected virtual void Dispose(bool disposing) {
               if(!this.iDisposed) {
                    if(disposing) {
                         iContext.Dispose();
                    }

                    this.iDisposed = true;
               }
          }

          public void Dispose() {
               Dispose(true);
               GC.SuppressFinalize(this);
          }

          protected DbSet<TEntity> DbSet {
               get {
                    if(iDbSet == null)
                         iDbSet = iContext.Set<TEntity>();

                    return iDbSet;
               }
          }

          public virtual async Task<IEnumerable<TEntity>> GetAllAsync() {
               return await this.DbSet.ToListAsync();
          }

          public virtual async Task<TEntity> GetByIDAsync<T>(T pID) {
               return await this.DbSet.FindAsync(pID);
          }

          public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> pMatch) {
               return await this.DbSet.FirstOrDefaultAsync(pMatch);
          }

          public virtual async Task<TEntity> InsertAsync(
               TEntity pEntity
               , bool pSaveChanges = false) {

               EntityEntry<TEntity> lReturn = await this.DbSet.AddAsync(pEntity);
               if(pSaveChanges)
                    await iContext.SaveChangesAsync();

               return lReturn.Entity;
          }

          public virtual async Task DeleteAsync<T>(
               T pID
               , bool pSaveChanges = false) {

               TEntity lItem = await GetByIDAsync<T>(pID);
               this.DbSet.Remove(lItem);

               if(pSaveChanges)
                    await iContext.SaveChangesAsync();
          }

          public virtual async Task DeleteAsync(
               TEntity pEntity
               , bool pSaveChanges = false) {

               this.DbSet.Attach(pEntity);
               this.DbSet.Remove(pEntity);

               if(pSaveChanges)
                    await iContext.SaveChangesAsync();
          }

          public virtual async Task UpdateAsync(
               TEntity pEntity
               , bool pSaveChanges = false) {

               EntityEntry<TEntity> lReturn = iContext.Entry(pEntity);
               this.DbSet.Attach(pEntity);
               lReturn.State = EntityState.Modified;

               if(pSaveChanges)
                    await iContext.SaveChangesAsync();
          }

          public virtual async Task<TEntity> UpdateAsync<T>(
               TEntity pEntity
               , T pKey
               , bool pSaveChanges = false) {

               if(pEntity == null)
                    return null;

               TEntity lReturn = await this.DbSet.FindAsync(pKey);
               if(lReturn != null) {
                    iContext.Entry(lReturn).CurrentValues.SetValues(pEntity);

                    if(pSaveChanges)
                         await iContext.SaveChangesAsync();
               }

               return lReturn;
          }

          public virtual async Task CommitAsync() {
               await iContext.SaveChangesAsync();
          }
	}
}
