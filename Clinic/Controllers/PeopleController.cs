using Clinic.Src.VO.Peoples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static List<People> Peoples = new List<People>
        {
                new People { Id = 1, Name = "First People", CPF ="223.123.123-23", RG = "1231233-2", Address="Street Nowhere"},
                new People { Id = 2, Name = "Second People", CPF ="223.123.123-24", RG = "1231233-3", Address="Street Other"}

        };

        [HttpGet]
        public async Task<ActionResult<People>> Get()
        {

            return Ok(Peoples);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<People>> Get(int id)
        {
            var People = Peoples.Find(h => h.Id == id);
            if (People == null) return BadRequest("People Not found.");
            return Ok(People);
        }

        [HttpPost]
        public async Task<ActionResult<People>> Post(People People)
        {
            Peoples.Add(People);
            return Ok(Peoples);
        }
        [HttpPut]
        public async Task<ActionResult<List<People>>> Put(People request)
        {
            var People = Peoples.Find(h => h.Id == request.Id);
            if (People == null) return BadRequest("People Not found.");

            People.Name = request.Name;
            People.RG = request.RG;
            People.CPF = request.CPF;
            People.Address = request.Address;

            return Ok(Peoples);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<People>>> Delete(int id)
        {
            var People = Peoples.Find(h => h.Id == id);
            if (People == null) return BadRequest("People Not found.");
            Peoples.Remove(People);
            return Ok(Peoples);
        }
    }
}
