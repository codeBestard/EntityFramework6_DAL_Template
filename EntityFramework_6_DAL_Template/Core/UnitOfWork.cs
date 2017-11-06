using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework_6_DAL_Template.Specifications;

namespace EntityFramework_6_DAL_Template.Core
{
    public sealed class UnitOfWork : IUnitOfWork
    {

        private static readonly IDictionary<Type , object> _allRepositories = new Dictionary<Type, object>();

        private IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            if( ReferenceEquals( dbContext , null ) ) throw new ArgumentNullException( nameof( dbContext ) );

            this._dbContext = dbContext;
        }

        public TRepository GetRepository<TRepository>( ) where TRepository : class
        {
            var type   = typeof(TRepository);

            if (_allRepositories.TryGetValue(type, out var repository))
            {
                return repository as TRepository;
            }
            
            repository = Activator.CreateInstance(typeof(TRepository), this._dbContext);

            _allRepositories.Add(type, repository);

            return repository as TRepository;
        }


        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit( )
        {
            // Save changes with the default options
            return this._dbContext.SaveChanges();
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose( bool disposing )
        {
            if (!disposing)         return;
            if (this._dbContext == null) return;

            this._dbContext.Dispose();
            this._dbContext = null;
        }
    }
}
