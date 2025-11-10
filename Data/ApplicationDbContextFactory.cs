using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FlixUp.API.Data;

namespace FlixUp.API.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Configuração para SQLite
            const string connectionString = "Data Source=FlixUp.db";

            optionsBuilder.UseSqlite(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
