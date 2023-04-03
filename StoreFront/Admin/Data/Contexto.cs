using Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Admin.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
