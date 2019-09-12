using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionConsultorio.Models;
using GestionConsultorio.Models.Entities;
using System.Security.Claims;
using GestionConsultorio.Helpers;
using GestionConsultorio.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authorization;

namespace GestionConsultorio.Controllers
{
    public class HomeController : Controller
        //GestionConsultorioController
    {

        //private readonly ILoggerHelper _logger;
        //public HomeController(DataContext context, ILoggerHelper logger) : base(context)
        //{
        //    _logger = logger;
        //}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
