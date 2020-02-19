using System.Threading.Tasks;
using Knewin.Application.Interfaces;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;

namespace Knewin.Application.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepositoy;
        public CidadeService(IRepositoryBase<Cidade> repository, ICidadeRepository cidadeRepository) : base(repository)
        {
            _cidadeRepositoy = cidadeRepository;
        }

        public async Task<Cidade> GetByNameAsync(string nomeCidade)
        {
            var cidade = await _cidadeRepositoy.GetByNameAsync(nomeCidade);

            return cidade;
        }   
    }
}
