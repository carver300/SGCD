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


namespace SGCD_API.Repositorio.Pacientes
{
    public class PacientesRepository : IPacientesRepository
    {

        public bool GetAll(IEnumerable<Paciente> pacientes)
        {
            
            bool bRespuesta = false;
            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try{
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Select * from paciente";
                        pacientes = connection.Query<Paciente>(sQuery);
                        connection.Close();
                        
                        if(pacientes.Count() > 0){
                            bRespuesta =  true;
                        }
                        else{
                            return bRespuesta;
                        }         
                    }
                }
                catch(SqlException error){
                    return bRespuesta;
                }
            }

            return bRespuesta;
        }

        public bool GetById(int id_paciente,Paciente paciente){

            bool bRespuesta = false;
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Select nombre,apepaterno,apematerno,sexo,edad,calle,colonia,codigopostal,telefono"+
                                        ",correo,alergia from paciente where id_paciente = @id";

                        var result = connection.Query<Paciente>(sQuery, new { ID = id_paciente });
                        paciente = result.FirstOrDefault();
                        connection.Close();

                       if(paciente != null){
                           bRespuesta = true;
                       }
                    }
                }
                catch (SqlException error)
                {
                    return bRespuesta;
                }
            }

            return bRespuesta;
            
        }

        public int Delete(int id_paciente){

            int iRespuesta = 0;

            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Delete from paciente where id_paciente = @id";
                        var result = connection.Query<Paciente>(sQuery, new { ID = id_paciente });
                        connection.Close();
                    }
                }
                catch(SqlException error){
                    return iRespuesta;
                }                
            }

            return iRespuesta;
        }
    }
}