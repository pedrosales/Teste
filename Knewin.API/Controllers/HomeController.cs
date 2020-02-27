using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Knewin.API.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using Knewin.API.Services;
using Knewin.Application.Interfaces;

namespace Knewin.Controllers
{
    [Route("v1/home")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody]UserModel model,
                                                       [FromServices] IUserService userService)
        {
            if(model == null)
                return Json( new { mensagem = "Usuário não informado" });

            var user = await userService.Login(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

    }
}