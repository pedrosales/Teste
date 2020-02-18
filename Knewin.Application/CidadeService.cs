using Knewin.Application.Interfaces;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;

namespace Knewin.Application
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {

        public CidadeService(IRepositoryBase<Cidade> repository) : base(repository)
        {

        }
    }
}
