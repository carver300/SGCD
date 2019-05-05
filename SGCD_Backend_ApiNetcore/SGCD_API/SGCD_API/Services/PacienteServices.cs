using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGCD_API.Models;

namespace SGCD_API.Services
{
    public class PacienteServices
    {
        public readonly DBContext _PacientesDB;
        public PacienteServices(DBContext PacientesDB)
        {
            _PacientesDB = PacientesDB;
        }
        public List<Paciente> verListado()
        {
            var PacienteBuscado = _PacientesDB.Paciente.Take(15).ToList();
            return PacienteBuscado;
        }

        public Paciente ObtenerPorID(int id_paciente)
        {
            try
            {
               
                return _PacientesDB.Paciente.Where(x => x.id_paciente == id_paciente).FirstOrDefault(); ;
            }
            catch (Exception error)
            {
               
               return new Paciente();
            }
        }

        public bool Agregar(Paciente PacienteAgregar)
        {
            try {
                _PacientesDB.Paciente.Add(PacienteAgregar);
                _PacientesDB.SaveChanges();
                return true;
            } catch
            {
                return false;
            }
            
        }

        public bool Editar(Paciente PacienteEditar)
        {  
            try
            {
                var paciente = _PacientesDB.Paciente.FirstOrDefault(x => x.id_paciente == PacienteEditar.id_paciente);
                paciente.nombre = PacienteEditar.nombre;
                paciente.apepaterno = PacienteEditar.apepaterno;
                paciente.apematerno = PacienteEditar.apepaterno;
                paciente.sexo = PacienteEditar.sexo;
                paciente.edad = PacienteEditar.edad;
                paciente.calle = PacienteEditar.calle;
                paciente.colonia = PacienteEditar.colonia;
                paciente.codigopostal = PacienteEditar.codigopostal;
                paciente.telefono = PacienteEditar.telefono;
                paciente.correo = PacienteEditar.correo;
                paciente.alergia = PacienteEditar.alergia;
                _PacientesDB.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }

        public bool Eliminar(int id_paciente)
        {
            try
            {
                var pacienteEliminar = _PacientesDB.Paciente.FirstOrDefault(x => x.id_paciente == id_paciente);
                _PacientesDB.Paciente.Remove(pacienteEliminar);
                _PacientesDB.SaveChanges();
                return true;
            }
            catch(Exception E){
                return false;
            }
            

        }
    }
}
