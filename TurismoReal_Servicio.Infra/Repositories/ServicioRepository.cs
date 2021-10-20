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
        public async Task<Servicio> GetServicio(int id)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_servicio_id", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("servicio_id", OracleDbType.Int32).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("servicios", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters["servicio_id"].Value = id;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();

            Servicio servicio = new Servicio();
            while (reader.Read())
            {
                servicio.idServicio = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("id_servicio")).ToString());
                servicio.nombre = reader.GetValue(reader.GetOrdinal("nombre_servicio")).ToString();
                servicio.descripcion = reader.GetValue(reader.GetOrdinal("descripcion")).ToString();
                servicio.valor = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("valor")).ToString());
                servicio.tipo = reader.GetValue(reader.GetOrdinal("tipo_servicio")).ToString();
            }
            reader.Close();
            _context.CloseConnection();
            return servicio;
        }

        // ADD SERVICE
        public async Task<int> CreateServicio(Servicio servicio)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_agregar_servicio", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.BindByName = true;
            cmd.Parameters.Add("nombre_s", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("descripcion_s", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("valor_s", OracleDbType.Double).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("tipo_s", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("saved", OracleDbType.Int32).Direction = ParameterDirection.Output;

            cmd.Parameters["nombre_s"].Value = servicio.nombre;
            cmd.Parameters["descripcion_s"].Value = servicio.descripcion;
            cmd.Parameters["valor_s"].Value = servicio.valor;
            cmd.Parameters["tipo_s"].Value = servicio.tipo;

            await cmd.ExecuteNonQueryAsync();
            // Retorna el id del servicio agregado
            int saved = int.Parse(cmd.Parameters["saved"].Value.ToString());

            _context.CloseConnection();
            return saved;
        }

        // EDIT SERVICE
        public async Task<int> UpdateServicio(int id, Servicio servicio)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_editar_servicio", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.BindByName = true;
            cmd.Parameters.Add("servicio_id", OracleDbType.Int32).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("nombre_s", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("descripcion_s", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("valor_s", OracleDbType.Double).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("tipo_s", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("updated", OracleDbType.Int32).Direction = ParameterDirection.Output;

            cmd.Parameters["servicio_id"].Value = id;
            cmd.Parameters["nombre_s"].Value = servicio.nombre;
            cmd.Parameters["descripcion_s"].Value = servicio.descripcion;
            cmd.Parameters["valor_s"].Value = servicio.valor;
            cmd.Parameters["tipo_s"].Value = servicio.tipo;

            await cmd.ExecuteNonQueryAsync();
            int updated = int.Parse(cmd.Parameters["updated"].Value.ToString());

            _context.CloseConnection();
            return updated;
        }

        // DELETE SERVICE
        public async Task<int> DeleteServicio(int id)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_eliminar_servicio", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.BindByName = true;

            cmd.Parameters.Add("servicio_id", OracleDbType.Int32).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("removed", OracleDbType.Int32).Direction = ParameterDirection.Output;

            cmd.Parameters["servicio_id"].Value = id;
            await cmd.ExecuteNonQueryAsync();
            int removed = Convert.ToInt32(cmd.Parameters["removed"].Value.ToString());
            return removed;
        }
    }
}
