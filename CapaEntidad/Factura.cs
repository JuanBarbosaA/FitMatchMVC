using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string FechaEmision { get; set; }
        public string MontoTotal { get; set; }
        public int IdEntidad { get; set; }
    }
}
