using System;

namespace EntityFramework_6_DAL_Template.Core
{
    internal interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository>( ) where TRepository : class;

        int Commit();
    }
}
