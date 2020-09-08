using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pets.Domains;
using Pets.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {
        // chamar o repositório de petzinhos 
        TipoDePetRepository repositorio = new TipoDePetRepository();


        // GET: api/<TipoDePetController>
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return repositorio.LerTodos();
        }

        // GET api/<TipoDePetController>/5
        [HttpGet("{id}")]
        public TipoDePet Get(int id)
        {
            return repositorio.BuscarPorId(id);
        }

        // POST api/<TipoDePetController>
        [HttpPost]
        public TipoDePet Post([FromBody] TipoDePet b)
        {
            return repositorio.Cadastrar(b);
        }

        // PUT api/<TipoDePetController>/5
        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet b)
        {
            return repositorio.Alterar(id, b);
        }

        // DELETE api/<TipoDePetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repositorio.Excluir(id);
        }
    }
}
