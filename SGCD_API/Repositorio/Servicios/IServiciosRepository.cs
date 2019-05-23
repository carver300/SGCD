using SGCD_API.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SGCD_API.Repositorio.Servicios
{
    public interface IServiciosRepository
    {
        bool GetAll();

        bool GetById(int id_servicio);

        bool InsertServicio(Servicio servicio);
        
        IEnumerable<Servicio> getIEnu();

        Servicio getServicio();
        
    }
}