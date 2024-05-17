using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Estadistica
    {
        public int IdEstadistica { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Fecha { get; set; }
        public int IdPermiso { get; set; }
    }
}
