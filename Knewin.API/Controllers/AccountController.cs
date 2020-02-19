using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knewin.API.Models;
using Knewin.Application.Interfaces;
using Knewin.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knewin.API.Controllers
{

    [Route("v1/account")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromBody] UserModel model,
                                 [FromServices] IUserService userService)
        {
            if (model == null)
            {
                new ArgumentNullException("Usuário não informado");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role
                };
                var usuario = userService.Add(user);
                return Json(new { success = true, usuario });
            }

            return BadRequest("Erro");
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<User>> GetAllAsync([FromServices] IUserService userService) => await userService.GetAll();
    }
}