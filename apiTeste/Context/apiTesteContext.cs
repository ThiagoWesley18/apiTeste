using apiTeste.Model;
using Microsoft.EntityFrameworkCore;

namespace apiTeste.Context
{
    public class apiTesteContext : DbContext
    {
        public apiTesteContext(DbContextOptions<apiTesteContext> options) : base(options) 
        { 

        }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; } 
    }
}
