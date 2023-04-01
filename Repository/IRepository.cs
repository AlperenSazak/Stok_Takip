using Stok_Takip.Models;

namespace Stok_Takip.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Add(TEntity entity);

        void Update(TEntity entity, int id);

        void Delete(int id);
        
    }
}
