using Clinic.Src.VO.Procedures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProcedureController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Procedure>>> Get()
        {

            return Ok(await _dataContext.Procedure.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Procedure>> Get(int id)
        {
            var Procedure = await _dataContext.Procedure.FindAsync(id);
            if (Procedure == null) return BadRequest("Procedure Not found.");
            return Ok(Procedure);
        }

        [HttpPost]
        public async Task<ActionResult<List<Procedure>>> Post(Procedure Procedure)
        {
            _dataContext.Procedure.Add(Procedure);
            await _dataContext.SaveChangesAsync();
            return Ok(_dataContext.Procedure.ToList());
        }
        [HttpPut]
        public async Task<ActionResult<List<Procedure>>> Put(Procedure request)
        {
            var Procedure = await _dataContext.Procedure.FindAsync(request.Id);
            if (Procedure == null) return BadRequest("Procedure Not found.");

            Procedure.Decryption = request.Decryption;
            Procedure.Value = request.Value;

            return Ok(await _dataContext.Procedure.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Procedure>>> Delete(int id)
        {
            var Procedure = await _dataContext.Procedure.FindAsync(id);
            if (Procedure == null) return BadRequest("Procedure Not found.");
            _dataContext.Procedure.Remove(Procedure);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Procedure.ToListAsync());
        }
    }
}
