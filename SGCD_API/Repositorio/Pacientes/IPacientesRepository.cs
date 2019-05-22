using SGCD_API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGCD_API.Repositorio.Pacientes
{
    public interface IPacientesRepository
    {
        bool GetAll(IEnumerable<Paciente> pacientes);

        bool GetById(int id_paciente,Paciente paciente);

        int Delete(int id_paciente);

        
    }
}