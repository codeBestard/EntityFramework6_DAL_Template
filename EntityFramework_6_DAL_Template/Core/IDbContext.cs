using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EntityFramework_6_DAL_Template.Core
{
    public interface IDbContext
    {
        DbSet<T> Set<T>( ) where T : class;
        DbEntityEntry<T> Entry<T>( T entity ) where T : class;
        int SaveChanges( );
        void Dispose( );
    }
}
