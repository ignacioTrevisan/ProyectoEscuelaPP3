using EntidadAlumno;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadPermiso;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Globalization;
using EntidadNota;

namespace DatosAlumnos
{
    public class AlumnosDatos
    {
        public static int insertar(Alumno a)
        {
            int idAlumnoCreado = 0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("alumnosInsert", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", a.Nombre);
                command.Parameters.AddWithValue("@apellido", a.Apellido);
                command.Parameters.AddWithValue("@dni", a.Dni);
                command.Parameters.AddWithValue("@fechaNacimiento", a.FechaNacimiento);
                command.Parameters.AddWithValue("@email", a.Email);
                command.Parameters.AddWithValue("@domicilio", a.Domicilio);
                command.Parameters.AddWithValue("@telefono", a.Telefono);
                
                try
                {
                    connection.Open();
                    idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception)
                {
                    throw;
                }
                return idAlumnoCreado;

            }
        }
        public static int modificar(Alumno a)
        {
            int idAlumnoCreado = 0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("modificar_alumno", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_dni", a.Dni);
                command.Parameters.AddWithValue("@p_nombre", a.Nombre);
                command.Parameters.AddWithValue("@p_apellido", a.Apellido);
                command.Parameters.AddWithValue("@p_fecha_nacimiento", a.FechaNacimiento);
                command.Parameters.AddWithValue("@p_email", a.Email);
                command.Parameters.AddWithValue("@p_domicilio", a.Domicilio);
                command.Parameters.AddWithValue("@p_telefono", a.Telefono);
                try
                {
                    connection.Open();
                    idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception)
                {
                    throw;

                }
                return idAlumnoCreado;
                connection.Close();
            }

        }
        public static List<Alumno> buscar(string nombre, string apellido, string dni)
        {
            List<Alumno> lista = new List<Alumno>();
            int idAlumnoCreado = 0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))

