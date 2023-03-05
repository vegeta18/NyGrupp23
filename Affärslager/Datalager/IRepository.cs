using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using Modellager;

namespace Datalager
{
    interface IRepository<TEntity>
    {
        //Skapar
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        //Läser
        TEntity Find(int id);
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!,
                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
                           params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> query);

        //Uppdaterar
        void Update(TEntity entity);
        TEntity Update(TEntity oldEntity, TEntity newEntity);
        void UpdateRange(IEnumerable<TEntity> entities);

        //Tar bort
        void Remove(int id);
        TEntity Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);    
        
    }
}
