using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMDP.ApiCupones.DTOs;
using PruebaMDP.Application;
using PruebaMDP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMDP.ApiCupones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CuponController : ControllerBase
    {
        IApplication<Cupon> _cupon;

        public CuponController(IApplication<Cupon> cupon)
        {
            _cupon = cupon;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cupon.GetAll());
        }

        [HttpPost]
        public IActionResult GeneraCupon(CuponesDTO dto) 
        {
            // Condicion 1: "Para generar un código se debe proporcionar nombre y email"
            if (ModelState.IsValid)
            {
                // Condicion 2: "Solo se puede generar un código por email."
                var data = _cupon.GetAll();
                var existeCorreo = data.Where(i => i.Correo == dto.Correo).FirstOrDefault();

                if (existeCorreo != null)
                {
                    return BadRequest("Error: Solo se puede generar un codigo email.");
                }
                else
                {
                    // Generamos Codigo
                    var guid = Guid.NewGuid();
                    var soloNumeros = new String(guid.ToString().Where(Char.IsDigit).ToArray());
                    var semilla = int.Parse(soloNumeros.Substring(0, 3));
                    var random = new Random(semilla);
                    var codigo = random.Next(10000000, 99999999);

                    // Guardamos Datos
                    var f = new Cupon()
                    {
                        Nombre = dto.Nombre,
                        Correo = dto.Correo,
                        Codigo = codigo.ToString(),
                        Estado = "generado"
                    };
                    return Ok(_cupon.Save(f));
                }
            }
            else
            {
                return BadRequest("Error: Se requiere Nombre y email.");
            }
        }
    }
}
