using GestionConsultorio.Models;
using GestionConsultorio.Models.Dto;
using GestionConsultorio.Models.Entities;
using GestionConsultorio.ViewModels;
using GestionConsultorio.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using GestionConsultorio.Controllers;

namespace GestionConsultorio.Controllers
{
    public class PerfilesController : GestionConsultorioController
    {
        private readonly ILoggerHelper _logger;
        public PerfilesController(DataContext context, ILoggerHelper logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var perfiles = await Perfilset.ObtenerPerfiles(db);
            return View(perfiles);
        }

        public IActionResult CrearPerfil()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearPerfil([FromBody] CrearPerfilDto cpd)
        {
            bool error = false;
            int idPerfil = 0;
            try
            {
                Perfilset perfil = new Perfilset
                {
                    Nombre = cpd.Descripcion,
                    SessionTimeOut = cpd.TimeOut,
                    TipoPerfil = cpd.TipoPerfil
                };

                db.Perfilset.Add(perfil);
                db.SaveChanges();
                idPerfil = perfil.Id;
            }
            catch (Exception e)
            {
                error = true;

                _logger.logError(e);
            }

            return Json(new { success = true, error, idPerfil });
        }

        [HttpPost]
        public async Task<IActionResult> EditarPerfil([FromBody] EditarPerfilViewModel ep)
        {
            var perfil = await db.Perfilset.FirstOrDefaultAsync(x => x.Id == ep.PerfilId);
            bool error = false;

            try
            {
                if (!String.IsNullOrEmpty(ep.Nombre))
                {
                    perfil.Nombre = ep.Nombre;
                    perfil.SessionTimeOut = ep.Timeout;
                }

                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                error = true;

                _logger.logError(e);
            }

            return Json(new { error, success = true });
        }

        public async Task<IActionResult> AdministrarPermisos(int id)
        {
            PerfilPermisosViewModel ppvm = new PerfilPermisosViewModel
            {
                Perfil = await Perfilset.ObtenerPerfilPorId(db, id),
                Paginas = Paginaset.ObtenerPaginas(db),
                Acciones = Permisoset.ObtenerPermisos(db),
                Perfiles = await Perfilset.ObtenerPerfiles(db)

            };
            return View(ppvm);
        }

        [HttpPost]
        public async Task<IActionResult> ModificarPerfilPagina([FromBody] ModificarPermisoDto m)
        {
            bool resultado;
            try
            {
                var perfil = await Perfilset.ObtenerPerfilPorId(db, m.PerfilId);
                var permiso = await Perfilset.ObtenerPerfilPagina(db, m.PaginaId, m.PerfilId);
                if (m.Permitido)
                {
                    perfil.Perfilpaginaset.Add(permiso);
                }
                else
                    perfil.Perfilpaginaset.Remove(permiso);

                db.Update(perfil);
                //db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();

                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;

                _logger.logError(e);
            }

            return Json(new { succes = true, error = !resultado, res = resultado });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarPerfilPermiso([FromBody] ModificarPermisoDto m)
        {
            bool resultado;
            try
            {
                var perfil = await Perfilset.ObtenerPerfilPorId(db, m.PerfilId);
                var permiso = await Perfilset.ObtenerPerfilPermiso(db, m.PermisoId, m.PerfilId);

                if (m.Permitido)
                {
                    perfil.Perfilpermisoset.Add(permiso);
                }
                else
                    perfil.Perfilpermisoset.Remove(permiso);

                db.Update(perfil);
                db.SaveChanges();

                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;

                _logger.logError(e);
            }

            return Json(new { succes = true, error = !resultado, res = resultado });
        }

        [HttpPost]
        public async Task<IActionResult> ModificarPuedeCrear([FromBody] ModificarPermisoDto m)
        {
            bool resultado;
            try
            {
                var perfil = await Perfilset.ObtenerPerfilPorId(db, m.PerfilId);
                var perfilACrear = await Perfilset.ObtenerPerfilPorId(db, m.PerfilCrearId);

                var puedeCrear = await Perfilset.ObtenerPuedeCrear(db, perfilACrear, perfil);

                if (m.Permitido)
                    perfil.PuedecrearsetPuedeCrearNavigation.Add(puedeCrear);
                else
                    perfil.PuedecrearsetPuedeCrearNavigation.Remove(puedeCrear);

                db.Update(perfil);
                await db.SaveChangesAsync();

                resultado = true;

            }
            catch (Exception e)
            {
                resultado = false;

                _logger.logError(e);
            }

            return Json(new { success = true, error = !resultado, res = resultado });
        }
    }
}
