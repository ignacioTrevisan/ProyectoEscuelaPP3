using EntidadAlumno;
using System.Data.SqlClient;
using System.Configuration;
using DatosAlumnos;
using System;
using EntidadPermiso;
using System.Data;
using System.Dynamic;
using System.Collections.Generic;
using EntidadNota;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class NegocioAlumnos
    {

        public static List<barrios> getBarrios() 
        {
            List<barrios> list = new List<barrios>();
            return list = AlumnosDatos.getBarrios();
        }
        public static Permisos buscarCargo(Permisos p)
        {
            try
            {
                return AlumnosDatos.buscarCargo(p);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static int insertar(Alumno a)
        {
            if (a.FechaNacimiento == null)
            {
                a.FechaNacimiento = DateTime.Now;
            }
            
            try
            {
                return AlumnosDatos.insertar(a);
            }
            catch (Exception)
            {
                throw;
            }
            
            
            

        }
        public static int editar(Alumno a)
        {
            if (String.IsNullOrEmpty(a.Nombre))
            {
                return 0;
            }
            if (a.Dni == "")
            {
                return 0;
            }
            if (a.FechaNacimiento == null)
            {
                a.FechaNacimiento = DateTime.Now;
            }
            try
            {
                return AlumnosDatos.modificar(a);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Alumno> buscar(string nombre, string apellido, string dni)
        {
            
            try
            {
                return AlumnosDatos.buscar(nombre, apellido, dni);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int registrarEstado(string estado, DateTime fecha, int dni, string curso, string division, int ciclo)
            {
            
            try
            {
                return AlumnosDatos.registrarEstado(estado, fecha , dni, curso, division, ciclo  );
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static DataTable buscarinasistencias() 
        {
            return AlumnosDatos.buscarinasistencias();
        }

        public static List<Alumno> Get( string dni, string nombre ,int ciclo)
        {
            return AlumnosDatos.Get(dni, nombre, ciclo);
        }

        public static List<Alumno> Get(string nombre, string curso, string division, int ciclo)
        {
            return AlumnosDatos.Get( nombre, curso, division, ciclo);
        }
        public static List<Alumno> GetXCurso(string nombre, string curso, string division, int ciclo)
        {
            return AlumnosDatos.GetXCurso(nombre, curso, division, ciclo);
        }

        public static List<Faltas> BuscarFaltas(string dni, int ciclo, string curso, string division)
        {

            return AlumnosDatos.buscarfaltas(dni, ciclo, curso, division);
        }

        public static string getgmail(string text)
        {
            return AlumnosDatos.getgmail(text);
        }

        public static void eliminar(string dni)
        {
            AlumnosDatos.eliminar(dni);
        }

        public static List<Faltas> BuscarTodasFaltas()
        {
            return AlumnosDatos.verTodasFaltas();
        }

        public static List<Alumno> TraerAsistenciasDeHoy(string curso, string division, DateTime value, int ciclo)
        {
            return AlumnosDatos.TraerAsistenciasDeHoy(curso, division, value, ciclo);
        }

        public static List<Nota> GetCursosDirector()
        {
            return AlumnosDatos.getCursosDirector();
        }

        public static List<Cursos> GetCursos(int dni)
        {
            return AlumnosDatos.getCurso(dni);
        }

        public static void inscribir(string dni, string curso, string division, int ciclo)
        {
            AlumnosDatos.inscribir(dni, curso, division, ciclo);
        }

        public static List<string> getaAllgmail(string v)
        {
            return AlumnosDatos.getAllGmail(v);
        }

        public static List<string> getaAllgmailDoc(string v)
        {
            return AlumnosDatos.getAllGmailDoc(v);
        }

        public static List<string> getAllGmailCurso(string curso, string divison, int ciclo)
        {
            return AlumnosDatos.getAllGmailCurso(curso,  divison,  ciclo);
        }
        
        public static List<Alumno> getPorcentaje()
        {
            return AlumnosDatos.getPorcentaje();
        }
        public static List<Alumno> getPorcentajeTomado(DateTime fecha)
        {
            return AlumnosDatos.getPorcentajeTomado(fecha);
        }

        public static List<Cursos> GetCursosActivos()
        {
            return AlumnosDatos.getCursosActivos();
        }

        public static float getPromedio(string dni, string materia, string curso, string division, int ciclo, string etapa)
        {
            return AlumnosDatos.getPromedio(dni, materia, curso, division, ciclo, etapa);
        }
    }
   
}
