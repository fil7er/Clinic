using Clinic.Src.VO.Employers;
using Clinic.Src.VO.Peoples;
using Clinic.Src.VO.Procedures;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Src.VO.Attendances
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
        [Required]
        public Employer EmployerDoctor { get; set; } = new Employer() { EmployerType = new EmployerType() { Id = 1 } };
        [Required]
        public Employer EmployerAttendant { get; set; } = new Employer() {EmployerType = new EmployerType() { Id = 2 } };
        [Required]
        public People People { get; set; } = new People();
        [Required]
        public Procedure Procedure { get; set; } = new Procedure();
    }
}
