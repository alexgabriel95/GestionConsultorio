using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Perfilpermisoset
    {
        public int PerfilId { get; set; }
        public int PermisoId { get; set; }

        public Perfilset Perfil { get; set; }
        public Permisoset Permiso { get; set; }
    }
}
