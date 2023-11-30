using DatosAlumnos;
using EntidadRecursosSalas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datosRecursos;

namespace NegocioAlumnos
{
    public class NegociosRecursosSalas
    {
        public static List<ReservasRecursosSalas> GetReservas(List<ReservasRecursosSalas> lista)
        {
            return DatosRecursosSalas.GetReservas(lista);
        }
        public static int RegistrarReservas(string recurso, string fecha,string horarioDesde, string horarioHasta, string comentario, int profesor)    
        {
            int id = DatosRecursosSalas.RegistrarReservas(recurso, fecha,horarioDesde, horarioHasta, comentario, profesor);
            return id;
        }
        public static List<string> GetRecursos() 
        {
            List<string> lista = new List<string>();
            return lista = DatosRecursosSalas.GetRecursos();
        }

        public static int Eliminar(int id, int idProf, string cargo)
        {
            int a = DatosRecursosSalas.Eliminar(id, idProf, cargo);
            return a;
        }
    }
}
