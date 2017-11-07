using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFramework_6_DAL_Template.Core
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity: class
    {
        protected readonly IDbContext DbContext;

        protected RepositoryBase( IDbContext dbContext )
        {
            if(ReferenceEquals(dbContext, null)) throw new ArgumentNullException(nameof(dbContext));
            this.DbContext = dbContext;
        }
        public virtual void Add(TEntity entity)
        {
            if(ReferenceEquals(entity, null)) throw new ArgumentNullException(nameof(entity));
            this.DbContext.Set<TEntity>().Add(entity);

        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if( ReferenceEquals( entities , null ) ) throw new ArgumentNullException( nameof( entities ) );
            this.DbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            if( ReferenceEquals( entity , null ) ) throw new ArgumentNullException( nameof( entity ) );
            this.DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            if( ReferenceEquals( entities , null ) ) throw new ArgumentNullException( nameof( entities ) );
            this.DbContext.Set<TEntity>().RemoveRange( entities );
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            if (ReferenceEquals(predicate, null)) throw new ArgumentNullException(nameof(predicate));
            var result = this.DbContext.Set<TEntity>().Where(predicate);
            return result;
        }

        /// <summary>
        /// Each Repository should have its own implementation on how to resolve the Keys
        /// </summary>
        /// <param name="key">key for the entity</param>
        /// <returns>Entity</returns>
        public abstract TEntity Get(TKey key);

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            if( ReferenceEquals( predicate , null ) ) throw new ArgumentNullException( nameof( predicate ) );
            var result = this.DbContext.Set<TEntity>().SingleOrDefault( predicate );
            return result;
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = this.DbContext.Set<TEntity>().ToList();
            return result;
        }

        public virtual IEnumerable<TEntity> GetRange(int skipCount, int takeCount)
        {
            var result = this.DbContext.Set<TEntity>()
                                     .Skip(skipCount)
                                     .Take(takeCount);
            return result;
        }
    }
}
