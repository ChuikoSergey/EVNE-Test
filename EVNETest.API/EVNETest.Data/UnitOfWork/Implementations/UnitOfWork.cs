namespace EVNETest.Data.UnitOfWork.Implementations
{
    using System;
    using System.Threading.Tasks;
    using EVNETest.Core.Entities.Base;
    using EVNETest.Data.Context;
    using EVNETest.Data.Repository.Intarfaces;
    using EVNETest.Data.UnitOfWork.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private DataContext Context { get; }
        
        private IServiceProvider ServiceProvider { get; }
        private bool _disposed;

        #endregion

        #region Constructors

        public UnitOfWork(DataContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            ServiceProvider = serviceProvider;
        }

        #endregion

        #region Interface members

        public void Dispose()
        {
            if (!_disposed)
            {
                Context?.Dispose();
            }
            _disposed = true;
        }

        public IRepository<T> GetRepository<T>() where T: class, IEntity
        {
            if (!_disposed && Context != null) 
            {
                return ServiceProvider.GetService<IRepository<T>>();
            } 
            else 
            {
                return null;
            }
        }

        public async Task SaveChangesAsync()
        {
            if (!_disposed) 
            {
                await Context?.SaveChangesAsync();
            }
        }

        #endregion
    }
}