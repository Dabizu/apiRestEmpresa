using apirest.model;
using Microsoft.EntityFrameworkCore;

namespace apirest.context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options):base(options){ }
        public DbSet<Usuario> Usuarios { get; set; }
        /*
        //si no queremos que salga la "s" especificamos el nombre de nuestra tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
        }*/
    }
}
