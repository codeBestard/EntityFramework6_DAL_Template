using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EntityFramework_6_DAL_Template.Core;

namespace EntityFramework_6_DAL_Template.TestingClasses
{
    internal sealed class TestDbContext : IDbContext
    {
        private readonly IDictionary<Type , object> _sets;

        public TestDbContext( IDictionary<Type , object> sets )
        {
            this._sets = new Dictionary<Type , object>( sets );
        }
        public void Dispose( )
        {
            // do nothing
        }

        public DbEntityEntry<T> Entry<T>( T entity ) where T : class
        {
            throw new NotImplementedException();
        }

        public int SaveChanges( )
        {
            return 0;
        }

        public DbSet<T> Set<T>( ) where T : class
        {
            var type = typeof( T );

            if( !_sets.ContainsKey( type ) )
            {
                throw new KeyNotFoundException( nameof( type ) );
            }
            return _sets[type] as TestDbSet<T>;
        }
    }
}
