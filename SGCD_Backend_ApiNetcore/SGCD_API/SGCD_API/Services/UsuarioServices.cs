using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SGCD_API.Models;
using Microsoft.EntityFrameworkCore;

namespace SGCD_API.Services
{
    public class UsuarioServices
    {
        public readonly DBContext _UsuariosDB;
        public UsuarioServices(DBContext UsuariosDB)
        {
            _UsuariosDB = UsuariosDB;
        }
     
        public String Agregar(Usuario UsuarioAgregar)
        {
            try
            {
                _UsuariosDB.Usuario.Add(UsuarioAgregar);
                _UsuariosDB.SaveChanges();
                string id = UsuarioAgregar.usuario.ToString();
                return id;
            }
            catch (SqlException e)
            {
                return e.Message;
            }

        }

        public Usuario Login(Usuario Usuario)
        {
            try
            {
                return _UsuariosDB.Usuario.Where(x => x.usuario == Usuario.usuario && x.contra == Usuario.contra).FirstOrDefault();
            }    
            catch (Exception error)
            {
                return null;
            }
        }

        public int LoginAPP(Usuario Usuario)
        {
            try
            {
                var encontrado = _UsuariosDB.Usuario.Where(x => x.usuario == Usuario.usuario && x.contra == Usuario.contra).FirstOrDefault();
                if (encontrado != null)
                {
                    return 1;
                }
                return 0;
            }
            catch (Exception error)
            {   
                return 0;
            }
        }
    }
}
