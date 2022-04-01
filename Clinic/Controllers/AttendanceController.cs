using Clinic.Src.VO.Attendances;
using Clinic.Src.VO.Employers;
using Clinic.Src.VO.Peoples;
using Clinic.Src.VO.Procedures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AttendanceController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Attendance>>> Get()
        {

            return Ok(await _dataContext.Attendance.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> Get(int id)
        {
            var Attendance = await _dataContext.Attendance.FindAsync(id);
            if (Attendance == null) return BadRequest("Attendance Not found.");
            return Ok(Attendance);
        }

        [HttpPost]
        public async Task<ActionResult<List<Attendance>>> Post(Attendance Attendance)
        {
            Dictionary<string, Object> listObjects = new Dictionary<string, Object>();

            listObjects.Add("Doctor", await _dataContext.Employer.FindAsync(Attendance.EmployerDoctor.Id));
            listObjects.Add("Attendant", await _dataContext.Employer.FindAsync(Attendance.EmployerAttendant.Id));
            listObjects.Add("People", await _dataContext.Employer.FindAsync(Attendance.People.Id));
            listObjects.Add("Procedure", await _dataContext.Procedure.FindAsync(Attendance.Procedure.Id));

            foreach(KeyValuePair<string, Object> entry in listObjects)
            {
                if(entry.Value == null) return BadRequest($"{entry.Key} not Found.");
            }

      


            _dataContext.Attendance.Add(Attendance);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Attendance.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Attendance>>> Put(Attendance request)
        {
            var Attendance = await _dataContext.Attendance.FindAsync(request.Id);
            if (Attendance == null) return BadRequest("Attendance Not found.");

            Attendance.Date = request.Date;
            Attendance.People.Id = request.People.Id;
            Attendance.Procedure.Id = request.Procedure.Id;
            Attendance.EmployerAttendant.Id = request.EmployerAttendant.Id;
            Attendance.EmployerDoctor.Id = request.EmployerDoctor.Id;

            return Ok(await _dataContext.Attendance.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Attendance>>> Delete(int id)
        {
            var Attendance = await _dataContext.Attendance.FindAsync(id);
            if (Attendance == null) return BadRequest("Attendance Not found.");
            _dataContext.Attendance.Remove(Attendance);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Attendance.ToListAsync());
        }
    }
}
