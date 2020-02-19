using Knewin.Domain.Entities;
using System.Threading.Tasks;
namespace Knewin.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> Login(string username, string password); 
    }
}