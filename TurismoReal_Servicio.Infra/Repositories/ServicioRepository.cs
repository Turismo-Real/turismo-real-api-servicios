using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<List<Servicio>> GetServicios()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_servicios", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("servicios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader) await cmd.ExecuteReaderAsync();

            List<Servicio> servicios = new List<Servicio>();
            while (reader.Read())
            {
                Servicio servicio = new Servicio();
                servicio.idServicio = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("id_servicio")).ToString());
                servicio.nombre = reader.GetValue(reader.GetOrdinal("nombre_servicio")).ToString();
                servicio.descripcion = reader.GetValue(reader.GetOrdinal("descripcion")).ToString();
                servicio.valor = Convert.ToDouble(reader.GetValue(reader.GetOrdinal("valor")).ToString());
                servicio.tipo = reader.GetValue(reader.GetOrdinal("tipo_servicio")).ToString();
                servicios.Add(servicio);
            }
            _context.CloseConnection();
            return servicios;
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
