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
                command.Parameters.AddWithValue("@año", a.Curso);
                command.Parameters.AddWithValue("@division", a.division);
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
                command.Parameters.AddWithValue("@p_año", a.Curso);
                command.Parameters.AddWithValue("@p_division", a.division);
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
        public static int buscar(Alumno a, string curso, string division)
        {
            int idAlumnoCreado = 0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))

            {
                connection.Open();
                SqlCommand command = new SqlCommand("BuscarAlumno", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@dni", Convert.ToDouble(a.Dni));
                if (curso != "-" && division != "-")
                {
                    command.Parameters.AddWithValue("@año", Convert.ToDouble(a.Curso));
                    command.Parameters.AddWithValue("@division", Convert.ToDouble(a.Curso));
                }
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Alumno busqueda = new Alumno();
                    a.Nombre = Convert.ToString(reader["nombre"]);
                    a.Apellido = Convert.ToString(reader["apellido"]);
                    a.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    a.Email = Convert.ToString(reader["email"]);
                    a.Domicilio = Convert.ToString(reader["Domicilio"]);
                    a.Telefono = Convert.ToString(reader["telefono"]);
                    a.Curso = Convert.ToString(reader["año"]);
                    a.division = Convert.ToString(reader["division"]);
                    a.Id = Convert.ToInt32(reader["id"]);
                    connection.Close();
                    reader.Close();
                }
            }
            return idAlumnoCreado;

        }
        public static int registrarEstado(string estado, string fecha, int dni)
        {
            int idAlumnoCreado = 0;

            string estadotraido = estado;
            DateTime Fecha = DateTime.Parse(fecha);
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {

                SqlCommand command = new SqlCommand("InsertarAsistencia", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@asistencia", estadotraido);
                command.Parameters.AddWithValue("@fecha", Fecha);
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

        public static void eliminar(string dni)
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
    }

}
