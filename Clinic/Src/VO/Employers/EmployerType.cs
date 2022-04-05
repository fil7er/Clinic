using System.ComponentModel.DataAnnotations;

namespace Clinic.Src.VO.Employers
{
    public class EmployerType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
