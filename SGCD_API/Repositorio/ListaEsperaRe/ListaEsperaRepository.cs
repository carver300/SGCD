using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SGCD_API.Models;
using Dapper;

namespace SGCD_API.Repositorio.ListaEsperaRe
{
    public class ListaEsperaRepository : IListaEsperaRepository
    {
        IEnumerable<ListaEspera> listaCompleta;

        ListaEspera listaElemento;
        public bool GetListaDelDia()
        {
            using (var connection = new SqlConnection("Data Source=scgddb.database.windows.net;Initial Catalog=Clinica;User ID=administrador;Password=Clinica123;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                try
                {
                    connection.Open();
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        string sQuery = "SELECT keyx,fechacita,horacita,nombreservicio,id_paciente,nombre,apepaterno,apematerno " +
                                        "FROM Listadeespera " +
                                        "WHERE fechacita = CONVERT(date, getdate())";

                        listaCompleta = connection.Query<ListaEspera>(sQuery);
                        connection.Close();

                        if (listaCompleta.Count() > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
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

        public IEnumerable<ListaEspera> GetLista()
        {
            return listaCompleta;
        }
    }
}
