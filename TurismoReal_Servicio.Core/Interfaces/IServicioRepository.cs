﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TurismoReal_Servicio.Core.Entities;

namespace TurismoReal_Servicio.Core.Interfaces
{
    public interface IServicioRepository
    {
        // GET ALL SERVICES
        Task<List<object>> GetServicios();

        // GET SERVICE BY ID
        Task<object> GetServicio(int id);

        // ADD SERVICE
        Task<object> CreateServicio(Servicio servicio);

        // EDIT SERVICE
        Task<object> UpdateServicio(int id, Servicio servicio);

        // DELETE SERVICE
        Task<object> DeleteServicio(int id);
    }
}