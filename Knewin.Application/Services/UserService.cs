using System.Threading.Tasks;
using Knewin.Application.Interfaces;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;

namespace Knewin.Application.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IRepositoryBase<User> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Login(string username, string password)
        {
           var userLogado = await _userRepository.Login(username, password);

           return userLogado;
        }
    }
}
