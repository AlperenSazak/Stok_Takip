using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Stok_Takip.Data;
using Stok_Takip.Helpers.LogHelper;
using Stok_Takip.Models;

namespace Stok_Takip.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public TEntity Add(TEntity entity)
        {
            try
            {
                _appDbContext.Set<TEntity>().Add(entity);
                Log.Info(entity+"Kaydı Eklendi");
                _appDbContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                {
                    Log.Error(sqlException.Message);
                    throw new Exception("Bu değer daha önce eklenmiş.");
                }
                else
                {
                    Log.Error("Different error");
                    throw;
                }
            }
           
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity()
            {
                Id = id
            };
            _appDbContext.Set<TEntity>().Remove(entity);
            _appDbContext.SaveChanges ();
            
        }

        public IQueryable<TEntity> GetAll()
        {
            return _appDbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return _appDbContext.Set<TEntity>().AsNoTracking().First(x => x.Id == id );
        }

        public void Update(TEntity entity, int id)
        {
            try
            {
                _appDbContext.Set<TEntity>().Update(entity);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                {
                    throw new Exception("Bu değer daha önce eklenmiş.");
                }
                else
                {
                    throw;
                }
            }
            
        }
    }
}
