using System.Linq;
using System.Threading.Tasks;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Knewin.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly KnewinContext _context;
        public UserRepository(KnewinContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var userLogado = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
            
            return userLogado;
        }
    }
}
