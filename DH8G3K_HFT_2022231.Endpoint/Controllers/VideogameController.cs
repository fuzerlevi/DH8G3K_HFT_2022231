using DH8G3K_HFT_2022231.Logic;
using DH8G3K_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DH8G3K_HFT_2022231.Endpoint.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class VideogameController : ControllerBase
    {
        IVideogameLogic logic;

        public VideogameController(IVideogameLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<VideogameController>
        [HttpGet]
        public IEnumerable<Videogame> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<VideogameController>/5
        [HttpGet("{id}")]
        public Videogame Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<VideogameController>
        [HttpPost]
        public void Create([FromBody] Videogame value)
        {
            this.logic.Create(value);
        }

        // PUT api/<VideogameController>/5
        [HttpPut]
        public void Update([FromBody] Videogame value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<VideogameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
