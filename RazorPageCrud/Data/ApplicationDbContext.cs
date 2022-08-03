using Microsoft.EntityFrameworkCore;
using RazorPageCrud.Model;

namespace RazorPageCrud.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
      public DbSet<Catagory> CatagoryList { get; set; }
    }
}
