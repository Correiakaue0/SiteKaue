using Back.Models;
using Microsoft.EntityFrameworkCore;
using Store.Model;

namespace Store.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
    }
}
