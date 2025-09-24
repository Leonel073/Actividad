using Actividad.Entities;

namespace Actividad.Services
{
    public class SucursalService
    {
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarBusqueda(string ciudad)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(ciudad);
            }
        }

        private List<SucursalListCLS> lista;
        private EmpleadoService empleadoService;

        public SucursalService(EmpleadoService _empleadoService)
        {
            empleadoService = _empleadoService;

            lista = new List<SucursalListCLS>();
            lista.Add(new SucursalListCLS() { idSucursal = 1, ciudad = "La Paz" ,Region = "Bolivia", Director = "Juan"});
            lista.Add(new SucursalListCLS() { idSucursal = 2, ciudad = "Santa Cruz", Region = "Bolivia", Director = "Ana" });
            lista.Add(new SucursalListCLS() { idSucursal = 3, ciudad = "Cochabamba", Region = "Bolivia", Director = "Juan" });
        }
        public List<SucursalListCLS> listarSucursal()
        {
            return lista;
        }
        public int obtenerIdSucursal(string nombreSucursal)
        {
            var obj = lista.Where(p => p.ciudad == nombreSucursal).FirstOrDefault();
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
                return obj.ciudad;
            }
        }
        public List<SucursalListCLS> filtrarSucursales(string ciudad)
        {
            List<SucursalListCLS> l = listarSucursal();
            if (ciudad == "")
            {
                return l;
            }
            else
            {
                List<SucursalListCLS> listafiltrada = l.Where(p => p.ciudad.ToUpper().Contains(ciudad.ToUpper())).ToList();
                return listafiltrada;
            }
        }

        public List<RepresentanteListCLS> ObtenerDirectores()
        {
            return empleadoService.ListarDirectores(); // Usa el método para directores
        }

        public void eliminarSucursal(int idSucursal)
        {
            var listaQueda = lista.Where(p => p.idSucursal != idSucursal).ToList();
            lista = listaQueda;
        }

        public SucursalCLS recuperarSucursalPorId(int idSucursal)
        {
            var obj = lista.Where(p => p.idSucursal == idSucursal).FirstOrDefault();
            if (obj != null)
            {
                return new SucursalCLS
                {
                    idSucursal = obj.idSucursal,
                    ciudad = obj.ciudad,
                    Region = obj.Region,
                    Num_Empl = empleadoService.obtenerIdEmpleado(obj.Director),
                    ObjetivoVenta = obj.ObjetivoVenta,
                    VentasReales = obj.VentasReales,
                };
            }
            else
            {
                return new SucursalCLS();
            }
        }

        public void guardarSucursal(SucursalCLS sucursal)
        {
            if (sucursal.idSucursal == 0)
            {
                int idSucursal = lista.Select(p => p.idSucursal).Max() + 1;
                lista.Add(new SucursalListCLS
                {
                    idSucursal = idSucursal,
                    ciudad = sucursal.ciudad,
                    Region = sucursal.Region,
                    Director = empleadoService.obtenerNombreEmpleado(sucursal.Num_Empl),
                    ObjetivoVenta = sucursal.ObjetivoVenta,
                    VentasReales = sucursal.VentasReales,
                });
            }
            else
            {
                var obj = lista.Where(p => p.idSucursal == sucursal.idSucursal).FirstOrDefault();
                if (obj != null)
                {
                    obj.ciudad = sucursal.ciudad;
                    obj.Region = sucursal.Region;
                    obj.Director = empleadoService.obtenerNombreEmpleado(sucursal.Num_Empl);
                    obj.ObjetivoVenta = sucursal.ObjetivoVenta;
                    obj.VentasReales = sucursal.VentasReales;
                }
            }
        }
    }
}
