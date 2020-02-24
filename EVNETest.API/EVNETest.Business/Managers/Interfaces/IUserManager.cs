namespace EVNETest.Business.Managers.Interfaces
{
    using System.Threading.Tasks;
    using EVNETest.Business.Managers.Interfaces.Base;
    using EVNETest.Core.Entities;

    public interface IUserManager : ICrudManager<User>
    {
        Task<User> GetByCredentialsAsync(string email, string password);
    }
}