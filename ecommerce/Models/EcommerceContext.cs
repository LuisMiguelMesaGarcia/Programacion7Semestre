using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ecommerce.Models
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarritoCompra> CarritoCompras { get; set; } = null!;
        public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<ModuloPermiso> ModuloPermisos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Publicidad> Publicidads { get; set; } = null!;
        public virtual DbSet<ResgitroLogin> ResgitroLogins { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6QPOGAP\\SQLEXPRESS; Database=Ecommerce;Encrypt = False; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarritoCompra>(entity =>
            {
                entity.HasKey(e => e.IdCarrito);

                entity.ToTable("Carrito_compras");

                entity.Property(e => e.IdCarrito)
                    .ValueGeneratedNever()
                    .HasColumnName("id_carrito");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPersonaFk).HasColumnName("id_persona_fk");

                entity.Property(e => e.IdProductoFk).HasColumnName("id_producto_fk");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.CarritoCompras)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_compras_Persona");

                entity.HasOne(d => d.IdProductoFkNavigation)
                    .WithMany(p => p.CarritoCompras)
                    .HasForeignKey(d => d.IdProductoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Carrito_compras_Producto");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.HasKey(e => e.IdDetalleFactura)
                    .HasName("PK_Detalles_factura");

                entity.ToTable("Detalle_factura");

                entity.Property(e => e.IdDetalleFactura).HasColumnName("id_detalle_factura");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdFacturaFk).HasColumnName("id_factura_fk");

                entity.Property(e => e.IdProductoFk).HasColumnName("id_producto_fk");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("precio_total");

                entity.HasOne(d => d.IdFacturaFkNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdFacturaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_factura_Factura");

                entity.HasOne(d => d.IdProductoFkNavigation)
                    .WithMany(p => p.DetalleFacturas)
                    .HasForeignKey(d => d.IdProductoFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_factura_Producto");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdClienteFk).HasColumnName("id_cliente_fk");

                entity.Property(e => e.IdVendedorFk).HasColumnName("id_vendedor_fk");

                entity.HasOne(d => d.IdClienteFkNavigation)
                    .WithMany(p => p.FacturaIdClienteFkNavigations)
                    .HasForeignKey(d => d.IdClienteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Persona1");

                entity.HasOne(d => d.IdVendedorFkNavigation)
                    .WithMany(p => p.FacturaIdVendedorFkNavigations)
                    .HasForeignKey(d => d.IdVendedorFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Persona");
            });

            modelBuilder.Entity<ModuloPermiso>(entity =>
            {
                entity.HasKey(e => e.IdModuloPermiso)
                    .HasName("PK_Modulos_permisos");

                entity.ToTable("Modulo_permiso");

                entity.Property(e => e.IdModuloPermiso).HasColumnName("id_modulo_permiso");

                entity.Property(e => e.Modulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modulo");

                entity.Property(e => e.Permiso)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("permiso");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumeroDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("numero_doc");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rol");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_doc");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("categoria");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Existencias).HasColumnName("existencias");

                entity.Property(e => e.Imagen)
                    .HasColumnType("text")
                    .HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<Publicidad>(entity =>
            {
                entity.HasKey(e => e.IdPublicidad);

                entity.ToTable("Publicidad");

                entity.Property(e => e.IdPublicidad).HasColumnName("id_publicidad");

                entity.Property(e => e.FechaFinal)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_final");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdPersonaFk).HasColumnName("id_persona_fk");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("precio");

                entity.Property(e => e.TipoPublicidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_publicidad");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Publicidads)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publicidad_Persona");
            });

            modelBuilder.Entity<ResgitroLogin>(entity =>
            {
                entity.HasKey(e => e.IdRegistroLogin)
                    .HasName("PK_Login");

                entity.ToTable("Resgitro_login");

                entity.Property(e => e.IdRegistroLogin).HasColumnName("id_registro_login");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("detalle");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuarioFk).HasColumnName("id_usuario_fk");

                entity.HasOne(d => d.IdUsuarioFkNavigation)
                    .WithMany(p => p.ResgitroLogins)
                    .HasForeignKey(d => d.IdUsuarioFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resgitro_login_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdPersonaFk).HasColumnName("id_persona_fk");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdPersonaFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersonaFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Persona1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
