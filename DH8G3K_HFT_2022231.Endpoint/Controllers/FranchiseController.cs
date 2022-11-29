using DH8G3K_HFT_2022231.Logic;
using DH8G3K_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DH8G3K_HFT_2022231.Endpoint.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        IFranchiseLogic logic;

        public FranchiseController(IFranchiseLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<FranchiseController>
        [HttpGet]
        public IEnumerable<Franchise> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<FranchiseController>/5
        [HttpGet("{id}")]
        public Franchise Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<FranchiseController>
        [HttpPost]
        public void Create([FromBody] Franchise value)
        {
            this.logic.Create(value);
        }

        // PUT api/<FranchiseController>/5
        [HttpPut]
        public void Update([FromBody] Franchise value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<FranchiseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
