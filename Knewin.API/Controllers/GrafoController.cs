using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Knewin.Domain.Entities;
using Knewin.Application.Interfaces;
using Knewin.API.Models;
using System.Linq;
using System;
using Knewin.Application.GrafoHelper;

namespace Knewin.Controllers
{
    [Route("v1/grapho")]
    [ApiController]
    [Authorize]
    public class GrafoController : Controller
    {
        // GET: api/values
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShortPath([FromServices] ICidadeService cidadeService, [FromServices] IFronteiraService fronteiraService, int inicio, int final)
        {
            var vertices = cidadeService.GetAll().Result.Select(x => x.Id).ToArray();
            var fronteiras = fronteiraService.GetAll().Result.ToArray();
            var edges = new List<Tuple<int, int>>();

            foreach (var fronteira in fronteiras)
            {
                edges.Add(Tuple.Create(fronteira.Cidade1, fronteira.Cidade2));
            }

            var grafo = new Graph<int>(vertices, edges.ToArray());

            var menorCaminho = BuscaMenorCaminho.ShortestPathFunction(grafo, inicio);

            return Json(new { result = menorCaminho(final) });
        }
    }
}