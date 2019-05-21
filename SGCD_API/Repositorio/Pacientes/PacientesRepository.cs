using System.Collections.Generic;
using SGCD_API.Repositorio;
using SGCD_API.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;


namespace SGCD_API.Repositorio.Pacientes
{
    public class PacientesRepository : IPacientesRepository
    {

        private readonly IConfiguration _configuration;
        public IEnumerable<Paciente> GetAll()
        {
            IEnumerable<Paciente> pacientes = null;

            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();

                string sQuery = "Select * from paciente";

                pacientes = connection.Query<Paciente>(sQuery);

                connection.Close();
            }


            return pacientes;
        }

        public Paciente GetById(int id_paciente){

            Paciente paciente;
            
            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                
                connection.Open();

                string sQuery = "Select nombre,apepaterno,apematerno,sexo,edad,calle,colonia,codigopostal,telefono,correo,alergia from paciente where id_paciente = @id";

                var result = connection.Query<Paciente>(sQuery,new{ ID = id_paciente});

                paciente = result.FirstOrDefault();
                connection.Close();

                
               
            }
            
            return paciente;
            
        }

        public int Delete(int id_paciente){

            int iRespuesta = 0;

            using(var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                
                connection.Open();

                string sQuery = "Delete from paciente where id_paciente = @id";

                var result = connection.Query<Paciente>(sQuery,new{ ID = id_paciente});

                
                connection.Close();

                
               
            }

            return iRespuesta;
        }
    }
}