using Clinic.Src.VO.Attendances;
using Clinic.Src.VO.Employers;
using Clinic.Src.VO.Peoples;
using Clinic.Src.VO.Procedures;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employer> Employer { get; set; }
        public DbSet<EmployerType> EmployerType { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<Attendance> Attendance { get; set; }

    }
}
