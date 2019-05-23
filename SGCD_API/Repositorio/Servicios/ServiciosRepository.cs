using System.Collections.Generic;
using SGCD_API.Repositorio;
using SGCD_API.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;


namespace SGCD_API.Repositorio.Servicios
{
    public class ServiciosRepository : IServiciosRepository
    {

        private IEnumerable<Servicio> servicios;
        private Servicio servicio;
        public bool GetAll()
        {
            
           
            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try{
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Select id_servicio, nombre, descripcion, precio, tiempoestimado from servicio";
                        servicios = connection.Query<Servicio>(sQuery);
                        connection.Close();
                        
                        if(servicios.Count() > 0){
                            return true;
                        }
                        else{
                            return false;
                        }         
                    }
                }
                catch(SqlException error){
                    return false;
                }
            }

            return false;
        }

        public bool GetById(int id_servicio){

            
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Select id_servicio, nombre, descripcion, precio, tiempoestimado"+
                                        " from servicio where id_servicio = @id";

                        var result = connection.Query<Servicio>(sQuery, new { ID = id_servicio });
                        servicio = result.FirstOrDefault();
                        connection.Close();

                       if(servicio != null){
                          return true;
                       }
                    }
                }
                catch (SqlException error)
                {
                    return false;
                }
            }

            return false;
            
        }

        public bool InsertServicio(Servicio servicio){
            
            
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {

                        DynamicParameters parameters = new DynamicParameters();  
                        parameters.Add("@nombre",servicio.nombre);
                        parameters.Add("@descripcion",servicio.descripcion);
                        parameters.Add("@precio",servicio.precio);
                        parameters.Add("@tiempoestimado",servicio.tiempoestimado);
                        

                        int result = connection.Execute("SP_AgregaServicios", parameters,commandType:CommandType.StoredProcedure);

                         
                        connection.Close();

                       if(result == 1){
                          return true;
                       }
                    }
                }
                catch (SqlException error)
                {
                    return false;
                }
            }
            return false;
        }
        public int Delete(int id_servicio){

            int iRespuesta = 0;

            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Delete from servicio where id_servicio = @id";
                        var result = connection.Query<Servicio>(sQuery, new { ID = id_servicio });
                        connection.Close();

                        if(result != null){
                            return 1;
                        }
                    }
                }
                catch(SqlException error){
                    return 0;
                }                
            }

            return 0;
        }

        public IEnumerable<Servicio> getIEnu(){
            return servicios;
        }

        public Servicio getServicio(){
            return servicio;
        }
    }
}