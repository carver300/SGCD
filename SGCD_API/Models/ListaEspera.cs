using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGCD_API.Models
{
    public class ListaEspera
    {
        public int keyx { get; set; }

        public string fechacita { get; set; }

        public string horacita { get; set; }

        public string nombreservicio { get; set; }

        public int id_paciente { get; set; }

        public string nombre { get; set; }

        public string apepaterno { get; set; }

        public string apematerno { get; set; }


    }
}