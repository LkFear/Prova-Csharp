using Microsoft.EntityFrameworkCore;
using provaLeonardo.models;

namespace provaLeonardo.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

         public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Folha> Folhas { get; set; }
    }
}