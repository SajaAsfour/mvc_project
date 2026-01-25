using KASHOP.Models;
using Microsoft.EntityFrameworkCore;

namespace KASHOP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> categories   { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //DataBase for deployment (production)
            optionsBuilder.UseSqlServer("Server=db38750.public.databaseasp.net; Database=db38750; User Id=db38750; Password=b_2LXa%3#5yT; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True; ");

            //DataBase for development
            //optionsBuilder.UseSqlServer("Data Source=.;DataBase=mvcProject;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
    }
}
