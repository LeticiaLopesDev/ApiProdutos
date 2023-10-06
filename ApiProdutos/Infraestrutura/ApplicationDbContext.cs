using ApiProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Infraestrutura
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port= 5433;" +
                "Database= projeto_extensao;" +
                "User Id=postgres;" +
                "Password=123;");
    }
}
