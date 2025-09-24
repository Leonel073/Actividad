using Actividad.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad.Services
{
    public class EmpleadoService
    {
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarBusqueda(string nombrerepresentante)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombrerepresentante);
            }
        }

        private List<RepresentanteListCLS> lista;
        private JefeRepresentanteService jefeService;
        private readonly Lazy<SucursalService> sucursalServiceLazy;

        public EmpleadoService(Lazy<SucursalService> _sucursalServiceLazy)
        {
            jefeService = new JefeRepresentanteService();
            sucursalServiceLazy = _sucursalServiceLazy;

            lista = new List<RepresentanteListCLS>
            {

                new RepresentanteListCLS { Num_Empl = 1, Nombre = "Juan", nombreJefe = "Charly", ciudad = "Santa Cruz", Cargo = "Director", Edad = 40, FechaContrato = DateTime.Now, Cuota = 1000, Ventas = 800 },
                new RepresentanteListCLS { Num_Empl = 2, Nombre = "Pablo", nombreJefe = "Miguel", ciudad = "La Paz", Cargo = "Empleado", Edad = 30, FechaContrato = DateTime.Now, Cuota = 500, Ventas = 400 },
                new RepresentanteListCLS { Num_Empl = 3, Nombre = "Ana", nombreJefe = "Jose", ciudad = "La Paz", Cargo = "Director", Edad = 45, FechaContrato = DateTime.Now, Cuota = 1200, Ventas = 1000 },

            };
        }

        public List<RepresentanteListCLS> listarRepresentantes()
        {
            return lista; // Devuelve TODOS los empleados para la página de representantes
        }

        public List<RepresentanteListCLS> ListarDirectores()
        {
            return lista.Where(p => p.Cargo == "Director").ToList(); // Devuelve solo directores para sucursales
        }

        public List<RepresentanteListCLS> filtrarRepresentantes(string nombrerepresentante)
        {
            List<RepresentanteListCLS> l = listarRepresentantes();
            if (string.IsNullOrEmpty(nombrerepresentante))
            {
                return l;
            }
            else
            {
                List<RepresentanteListCLS> listafiltrada = l.Where(p => p.Nombre.ToUpper().Contains(nombrerepresentante.ToUpper())).ToList();
                return listafiltrada;
            }
        }

        public void eliminarEmpleado(int Num_Empl)
        {
            var listaQueda = lista.Where(p => p.Num_Empl != Num_Empl).ToList();
            lista = listaQueda;
        }

        public RepresentantesVentasCLS recuperarRepresentantePorId(int Num_Empl)
        {
            var obj = lista.FirstOrDefault(p => p.Num_Empl == Num_Empl);
            if (obj != null)
            {
                return new RepresentantesVentasCLS
                {
                    Num_Empl = obj.Num_Empl,
                    Nombre = obj.Nombre,
                    Cargo = obj.Cargo,
                    Edad = obj.Edad,
                    FechaContrato = obj.FechaContrato,
                    Cuota = obj.Cuota,
                    Ventas = obj.Ventas,
                    idJefe = jefeService.obtenerIdJefe(obj.nombreJefe),
                    idSucursal = sucursalServiceLazy.Value.obtenerIdSucursal(obj.ciudad)
                };
            }
            else
            {
                return new RepresentantesVentasCLS();
            }
        }

        public int obtenerIdEmpleado(string Nombre)
        {
            var obj = lista.FirstOrDefault(p => p.Nombre == Nombre);
            return obj?.Num_Empl ?? 0;
        }

        public string obtenerNombreEmpleado(int Num_Empl)
        {
            var obj = lista.FirstOrDefault(p => p.Num_Empl == Num_Empl);
            return obj?.Nombre ?? "";
        }

        public void guardarRepresentante(RepresentantesVentasCLS representante)
        {
            if (representante.Num_Empl == 0)
            {
                int Num_Empl = lista.Any() ? lista.Max(p => p.Num_Empl) + 1 : 1;
                lista.Add(new RepresentanteListCLS
                {
                    Num_Empl = Num_Empl,
                    Nombre = representante.Nombre,
                    Edad = representante.Edad,
                    Cargo = representante.Cargo,
                    FechaContrato = representante.FechaContrato,
                    Cuota = representante.Cuota,
                    Ventas = representante.Ventas,
                    nombreJefe = jefeService.obtenerNombreJefe(representante.idJefe),
                    ciudad = sucursalServiceLazy.Value.obtenerNombreSucursal(representante.idSucursal)
                });
            }
            else
            {
                var obj = lista.FirstOrDefault(p => p.Num_Empl == representante.Num_Empl);
                if (obj != null)
                {
                    obj.Nombre = representante.Nombre;
                    obj.Edad = representante.Edad;
                    obj.Cargo = representante.Cargo;
                    obj.FechaContrato = representante.FechaContrato;
                    obj.Cuota = representante.Cuota;
                    obj.Ventas = representante.Ventas;
                    obj.nombreJefe = jefeService.obtenerNombreJefe(representante.idJefe);
                    obj.ciudad = sucursalServiceLazy.Value.obtenerNombreSucursal(representante.idSucursal);
                }
            }
        }
    }
}