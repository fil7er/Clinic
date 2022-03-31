using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Src.VO.Employer
{
    public class Employer
    {

        public Employer()
        {
            this.EmployerType = new EmployerType();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Enrollment { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        
   

        public virtual EmployerType EmployerType { get; set; }
    }
}
