using Clinic.Src.VO.Employers;
using Clinic.Src.VO.Peoples;
using Clinic.Src.VO.Procedures;

namespace Clinic.Src.VO.Attendances
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public Attendance()
        {
            EmployerDoctor = new Employer(new EmployerType() { Id = 1});
            EmployerAttendant = new Employer(new EmployerType() { Id = 2 });
            People = new People();
            Procedure = new Procedure();
        }
        
        public  Employer EmployerDoctor { get; set; } 
        public  Employer EmployerAttendant { get; set; }
        public  People People { get; set; }
        public  Procedure Procedure { get; set; }
    }
}
