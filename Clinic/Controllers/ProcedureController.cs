using Clinic.Src.VO.Procedures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private static List<Procedure> Procedures = new List<Procedure>
        {
                new Procedure { Id = 1, Decryption = "First Procedure", Value = 25.6},
                new Procedure { Id = 2, Decryption = "Second Procedure", Value = 23.87}

        };

        [HttpGet]
        public async Task<ActionResult<Procedure>> Get()
        {

            return Ok(Procedures);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Procedure>> Get(int id)
        {
            var Procedure = Procedures.Find(h => h.Id == id);
            if (Procedure == null) return BadRequest("Procedure Not found.");
            return Ok(Procedure);
        }

        [HttpPost]
        public async Task<ActionResult<Procedure>> Post(Procedure Procedure)
        {
            Procedures.Add(Procedure);
            return Ok(Procedures);
        }
        [HttpPut]
        public async Task<ActionResult<List<Procedure>>> Put(Procedure request)
        {
            var Procedure = Procedures.Find(h => h.Id == request.Id);
            if (Procedure == null) return BadRequest("Procedure Not found.");

            Procedure.Decryption = request.Decryption;
            Procedure.Value = request.Value;

            return Ok(Procedures);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Procedure>>> Delete(int id)
        {
            var Procedure = Procedures.Find(h => h.Id == id);
            if (Procedure == null) return BadRequest("Procedure Not found.");
            Procedures.Remove(Procedure);
            return Ok(Procedures);
        }
    }
}
