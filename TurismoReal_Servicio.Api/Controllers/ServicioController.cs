﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Servicio.Core.Entities;
using TurismoReal_Servicio.Core.Interfaces;

namespace TurismoReal_Servicio.Api.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<List<object>> GetServicios()
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // GET /api/v1/servicio/{id}
        [HttpGet("{id}")]
        public async Task<object> GetServicio(int id)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // POST /api/v1/servicio
        [HttpPost]
        public async Task<object> CreateServicio([FromBody] Servicio servicio)
        {
            await Task.Delay(1);
            throw new NotImplementedException();
        }

        // PUT /api/v1/servicio/{id}
        [HttpPut]
        public async Task<object> UpdateServicio(int id)
        {
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