using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGCD_API.Models;

namespace SGCD_API
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions opciones) : base(opciones)
        {

        }
        public virtual DbSet<Paciente> Paciente {get; set;}
        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new Paciente.Map(modelB.Entity<Paciente>());
            base.OnModelCreating(modelB);
        }
       
    }
}
