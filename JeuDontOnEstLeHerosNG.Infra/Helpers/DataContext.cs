namespace JeuDontOnEstLeHerosNG.Infra.Helpers;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public abstract class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
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