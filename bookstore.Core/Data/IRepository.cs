using System.Collections.Generic;
using bookstore.Shared.Model;

namespace bookstore.Core.Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();

        TEntity Get(int id);

        bool Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);
    }
}
