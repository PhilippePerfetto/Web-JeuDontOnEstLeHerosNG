namespace JeuDontOnEstLeHerosNG.Infra.Database;

using JeuDontOnEstLeHerosNG.Data.Models;
using JeuDontOnEstLeHerosNG.Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AventureDataContext : DataContext
{
    public AventureDataContext(IConfiguration configuration)
        :base(configuration)
    {
    }

    public DbSet<Aventure> Aventures => Set<Aventure>();
    public DbSet<Paragraphe> Paragraphes => Set<Paragraphe>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Reponse> Reponses => Set<Reponse>();
}