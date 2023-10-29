using Microsoft.EntityFrameworkCore;
using Proyecto1_Progra5.Models;
using System.Collections.Generic;

namespace Proyecto1_Progra5.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<ElementosCarrito> ElementosCarritos { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
