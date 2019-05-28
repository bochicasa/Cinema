using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Cine.API.Models
{
    public partial class CineContext : DbContext
    {
        IConfiguration _configuration;
        public CineContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CineContext(DbContextOptions<CineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleta> Boleta { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Funcion> Funcion { get; set; }
        public virtual DbSet<Localidad> Localidad { get; set; }
        public virtual DbSet<LocalidadMapa> LocalidadMapa { get; set; }
        public virtual DbSet<Mapa> Mapa { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Silla> Silla { get; set; }
        public virtual DbSet<SillaLocalidadMapa> SillaLocalidadMapa { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Boleta>(entity =>
            {
                entity.ToTable("BOLETA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CodVen)
                    .HasColumnName("COD_VEN")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Funcion)
                    .HasColumnName("FUNCION")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("LOCALIDAD")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Mapa)
                    .HasColumnName("MAPA")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.NumSil)
                    .HasColumnName("NUM_SIL")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Sala)
                    .HasColumnName("SALA")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SecCliente)
                    .HasColumnName("SEC_CLIENTE")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.ValorBolVen)
                    .HasColumnName("VALOR_BOL_VEN")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.CodVenNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.CodVen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_VENTA");

                entity.HasOne(d => d.FuncionNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.Funcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_FUNCION");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_LOCALIDAD");

                entity.HasOne(d => d.MapaNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.Mapa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_MAPA");

                entity.HasOne(d => d.NumSilNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.NumSil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_SILLA");

                entity.HasOne(d => d.SalaNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.Sala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_SALA");

                entity.HasOne(d => d.SecClienteNavigation)
                    .WithMany(p => p.Boleta)
                    .HasForeignKey(d => d.SecCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BOLETA_CLIENTE");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.SecCli);

                entity.ToTable("CLIENTE");

                entity.Property(e => e.SecCli)
                    .HasColumnName("SEC_CLI")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apellido1)
                    .HasColumnName("APELLIDO1")
                    .HasMaxLength(20);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("APELLIDO2")
                    .HasMaxLength(20);

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(200);

                entity.Property(e => e.Documento)
                    .HasColumnName("DOCUMENTO")
                    .HasColumnType("numeric(15, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(200);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.ToTable("FUNCION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaFun)
                    .HasColumnName("FECHA_FUN")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pelicula)
                    .HasColumnName("PELICULA")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Reservas)
                    .HasColumnName("RESERVAS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.PeliculaNavigation)
                    .WithMany(p => p.Funcion)
                    .HasForeignKey(d => d.Pelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FUNCION_PELICULA");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.ToTable("LOCALIDAD");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasMaxLength(4000);

                entity.Property(e => e.Sala)
                    .HasColumnName("SALA")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.SalaNavigation)
                    .WithMany(p => p.Localidad)
                    .HasForeignKey(d => d.Sala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCALIDAD_SALA");
            });

            modelBuilder.Entity<LocalidadMapa>(entity =>
            {
                entity.ToTable("LOCALIDAD_MAPA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Costo)
                    .HasColumnName("COSTO")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("LOCALIDAD")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Mapa)
                    .HasColumnName("MAPA")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.LocalidadMapa)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCALIDAD_MAPA_LOCALIDAD");

                entity.HasOne(d => d.MapaNavigation)
                    .WithMany(p => p.LocalidadMapa)
                    .HasForeignKey(d => d.Mapa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOCALIDAD_MAPA_MAPA");
            });

            modelBuilder.Entity<Mapa>(entity =>
            {
                entity.ToTable("MAPA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Funcion)
                    .HasColumnName("FUNCION")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200);

                entity.Property(e => e.Publicado)
                    .IsRequired()
                    .HasColumnName("PUBLICADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Sala)
                    .HasColumnName("SALA")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.TipoMap)
                    .IsRequired()
                    .HasColumnName("TIPO_MAP")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.FuncionNavigation)
                    .WithMany(p => p.Mapa)
                    .HasForeignKey(d => d.Funcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAPA_FUNCION");

                entity.HasOne(d => d.SalaNavigation)
                    .WithMany(p => p.Mapa)
                    .HasForeignKey(d => d.Sala)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MAPA_SALA");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("PELICULA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.OriginalTitle)
                    .IsRequired()
                    .HasColumnName("ORIGINAL_TITLE")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("RESERVA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(5, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRes)
                    .HasColumnName("FECHA_RES")
                    .HasColumnType("datetime");

                entity.Property(e => e.Funcion)
                    .HasColumnName("FUNCION")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.NumSil)
                    .HasColumnName("NUM_SIL")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SecCliente)
                    .HasColumnName("SEC_CLIENTE")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SillaLocalidad)
                    .HasColumnName("SILLA_LOCALIDAD")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.TipoRes)
                    .IsRequired()
                    .HasColumnName("TIPO_RES")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.FuncionNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Funcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVA_FUNCION");

                entity.HasOne(d => d.SecClienteNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.SecCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVA_CLIENTE");

                entity.HasOne(d => d.SillaLocalidadNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.SillaLocalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RESERVA_SILLA_MAPA");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("SALA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(150);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200);

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasMaxLength(4000);

                entity.Property(e => e.RutaImg)
                    .HasColumnName("RUTA_IMG")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Silla>(entity =>
            {
                entity.HasKey(e => e.NumSil);

                entity.ToTable("SILLA");

                entity.Property(e => e.NumSil)
                    .HasColumnName("NUM_SIL")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ColSil)
                    .HasColumnName("COL_SIL")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.FilSil)
                    .HasColumnName("FIL_SIL")
                    .HasColumnType("numeric(5, 0)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("LOCALIDAD")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.NomFil)
                    .IsRequired()
                    .HasColumnName("NOM_FIL")
                    .HasMaxLength(200);

                entity.Property(e => e.ObsSil)
                    .HasColumnName("OBS_SIL")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.Silla)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SILLA_LOCALIDAD");
            });

            modelBuilder.Entity<SillaLocalidadMapa>(entity =>
            {
                entity.ToTable("SILLA_LOCALIDAD_MAPA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Estado)
                    .HasColumnName("ESTADO")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Localidad)
                    .HasColumnName("LOCALIDAD")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Mapa)
                    .HasColumnName("MAPA")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.NumSil)
                    .HasColumnName("NUM_SIL")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.SillaLocalidadMapa)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SILLA_LOCALIDAD_MAPA_LOCALIDAD");

                entity.HasOne(d => d.MapaNavigation)
                    .WithMany(p => p.SillaLocalidadMapa)
                    .HasForeignKey(d => d.Mapa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SILLA_LOCALIDAD_MAPA_MAPA");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.ToTable("TIPO_PAGO");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("VENTA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(10, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FechaVen)
                    .HasColumnName("FECHA_VEN")
                    .HasColumnType("date");

                entity.Property(e => e.Funcion)
                    .HasColumnName("FUNCION")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.RespVen)
                    .HasColumnName("RESP_VEN")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SecCliente)
                    .HasColumnName("SEC_CLIENTE")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.FuncionNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Funcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VENTA_FUNCION");

                entity.HasOne(d => d.SecClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.SecCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VENTA_CLIENTE");
            });
        }
    }
}
