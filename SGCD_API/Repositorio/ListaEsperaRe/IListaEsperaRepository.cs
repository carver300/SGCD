using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGCD_API.Models;

namespace SGCD_API.Repositorio.ListaEsperaRe
{
    interface IListaEsperaRepository
    {

        bool GetListaDelDia();

        IEnumerable<ListaEspera> GetLista();
    }
}
