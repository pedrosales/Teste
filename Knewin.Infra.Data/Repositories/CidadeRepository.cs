using System.Threading.Tasks;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Knewin.Infra.Data.Repositories
{
    public class CidadeRepository : RepositoryBase<Cidade>, ICidadeRepository
    {
        private readonly KnewinContext _context;
        public CidadeRepository(KnewinContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cidade> GetByNameAsync(string nomeCidade)
        {
            var cidade = await _context.Cidades.FirstOrDefaultAsync(x => x.Nome.Equals(nomeCidade));

            return cidade;
        }
    }
}