            {
                connection.Open();
                SqlCommand command = new SqlCommand("BuscarAlumno", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", (nombre));
                command.Parameters.AddWithValue("@apellido", (apellido));
                command.Parameters.AddWithValue("@dni", (dni));
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Alumno b = new Alumno();
                    b.Nombre = Convert.ToString(reader["nombre"]);
                    b.Dni = Convert.ToString(reader["dni"]);
                    b.Apellido = Convert.ToString(reader["apellido"]);
                    b.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    b.Email = Convert.ToString(reader["email"]);
                    b.Domicilio = Convert.ToString(reader["Domicilio"]);
                    b.Telefono = Convert.ToString(reader["telefono"]);
                    b.Id = Convert.ToInt32(reader["id"]);
                    lista.Add(b);
                }
                connection.Close();
                reader.Close();
            }
            return lista;

        }
        public static int registrarEstado(string estado, DateTime fecha, int dni, string curso, string division, int ciclo)
        {
            int idAlumnoCreado = 0;

           
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {

                SqlCommand command = new SqlCommand("InsertarAsistencia", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@asistencia", estado);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                try
                {

                    connection.Open();
                    idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception)
                {
                    throw;
                }
                return idAlumnoCreado;
            }


        }
        public static Permisos buscarCargo(Permisos p)
        {



            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("VerificarUsuario", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DNI", p.dni);
                command.Parameters.AddWithValue("@contraseña", p.pass);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    p.Desc = Convert.ToString(reader["cargo"]);
                    p.id = Convert.ToInt32(reader["id"]);

                    connection.Close();
                    reader.Close();

                }
                return p;
            }

        }
        public static DataTable buscarinasistencias()
        {

            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("MostrarAlumnosAusentes", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Aquí debes cerrar la conexión a tu base de datos
                return dt;


            }
        }

        public static List<Alumno> Get(string nombre, int ciclo)
        {
            List<Alumno> list = new List<Alumno>();

            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("alumnosGet", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@ciclo", ciclo);


                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Alumno busqueda = new Alumno();
                        busqueda.Nombre = Convert.ToString(reader["nombre"]);
                        busqueda.Apellido = Convert.ToString(reader["apellido"]);
                        busqueda.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                        busqueda.Email = Convert.ToString(reader["email"]);
                        busqueda.Dni = Convert.ToString(reader["dni"]);
                        busqueda.Domicilio = Convert.ToString(reader["Domicilio"]);
                        busqueda.Telefono = Convert.ToString(reader["telefono"]);
                        busqueda.Curso = Convert.ToString(reader["año"]);
                        busqueda.division = Convert.ToString(reader["division"]);
                        busqueda.cantidadFaltas = Convert.ToInt32(reader["CantidadAusencias"]);
                        busqueda.Id = Convert.ToInt32(reader["id"]);
                        list.Add(busqueda);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }
        public static List<Alumno> Get(string nombre, string curso, string division, int ciclo)
        {
            List<Alumno> list = new List<Alumno>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("alumnosGetXNombre", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombe", nombre);
                command.Parameters.AddWithValue("@curso", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);

                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Alumno busqueda = new Alumno();
                        busqueda.Nombre = Convert.ToString(reader["nombre"]);
                        busqueda.Apellido = Convert.ToString(reader["apellido"]);
                        busqueda.Dni = Convert.ToString(reader["dni"]);
                        busqueda.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                        busqueda.Email = Convert.ToString(reader["email"]);
                        busqueda.Domicilio = Convert.ToString(reader["Domicilio"]);
                        busqueda.Telefono = Convert.ToString(reader["telefono"]);
                        busqueda.Curso = Convert.ToString(reader["año"]);
                        busqueda.division = Convert.ToString(reader["division"]);
                        busqueda.Id = Convert.ToInt32(reader["id"]);
                        busqueda.cantidadFaltas = Convert.ToInt32(reader["CantidadAusencias"]);

                        list.Add(busqueda);

                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }
        public static List<Alumno> GetXCurso(string nombre, string curso, string division, int ciclo)
        {
            List<Alumno> list = new List<Alumno>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("alumnosGetXCurso", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);

                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Alumno busqueda = new Alumno();
                        busqueda.Nombre = Convert.ToString(reader["nombre"]);
                        busqueda.Apellido = Convert.ToString(reader["apellido"]);
                        busqueda.Dni = Convert.ToString(reader["dni"]);
                        busqueda.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                        busqueda.Email = Convert.ToString(reader["email"]);
                        busqueda.Domicilio = Convert.ToString(reader["Domicilio"]);
                        busqueda.Telefono = Convert.ToString(reader["telefono"]);
                        busqueda.Curso = Convert.ToString(reader["año"]);
                        busqueda.division = Convert.ToString(reader["division"]);
                        busqueda.Id = Convert.ToInt32(reader["id"]);
                        busqueda.cantidadFaltas = Convert.ToInt32(reader["CantidadAusencias"]);

                        list.Add(busqueda);

                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }


        public static List<Faltas> buscarfaltas(string dni)
        {
            List<Faltas> list = new List<Faltas>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("verFaltas", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", dni);

                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Faltas busqueda = new Faltas();
                        busqueda.nombre = Convert.ToString(reader["nombre"]);
                        busqueda.apellido = Convert.ToString(reader["apellido"]);
                        busqueda.fecha = Convert.ToString(reader["fecha"]);
                        busqueda.estado = Convert.ToString(reader["estado"]);
                        list.Add(busqueda);

                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }

        public static string getgmail(string text)
        {
            string gmail = "";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                Connection.Open();

                SqlCommand command = new SqlCommand("getGmail", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", text);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gmail = Convert.ToString(reader["email"]);
                }
            }
            return gmail;
        }

        /*public static void eliminar(string dni)
        {
            int idAlumnoCreado = 1;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("eliminarAlumno", connection);

                cmd.Parameters.AddWithValue("@dni", dni);
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
        */

        public static void eliminar(string dni)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("eliminarAlumno", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;  // Establece el tipo de comando como un procedimiento almacenado
                    cmd.Parameters.AddWithValue("@dni", dni);

                    try
                    {
                        cmd.ExecuteNonQuery();  // Ejecuta la instrucción SQL para eliminar el alumno
                    }
                    catch (Exception ex)
                    {
                        // Maneja la excepción adecuadamente (puedes imprimir o registrar la excepción)
                        Console.WriteLine("Error al eliminar el alumno: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public static List<Faltas> verTodasFaltas()
        {
            List<Faltas> list = new List<Faltas>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("VerTodasLasAsitencias", Connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Faltas busqueda = new Faltas();
                      
                        busqueda.fecha = Convert.ToString(reader["fecha"]);
                        busqueda.estado = Convert.ToString(reader["estado"]);
                        busqueda.nombre = Convert.ToString(reader["nombre"]);
                        busqueda.apellido = Convert.ToString(reader["apellido"]);
                        list.Add(busqueda);

                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return list;
        }

        public static List<Alumno> TraerAsistenciasDeHoy(string curso, string division, DateTime dateTime, int ciclo)
        {
            List<Alumno> listas = new List<Alumno>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("VerAsistenciasDelDia", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@fecha", dateTime);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);


                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    



                    while (reader.Read())
                    {
                        Alumno busqueda = new Alumno();

                        busqueda.Nombre = Convert.ToString(reader["nombre"]);
                        busqueda.Apellido = Convert.ToString(reader["apellido"]);
                        busqueda.estado = Convert.ToString(reader["estado"]);
                        busqueda.Dni = Convert.ToString(reader["dni"]);
                        listas.Add(busqueda);
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return listas;
        }

        public static List<Nota> getCursosDirector()
        {
            List<Nota> listas = new List<Nota>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("GetCursos", Connection);
                

                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();




                    while (reader.Read())
                    {
                        Nota busqueda = new Nota();

                        busqueda.Curso = Convert.ToString(reader["año"]);
                        busqueda.Division = Convert.ToString(reader["division"]);
                        
                        busqueda.ciclo = Convert.ToInt16(reader["ciclo"]);
                        listas.Add(busqueda);
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return listas;
        }

        public static List<Cursos> getCurso(int dni)
        {
            List<Cursos> listas = new List<Cursos>();


            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("GetHistorialCursosXdni", Connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", dni);

                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cursos busqueda = new Cursos();
                        busqueda.año = Convert.ToString(reader["año"]);
                        busqueda.division = Convert.ToString(reader["division"]);
                        busqueda.ciclo = Convert.ToString(reader["ciclo"]);
                        listas.Add(busqueda);
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return listas;
        }
    }

}
