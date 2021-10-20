using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Servicio.Core.Entities;
using TurismoReal_Servicio.Core.Interfaces;
using TurismoReal_Servicio.Infra.Context;

namespace TurismoReal_Servicio.Infra.Repositories
{
    public class ServicioRepository :IServicioRepository
    {
        protected readonly OracleContext _context;

        public ServicioRepository()
        {
            _context = new OracleContext();
        }

        // GET ALL SERVICES
        public async Task<List<object>> GetServicios()
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // GET SERVICE BY ID
        public async Task<object> GetServicio(int id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // ADD SERVICE
        public async Task<object> CreateServicio(Servicio servicio)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // EDIT SERVICE
        public async Task<object> UpdateServicio(int id, Servicio servicio)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // DELETE SERVICE
        public async Task<object> DeleteServicio(int id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }
    }
}
