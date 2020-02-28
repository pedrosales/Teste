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
    [Route("v1/fronteira")]
    [ApiController]
    [AllowAnonymous]
    public class FronteiraController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<Fronteira>> GetAll([FromServices] IFronteiraService fronteiraService)
        {
            return await fronteiraService.GetAll();
        }
    }
}