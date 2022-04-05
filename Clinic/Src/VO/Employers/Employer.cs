using System.ComponentModel.DataAnnotations;


namespace Clinic.Src.VO.Employers
{
    public class Employer
    {



        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Enrollment { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public bool? Active { get; set; }
        
   
        [Required]
        public EmployerType EmployerType { get; set; }

        public Employer(EmployerType employerType)
        {
            EmployerType = employerType;
        }
    }
}
