using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago
    {
        public int IdPago{ get; set; }
        public string FechaPago { get; set; }
        public int IdEntidad { get; set; }
        public int IdFactura { get; set; }
    }
}
