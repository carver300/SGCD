using SGCD_API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGCD_API.Repositorio.Pacientes
{
    public interface IPacientesRepository
    {
        IEnumerable<Paciente> GetAll();

        Paciente GetById(int id_paciente);

        int Delete(int id_paciente);
    }
}