using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;
using Knewin.Infra.Data.Context;

namespace Knewin.Infra.Data.Repositories
{
    public class FronteiraRepository : RepositoryBase<Fronteira>, IFronteiraRepository
    {
        private readonly KnewinContext _context;
        public FronteiraRepository(KnewinContext context) : base(context)
        {
            _context = context;
        }
    }
}
