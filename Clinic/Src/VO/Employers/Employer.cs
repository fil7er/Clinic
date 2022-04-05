using System.ComponentModel.DataAnnotations;


namespace Clinic.Src.VO.Employers
{
    public class Employer
    {


        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Enrollment { get; set; } = 0;
        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public bool Active { get; set; } = false;


        [Required]
        public EmployerType EmployerType { get; set; } = new EmployerType();

    }
}
