using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knewin.Application.Interfaces;
using Knewin.Domain.Entities;
using Knewin.Domain.Interfaces.Repositories;

namespace Knewin.Application.Services
{
    public class CidadeService : ServiceBase<Cidade>, ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepositoy;
        private readonly IFronteiraService _fronteiraService;
        public CidadeService(IRepositoryBase<Cidade> repository, ICidadeRepository cidadeRepository, 
                                IFronteiraService fronteiraService) : base(repository)
        {
            _cidadeRepositoy = cidadeRepository;
            _fronteiraService = fronteiraService;
        }

        public async Task<IEnumerable<Cidade>> GetAllFronteira()
        {
            var cidades = await _cidadeRepositoy.GetAllFronteira();

            foreach (var cidade in cidades)
            {
                var fronteiras = await _fronteiraService.GetFronteiraCidade(cidade.Id);
                var cidadesFronteiras = new List<Cidade>();

                foreach (var fronteira in fronteiras)
                {
                    cidade.Fronteiras.Add(_cidadeRepositoy.GetById(fronteira.Cidade2).Result);
                }
            }

            return await _cidadeRepositoy.GetAllFronteira();
        }
        public async Task<Cidade> GetByIdFronteiras(int id)
        {
            var cidade = await _cidadeRepositoy.GetByIdFronteiras(id);
            var fronteiras = await _fronteiraService.GetFronteiraCidade(cidade.Id);

            foreach (var fronteira in fronteiras)
            {
                cidade.Fronteiras.Add(_cidadeRepositoy.GetById(fronteira.Cidade2).Result);
            }

            return cidade;
        }

        public async Task<Cidade> GetByNameAsync(string nomeCidade)
        {
            var cidade = await _cidadeRepositoy.GetByNameAsync(nomeCidade);

            var fronteiras = await _fronteiraService.GetFronteiraCidade(cidade.Id);

            foreach (var fronteira in fronteiras)
            {
                cidade.Fronteiras.Add(_cidadeRepositoy.GetById(fronteira.Cidade2).Result);
            }

            return cidade;
        }

        public async Task<double> GetTotalHabitantes(int[] cidades)
        {
           return await _cidadeRepositoy.GetTotalHabitantes(cidades);
        }
    }
}
