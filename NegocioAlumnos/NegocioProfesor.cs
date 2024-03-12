using EntidadProfesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosAlumnos;
using EntidadNota;
using System.Security.Cryptography.X509Certificates;
using EntidadAlumno;

namespace NegocioAlumnos
{
    public class NegocioProfesor
    {
        public static int insertar(profesor p, string cargo)
        {
            return datosProfesores.insertar(p, cargo);
        }

        public static int buscarDirectivo(string dni, string pass) {
            int bol = datosProfesores.buscarDirectivo(dni, pass);
            return bol;
        }
        public static List<Nota> GetCursos(int id) 
        {
            List<Nota> lista = new List<Nota>();
            return datosProfesores.GetPermisos(id);
        }
        public static List<profesor> getProfesoresConCursosActivos() 
        {
            return datosProfesores.getProfesoresConCursosActivos();
        }

        public static List<Nota> GetPermisosPreceptor(int estado)
        {
            List<Nota> lista = new List<Nota>();
            return datosProfesores.GetPermisosPreceptor(estado);
        }

        public static List<profesor> GetProfesores()
        {
            
            return datosProfesores.getProfesores();
        }

        public static void eliminarRelacionProfMat(int idProfesor, string materia, string curso, string division)
        {
            datosProfesores.eliminarRelacionProfMat(idProfesor, materia, curso, division);
        }

        public static List<string> getMaterias(string año, string division, int ciclo)
        {
            return datosProfesores.getMaterias(año, division, ciclo);
        }

       

        public static string ConfigurarCursoProfesor(int idProfesor, string año, string division, string materia, string error)
        {
            return datosProfesores.ConfigurarCursoProfesor(idProfesor, año, division, materia, error);
        }

        public static int modificar(profesor p)
        {

            return datosProfesores.modificar(p);
        }

        public static void eliminar(string text)
        {
            datosProfesores.eliminar(text);
        }

        public static profesor getProfesor(string dni)
        {
            return datosProfesores.getProfesor(dni);
        }

        public static List<Cursos> GetCursosPorProfesor(string dni)
        {
            return datosProfesores.GetCursosPorProfesor(dni);
        }

        public static List<string> getMateriasXProfesor(string dni)
        {
            return datosProfesores.getMateriasXProfesor(dni);
        }

        public static string cambiarPermisosParaRegistrarNotas(int modo, string etapa, string dniProfesor, string año, string division, string ciclo, string materia, string estado)
        {
            return datosProfesores.cambiarPermisosParaRegistrarNotas(modo, etapa, dniProfesor, año, division, ciclo, materia, estado);
        }

        public static string cambiarPermisosParaRegistrarNotas(string estado,  string año, string division, string ciclo, string etapa, int modo)
        {
            return datosProfesores.cambiarPermisosParaRegistrarNotas(estado, año, division, ciclo, etapa, modo);

        }

        public static string cambiarPermisosParaRegistrarNotas(string estado, string etapa, int modo)
        {
            return datosProfesores.cambiarPermisosParaRegistrarNotas(estado, etapa, modo);
        }

        public static List<string> getEtapas(string dni, string materia, int id, string año, string division, int ciclo)
        {
            return datosProfesores.getEtapas(dni, materia, id, año, division, ciclo);
        }

        public static void ejecutarCambioAutomaticoPermiso()
        {
            datosProfesores.ejecutarCambioAutomaticoPermis();
        }
    }
}
