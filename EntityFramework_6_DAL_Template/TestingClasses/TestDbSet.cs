using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace EntityFramework_6_DAL_Template.TestingClasses
{
    internal sealed class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
        where TEntity : class
    {
        readonly ObservableCollection<TEntity> _data;
        readonly IQueryable                    _query;

        public TestDbSet( )
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public override TEntity Add( TEntity item )
        {
            _data.Add( item );
            return item;
        }

        public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            var items = entities as TEntity[] ?? entities.ToArray();
            foreach (var item in items )
            {
                this.Add(item);
            }
            return items;
        }

        public override TEntity Remove( TEntity item )
        {
            _data.Remove( item );
            return item;
        }

        public override TEntity Attach( TEntity item )
        {
            _data.Add( item );
            return item;
        }

        public override TEntity Create( )
        {
            return Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>( )
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override TEntity Find(params object[] keyValues)
        {
            // The work around for testing is to inject a Func expression
            throw new NotImplementedException();
        }

        public override ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<TEntity>( _query.Provider ); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator( )
        {
            return _data.GetEnumerator();
        }

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator( )
        {
            return _data.GetEnumerator();
        }

        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator( )
        {
            return new TestDbAsyncEnumerator<TEntity>( _data.GetEnumerator() );
        }
    }
}