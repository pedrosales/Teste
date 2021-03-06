using System.Collections.Generic;
using System.Threading.Tasks;
using Knewin.Domain.Entities;

namespace Knewin.Domain.Interfaces.Repositories
{
    public interface ICidadeRepository : IRepositoryBase<Cidade>
    {
        Task<IEnumerable<Cidade>> GetAllFronteira();
        Task<Cidade> GetByNameAsync(string nomeCidade);
        Task<Cidade> GetByIdFronteiras(int id);
        Task<double> GetTotalHabitantes(int[] cidades);
    }
}