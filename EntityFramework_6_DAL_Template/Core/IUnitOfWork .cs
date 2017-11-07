using System;

namespace EntityFramework_6_DAL_Template.Core
{
    internal interface IUnitOfWork : IDisposable
    {
        TRepository GetRepository<TRepository, TEntity, TKey>()
            where TRepository : class, IRepository<TEntity, TKey>
            where TEntity : class;

        int Commit();
    }
}
