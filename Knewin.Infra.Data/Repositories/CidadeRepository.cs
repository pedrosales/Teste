using System.Collections.Generic;
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

        public async Task<IEnumerable<Cidade>> GetAllFronteira()
        {
            var cidades = await _context.Cidades.Include(c => c.Fronteiras).ToListAsync();

            return cidades;
        }
        public async Task<Cidade> GetByIdFronteiras(int id)
        {
            var cidade = await _context.Cidades.Include(x => x.Fronteiras).ThenInclude(x => x.Fronteiras)
                                                .FirstOrDefaultAsync(x => x.Id == id);

            return cidade;
        }

        public async Task<Cidade> GetByNameAsync(string nomeCidade)
        {
            var cidade = await _context.Cidades.FirstOrDefaultAsync(x => x.Nome.ToLower().Trim().Equals(nomeCidade.ToLower().Trim()));

            return cidade;
        }

        public async Task<double> GetTotalHabitantes(int[] cidades)
        {
            double totalHabitantes = 0;

            for (int i = 0; i < cidades.Length; i++)
            {
                var cidade = await _context.Cidades.FirstOrDefaultAsync(c => c.Id == cidades[i]);
                if (cidade != null)
                {
                    totalHabitantes += cidade.Habitantes;
                }
            }

            return totalHabitantes;
        }
    }
}
