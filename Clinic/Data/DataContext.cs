using Clinic.Src.VO.Employer;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employer> Employers { get; set; }
    }
}
