using Clinic.Src.VO.Peoples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public PeopleController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<People>>> Get()
        {

            return Ok(await _dataContext.People.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<People>> Get(int id)
        {
            var people = await _dataContext.People.FindAsync(id);
            if (people == null) return BadRequest("People Not found.");
            return Ok(people);
        }

        [HttpPost]
        public async Task<ActionResult<People>> Post(People people)
        {
            _dataContext.People.Add(people);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.People.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<People>>> Put(People request)
        {
            var people = await _dataContext.People.FindAsync(request.Id);
            if (people == null) return BadRequest("People Not found.");

            people.Name = request.Name;
            people.RG = request.RG;
            people.CPF = request.CPF;
            people.Address = request.Address;

            return Ok(await _dataContext.People.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<People>>> Delete(int id)
        {
            var People = await _dataContext.People.FindAsync(id);
            if (People == null) return BadRequest("People Not found.");
            _dataContext.People.Remove(People);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.People.ToListAsync());
        }
    }
}
