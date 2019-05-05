using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGCD_API.Models;

namespace SGCD_API.Services
{
        public class CitaServices
        {
            public readonly DBContext _CitasDB;
            public CitaServices(DBContext CitasDB)
            {
                _CitasDB = CitasDB;
            }
            public List<Cita> verListado()
            {
                var CitaBuscado = _CitasDB.Cita.Include(x=>x.Paciente).Include(x => x.Servicio).OrderByDescending(x => x.id_cita).Take(15).ToList(); ;
                return CitaBuscado;
            }

            public Cita ObtenerPorID(int id_cita)
            {
                try
                {
                    return _CitasDB.Cita.Where(x => x.id_cita == id_cita).Include(x => x.Paciente).Include(x => x.Servicio).FirstOrDefault(); ;
                }
                catch (Exception error)
                {

                    return new Cita();
                }
            }

            public bool Agregar(Cita CitaAgregar)
            {
                try
                {
                    _CitasDB.Cita.Add(CitaAgregar);
                    _CitasDB.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }

            public bool Editar(Cita CitaEditar)
            {
                try
                {
                    var cita = _CitasDB.Cita.FirstOrDefault(x => x.id_cita == CitaEditar.id_cita);
                    cita.estatus = CitaEditar.estatus;
                    _CitasDB.SaveChanges();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                }
            }
        }
}
