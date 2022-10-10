namespace JeuDontOnEstLeHerosNG.Infra.Database;

using JeuDontOnEstLeHerosNG.Infra.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

public class IdentityDataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    //public DbSet<IdentityUserLogin<string>> IdentityUserLogin => Set<IdentityUserLogin<string>>();
    //public DbSet<IdentityUser<string>> IdentityUser => Set<IdentityUser<string>>();

    public IdentityDataContext(DbContextOptions options)
        :base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // in memory database used for simplicity, change to a real db for production applications
        // options.UseInMemoryDatabase("TestDb");
        // Data Source=localhost;Initial Catalog=JeuDontOnEstLeHero.database.dev;Integrated Security=True;Pooling=False
        var conn = new SqlConnection("Data Source=localhost;Initial Catalog=JeuDontOnEstLeHero.database.dev;Integrated Security=True;Pooling=False;"); // User ID=lmcomdatatest;Password=lmcomdatatest;
        options.UseSqlServer(conn);
    }
}