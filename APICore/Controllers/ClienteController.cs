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

        /// <summary>
        /// Atualiza o cliente informado no parâmetro
        /// </summary>
        /// <param name="clienteRequest">Informações para atualizar o cliente</param>
        /// <returns>
        /// Retorna o response do cliente atualizado
        /// </returns>
        /// <response code="200">Cliente Atualizado</response>
        /// <response code="404">Não foi possível encontrar um cliente com o Id informado</response>
        /// <response code="500">Erro no servidor</response>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Atualizar(ClienteRequest clienteRequest)
        {
            if (clienteRequest.Id != Guid.Empty)
                return Ok(new ClienteResponse()); 
            else
                return NotFound();
        }
    }

    public class ClienteRequest
    {
        /// <summary>
        /// Id do cliente que será atualizado
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do cliente
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Data de nascimento do cliente
        /// </summary>
        public DateTime DataNascimento { get; set; }
    }

    public class ClienteResponse
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}