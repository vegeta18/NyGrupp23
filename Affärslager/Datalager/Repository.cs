﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using Modellager;

namespace Datalager
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public BibliotekContext Context;
        public Repository(BibliotekContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity) 
        {
            Context.Set<TEntity>().Remove(entity);  
        }

        public TEntity Get(int id) 
        {
            return Context.Set<TEntity>().Find(id);    
        }

        public IEnumerable<TEntity> GetAll() 
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) 
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void RemoveRange(IEnumerable<TEntity> entities) 
        {
            Context.Set<TEntity>.RemoveRange(entities);
        }
      

    }
}
