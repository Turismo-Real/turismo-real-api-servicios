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
        [HttpPut]
        public async Task<object> UpdateServicio(int id, [FromBody] Servicio servicio)
        {
            int updated = await _servicioRepository.UpdateServicio(id, servicio);

            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // DELETE /api/v1/servicio/{id}
        [HttpDelete]
        public async Task<object> DeleteServicio(int id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

    }
}
