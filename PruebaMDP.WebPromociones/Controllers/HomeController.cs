using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaMDP.Application;
using PruebaMDP.DataAccess;
using PruebaMDP.Entities;
using PruebaMDP.WebPromociones.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMDP.WebPromociones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiDbContext _context;

        public HomeController(ApiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Datos datos)
        {
            // Condicion 1: "Para generar un código se debe proporcionar nombre y email"
            if (ModelState.IsValid)
            {
                // Condicion 2: "Solo se puede generar un código por email."
                return Ok("Registrado.");
            }
            else
            {
                return BadRequest("Error: Se requiere Nombre y email.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
