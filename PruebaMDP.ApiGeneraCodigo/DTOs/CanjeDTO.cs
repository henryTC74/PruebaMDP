using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMDP.ApiCanjeaCupon.DTOs
{
    public class CanjeDTO
    {
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}