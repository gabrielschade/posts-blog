using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICore.Controllers
{
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        /// <summary>
        /// Método para obter o Id do cliente por CPF
        /// </summary>
        /// <returns>
        /// Retorna o Id do cliente
        /// </returns>
        [HttpGet]
        public Guid ObterId(string CPF)
        => Guid.NewGuid();
    }
}