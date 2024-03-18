using EntidadAlumno;
using EntidadNota;
using EntidadProfesor;
using iTextSharp.text.pdf.codec.wmf;
using iTextSharp.text.pdf.qrcode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DatosAlumnos
{
    public class datosProfesores
    {
        public static string agregarNuevaMateriaACurso(string materia, string año, string division, string ciclo)
        {
            string error = "";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("ConfigurarCursoMateria", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                command.Parameters.AddWithValue("@materia", materia);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@Mensaje";
                outputParameter.SqlDbType = SqlDbType.VarChar;
                outputParameter.Size = 100;
                outputParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); 
                    return outputParameter.Value.ToString();
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    throw;
                }
                finally
                {
                    connection.Close(); 
                }
            }
        }
        public static string AgregarNuevoCurso(string año, string division, string ciclo)
        {
            string query = "insert into cursos (año, division, ciclo, estado) values (@año, @division, @ciclo, '1')";
            string consString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(consString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                try
                {
                    connection.Open();
                    command.ExecuteScalar();
                    connection.Close();
                    return "Se agrego exitosamente el nuevo curso";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }

            }
        }

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

        public static string cambiarEstadoCurso(string año, string division, string ciclo, string estado)
        {
            if (estado == "1")
            {
                estado = "0";
            }
            else 
            {
                estado = "1";
            }
            string query = "update cursos set año = @año, division =@division, ciclo= @ciclo, estado = @estado where año = @año and division =@division and ciclo= @ciclo";
            string consString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(consString)) 
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                command.Parameters.AddWithValue("@estado", estado);
                try
                {
                    connection.Open();
                    command.ExecuteScalar();
                    connection.Close();
                    return "Cambio exitoso!";
                } catch (Exception ex) 
                {
                    return (ex.ToString());
                }

            }
        }

        public static string cambiarPermisosParaRegistrarNotas(int modo, string etapa, string dniProfesor, string año, string division, string ciclo, string materia, string estado)
        {
            string error="";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("cambiarPermisoParaRegistrarNota", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dniProfesor", dniProfesor);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                command.Parameters.AddWithValue("@materia", materia);
               
                    command.Parameters.AddWithValue("@desde", null);
                    command.Parameters.AddWithValue("@hasta", null);
                
                
                command.Parameters.AddWithValue("@etapa", etapa);
                command.Parameters.AddWithValue("@modo", modo);
                command.Parameters.AddWithValue("@estado", estado);
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

        public static string cambiarPermisosParaRegistrarNotas(string estado, string año, string division, string ciclo, string etapa, int modo)
        {
            string error = "";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("cambiarPermisoParaRegistrarNota", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
               
                command.Parameters.AddWithValue("@etapa", etapa);
                command.Parameters.AddWithValue("@modo", modo);
                command.Parameters.AddWithValue("@estado", estado);
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

        public static string cambiarPermisosParaRegistrarNotas(string estado, string etapa, int modo)
        {
            string error = "";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("cambiarPermisoParaRegistrarNota", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.AddWithValue("@etapa", etapa);
                command.Parameters.AddWithValue("@modo", modo);
                command.Parameters.AddWithValue("@estado", estado);
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

        public static string ConfigurarCursoProfesor(int idProfesor, string año, string division, int ciclo, string materia, string error)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("ConfigurarCursoProfesor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdProfesor", idProfesor);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@materia", materia);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@Mensaje";
                outputParameter.SqlDbType = SqlDbType.VarChar;
                outputParameter.Size = 100;
                outputParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter);
                try
                {
                    connection.Open();
                    int idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    return outputParameter.Value.ToString();
                    

                    error = "Insercion exitosa. ";
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    throw;
                    
                }

            }
        }

        public static void ejecutarCambioAutomaticoPermis()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("cambioDeEtapaAutomatico", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@fecha", DateTime.Now);
                try
                {
                    connection.Open();
                    int idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    // Manejar la excepción de alguna manera (por ejemplo, registrándola)
                    // Aquí solo se relanza la excepción, considera manejarla de manera adecuada según tus necesidades
                    throw;
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
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

        public static string eliminarMateriaDeCurso(string año, string division, string ciclo, string materia)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("eliminarMateriaDeCurso", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@materia", materia);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                try
                {
                    connection.Open();
                    int idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                    
                    connection.Close();
                    return "eliminacion exitosa";
                }
                catch (Exception ex)
                {
                    return (ex.ToString());
                }

            }
        }

        public static void eliminarRelacionProfMat(int idProfesor, string materia, string curso, string division, string ciclo)
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
                command.Parameters.AddWithValue("@ciclo", ciclo);
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

        public static List<string> getAllMaterias()
        {
            List<string> lista = new List<string>();
            string query = "Select Denominación from materias";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                { 
                    lista.Add(Convert.ToString(reader["Denominación"]));
                }
                reader.Close();
                con.Close();
                return lista;
            }
        }

        public static List<Cursos> GetCursosPorProfesor(string dni)
        {
            List<Cursos> lista = new List<Cursos>();
            string query = "Select distinct c.año, c.division, c.ciclo from Materia_curso mc, directivos d, Cursos c where mc.idProfesor = d.id and d.DNI = '"+dni+"' and mc.IdCurso = c.id";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cursos c = new Cursos();
                    c.año = Convert.ToString(reader["año"]);
                    c.division = Convert.ToString(reader["division"]);
                    c.ciclo = Convert.ToString(reader["ciclo"]);
                    lista.Add(c);
                }
                reader.Close();
                con.Close();
                return lista;
            }
        }

        public static List<string> getEtapas(string dni, string materia, int id, string año, string division, int ciclo)
        {
            List<string> lista = new List<string>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("GetMateriasxCurso", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
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

        public static List<string> getMaterias(string año, string division, int ciclo)
        {
            List <string> lista = new List<string>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand("GetMateriasxCurso", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", año);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
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


        public static List<string> getMateriasXProfesor(string dni)
        {
            List<string> Materias = new List<string>();
            string query = "Select m.Denominación from Materia_curso mc, directivos d, Cursos c, Materias m where mc.idProfesor = d.id and d.DNI = '" + dni + "' and mc.IdCurso = c.id and m.id = mc.IdMateria";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string a = Convert.ToString(reader["Denominación"]);
                    Materias.Add(a);
                }
                reader.Close();
                con.Close();
                return Materias;
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
        public static List<profesor> getProfesoresConCursosActivos()
        {
            List<profesor> profesores = new List<profesor>();
            string query = "SELECT DISTINCT d.* FROM Materia_curso mc, directivos d, Cursos c WHERE d.cargo='profesor' AND d.id = mc.IdProfesor AND mc.IdCurso = c.id AND c.Estado='1'";
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
                    p.Dni = Convert.ToString(reader["DNI"]);
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
                command.Parameters.AddWithValue("@estado", p.estado);
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
                command.Parameters.AddWithValue("@estado", p.estado);
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
