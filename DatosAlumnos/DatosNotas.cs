﻿using EntidadAlumno;
using EntidadNota;
using EntidadProfesor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosNotas
{
    public class NotasDatos
    {
        public static List<boletin> armarboletin(string dni, int curso, int division, int ciclo)
        {
            List<boletin> boletin = new List<boletin>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("ArmarBoletin", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        boletin b = new boletin();
                        
                        b.materia = Convert.ToString(reader["materia"]);
                        b.nota = Convert.ToString(reader["nota"]);
                        
                        boletin.Add(b);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return boletin;
        }

        public static int Eliminar(int id)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("EliminarNota", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    int idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return 1;
            }
        }

        public static List<string> GetMateriasxCurso(string curso, string division, int ciclo, string dnii)
        {
            List<string> materias = new List<string>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("GetMateriasXcurso", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string denominacion = Convert.ToString(reader["Denominación"]);
                        materias.Add(denominacion);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return materias;

            }
        }

        public static List<Nota> GetNotas(string curso, string division, string materia, int ciclo)
        {
            List<Nota> notasLista = new List<Nota>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("GetNotasF", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@materia", materia);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Nota n = new Nota();
                        
                        n.Nombre = Convert.ToString(reader["nombre"]);
                        n.Apellido = Convert.ToString(reader["apellido"]);
                        n.Materia = Convert.ToString(reader["materia"]);
                        n.Dni = Convert.ToString(reader["dni"]);
                        n.comentario = Convert.ToString(reader["comentario"]);
                        n.Calificacion = Convert.ToString(reader["Nota"]);
                        n.fecha = Convert.ToString(reader["fecha"]);
                        notasLista.Add(n);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return notasLista;
        }

        public static List<Nota> GetNotasXAlumno(string dni, string materia, int idProfesor, string curso, string division, int ciclo)
        {
            List<Nota> alumno = new List<Nota>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))

            {
                SqlCommand command = new SqlCommand("GetNotasXAlumno", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@materia", materia);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Nota n = new Nota();
                        n.Dni = Convert.ToString(reader["dni"]);
                        n.Nombre = Convert.ToString(reader["nombre"]);
                        n.Apellido = Convert.ToString(reader["apellido"]);
                        n.Materia = Convert.ToString(reader["materia"]);
                        n.Calificacion = Convert.ToString(reader["Nota"]);
                        n.comentario = Convert.ToString(reader["Comentario"]);
                        n.fecha = Convert.ToString(reader["fecha"]);
                        alumno.Add(n);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return alumno;
        
        }

        public static List<Nota> GetNotasXdni(string dni, string v, int curso, int division, int ciclo)
        {
            List<Nota> alumno = new List<Nota>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString)) 
            {
                SqlCommand command = new SqlCommand("GetNotasXdni", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@Deno", v);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        Nota n = new Nota();
                        n.id = Convert.ToInt16(reader["ID"]);
                        n.Dni = Convert.ToString(reader["DniAlumno"]);
                        n.Calificacion = Convert.ToString(reader["nota"]);
                        n.comentario = Convert.ToString(reader["Comentario"]);
                        n.fecha = Convert.ToString(reader["fecha"]);
                        alumno.Add(n);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return alumno;
            }
        }

        public static int registroNotas(string materia, string alumno, string nota, int profesor, DateTime fecha, string comentario, string curso, string division, int ciclo)
        {
            int idAlumnoCreado = 0;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))

            {

                SqlCommand command = new SqlCommand("IngresarNotas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@dni", Convert.ToString(alumno));
                command.Parameters.AddWithValue("@materia", Convert.ToString(materia));
                command.Parameters.AddWithValue("@nota", Convert.ToString(nota));
                command.Parameters.AddWithValue("@idprofesor", (profesor));
                command.Parameters.AddWithValue("@fecha", fecha);
                command.Parameters.AddWithValue("@Comentario", comentario);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);


                try
                {

                    connection.Open();
                    idAlumnoCreado = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
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
