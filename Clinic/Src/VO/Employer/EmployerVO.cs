namespace Clinic.Src.VO.Employer
{
    public class EmployerVO
    {
        public int Id { get; set; }
        public string? Name { get; set; } 
        public int Enrollment { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        private EmployerTypeVO employerType;

        public EmployerVO(EmployerTypeVO employerType)
        {
            this.employerType = employerType;
        }

        public EmployerTypeVO EmployerType 
        { 
            get 
            { 
                return this.employerType; 
            } 
            set 
            {

                this.employerType = value; 
            }
        }
    }
}
