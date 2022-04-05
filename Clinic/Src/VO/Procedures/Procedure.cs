using System.ComponentModel.DataAnnotations;

namespace Clinic.Src.VO.Procedures
{
    public class Procedure
    {
        [Key]
        public int Id { get; set; }
        public string Decryption { get; set; } = string.Empty;
        public double Value { get; set; } = 0;
    }
}
