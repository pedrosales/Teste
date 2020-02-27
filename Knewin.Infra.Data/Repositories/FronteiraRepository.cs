using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Knewin.Infra.Data.Repositories
{
    public class FronteiraRepository : RepositoryBase<Fronteira>, IFronteiraRepository
    {
        private readonly KnewinContext _context;
        public FronteiraRepository(KnewinContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fronteira>> GetFronteiraCidade(int idCidade)
        {
            var fronteiras = await _context.Fronteiras.Where(f => f.Cidade1 == idCidade).ToListAsync();

            return fronteiras;
        }
    }
}
