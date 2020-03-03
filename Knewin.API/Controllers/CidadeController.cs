using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Knewin.Domain.Entities;
using Knewin.Application.Interfaces;
using Knewin.API.Models;
using System.Linq;
using System;
using AutoMapper;
using Knewin.API.ViewModels.CidadeViewModel;

namespace Knewin.Controllers
{
    [Route("v1/cidade")]
    [ApiController]
    [Authorize]
    public class CidadeController : Controller
    {
        private readonly IMapper _mapper;

        public CidadeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: api/values
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CidadeViewModel>> GetAll([FromServices] ICidadeService cidadeService)
        {
            var cidades = _mapper.Map<IEnumerable<CidadeViewModel>>(await cidadeService.GetAllFronteira());
            return cidades;
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<CidadeViewModel> GetByIdFronteira([FromServices] ICidadeService cidadeService, int id)
        {
            return _mapper.Map<CidadeViewModel>(await cidadeService.GetByIdFronteiras(id));
        }

        [HttpGet]
        [Route("GetByName")]
        [AllowAnonymous]
        public async Task<CidadeViewModel> GetByName([FromServices] ICidadeService cidadeService,
                                                        string nomeCidade)
        {
            return _mapper.Map<CidadeViewModel>(await cidadeService.GetByNameAsync(nomeCidade));
        }

        // POST api/values
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]CidadeModel value, [FromServices] ICidadeService cidadeService)
        {
            if (value != null)
            {
                var cidadesFronteira = new List<Cidade>();

                if (value.Fronteiras != null && value.Fronteiras.Any())
                {
                    foreach (var cidade in value.Fronteiras)
                    {
                        var cidadeFronteira = await cidadeService.GetById(cidade);
                        if (cidadeFronteira == null)
                        {
                            return NotFound("Cidade fronteira não encontrada");
                        }

                        cidadesFronteira.Add(cidadeFronteira);
                    }
                }

                var novaCidade = await cidadeService.Add(new Cidade
                {
                    Habitantes = value.Habitantes,
                    Nome = value.Nome,
                    Fronteiras = cidadesFronteira
                });
            }
            return Ok();
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Put(int id, [FromBody]Cidade cidade, [FromServices]ICidadeService cidadeService)
        {
            if (cidade == null || id != cidade.Id)
            {
                return BadRequest();
            }

            await cidadeService.Update(cidade);

            return Ok();
        }

        [HttpPost]
        [Route("TotalHabitantes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTotalHabitantes(int[] listaInteiros, [FromServices] ICidadeService cidadeService)
        {

            if (listaInteiros == null || listaInteiros.Length == 0)
            {
                return BadRequest();
            }

            var total = await cidadeService.GetTotalHabitantes(listaInteiros);
            return Ok(total);
        }
    }
}