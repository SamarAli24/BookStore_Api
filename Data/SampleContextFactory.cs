using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using BookShop.Db;

namespace BookShop.Data
{
    public class SampleContextFactory : IDesignTimeDbContextFactory<AppDbAccess>
    {
        public AppDbAccess CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbAccess>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("BookShop"));

            return new AppDbAccess(builder.Options);
        }
    }
}
