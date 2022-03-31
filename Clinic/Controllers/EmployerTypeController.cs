using Clinic.Src.VO.Employers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerTypeController : ControllerBase
    {
        private static List<EmployerType> EmployerTypes = new List<EmployerType>
        {
                new EmployerType { Id = 1, Name = "Doctor"},
                new EmployerType { Id = 2, Name = "Attendant"}

        };

        [HttpGet]
        public async Task<ActionResult<EmployerType>> Get()
        {

            return Ok(EmployerTypes);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerType>> Get(int id)
        {
            var EmployerType = EmployerTypes.Find(h => h.Id == id);
            if (EmployerType == null) return BadRequest("Employer Type Not found.");
            return Ok(EmployerType);
        }

        [HttpPost]
        public async Task<ActionResult<EmployerType>> Post(EmployerType EmployerType)
        {
            EmployerTypes.Add(EmployerType);
            return Ok(EmployerTypes);
        }
        [HttpPut]
        public async Task<ActionResult<List<EmployerType>>> Put(EmployerType request)
        {
            var EmployerType = EmployerTypes.Find(h => h.Id == request.Id);
            if (EmployerType == null) return BadRequest("Employer Type Not found.");

            EmployerType.Name = request.Name;

            return Ok(EmployerTypes);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EmployerType>>> Delete(int id)
        {
            var EmployerType = EmployerTypes.Find(h => h.Id == id);
            if (EmployerType == null) return BadRequest("Employer Type Not found.");
            EmployerTypes.Remove(EmployerType);
            return Ok(EmployerTypes);
        }
    }
}
