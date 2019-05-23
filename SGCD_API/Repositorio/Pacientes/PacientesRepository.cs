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
        private Paciente pacienteAux;
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
                        pacienteAux = result.FirstOrDefault();
                        connection.Close();

                       if(pacienteAux != null){
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

        public bool insertPaciente(Paciente paciente){
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {

                        DynamicParameters parameters = new DynamicParameters();  
                        parameters.Add("@nombre",paciente.nombre);
                        parameters.Add("@apepaterno",paciente.apepaterno);
                        parameters.Add("@apematerno",paciente.apematerno);
                        parameters.Add("@sexo",paciente.sexo);
                        parameters.Add("@edad",paciente.edad);
                        parameters.Add("@calle",paciente.calle);
                        parameters.Add("@colonia",paciente.colonia);
                        parameters.Add("@codigopostal",paciente.codigopostal);
                        parameters.Add("@telefono",paciente.telefono);
                        parameters.Add("@correo",paciente.correo);
                        parameters.Add("@alergia",paciente.alergia);

                        int result = connection.Execute("SP_AgregaPaciente", parameters,commandType:CommandType.StoredProcedure);

                        pacienteAux = paciente;
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
        public bool UpdatePaciente(Paciente pacienteMod){

            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        
                        DynamicParameters parameters = new DynamicParameters();  
                        parameters.Add("@id_paciente",pacienteMod.id_paciente);
                        parameters.Add("@nombre",pacienteMod.nombre);
                        parameters.Add("@apepaterno",pacienteMod.apepaterno);
                        parameters.Add("@apematerno",pacienteMod.apematerno);
                        parameters.Add("@sexo",pacienteMod.sexo);
                        parameters.Add("@edad",pacienteMod.edad);
                        parameters.Add("@calle",pacienteMod.calle);
                        parameters.Add("@colonia",pacienteMod.colonia);
                        parameters.Add("@codigopostal",pacienteMod.codigopostal);
                        parameters.Add("@telefono",pacienteMod.telefono);
                        parameters.Add("@correo",pacienteMod.correo);
                        parameters.Add("@alergia",pacienteMod.alergia);

                        int result = connection.Execute("SP_ActualizarInformacionPaciente", parameters,commandType:CommandType.StoredProcedure);

                        
                       if(result == 1){
                           pacienteAux = pacienteMod;
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
            return pacienteAux;
        }
    }
}