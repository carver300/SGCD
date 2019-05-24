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


        public Paciente (){
            
        }
        public Paciente (int tipo){
            if (tipo == 1){
                //Objeto campos importantes vacios
                correo = "";
                telefono = "";
                nombre = "asas";
            }else if(tipo == 2){
                //Objeto datos ejemplo 1
                correo = "prueba@gmail.com";
                telefono = "6671744578";
            }else if (tipo == 3){
                //Objeto datos ejemplo 2
                correo = "prueba2@gmail.com";
                telefono = "6681744578";
            }else if(tipo == 4){
                nombre = "paco.";
            }
            
        }
    }
}