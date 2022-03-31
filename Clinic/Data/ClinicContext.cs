#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clinic.Src.VO.Employer;

namespace Clinic.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext (DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        public DbSet<Clinic.Src.VO.Employer.Employer> Employer { get; set; }

        public DbSet<Clinic.Src.VO.Employer.EmployerType> EmployerType { get; set; }
    }
}
