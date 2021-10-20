using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Servicio.Core.Entities;

namespace TurismoReal_Servicio.Core.Interfaces
{
    public interface IServicioRepository
    {
        // GET ALL SERVICES
        Task<List<Servicio>> GetServicios();

        // GET SERVICE BY ID
        Task<Servicio> GetServicio(int id);

        // ADD SERVICE
        Task<int> CreateServicio(Servicio servicio);

        // EDIT SERVICE
        Task<object> UpdateServicio(int id, Servicio servicio);

        // DELETE SERVICE
        Task<object> DeleteServicio(int id);
    }
}
