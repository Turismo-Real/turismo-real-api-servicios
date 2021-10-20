using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Servicio.Core.Entities;
using TurismoReal_Servicio.Core.Interfaces;

namespace TurismoReal_Servicio.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        // GET /api/v1/servicio
        [HttpGet]
        public async Task<List<Servicio>> GetServicios()
        {
            List<Servicio> servicios = await _servicioRepository.GetServicios();
            return servicios;
        }

        // GET /api/v1/servicio/{id}
        [HttpGet("{id}")]
        public async Task<Servicio> GetServicio(int id)
        {
            Servicio servicio = await _servicioRepository.GetServicio(id);
            return servicio;
        }

        // POST /api/v1/servicio
        [HttpPost]
        public async Task<object> CreateServicio([FromBody] Servicio servicio)
        {
            int saved = await _servicioRepository.CreateServicio(servicio);

            if (saved == -1) return new { message = $"No existe el tipo de servicio [{servicio.tipo}].", saved = false };
            if (saved == 0) return new { message = "Error al agregar servicio.", saved = false };
            return new { message = $"Servicio agregado con id {saved}", saved = true };
        }

        // PUT /api/v1/servicio/{id}
        [HttpPut("{id}")]
        public async Task<object> UpdateServicio(int id, [FromBody] Servicio servicio)
        {
            int updated = await _servicioRepository.UpdateServicio(id, servicio);

            if (updated == -1) return new { message = $"No existe el servicio con id {id}.", updated = false };
            if (updated == -2) return new { message = $"No existe el tipo de servicio [{servicio.tipo}].", updated = false };
            if (updated == 0) return new { message = "Error al actualizar servicio.", updated = false };
            return new { message = "Servicio modificado correctamente.", updated = true };
        }

        // DELETE /api/v1/servicio/{id}
        [HttpDelete("{id}")]
        public async Task<object> DeleteServicio(int id)
        {
            int removed = await _servicioRepository.DeleteServicio(id);

            if (removed == -1) return new { message = $"No existe el servicio con id {id}.", removed = false };
            if (removed == 0) return new { message = "Error al eliminar servicio.", removed = false };
            return new { message = "Servicio eliminado.", removed = true };
        }

    }
}
