using Microsoft.EntityFrameworkCore;
using TodoCoreList.Data.Entities;

namespace TodoCoreList.Data.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base()
        {

        }
        public DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=TodoCoreList;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
