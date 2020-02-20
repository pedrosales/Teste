using Knewin.Application.Interfaces;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;

namespace Knewin.Application.Services
{
    public class FronteiraService : ServiceBase<Fronteira>, IFronteiraService
    {
        private readonly IFronteiraRepository _fronteiraRepository;
        public FronteiraService(IRepositoryBase<Fronteira> repository, IFronteiraRepository fronteiraRepository) : base(repository)
        {
            _fronteiraRepository = fronteiraRepository;
        }
    }
}
