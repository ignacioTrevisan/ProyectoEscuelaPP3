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

namespace Negocio
{
    public class NegocioAlumnos
    {
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
        public static int buscar(Alumno a, string curso, string division)
        {
            
            try
            {
                return AlumnosDatos.buscar(a, curso, division);
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

        public static List<Alumno> Get( string nombre, int ciclo)
        {
            return AlumnosDatos.Get(nombre, ciclo);
        }

        public static List<Alumno> Get(string nombre, string curso, string division, int ciclo)
        {
            return AlumnosDatos.Get( nombre, curso, division, ciclo);
        }
        public static List<Alumno> GetXCurso(string nombre, string curso, string division, int ciclo)
        {
            return AlumnosDatos.GetXCurso(nombre, curso, division, ciclo);
        }

        public static List<Faltas> BuscarFaltas(string dni)
        {

            return AlumnosDatos.buscarfaltas(dni);
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

        public static List<Alumno> TraerAsistenciasDeHoy(string curso, string division, DateTime value)
        {
            return AlumnosDatos.TraerAsistenciasDeHoy(curso, division, value);
        }

        public static List<Nota> GetCursosDirector()
        {
            return AlumnosDatos.getCursosDirector();
        }
    }
   
}
