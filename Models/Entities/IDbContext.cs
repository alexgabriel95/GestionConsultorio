using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionConsultorio.Models.Entities
{
    public interface IDbContext
    {
          DbSet<Atencionpacientegestionset> Atencionpacientegestionset { get; set; }
          DbSet<Atencionset> Atencionset { get; set; }
          DbSet<Contactopacienteset> Contactopacienteset { get; set; }
          DbSet<Contactoset> Contactoset { get; set; }
          DbSet<Especialidadusuarioset> Especialidadusuarioset { get; set; }
          DbSet<Especializacionset> Especializacionset { get; set; }
          DbSet<Gestionperdidaset> Gestionperdidaset { get; set; }
          DbSet<Log> Log { get; set; }
          DbSet<Medicamentoatencionset> Medicamentoatencionset { get; set; }
          DbSet<Medicamentoset> Medicamentoset { get; set; }
          DbSet<Menupaginaset> Menupaginaset { get; set; }
          DbSet<Menuset> Menuset { get; set; }
          DbSet<Notificacionset> Notificacionset { get; set; }
          DbSet<Notificacionusuarioset> Notificacionusuarioset { get; set; }
          DbSet<Pacienteset> Pacienteset { get; set; }
          DbSet<Paginaset> Paginaset { get; set; }
          DbSet<Perfilpaginaset> Perfilpaginaset { get; set; }
          DbSet<Perfilpermisoset> Perfilpermisoset { get; set; }
          DbSet<Perfilset> Perfilset { get; set; }
          DbSet<Permisoset> Permisoset { get; set; }
          DbSet<Puedecrearset> Puedecrearset { get; set; }
          DbSet<Usuarioset> Usuarioset { get; set; }

        IModel Model { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChanges();
        void Dispose();
        EntityEntry Update(object entity);
        //void MarkAsModified<T>(T item) where T : class;
    }
}
