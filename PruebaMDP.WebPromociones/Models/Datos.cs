using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMDP.WebPromociones.Models
{
    public class Datos
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
