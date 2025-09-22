using Actividad.Entities;

namespace Actividad.Services
{
    public class ClienteService
    {
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarBusqueda(string nombrecliente)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombrecliente);
            }
        }

        private List<ClienteListCLS> lista;
        private EmpleadoService empleadoService;

        public ClienteService(EmpleadoService _empleadoService)
        {
            empleadoService = _empleadoService;

            lista = new List<ClienteListCLS>();
            lista.Add(new ClienteListCLS { CodigoCliente = 1, NombreCliente = "Alexis", RepresentanteAsignado = "Miguel" });
            lista.Add(new ClienteListCLS { CodigoCliente = 2, NombreCliente = "Charly", RepresentanteAsignado = "Sebastian" });
        }
        public List<ClienteListCLS> listarClientes()
        {
            return lista;
        }

        public List<ClienteListCLS> filtrarClientes(string nombrecliente)
        {
            List<ClienteListCLS> l = listarClientes();
            if (nombrecliente == "")
            {
                return l;
            }
            else
            {
                List<ClienteListCLS> listafiltrada = l.Where(p => p.NombreCliente.ToUpper().Contains(nombrecliente.ToUpper())).ToList();
                return listafiltrada;
            }
        }

        public void eliminarCliente(int CodigoCliente)
        {
            var listaQueda = lista.Where(p => p.CodigoCliente != CodigoCliente).ToList();
            lista = listaQueda;
        }

        public ClienteCLS recuperarClientePorId(int CodigoCliente)
        {
            var obj = lista.Where(p => p.CodigoCliente == CodigoCliente).FirstOrDefault();
            if (obj != null)
            {
                return new ClienteCLS
                {
                    CodigoCliente = obj.CodigoCliente,
                    NombreCliente = obj.NombreCliente,
                    Num_Empl = empleadoService.obtenerIdEmpleado(obj.RepresentanteAsignado),
                    LimiteCredito = obj.LimiteCredito,
                };
            }
            else
            {
                return new ClienteCLS();
            }
        }

        public void guardarCliente(ClienteCLS cliente)
        {
            if (cliente.CodigoCliente == 0)
            {
                int CodigoCliente = lista.Select(p => p.CodigoCliente).Max() + 1;
                lista.Add(new ClienteListCLS
                {
                    CodigoCliente = CodigoCliente,
                    NombreCliente = cliente.NombreCliente,
                    RepresentanteAsignado = empleadoService.obtenerNombreEmpleado(cliente.Num_Empl),
                    LimiteCredito = cliente.LimiteCredito,
                });
            }
            else
            {
                var obj = lista.Where(p => p.CodigoCliente == cliente.CodigoCliente).FirstOrDefault();
                if (obj != null)
                {
                    obj.NombreCliente = cliente.NombreCliente;
                    obj.RepresentanteAsignado = empleadoService.obtenerNombreEmpleado(cliente.Num_Empl);
                    obj.LimiteCredito = cliente.LimiteCredito;
                }
            }
        }
    }
}
