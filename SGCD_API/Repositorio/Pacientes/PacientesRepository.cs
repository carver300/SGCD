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

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                string sQuery = "Select * from pacientes";

                pacientes = connection.Query<Paciente>(sQuery);

                connection.Close();
            }


            return pacientes;
        }
    }
}