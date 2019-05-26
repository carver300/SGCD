using SGCD_API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGCD_API.Repositorio.Citas
{
    public interface ICitaRepository
    {
        bool GetAll();

        bool GetById(int id_cita);

        bool insertarCita(Cita cita);

        bool  actualizarCita(Cita cita);

        int Delete(int id_cita);        
        IEnumerable<Cita> getIEnu();

        Cita getCitas();
        
    }
}