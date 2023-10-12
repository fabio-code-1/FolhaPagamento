using Microsoft.EntityFrameworkCore;
using FolhaPagamento.Models;

namespace FolhaPagamento.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<FolhaPagamento.Models.Feria>? Feria { get; set; }


    }
}
