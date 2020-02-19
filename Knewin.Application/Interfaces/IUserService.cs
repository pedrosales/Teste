using System.Threading.Tasks;
using Knewin.Domain.Entities;

namespace Knewin.Application.Interfaces
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User> Login(string username, string password);
    }
}
