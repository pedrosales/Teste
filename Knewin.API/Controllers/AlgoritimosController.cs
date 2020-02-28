using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knewin.API.Controllers
{

    [Route("v1/algoritimos")]
    [ApiController]
    [AllowAnonymous]
    public class AlgoritimosController : Controller
    {
        [HttpPost]
        [Route("Duplicated")]
        public ActionResult GetIndexDuplicated(int[] listaInteiros)
        {

            if (listaInteiros == null || listaInteiros.Length == 0)
            {
                return Json(new { duplicado = false, index = 0 });
            }

            var duplicates = listaInteiros
                    .Select((t, j) => new { Index = j, Text = t })
                    .GroupBy(g => g.Text)
                    .Where(g => g.Count() > 1);

            return Json(new { duplicado = duplicates });
        }

        [HttpPost]
        [Route("Palindromo")]
        public ActionResult IsPalindromo(string valor)
        {

            if (string.IsNullOrEmpty(valor))
            {
                return Json(new { Palindromo = false });
            }

            var newString = new string(valor.Reverse().ToArray());

            return Json(new { Palindromo = newString == valor });
        }
    }
}