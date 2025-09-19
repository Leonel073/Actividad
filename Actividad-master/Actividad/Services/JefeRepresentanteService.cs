using Actividad.Entities;

namespace Actividad.Services
{
    public class JefeRepresentanteService
    {
        private List<JefeRepresentanteCLS> lista;
        public JefeRepresentanteService()
        {
            lista = new List<JefeRepresentanteCLS>();
            lista.Add(new JefeRepresentanteCLS() { idJefe = 2, nombreJefe = "Rudy" });
            lista.Add(new JefeRepresentanteCLS() { idJefe = 3, nombreJefe = "Oscar" });
        }
        public List<JefeRepresentanteCLS> listarJefes()
        {
            return lista;
        }
        public int obtenerIdJefe(string nombreJefe)
        {
            var obj = lista.Where(p => p.nombreJefe == nombreJefe).FirstOrDefault();
            if(obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idJefe;
            }
        }
        public string obtenerNombreJefe(int idJefe)
        {
            var obj = lista.Where(p => p.idJefe == idJefe).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.nombreJefe;
            }
        }
    }
}
