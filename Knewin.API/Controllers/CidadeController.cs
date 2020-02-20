using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Knewin.Domain.Entities;
using Knewin.Application.Interfaces;
using Knewin.API.Models;
using System.Linq;
using System;

namespace Knewin.Controllers
{
    [Route("v1/cidade")]
    [ApiController]
    [Authorize]
    public class CidadeController : Controller
    {
        // GET: api/values
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Cidade>> GetAll([FromServices] ICidadeService cidadeService)
        {
            return await cidadeService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Cidade> GetById([FromServices] ICidadeService cidadeService,
                                                        int id)
        {
            return await cidadeService.GetById(id);
        }

        [HttpGet]
        [Route("GetWithFronteiras/{id:int}")]
        [AllowAnonymous]
        public async Task<Cidade> GetByIdFronteira([FromServices] ICidadeService cidadeService, int id)
        {
            return await cidadeService.GetByIdFronteiras(id);
        }

        [HttpGet]
        [Route("GetByName")]
        [AllowAnonymous]
        public async Task<Cidade> GetByName([FromServices] ICidadeService cidadeService,
                                                        string nomeCidade)
        {
            return await cidadeService.GetByNameAsync(nomeCidade);
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
                            return BadRequest("Cidade fronteira não encontrada");
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
    }
}