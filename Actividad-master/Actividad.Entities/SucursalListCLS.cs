using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad.Entities
{
    public class SucursalListCLS
    {
        public int idSucursal { get; set; }
        public string ciudad { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string ObjetivoVenta { get; set; } = null!;
        public int VentasReales { get; set; }
        public string Director {  get; set; } = string.Empty!;
    }
}
