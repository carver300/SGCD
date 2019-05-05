using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGCD_API.Models;

namespace SGCD_API.Services
{
    public class ServicioServices
    {
        public readonly DBContext _ServiciosDB;
        public ServicioServices(DBContext ServiciosDB)
        {
            _ServiciosDB = ServiciosDB;
        }
        public List<Servicio> verListado()
        {
            var ServicioBuscado = _ServiciosDB.Servicio.Take(15).ToList();
            return ServicioBuscado;
        }

        public Servicio ObtenerPorID(int id_servicio)
        {
            try
            {
                var ServicioBuscado = _ServiciosDB.Servicio.Where(x => x.id_servicio == id_servicio).FirstOrDefault();
                return ServicioBuscado;
            }
            catch (Exception error)
            {
                return new Servicio();
            }
        }

        public bool Agregar(Servicio ServicioAgregar)
        {
            try
            {
                _ServiciosDB.Servicio.Add(ServicioAgregar);
                _ServiciosDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Editar(Servicio ServicioEditar)
        {
            try
            {
                var servicio = _ServiciosDB.Servicio.FirstOrDefault(x => x.id_servicio == ServicioEditar.id_servicio);
                servicio.nombre = ServicioEditar.nombre;
                servicio.descripcion = ServicioEditar.descripcion;
                servicio.precio = ServicioEditar.precio;
                servicio.tiempoestimado = ServicioEditar.tiempoestimado; 
                _ServiciosDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool Eliminar(int id_servicio)
        {
            try
            {
                var servicioEliminar = _ServiciosDB.Servicio.FirstOrDefault(x => x.id_servicio == id_servicio);
                _ServiciosDB.Servicio.Remove(servicioEliminar);
                _ServiciosDB.SaveChanges();
                return true;
            }
            catch (Exception E)
            {
                return false;
            }


        }
    }
}
