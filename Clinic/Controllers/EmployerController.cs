using Clinic.Src.VO.Employer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private static List<Employer> employers = new List<Employer>
        {
                new Employer { Id = 1, Name = "First Employer", CPF ="123.123.123-23", Enrollment = 1, RG = "1231233-2", EmployerType = new EmployerType{ Id = 1, Name ="Doctor" }},
                new Employer { Id = 2, Name = "Second Employer", CPF ="123.123.123-24", Enrollment = 1, RG = "1231233-3", EmployerType = new EmployerType{ Id = 1, Name ="Doctor" }}

        };
   
        [HttpGet]
        public async Task<ActionResult<Employer>> Get()
        {
            
            return Ok(employers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> Get(int id)
        {
            var employer = employers.Find(h => h.Id == id);
            if (employer == null) return BadRequest("Employer Not found.");
            return Ok(employer);
        }

        [HttpPost]
        public async Task<ActionResult<Employer>> Post(Employer employer)
        {
            employers.Add(employer);
            return Ok(employers);
        }
        [HttpPut]
        public async Task<ActionResult<List<Employer>>> Put(Employer request)
        {
            var employer = employers.Find(h => h.Id == request.Id);
            if (employer == null) return BadRequest("Employer Not found.");

            employer.Name = request.Name;
            employer.RG = request.RG;
            employer.CPF = request.CPF;
            employer.Enrollment = request.Enrollment;
            employer.EmployerType.Id = request.EmployerType.Id;
            return Ok(employers);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employer>>> Delete(int id)
        {
            var employer = employers.Find(h => h.Id == id);
            if (employer == null) return BadRequest("Employer Not found.");
            employers.Remove(employer);
            return Ok(employers);
        }

    }
}
