using System;
using System.Collections.Generic;

namespace GestionConsultorio.Models
{
    public partial class Menupaginaset
    {
        public int? MenuId { get; set; }
        public int PaginaId { get; set; }

        public virtual Menuset Menu { get; set; }
        public virtual Paginaset Pagina { get; set; }
    }
}
