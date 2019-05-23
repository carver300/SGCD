using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGCD_API.Models
{
    public class Servicio
    {
        public int id_servicio { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public decimal precio { get; set; }
        [Required]
        public string tiempoestimado { get; set; }
        
    }
}
