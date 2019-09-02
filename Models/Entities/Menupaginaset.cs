using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Menupaginaset
    {
        public int MenuId { get; set; }
        public int PaginaId { get; set; }

        public Menuset Menu { get; set; }
        public Paginaset Pagina { get; set; }
    }
}
