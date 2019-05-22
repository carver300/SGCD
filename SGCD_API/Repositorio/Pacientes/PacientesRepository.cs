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

        private IEnumerable<Paciente> pacientes;
        private Paciente paciente;
        public bool GetAll()
        {
            
           
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

        public bool GetById(int id_paciente){

            
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

        public IEnumerable<Paciente> getIEnu(){
            return pacientes;
        }

        public Paciente getPaciente(){
            return paciente;
        }
    }
}