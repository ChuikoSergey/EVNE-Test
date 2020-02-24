namespace EVNETest.Data.UnitOfWork.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using EVNETest.Core.Entities.Base;
    using EVNETest.Data.Repository.Intarfaces;

    public interface IUnitOfWork : IDisposable
    {
         IRepository<T> GetRepository<T>() where T: class, IEntity;
         Task SaveChangesAsync();
    }
}