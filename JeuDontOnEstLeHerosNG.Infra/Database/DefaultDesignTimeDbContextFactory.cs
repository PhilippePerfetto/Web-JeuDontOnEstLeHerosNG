using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHerosNG.Infra.Database
{
    /// <summary>
    /// dotnet ef migrations add CreateDatabase
    /// dotnet ef database update
    /// </summary>
    public class DefaultDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AventureDataContext>
    {
        public AventureDataContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder();

            var config = builder.Build();

            var connectionString = "Data Source=localhost;Initial Catalog=JeuDontOnEstLeHero.database.dev;Integrated Security=True;Pooling=False;"; // config.GetConnectionString("DefaultContext");

            DbContextOptionsBuilder<AventureDataContext> optionBuilder = new DbContextOptionsBuilder<AventureDataContext>();
            optionBuilder.UseSqlServer(connectionString);

            // return new AventureDataContext(optionBuilder.Options);
            // return new AventureDataContext(optionBuilder);
            return new AventureDataContext(config);
        }
    }
}
