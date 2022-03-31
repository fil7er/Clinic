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
            EmployerDoctor = new Employer() {EmployerType = new EmployerType {Id = 1 } };
            EmployerAttendant = new Employer() { EmployerType = new EmployerType { Id = 2 } };
            People = new People();
            Procedure = new Procedure();
        }
        
        public virtual Employer? EmployerDoctor { get; set; } 
        public virtual Employer? EmployerAttendant { get; set; }
        public virtual People? People { get; set; }
        public virtual Procedure? Procedure { get; set; }
    }
}
