using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGCD_API.Models
{
    public class Paciente
    {
        public int id_paciente { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apepaterno { get; set; }
        [Required]
        public string apematerno { get; set; }
        [Required]
        public string sexo { get; set; }
        [Required]
        public string edad { get; set; }
        [Required]
        public string calle { get; set; }
        [Required]
        public string colonia { get; set; }
        [Required]
        public string codigopostal { get; set; }
        [Required]
        public string telefono { get; set; }
        public string correo { get; set; }
        public string alergia { get; set; }
    }
}