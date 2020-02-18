using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Knewin.Domain.Entities;
using Knewin.Application.Interfaces;

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

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Cidade value, [FromServices] ICidadeService cidadeService)
        {
            if (value != null)
            {
                await cidadeService.Add(new Cidade
                {
                    Habitantes = value.Habitantes,
                    Nome = value.Nome
                });
            }
        }
    }
}