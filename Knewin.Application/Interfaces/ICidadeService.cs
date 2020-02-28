using System.Collections.Generic;
using System.Threading.Tasks;
using Knewin.Domain.Entities;

namespace Knewin.Application.Interfaces
{
    public interface ICidadeService : IServiceBase<Cidade>
    {
        Task<IEnumerable<Cidade>> GetAllFronteira();
        Task<Cidade> GetByNameAsync(string nomeCidade);
        Task<Cidade> GetByIdFronteiras(int id);
        Task<double> GetTotalHabitantes(int[] cidades);
    }
}
