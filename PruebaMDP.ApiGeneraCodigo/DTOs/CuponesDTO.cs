using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMDP.ApiCupones.DTOs
{
    public class CuponesDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
