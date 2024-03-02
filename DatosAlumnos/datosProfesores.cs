using EntidadAlumno;
using EntidadNota;
using EntidadProfesor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatosAlumnos
{
    public class datosProfesores
    {

        public static int buscarDirectivo(string dni, string pass)
        {
            string query = "SELECT COUNT(*) FROM directivos WHERE cargo = 'director' AND DNI = @dni AND contraseña=@pass";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString)) {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue ("@pass", pass);
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    return 0;
                } else
                {
                    return 1;
                }
            }

            
        }

        public static string ConfigurarCursoProfesor(int idProfesor, string año, string division, string materia, string error)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("ConfigurarCursoProfesor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdProfesor", idProfesor);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@materia", materia);
                try
                {
                    connection.Open();
                    int idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close(); 
                    error = "Insercion exitosa. ";
                    return error;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    throw;
                    
                }

            }
        }

        public static void eliminar(string text)
        {
            int idAlumnoCreado = 1;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            string query = "DELETE FROM DIRECTIVOS WHERE DNI = @dni";

            using (SqlConnection connection = new SqlConnection(conString))
            {

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@dni", text);
                try
                {
                    connection.Open();
                    idAlumnoCreado = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void eliminarRelacionProfMat(int idProfesor, string materia, string curso, string division)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("EliminarRelacionProfMat", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProf", idProfesor);
                command.Parameters.AddWithValue("@materia", materia);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@año", curso);
                try
                {
                    connection.Open();
                    int idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }

       

        public static List<string> getMaterias()
        {
            List <string> lista = new List<string>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("GetMaterias", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   
                    string Materia = Convert.ToString(reader["Denominación"]);
                    lista.Add(Materia);
                }
                reader.Close();
                con.Close();
                return lista;
            }
        }

        public static List<Nota> GetPermisos(int id)
        {
            List<Nota> lista = new List<Nota>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("CursosGetxProfesor", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idProfesor", id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Nota n = new Nota();
                    n.id = Convert.ToInt32(reader["id"]);
                    n.Curso = Convert.ToString(reader["año"]);
                    n.Division = Convert.ToString(reader["division"]);
                    n.ciclo = Convert.ToInt32(reader["ciclo"]);
                    n.Materia = Convert.ToString(reader["materia"]);
                    lista.Add(n);
                }
                reader.Close();
                con.Close();
                return lista;
            }
        }

        public static List<Nota> GetPermisosPreceptor(int estado)
        {
            List<Nota> lista = new List<Nota>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("GetCursos", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@estado", estado);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Nota n = new Nota();
                    n.Curso = Convert.ToString(reader["año"]);
                    n.Division = Convert.ToString(reader["division"]);
                    n.ciclo = Convert.ToInt32(reader["ciclo"]);
                    
                    lista.Add(n);
                }
                reader.Close();
                con.Close();
                return lista;
            }
        }

        public static profesor getProfesor(string dni)
        {
            profesor p = new profesor();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("getProfesor", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", dni);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    p.Dni = Convert.ToString(reader["dni"]);
                    p.Nombre = Convert.ToString(reader["nombre"]);
                    p.Apellido = Convert.ToString(reader["apellido"]);
                    p.FechaNacimiento = Convert.ToDateTime(reader["fechadenacimiento"]);
                    p.Email = Convert.ToString(reader["email"]);
                    p.barrio = Convert.ToString(reader["barrio"]);
                    p.calle = Convert.ToString(reader["calle"]);
                    p.altura = Convert.ToString(reader["altura"]);
                    p.edificio = Convert.ToString(reader["edificio"]);
                    p.piso = Convert.ToString(reader["piso"]);
                    p.numero_dpto = Convert.ToString(reader["numero_dpto"]);
                    p.indicacion = Convert.ToString(reader["indicacion"]);

                    p.Telefono = Convert.ToString(reader["telefono"]);

                }
                reader.Close();
                con.Close();
                return p;
            }
        }

        public static List<profesor> getProfesores()
        {
            List<profesor> profesores = new List<profesor>();
            string query = "SELECT nombre, apellido, id FROM directivos WHERE cargo = 'profesor'";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    profesor p = new profesor();
                    p.Id = Convert.ToInt32(reader["id"]);
                    p.Nombre = Convert.ToString(reader["nombre"]);
                    p.Apellido = Convert.ToString(reader["apellido"]);
                    profesores.Add(p);
                }
                reader.Close();
                connection.Close();
                return profesores;

            }
        }

        public static int insertar(profesor p, string cargo)
        {
            int idAlumnoCreado=0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("insertarProfesor", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", p.Nombre);
                command.Parameters.AddWithValue("@apellido", p.Apellido);
                command.Parameters.AddWithValue("@dni", p.Dni);
                command.Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);
                command.Parameters.AddWithValue("@email", p.Email);
                command.Parameters.AddWithValue("@barrio", p.barrio);
                command.Parameters.AddWithValue("@calle", p.calle);
                command.Parameters.AddWithValue("@altura", p.altura);
                command.Parameters.AddWithValue("@edificio", p.edificio);
                command.Parameters.AddWithValue("@piso", p.piso);
                command.Parameters.AddWithValue("@numero_dpto", p.numero_dpto);
                command.Parameters.AddWithValue("@indicacion", p.indicacion);
                command.Parameters.AddWithValue("@Telefono", p.Telefono);
                command.Parameters.AddWithValue("@contraseña", p.contraseña);
                command.Parameters.AddWithValue("@cargo", cargo);
                try
                {
                    con.Open();
                    idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }

                return idAlumnoCreado;
            }

        }

        public static int modificar(profesor p)
        {
            int idAlumnoCreado = 0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("ModificarProfesor", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", p.Nombre);
                command.Parameters.AddWithValue("@apellido", p.Apellido);
                command.Parameters.AddWithValue("@dni", p.Dni);
                command.Parameters.AddWithValue("@fechaNacimiento", p.FechaNacimiento);
                command.Parameters.AddWithValue("@email", p.Email);
                command.Parameters.AddWithValue("@barrio", p.barrio);
                command.Parameters.AddWithValue("@calle", p.calle);
                command.Parameters.AddWithValue("@altura", p.altura);
                command.Parameters.AddWithValue("@edificio", p.edificio);
                command.Parameters.AddWithValue("@piso", p.piso);
                command.Parameters.AddWithValue("@numero_dpto", p.numero_dpto);
                command.Parameters.AddWithValue("@indicacion", p.indicacion);
                command.Parameters.AddWithValue("@Telefono", p.Telefono);
                command.Parameters.AddWithValue("@contraseña", p.contraseña);
                command.Parameters.AddWithValue("@cargo", "Profesor");
                try
                {
                    con.Open();
                    idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }

                return idAlumnoCreado;
            }
        }
    }


}
