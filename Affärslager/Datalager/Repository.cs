using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using Modellager;

namespace Datalager
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected BibliotekContext Context { get; }
        protected DbSet<TEntity> Table { get; }
        protected Repository(BibliotekContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        //Skapa 
        public virtual TEntity Add(TEntity entity) 
        {
            Table.Add(entity); return entity; 
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities) 
        { 
            Table.AddRange(entities); return entities;  
        }

        //Läser
        public virtual TEntity Find(int id) => Table.Find(id);
        public virtual TEntity FirstOfDefault(Func<TEntity, bool> predicate) => Table.FirstOrDefault(predicate);
        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate) => Table.Where(predicate);
        public virtual IEnumerable<TEntity> GetAll() => Table;

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null!,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null!, 
        params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Table;
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
            query = (filter != null) ? query.Where(filter) : query;
            query = (orderby != null) ? orderby(query) : query;
            return query.ToList();
        }

        public virtual IEnumerable<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> query) => query(Table);

        //uppdatering 
        public virtual void Update(TEntity entity) => Table.Update(entity); 
        public virtual TEntity Update(TEntity oldEntity, TEntity newEntity)
        {
            Context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            Table.Update(oldEntity);
            return oldEntity;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities) => Table.UpdateRange(entities);

        //Delete
        public virtual void Remove(int id)
        {
            var entity = Table.Find(id);
            if(entity != null)
            {
                Context.Entry(entity).State = EntityState.Deleted;
            }
        }
        public virtual TEntity Remove(TEntity entity)
        {
            Table.Remove(entity); return entity;
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities) => Table.RemoveRange(entities);


    }
}
