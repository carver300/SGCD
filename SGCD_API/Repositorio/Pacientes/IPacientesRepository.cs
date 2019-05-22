using SGCD_API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGCD_API.Repositorio.Pacientes
{
    public interface IPacientesRepository
    {
        bool GetAll();

        bool GetById(int id_paciente);

        int Delete(int id_paciente);
        
        IEnumerable<Paciente> getIEnu();

        Paciente getPaciente();
        
    }
}