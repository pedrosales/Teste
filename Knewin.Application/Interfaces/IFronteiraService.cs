using System.Collections.Generic;
using System.Threading.Tasks;
using Knewin.Domain.Entities;

namespace Knewin.Application.Interfaces
{
    public interface IFronteiraService : IServiceBase<Fronteira>
    {
        Task<IEnumerable<Fronteira>> GetFronteiraCidade(int idCidade);
    }
}
