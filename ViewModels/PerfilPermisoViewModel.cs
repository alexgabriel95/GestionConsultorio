using GestionConsultorio.Models;
using System.Collections.Generic;

namespace GestionConsultorio.ViewModels
{
    public class PerfilPermisosViewModel
    {
        public Perfilset Perfil { get; set; }
        public IEnumerable<Paginaset> Paginas { get; set; }
        public IEnumerable<Permisoset> Acciones { get; set; }
        public IEnumerable<Perfilset> Perfiles { get; set; }
    }
}