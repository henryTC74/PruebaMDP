using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaMDP.ApiCanjeaCupon.DTOs;
using PruebaMDP.Application;
using PruebaMDP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMDP.ApiCanjeaCupon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CanjeController : ControllerBase
    {
        IApplication<Cupon> _cupon;

        public CanjeController(IApplication<Cupon> cupon)
        {
            _cupon = cupon;
        }

        [HttpPatch]
        public IActionResult CanjeaCupon(CanjeDTO dto)
        {
            if (ModelState.IsValid)
            {

                var data = _cupon.GetAll();
                var Cupon = data.Where(i => i.Correo == dto.Correo && i.Codigo == dto.Codigo).FirstOrDefault();
                // Condicion 1: "Solo se puede canjear un código a la vez"
                if (Cupon.Estado != "canjeado")
                {
                    Cupon.Estado = "canjeado";
                    return Ok(_cupon.Save(Cupon));
                }
                else
                {
                    return BadRequest("Error: Se requiere Nombre y email.");
                }
            }
            else
            {
                return BadRequest("Error: Se requiere Codigo y Correo.");
            }
        }
    }
}