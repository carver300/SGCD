using System.Collections.Generic;
using SGCD_API.Models;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SGCD_API.Repositorio.Citas
{
    public class CitaRepository : ICitaRepository
    {

        private IEnumerable<Cita> Citas;
        private Cita CitaAux;
        public bool GetAll()
        {
            
           
            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try{
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Select * from Cita";
                        Citas = connection.Query<Cita>(sQuery);
                        connection.Close();
                        
                        if(Citas.Count() > 0){
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

        public bool GetById(int id_cita){

            
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "SELECT  id_cita,id_paciente,id_servicio,fecha,hora,estatus,observaciones"+
                                        "FROM cita WHERE id_paciente = @id";

                        Citas = connection.Query<Cita>(sQuery, new { ID = id_cita });
                        connection.Close();

                       if(Citas.Count() > 0){
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

        public bool insertarCita(Cita cita){
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {

                        DynamicParameters parameters = new DynamicParameters();  
                        parameters.Add("@id_paciente",cita.id_paciente);
                        parameters.Add("@id_servicio",cita.id_servicio);
                        parameters.Add("@fecha",cita.fecha);
                        parameters.Add("@hora",cita.hora);
                        parameters.Add("@estatus",cita.estatus);
                        parameters.Add("@observaciones",cita.observaciones);

                        int result = connection.Execute("SP_AgregaCita", parameters,commandType:CommandType.StoredProcedure);

                        CitaAux = cita;
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
        public bool actualizarCita(Cita citaMod){

            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        
                        DynamicParameters parameters = new DynamicParameters();  
                        

                        int result = connection.Execute("SP_ActualizarInformacionPaciente", parameters,commandType:CommandType.StoredProcedure);

                        
                       if(result == 1){
                           CitaAux = citaMod;
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

        public int Delete(int id_cita){

            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "Delete from cita where id_cita = @id";
                        var result = connection.Query<Cita>(sQuery, new { ID = id_cita });
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

        public IEnumerable<Cita> getIEnu(){
            return Citas;
        }

        public Cita getCitas(){
            return CitaAux;
        }
    }
}