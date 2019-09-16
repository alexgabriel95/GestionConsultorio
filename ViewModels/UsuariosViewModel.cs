using GestionConsultorio.Models;
using GestionConsultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionConsultorio.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public Perfilset Perfil { get; set; }
        public DateTime? FechaBaja { get; set; }
    }

    public class UsuarioViewModelList
    {
        public IEnumerable<SelectListItem> Perfiles { get; set; }
        public IEnumerable<SelectListItem> TiposDocDdl { get; set; }
        public int PerfilId { get; set; }
        public TipoDocumento TipoDoc { get; set; }
    }

    public class UsuarioEdicionViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento TipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int PerfilId { get; set; }
        public IEnumerable<SelectListItem> Perfiles { get; set; }
        public IEnumerable<SelectListItem> TiposDocDdl { get; set; }

    }
    public class UsuarioMailViewModel
    {
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
    }
}
