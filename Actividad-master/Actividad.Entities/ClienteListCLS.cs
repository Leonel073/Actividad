using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Actividad.Entities
{
    public class ClienteListCLS
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string RepresentanteAsignado { get; set; } = null!;
        public double LimiteCredito { get; set; }
    }
}