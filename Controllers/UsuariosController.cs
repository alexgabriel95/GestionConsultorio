using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionConsultorio.Models;
using GestionConsultorio.Models.Entities;
using GestionConsultorio.Models.Dto;
using GestionConsultorio.Helpers;
using GestionConsultorio.ViewModels;
using GestionConsultorio.Models.LS.Comp.Encriptador;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using System.Text;

namespace GestionConsultorio.Controllers
{
    public class UsuariosController : GestionConsultorioController
    //GestionConsultorioController
    {
        private readonly IViewRenderService _viewRenderService;
        private readonly ILoggerHelper _logger;
        public UsuariosController(IDbContext context, IViewRenderService viewRenderService, ILoggerHelper logger) : base(context)
        {
            _viewRenderService = viewRenderService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var uvm = new List<UsuariosViewModel>();
            try
            {
                var usuarios = await Usuarioset.ObtenerUsuariosSegunPuedeCrear(db, GetUsuarioLogueado(HttpContext).PerfilId);

                uvm = usuarios.Select(u => new UsuariosViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    TipoDocumento = Enum.GetName(typeof(TipoDocumento), u.TipoDocumento),
                    NumeroDocumento = u.NumeroDocumento,
                    Email = u.Email,
                    Telefono = u.Telefono,
                    Perfil = u.Perfil,
                    FechaBaja = u.FechaBaja
                }).ToList();
            }
            catch (Exception e)
            {

                _logger.logError(e);
            }

            return View(uvm);
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}