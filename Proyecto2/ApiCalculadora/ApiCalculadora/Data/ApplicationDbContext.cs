using System.Data.Entity;
using ApiCalculadora.Models;

namespace ApiCalculadora.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            // Deshabilitar el inicializador de base de datos
            // Esto evita que Entity Framework intente crear/modificar la BD
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        // Representa la tabla "Calculos" en tu base de datos
        public DbSet<Calculo> Calculos { get; set; }

        // Configurar el mapeo de la tabla
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mapear el modelo Calculo a la tabla Calculos
            modelBuilder.Entity<Calculo>().ToTable("Calculos");

            base.OnModelCreating(modelBuilder);
        }
    }
}