using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Perfilpaginaset
    {
        public int PerfilId { get; set; }
        public int PaginaId { get; set; }

        public virtual Paginaset Pagina { get; set; }
        public virtual Perfilset Perfil { get; set; }
    }
}
