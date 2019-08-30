using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Perfilpaginaset
    {
        public int PerfilId { get; set; }
        public int PaginaId { get; set; }

        public Paginaset Pagina { get; set; }
        public Perfilset Perfil { get; set; }
    }
}
