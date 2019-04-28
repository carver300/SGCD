using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGCD_API.Models
{
    public class Paciente
    {

        public int id_paciente { get; set; }
        public string nombre { get; set; }
        public string apepaterno { get; set; }
        public string apematerno { get; set; }
        public string sexo { get; set; }
        public string edad { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string codigopostal { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string alergia { get; set; }
      
        public class Map
        {
            public Map(EntityTypeBuilder<Paciente> ebPaciente)
            {
                ebPaciente.HasKey(x => x.id_paciente);
                ebPaciente.Property(x => x.nombre).HasColumnName("nombre").HasMaxLength(50);
                ebPaciente.Property(x => x.apepaterno).HasColumnName("apepaterno").HasMaxLength(30);
                ebPaciente.Property(x => x.apematerno).HasColumnName("apematerno").HasMaxLength(30);
                ebPaciente.Property(x => x.sexo).HasColumnName("sexo").HasMaxLength(30);
                ebPaciente.Property(x => x.edad).HasColumnName("edad").HasMaxLength(3);
                ebPaciente.Property(x => x.calle).HasColumnName("calle").HasMaxLength(200);
                ebPaciente.Property(x => x.colonia).HasColumnName("colonia").HasMaxLength(200);
                ebPaciente.Property(x => x.codigopostal).HasColumnName("codigopostal").HasMaxLength(5);
                ebPaciente.Property(x => x.telefono).HasColumnName("telefono").HasMaxLength(10);
                ebPaciente.Property(x => x.correo).HasColumnName("correo").HasMaxLength(100);
                ebPaciente.Property(x => x.alergia).HasColumnName("alergia").HasMaxLength(200);
            }
        }
    }
}
