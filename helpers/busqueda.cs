using EntidadAlumno;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    public class busqueda
    {
       public static List<Alumno> buscar(string nombre, string apellido)
            {
            List<Alumno> lista = new List<Alumno>();
                string query = "";
                if (string.IsNullOrEmpty(apellido) && string.IsNullOrEmpty(nombre))
                {
                    query = "select * from alumnos order by nombre, apellido asc";
                }
                else
                {
                    if (!string.IsNullOrEmpty(apellido) && !string.IsNullOrEmpty(nombre))
                    {
                        query = "select * from alumnos where nombre = '" + nombre + "' and apellido = '" + apellido + "' order by nombre, apellido asc";
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(apellido))
                        {
                            query = "select * from alumnos where nombre = '" + nombre + "' order by nombre, apellido asc";
                        }
                        else
                        {
                            query = "select * from alumnos where apellido = '" + apellido + "' order by apellido, nombre asc";
                        }
                    }

                }
                return lista = Negocio.NegocioAlumnos.buscarPorNombreOApellido(nombre, apellido, query);
                

            }
        
    }
}
