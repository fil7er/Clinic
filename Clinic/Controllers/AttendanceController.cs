using Clinic.Src.VO.Attendances;
using Clinic.Src.VO.Employers;
using Clinic.Src.VO.Peoples;
using Clinic.Src.VO.Procedures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private static List<Attendance> Attendances = new List<Attendance>
        {
                new Attendance { Id = 1, EmployerDoctor = new Employer{Id = 1}, EmployerAttendant = new Employer{ Id = 2 }, Date = DateTime.Parse("2022-03-31 17:00 PM"), People = new People{Id = 1 }, Procedure = new Procedure{ Id = 1 } },
                new Attendance { Id = 2, EmployerDoctor = new Employer{Id = 3}, EmployerAttendant = new Employer{ Id = 4 }, Date = DateTime.Parse("2022-03-31 17:00 PM"), People = new People{Id = 2 }, Procedure = new Procedure{ Id = 2 } }

        };

        [HttpGet]
        public async Task<ActionResult<Attendance>> Get()
        {

            return Ok(Attendances);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> Get(int id)
        {
            var Attendance = Attendances.Find(h => h.Id == id);
            if (Attendance == null) return BadRequest("Attendance Not found.");
            return Ok(Attendance);
        }

        [HttpPost]
        public async Task<ActionResult<Attendance>> Post(Attendance Attendance)
        {
            Attendances.Add(Attendance);
            return Ok(Attendances);
        }
        [HttpPut]
        public async Task<ActionResult<List<Attendance>>> Put(Attendance request)
        {
            var Attendance = Attendances.Find(h => h.Id == request.Id);
            if (Attendance == null) return BadRequest("Attendance Not found.");

            Attendance.Date = request.Date;
            Attendance.People.Id = request.People.Id;
            Attendance.Procedure.Id = request.Procedure.Id;
            Attendance.EmployerAttendant.Id = request.EmployerAttendant.Id;
            Attendance.EmployerDoctor.Id = request.EmployerDoctor.Id;

            return Ok(Attendances);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Attendance>>> Delete(int id)
        {
            var Attendance = Attendances.Find(h => h.Id == id);
            if (Attendance == null) return BadRequest("Attendance Not found.");
            Attendances.Remove(Attendance);
            return Ok(Attendances);
        }
    }
}
