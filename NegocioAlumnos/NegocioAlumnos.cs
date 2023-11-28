using EntidadAlumno;
using System.Data.SqlClient;
using System.Configuration;
using DatosAlumnos;
using System;
using EntidadPermiso;
using System.Data;
using System.Dynamic;
using System.Collections.Generic;

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
            if (a.Dni == "")
            {
                return 1;
            }
            try
            {
                return AlumnosDatos.buscar(a, curso, division);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int registrarEstado(string estado, string fecha, string dni)
            {
            
            try
            {
                return AlumnosDatos.registrarEstado(estado, fecha , dni  );
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

        public static List<Alumno> Get( double dni)
        {
            return AlumnosDatos.Get(dni);
        }

        public static List<Alumno> Get(double dni, string curso, string division)
        {
            return AlumnosDatos.Get( dni, curso, division);
        }

        public static List<Alumno> Get(string nombre, string curso, string division)
        {
            return AlumnosDatos.Get(nombre, curso, division);
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
    }
   
}
