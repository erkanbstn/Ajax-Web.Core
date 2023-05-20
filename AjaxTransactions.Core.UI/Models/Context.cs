using Microsoft.EntityFrameworkCore;

namespace AjaxTransactions.Core.UI.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AjaxTest;Integrated Security=True;MultipleActiveResultSets=True;");
        }
        public DbSet<Product> Products { get; set; }

    }
}
