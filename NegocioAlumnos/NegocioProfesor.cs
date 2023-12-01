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
        public static List<Nota> GetPermisos(int id) 
        {
            List<Nota> lista = new List<Nota>();
            return datosProfesores.GetPermisos(id);
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

        public static List<string> getMaterias()
        {
            return datosProfesores.getMaterias();
        }

        public static List<Nota> GetCursos()
        {
            return datosProfesores.GetCursos();
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
    }
}
