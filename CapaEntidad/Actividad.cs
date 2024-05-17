using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Actividad
    {
        public int IdActividad { get; set; }
        public string TipoActividad { get; set; }
        public string Descripcion { get; set; }
        public int IdEntidad { get; set; }
    }
}
