using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGCD_API.Models
{
    public class Cita
    {
        public int id_cita { get; set; }
        [Required]
        public int id_paciente { get; set; }
        [Required]
        public int id_servicio { get; set; }
        [Required]
        public string fecha { get; set; }
        [Required]
        public string hora { get; set; }
        public string observaciones { get; set; }
        public int estatus { get; set; }

        public Cita()
        {
            estatus = 0;
        }
    }
}