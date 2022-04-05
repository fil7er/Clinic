using System.ComponentModel.DataAnnotations;

namespace Clinic.Src.VO.Peoples
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
    }
}
