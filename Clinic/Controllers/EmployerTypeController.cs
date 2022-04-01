using Clinic.Src.VO.Employers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerTypeController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public EmployerTypeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployerType>>> Get()
        {

            return Ok(await _dataContext.EmployerType.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployerType>> Get(int id)
        {
            var employerType = await _dataContext.EmployerType.FindAsync(id);
            if (employerType == null) return BadRequest("Employer Type Not found.");
            return Ok(employerType);
        }

        [HttpPost]
        public async Task<ActionResult<EmployerType>> Post(EmployerType employerType)
        {


            _dataContext.EmployerType.Add(employerType);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.EmployerType.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<EmployerType>>> Put(EmployerType request)
        {
            var employerType = await _dataContext.EmployerType.FindAsync(request.Id);
            if (employerType == null) return BadRequest("Employer Type Not found.");

            employerType.Name = request.Name;

            return Ok(await _dataContext.EmployerType.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EmployerType>>> Delete(int id)
        {
            var EmployerType = await _dataContext.EmployerType.FindAsync(id);
            if (EmployerType == null) return BadRequest("Employer Type Not found.");
            _dataContext.EmployerType.Remove(EmployerType);
            return Ok(await _dataContext.EmployerType.ToListAsync());
        }
    }
}
