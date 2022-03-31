using Clinic.Src.VO.Employers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {

        private readonly DataContext _dataContext;
        public EmployerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpGet]
        public async Task<ActionResult<List<Employer>>> Get()
        {
            
            return Ok(await _dataContext.Employer.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> Get(int id)
        {
            var employer = await _dataContext.Employer.FindAsync(id);
            if (employer == null) return BadRequest("Employer Not found.");
            return Ok(employer);
        }

        [HttpPost]
        public async Task<ActionResult<Employer>> Post(Employer employer)
        {
            var employerType = await _dataContext.EmployerType.FindAsync(employer.EmployerType.Id);

            employer.EmployerType = employerType;

            _dataContext.Employer.Add(employer);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Employer.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Employer>>> Put(Employer request)
        {
            var employer = await _dataContext.Employer.FindAsync(request.Id);

            if (employer == null) return BadRequest("Employer Not found.");

            employer.Name = request.Name;
            employer.RG = request.RG;
            employer.CPF = request.CPF;
            employer.Enrollment = request.Enrollment;
            employer.EmployerType = await _dataContext.EmployerType.FindAsync(request.EmployerType.Id);
            employer.Active = request.Active;
            return Ok(await _dataContext.Employer.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employer>>> Delete(int id)
        {
            var employer = await _dataContext.Employer.FindAsync(id);
            if (employer == null) return BadRequest("Employer Not found.");
            _dataContext.Employer.Remove(employer);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Employer.ToListAsync());
        }

    }
}
