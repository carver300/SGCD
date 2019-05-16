using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGCD_API.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string contra { get; set; }
        public int tipo_usuario { get; set; }
        public class Map
        {
            public Map(EntityTypeBuilder<Usuario> ebUsuario)
            {
                ebUsuario.HasKey(x => x.id_usuario);
                ebUsuario.Property(x => x.usuario).HasColumnName("usuario").HasMaxLength(100);
                ebUsuario.Property(x => x.contra).HasColumnName("contra").HasMaxLength(30);
                ebUsuario.Property(x => x.tipo_usuario).HasColumnName("tipo_usuario").HasColumnType("int");
            }
        }
    }

}
