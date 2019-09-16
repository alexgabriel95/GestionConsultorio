using System;
using GestionConsultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GestionConsultorio.Models
{
    public partial class DataContext : DbContext, IDbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atencionpacientegestionset> Atencionpacientegestionset { get; set; }
        public virtual DbSet<Atencionset> Atencionset { get; set; }
        public virtual DbSet<Contactopacienteset> Contactopacienteset { get; set; }
        public virtual DbSet<Contactoset> Contactoset { get; set; }
        public virtual DbSet<Especialidadusuarioset> Especialidadusuarioset { get; set; }
        public virtual DbSet<Especializacionset> Especializacionset { get; set; }
        public virtual DbSet<Gestionperdidaset> Gestionperdidaset { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Medicamentoatencionset> Medicamentoatencionset { get; set; }
        public virtual DbSet<Medicamentoset> Medicamentoset { get; set; }
        public virtual DbSet<Menupaginaset> Menupaginaset { get; set; }
        public virtual DbSet<Menuset> Menuset { get; set; }
        public virtual DbSet<Notificacionset> Notificacionset { get; set; }
        public virtual DbSet<Notificacionusuarioset> Notificacionusuarioset { get; set; }
        public virtual DbSet<Pacienteset> Pacienteset { get; set; }
        public virtual DbSet<Paginaset> Paginaset { get; set; }
        public virtual DbSet<Perfilpaginaset> Perfilpaginaset { get; set; }
        public virtual DbSet<Perfilpermisoset> Perfilpermisoset { get; set; }
        public virtual DbSet<Perfilset> Perfilset { get; set; }
        public virtual DbSet<Permisoset> Permisoset { get; set; }
        public virtual DbSet<Puedecrearset> Puedecrearset { get; set; }
        public virtual DbSet<Usuarioset> Usuarioset { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;database=gestionconsultorio_local;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atencionpacientegestionset>(entity =>
            {
                entity.ToTable("atencionpacientegestionset");

                entity.HasIndex(e => e.AtencionPacienteId)
                    .HasName("IX_FK_AtencionPacienteId");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AtencionPacienteId).HasColumnType("int(11)");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.EstadoGestion).HasColumnType("int(11)");

                entity.Property(e => e.FechaGestion).HasColumnType("datetime");

                entity.HasOne(d => d.AtencionPaciente)
                    .WithMany(p => p.Atencionpacientegestionset)
                    .HasForeignKey(d => d.AtencionPacienteId)
                    .HasConstraintName("FK_AtencionPacienteId");
            });

            modelBuilder.Entity<Atencionset>(entity =>
            {
                entity.ToTable("atencionset");

                entity.HasIndex(e => e.EspecializacionId)
                    .HasName("IX_FK_EspecializacionId");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioIdAlta)
                    .HasName("IX_FK_UsuarioIdAlta");

                entity.HasIndex(e => e.UsuarioIdBaja)
                    .HasName("IX_FK_UsuarioIdBaja");

                entity.HasIndex(e => e.UsuarioIdMedico)
                    .HasName("IX_FK_UsuarioIdMedico");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EspecializacionId).HasColumnType("int(11)");

                entity.Property(e => e.FechaAltaAtencion).HasColumnType("datetime");

                entity.Property(e => e.FechaAtencion).HasColumnType("datetime");

                entity.Property(e => e.UsuarioIdAlta).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioIdBaja).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioIdMedico).HasColumnType("int(11)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Atencionset)
                    .HasForeignKey<Atencionset>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IX_FK_EspecializacionId");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.Atencionset)
                    .HasForeignKey<Atencionset>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IX_FK_UsuarioIdMedico");
            });

            modelBuilder.Entity<Contactopacienteset>(entity =>
            {
                entity.ToTable("contactopacienteset");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PacienteId)
                    .HasName("IX_FK_PacienteContacto");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PacienteId).HasColumnType("int(11)");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Contactopacienteset)
                    .HasForeignKey(d => d.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contactopacienteset_ibfk_1");
            });

            modelBuilder.Entity<Contactoset>(entity =>
            {
                entity.ToTable("contactoset");

                entity.HasIndex(e => e.ContactoPacienteId)
                    .HasName("IX_FK_PacienteContacto");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioIdAlta)
                    .HasName("IX_FK_UsuarioAltaContacto");

                entity.HasIndex(e => e.UsuarioIdBaja)
                    .HasName("IX_FK_UsuarioBajaContacto");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ContactoPacienteId).HasColumnType("int(11)");

                entity.Property(e => e.Dato)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.TipoContacto).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioIdAlta).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioIdBaja).HasColumnType("int(11)");

                entity.HasOne(d => d.ContactoPaciente)
                    .WithMany(p => p.Contactoset)
                    .HasForeignKey(d => d.ContactoPacienteId)
                    .HasConstraintName("contactoset_ibfk_1");

                entity.HasOne(d => d.UsuarioIdAltaNavigation)
                    .WithMany(p => p.ContactosetUsuarioIdAltaNavigation)
                    .HasForeignKey(d => d.UsuarioIdAlta)
                    .HasConstraintName("contactoset_ibfk_2");

                entity.HasOne(d => d.UsuarioIdBajaNavigation)
                    .WithMany(p => p.ContactosetUsuarioIdBajaNavigation)
                    .HasForeignKey(d => d.UsuarioIdBaja)
                    .HasConstraintName("contactoset_ibfk_3");
            });

            modelBuilder.Entity<Especialidadusuarioset>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.EspecializacionId });

                entity.ToTable("especialidadusuarioset");

                entity.HasIndex(e => e.EspecializacionId)
                    .HasName("IX_FK_EspecializacionId");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("IX_FK_UsuarioId");

                entity.Property(e => e.UsuarioId).HasColumnType("int(11)");

                entity.Property(e => e.EspecializacionId).HasColumnType("int(11)");

                entity.HasOne(d => d.Especializacion)
                    .WithMany(p => p.Especialidadusuarioset)
                    .HasForeignKey(d => d.EspecializacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EspecializacionId");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Especialidadusuarioset)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioId");
            });

            modelBuilder.Entity<Especializacionset>(entity =>
            {
                entity.ToTable("especializacionset");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.NombreEspecializacion)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Gestionperdidaset>(entity =>
            {
                entity.ToTable("gestionperdidaset");

                entity.HasIndex(e => e.AtencionId)
                    .HasName("IX_FK_Atencion_Id");

                entity.HasIndex(e => e.Id)
                    .HasName("id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AtencionId)
                    .HasColumnName("Atencion_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Atencion)
                    .WithMany(p => p.Gestionperdidaset)
                    .HasForeignKey(d => d.AtencionId)
                    .HasConstraintName("FK_Atencion_Id");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Aplication)
                    .IsRequired()
                    .HasColumnType("varchar(85)");

                entity.Property(e => e.Callsite)
                    .IsRequired()
                    .HasColumnType("varchar(85)");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasColumnType("varchar(85)");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasColumnName("level")
                    .HasColumnType("varchar(85)");

                entity.Property(e => e.Logged)
                    .HasColumnName("logged")
                    .HasColumnType("datetime");

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasColumnType("varchar(85)");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("varchar(85)");
            });

            modelBuilder.Entity<Medicamentoatencionset>(entity =>
            {
                entity.HasKey(e => new { e.AtencionId, e.MedicamentoId });

                entity.ToTable("medicamentoatencionset");

                entity.HasIndex(e => e.AtencionId)
                    .HasName("IX_FK_AtencionId");

                entity.HasIndex(e => e.MedicamentoId)
                    .HasName("IX_FK_Medicamento");

                entity.Property(e => e.AtencionId).HasColumnType("int(11)");

                entity.Property(e => e.MedicamentoId).HasColumnType("int(11)");

                entity.HasOne(d => d.Atencion)
                    .WithMany(p => p.Medicamentoatencionset)
                    .HasForeignKey(d => d.AtencionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AtencionId");

                entity.HasOne(d => d.Medicamento)
                    .WithMany(p => p.Medicamentoatencionset)
                    .HasForeignKey(d => d.MedicamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicamentoId");
            });

            modelBuilder.Entity<Medicamentoset>(entity =>
            {
                entity.ToTable("medicamentoset");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CantidadDisponible).HasColumnType("int(11)");

                entity.Property(e => e.FechaCarga).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.NombreMedicamento)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Menupaginaset>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.PaginaId });

                entity.ToTable("menupaginaset");

                entity.HasIndex(e => e.PaginaId)
                    .HasName("IX_FK_MenuPagina_Pagina");

                entity.Property(e => e.MenuId)
                    .HasColumnName("Menu_Id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaginaId)
                    .HasColumnName("Pagina_Id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Menupaginaset)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPagina_Menu");

                entity.HasOne(d => d.Pagina)
                    .WithMany(p => p.Menupaginaset)
                    .HasForeignKey(d => d.PaginaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPagina_Pagina");
            });

            modelBuilder.Entity<Menuset>(entity =>
            {
                entity.ToTable("menuset");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IconClass)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Order)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Notificacionset>(entity =>
            {
                entity.ToTable("notificacionset");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Detalle)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Notificacionusuarioset>(entity =>
            {
                entity.ToTable("notificacionusuarioset");

                entity.HasIndex(e => e.NotificacionId)
                    .HasName("IX_FK_usuarioNotificacion");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("IX_FK_notificacionUsuario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FueLeido).HasColumnType("bit(1)");

                entity.Property(e => e.NotificacionId).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioId).HasColumnType("int(11)");

                entity.HasOne(d => d.Notificacion)
                    .WithMany(p => p.Notificacionusuarioset)
                    .HasForeignKey(d => d.NotificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarioNotificacion");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Notificacionusuarioset)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notificacionUsuario");
            });

            modelBuilder.Entity<Pacienteset>(entity =>
            {
                entity.ToTable("pacienteset");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Barrio).HasColumnType("varchar(45)");

                entity.Property(e => e.Ciudad).HasColumnType("varchar(45)");

                entity.Property(e => e.DireccionCalle)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Localidad).HasColumnType("varchar(45)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Numerodocumento).HasColumnType("int(11)");

                entity.Property(e => e.Provincia).HasColumnType("varchar(45)");

                entity.Property(e => e.TipoDocumento).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Paginaset>(entity =>
            {
                entity.ToTable("paginaset");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Controller)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Perfilpaginaset>(entity =>
            {
                entity.HasKey(e => new { e.PerfilId, e.PaginaId });

                entity.ToTable("perfilpaginaset");

                entity.HasIndex(e => e.PaginaId)
                    .HasName("IX_FK_PaginaPerfil");

                entity.HasIndex(e => e.PerfilId)
                    .HasName("IX_FK_PerfilPagina");

                entity.Property(e => e.PerfilId).HasColumnType("int(11)");

                entity.Property(e => e.PaginaId).HasColumnType("int(11)");

                entity.HasOne(d => d.Pagina)
                    .WithMany(p => p.Perfilpaginaset)
                    .HasForeignKey(d => d.PaginaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfilpagina_idfk_2");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Perfilpaginaset)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("perfilpagina_idfk_1");
            });

            modelBuilder.Entity<Perfilpermisoset>(entity =>
            {
                entity.HasKey(e => new { e.PerfilId, e.PermisoId });

                entity.ToTable("perfilpermisoset");

                entity.HasIndex(e => e.PerfilId)
                    .HasName("IX_FK_PerfilPermiso");

                entity.HasIndex(e => e.PermisoId)
                    .HasName("IX_FK_PermisoPerfil");

                entity.Property(e => e.PerfilId).HasColumnType("int(11)");

                entity.Property(e => e.PermisoId).HasColumnType("int(11)");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Perfilpermisoset)
                    .HasForeignKey(d => d.PerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilPermiso");

                entity.HasOne(d => d.Permiso)
                    .WithMany(p => p.Perfilpermisoset)
                    .HasForeignKey(d => d.PermisoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisoPerfil");
            });

            modelBuilder.Entity<Perfilset>(entity =>
            {
                entity.ToTable("perfilset");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.SessionTimeOut).HasColumnType("int(11)");

                entity.Property(e => e.TipoPerfil).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Permisoset>(entity =>
            {
                entity.ToTable("permisoset");

                entity.HasIndex(e => e.Codigo)
                    .HasName("Codigo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnType("varchar(55)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("varchar(55)");

                entity.Property(e => e.DescripcionCompleta)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Grupo)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Puedecrearset>(entity =>
            {
                entity.HasKey(e => new { e.PuedeCrear, e.PerfilAcrear });

                entity.ToTable("puedecrearset");

                entity.HasIndex(e => e.PerfilAcrear)
                    .HasName("IX_FK_PerfilACrear");

                entity.HasIndex(e => e.PuedeCrear)
                    .HasName("IX_FK_PerfilPuedeCrear");

                entity.Property(e => e.PuedeCrear).HasColumnType("int(11)");

                entity.Property(e => e.PerfilAcrear)
                    .HasColumnName("PerfilACrear")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PerfilAcrearNavigation)
                    .WithMany(p => p.PuedecrearsetPerfilAcrearNavigation)
                    .HasForeignKey(d => d.PerfilAcrear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilACrear");

                entity.HasOne(d => d.PuedeCrearNavigation)
                    .WithMany(p => p.PuedecrearsetPuedeCrearNavigation)
                    .HasForeignKey(d => d.PuedeCrear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerfilPuedeCrear");
            });

            modelBuilder.Entity<Usuarioset>(entity =>
            {
                entity.ToTable("usuarioset");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PerfilId)
                    .HasName("PerfilId");

                entity.HasIndex(e => e.UsuarioIdAlta)
                    .HasName("fk_UsuarioAlta");

                entity.HasIndex(e => e.UsuarioIdBaja)
                    .HasName("fk_UsuarioBaja");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaBaja).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.NumeroDocumento).HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.PerfilId).HasColumnType("int(11)");

                entity.Property(e => e.Telefono).HasColumnType("varchar(45)");

                entity.Property(e => e.TipoDocumento).HasColumnType("int(11)");

                entity.Property(e => e.UltimoInicioSesion).HasColumnType("datetime");

                entity.Property(e => e.UsuarioIdAlta).HasColumnType("int(11)");

                entity.Property(e => e.UsuarioIdBaja).HasColumnType("int(11)");

                entity.HasOne(d => d.Perfil)
                    .WithOne(p => p.Usuarioset)
                    .HasForeignKey<Usuarioset>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuarioPerfil");

                entity.HasOne(d => d.UsuarioAlta)
                    .WithOne(p => p.UsuarioBaja)
                    .HasForeignKey<Usuarioset>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuarioBaja");
            });
        }
    }
}
