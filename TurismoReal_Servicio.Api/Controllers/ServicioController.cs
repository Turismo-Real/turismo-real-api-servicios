using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Servicio.Core.Entities;
using TurismoReal_Servicio.Core.Interfaces;
using TurismoReal_Servicio.Core.Log;

namespace TurismoReal_Servicio.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly string serviceName = "turismo_real_servicios";

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        // GET /api/v1/servicio
        [HttpGet]
        public async Task<List<Servicio>> GetServicios()
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/servicio";
            DateTime startService = DateTime.Now;

            List<Servicio> servicios = await _servicioRepository.GetServicios();

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = "Lista de servicios";
            Console.WriteLine(log.parseJson());
            // LOG
            return servicios;
        }

        // GET /api/v1/servicio/{id}
        [HttpGet("{id}")]
        public async Task<object> GetServicio(int id)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "GET";
            log.endpoint = "/api/v1/servicio/{id}";
            DateTime startService = DateTime.Now;

            Servicio servicio = await _servicioRepository.GetServicio(id);

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = servicio;
            Console.WriteLine(log.parseJson());
            // LOG
            return servicio;
        }

        // POST /api/v1/servicio
        [HttpPost]
        public async Task<object> CreateServicio([FromBody] Servicio servicio)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "POST";
            log.endpoint = "/api/v1/usuario";
            log.payload = servicio;
            DateTime startService = DateTime.Now;

            int saved = await _servicioRepository.CreateServicio(servicio);

            string message;
            if (saved == -1)
            {
                message = $"No existe el tipo de servicio [{servicio.tipo}].";
                var responseNotFound = new { message = message, saved = false };

                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseNotFound;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseNotFound;
            }

            if (saved == 0)
            {
                message = "Error al agregar servicio.";
                var responseError = new { message = message, saved = false };

                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseError;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseError;
            }

            message = "Servicio agregado.";
            Servicio servicioCreado = await _servicioRepository.GetServicio(saved);
            var responseOK = new { message = message, saved = true, servicio = servicioCreado };

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = responseOK;
            Console.WriteLine(log.parseJson());
            // LOG
            return responseOK;
        }

        // PUT /api/v1/servicio/{id}
        [HttpPut("{id}")]
        public async Task<object> UpdateServicio(int id, [FromBody] Servicio servicio)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "PUT";
            log.endpoint = "/api/v1/usuario/{id}";
            log.payload = servicio;
            DateTime startService = DateTime.Now;

            int updated = await _servicioRepository.UpdateServicio(id, servicio);

            string message;
            if (updated == -1)
            {
                message = $"No existe el servicio con id {id}.";
                var responseNotFound = new { message = message, updated = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseNotFound;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseNotFound;
            }

            if (updated == -2)
            {
                message = $"No existe el tipo de servicio [{servicio.tipo}].";
                var responseServiceTypeNotFound = new { message = message, updated = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseServiceTypeNotFound;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseServiceTypeNotFound;
            }

            if (updated == 0)
            {
                message = "Error al actualizar servicio.";
                var responseError = new { message = message, updated = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseError;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseError;
            }

            Servicio updatedService = await _servicioRepository.GetServicio(id);
            message = "Servicio modificado correctamente.";
            var responseOK = new { message = message, updated = true, servicio = updatedService };
            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = responseOK;
            Console.WriteLine(log.parseJson());
            // LOG
            return responseOK;
        }

        // DELETE /api/v1/servicio/{id}
        [HttpDelete("{id}")]
        public async Task<object> DeleteServicio(int id)
        {
            LogModel log = new LogModel();
            log.servicio = serviceName;
            log.method = "DELETE";
            log.endpoint = "/api/v1/usuario/{id}";
            DateTime startService = DateTime.Now;

            int removed = await _servicioRepository.DeleteServicio(id);

            string message;
            if (removed == -1)
            {
                message = $"No existe el servicio con id {id}.";
                var responseNotFound = new { message, removed = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseNotFound;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseNotFound;
            }

            if (removed == 0)
            {
                message = "Error al eliminar servicio.";
                var responseError = new { message, removed = false };
                // LOG
                log.inicioSolicitud = startService;
                log.finSolicitud = DateTime.Now;
                log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
                log.statusCode = 200;
                log.response = responseError;
                Console.WriteLine(log.parseJson());
                // LOG
                return responseError;
            }
            message = "Servicio eliminado.";
            var responseOK = new { message, removed = true };
            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = responseOK;
            Console.WriteLine(log.parseJson());
            // LOG
            return responseOK;
        }

    }
}
