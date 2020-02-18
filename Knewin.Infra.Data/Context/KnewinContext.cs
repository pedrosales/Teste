using Microsoft.EntityFrameworkCore;
using Knewin.Domain.Entities;

namespace Knewin.Infra.Data.Context
{
    public sealed class KnewinContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }

        public KnewinContext(DbContextOptions<KnewinContext> options) 
            : base (options)
        {

        }
    }
}