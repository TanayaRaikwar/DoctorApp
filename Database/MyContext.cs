using DoctorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Database
{
    public class MyContext: DbContext
    {
       public DbSet<Doctor> Doctors { get; set; }
       public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
       public DbSet<Specialization> Specializations { get; set; }
       public DbSet<Surgery> Surgeries { get; set; }
       public MyContext(DbContextOptions<MyContext> options) :base(options)
       {

       }
    }
}