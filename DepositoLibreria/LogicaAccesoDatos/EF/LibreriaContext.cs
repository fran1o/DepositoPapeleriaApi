using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace DepositoLibreria.LogicaAccesoDatos.EF
{
    public class LibreriaContext : DbContext
    {
        //Nombre de las tablas

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<TipoMovimiento> TiposMovimientos { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }

        //Conectarse a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=libreria;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //EMAIL UNICO
            modelBuilder.Entity<Usuario>()
                        .HasIndex(u => u.Email)
                        .IsUnique();


            //NOMBRE UNICO PARA TIPOS DE MOVIMIENTOS
            modelBuilder.Entity<TipoMovimiento>()
                        .HasIndex(t => t.Nombre)
                        .IsUnique();

            var nombreConvert = new ValueConverter<Nombre, string>(
                v => v.Value,
            v => new Nombre(v)
                );


            modelBuilder.Entity<Usuario>().Property(a => a.Nombre).HasConversion(nombreConvert);
            modelBuilder.Entity<Usuario>().HasIndex(a => a.Nombre).IsUnique();

            modelBuilder.Entity<Articulo>().Property(a => a.NombreArt).HasConversion(nombreConvert);
            modelBuilder.Entity<Articulo>().HasIndex(a => a.NombreArt).IsUnique();

        }


    }
}
