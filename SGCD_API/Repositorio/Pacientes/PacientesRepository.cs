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
                        string sQuery = "INSERT INTO paciente (nombre,apepaterno,apematerno,sexo,edad,calle,colonia,"+
                                        "codigopostal,telefono,correo,alergia) VALUES (@Nombre,@Apepaterno,@Apematerno,@Sexo"+
                                        "@Edad,@Calle,@Colonia,@Codigopostal,@Telefono,@Correo,@Alergia)";

                        var result = connection.Query<Paciente>(sQuery, new { Nombre = paciente.nombre,Apepaterno = paciente.apepaterno, Apematerno = paciente.apematerno,
                                                                Sexo = paciente.sexo, Edad = paciente.edad,Telefono = paciente.telefono,
                                                                Correo = paciente.correo, Calle = paciente.calle, Colonia = paciente.colonia,
                                                                Codigopostal = paciente.codigopostal, Alergia = paciente.alergia });

                        
                        paciente = result.FirstOrDefault();
                        pacienteAux = paciente;
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
        public bool UpdatePaciente(Paciente pacienteMod){

            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "UPDATE paciente set telefono = @Telefono, correo = @Correo, calle = @Calle, colonia = @Colonia,"+
                                        "codigopostal = @Codigopostal WHERE id_paciente = @id";

                        var result = connection.Query<Paciente>(sQuery, new { ID = pacienteMod.id_paciente, Telefono = pacienteMod.telefono,
                                                                Correo = pacienteMod.correo, Calle = pacienteMod.calle, Colonia = pacienteMod.colonia,
                                                                Codigopostal = pacienteMod.codigopostal });

                        
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