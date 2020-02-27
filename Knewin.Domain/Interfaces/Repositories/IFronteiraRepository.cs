using System.Collections.Generic;
using System.Threading.Tasks;
using Knewin.Domain.Entities;

namespace Knewin.Domain.Interfaces.Repositories
{
    public interface IFronteiraRepository : IRepositoryBase<Fronteira>
    {
        Task<IEnumerable<Fronteira>> GetFronteiraCidade(int idCidade);
    }
}