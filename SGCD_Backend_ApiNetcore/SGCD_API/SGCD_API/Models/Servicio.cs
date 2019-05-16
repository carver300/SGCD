using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
        

        public class Map
        {
            public Map(EntityTypeBuilder<Servicio> ebServicio)
            {
                ebServicio.HasKey(x => x.id_servicio);
                ebServicio.Property(x => x.nombre).HasColumnName("nombre").HasMaxLength(50);
                ebServicio.Property(x => x.descripcion).HasColumnName("descripcion").HasMaxLength(200);
                ebServicio.Property(x => x.precio).HasColumnName("precio").HasMaxLength(10);
                ebServicio.Property(x => x.tiempoestimado).HasColumnName("tiempoestimado").HasMaxLength(50);
            }
        }

    }
}
