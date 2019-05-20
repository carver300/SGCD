using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        [Required]
        public string observaciones { get; set; }
        public int estatus { get; set; }
 
        public Paciente Paciente { get; set; }
        public Servicio Servicio { get; set; }

        public Cita()
        {
            estatus = 0;
        }

        public class Map
        {
            public Map(EntityTypeBuilder<Cita> ebCita)
            {
                ebCita.HasKey(x => x.id_cita);
                ebCita.Property(x => x.id_paciente).HasColumnName("id_paciente").HasColumnType("int");
                ebCita.Property(x => x.id_servicio).HasColumnName("id_servicio").HasColumnType("int");
                ebCita.Property(x => x.fecha).HasColumnName("fecha").HasColumnType("Date");
                ebCita.Property(x => x.hora).HasColumnName("hora").HasMaxLength(5);
                ebCita.Property(x => x.observaciones).HasColumnName("observaciones").HasMaxLength(500);
                ebCita.Property(x => x.estatus).HasColumnName("estatus").HasColumnType("int");
                ebCita.HasOne(x => x.Paciente);
                ebCita.HasOne(x => x.Servicio);
            }
        }
    }
}
