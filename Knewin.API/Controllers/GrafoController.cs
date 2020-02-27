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
        public ActionResult ShortPath([FromServices] ICidadeService cidadeService, [FromServices] IFronteiraService fronteiraService, int inicio, int final)
        {
            var cidadeInicio = cidadeService.GetById(inicio).Result;
            if (cidadeInicio == null)
            {
                return NotFound(new { success = false, msg = "Cidade inicial não informada"});
            }

            var cidadeFim = cidadeService.GetById(final).Result;
            if (cidadeInicio == null)
            {
                return NotFound(new { success = false, msg = "Cidade final não informada"});
            }

            var vertices = cidadeService.GetAll().Result.ToArray();
            var fronteiras = fronteiraService.GetAll().Result.ToArray();
            var edges = new List<Tuple<Cidade, Cidade>>();

            foreach (var fronteira in fronteiras)
            {
                var cidade1 = cidadeService.GetById(fronteira.Cidade1);
                var cidade2 = cidadeService.GetById(fronteira.Cidade2);
                edges.Add(Tuple.Create(cidade1.Result, cidade2.Result));
            }
            
            // var grafo = new Graph<int>(vertices, edges.ToArray());
            var grapho = new Graph<Cidade>(vertices, edges);
            var menorCaminho = BuscaMenorCaminho.ShortestPathFunction(grapho, cidadeInicio);
            // var menorCaminho = BuscaMenorCaminho.ShortestPathFunction(grafo, inicio);
            return Json(new { result = menorCaminho(cidadeFim) });
            // return Json(new { result = menorCaminho(final) });
        }
    }
}