using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration["ConnectionString"];
            if (connectionString == null)
            {
                throw new Exception("Connection string is null");
            }
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            dbContextOptionsBuilder.UseNpgsql(connectionString);
            //dbContextOptionsBuilder.UseNpgsql(connectionString, opt => opt.MigrationsAssembly("DataAccess.EntityFramework"));
            return new DatabaseContext(dbContextOptionsBuilder.Options);
        }
    }
}
