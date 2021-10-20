using System;
using System.Collections.Generic;
using System.Text;

namespace TurismoReal_Servicio.Core.Entities
{
    public class Servicio
    {
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double valor { get; set; }
        public string tipo { get; set; }
    }
}
