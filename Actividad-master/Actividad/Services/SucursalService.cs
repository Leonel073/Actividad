using Actividad.Entities;

namespace Actividad.Services
{
    public class SucursalService
    {
        private List<SucursalCLS> lista;
        public SucursalService()
        {
            lista = new List<SucursalCLS>();
            lista.Add(new SucursalCLS() { idSucursal = 1, nombreSucursal = "La Paz"});
            lista.Add(new SucursalCLS() { idSucursal = 3, nombreSucursal = "Cochabamba"});
        }
        public List<SucursalCLS> listarSucursal()
        {
            return lista;
        }
        public int obtenerIdSucursal(string nombreSucursal)
        {
            var obj = lista.Where(p => p.nombreSucursal == nombreSucursal).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idSucursal;
            }
        }
        public string obtenerNombreSucursal(int idSucursal)
        {
            var obj = lista.Where(p => p.idSucursal == idSucursal).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.nombreSucursal;
            }
        }
    }
}
