using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace EntityFramework_6_DAL_Template.Core
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : class
    {
        TEntity SingleOrDefault( Expression<Func<TEntity , bool>> predicate );
        IEnumerable<TEntity> GetRange(int skipCount, int takeCount);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get( TKey key );



        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
