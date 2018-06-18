using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APICore.Controllers
{
    /// <summary>
    /// Controller para Valores
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Método para obter todos os valores disponíveis
        /// </summary>
        /// <returns>
        /// Retorna todos os valores
        /// </returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Método para obter um valor específico
        /// </summary>
        /// <param name="id">Id do valor que será obtido</param>
        /// <returns>
        /// Retorna o valor de acordo com o Id informado
        /// </returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Método para publicar um valor de acordo com o parâmetro
        /// </summary>
        /// <param name="value">
        /// Valor que deve ser publicado
        /// </param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
    }
}
