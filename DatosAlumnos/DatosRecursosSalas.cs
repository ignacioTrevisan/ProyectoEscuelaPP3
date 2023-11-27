﻿using EntidadProfesor;
using EntidadRecursosSalas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EntidadRecursosSalas;

namespace datosRecursos
{
    public class DatosRecursosSalas
    {
        public static List<ReservasRecursosSalas> GetReservas(List<ReservasRecursosSalas> lista)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            { 
                connection.Open();
                SqlCommand command = new SqlCommand("GetReserva", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReservasRecursosSalas re = new ReservasRecursosSalas();
                    re.id = Convert.ToInt32(reader["Id"]);
                    re.fecha = Convert.ToDateTime(reader["Fecha"]);
                    re.estado = Convert.ToString(reader["estado"]);
                    re.recurso = Convert.ToString(reader["recurso"]);
                    re.dniProfesor = Convert.ToString(reader["dniProfesor"]);
                    re.comentario = Convert.ToString(reader["Comentarios"]);
                    re.Hora = Convert.ToString(reader["hora"]);
                    lista.Add(re);
                }
            }
            return lista;

        }
        public void RegistrarSalasRecursos(string descripcion)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("RegistrarRecursosSalas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@descripcion", descripcion);
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static int RegistrarReservas(string recurso, string fecha, string horario,string estado, string comentario, string profesor)
        {
            int idAlumnoCreado = 0;
            DateTime Fecha = DateTime.Parse(fecha);
            string resultado = TimeSpan.FromHours(Convert.ToInt32(horario)).ToString("hh':'mm");
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("ReservasRecursosSalas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@recurso", recurso);
                command.Parameters.AddWithValue("@fecha", Fecha);
                command.Parameters.AddWithValue("@estado", estado);
                command.Parameters.AddWithValue("@comentario", comentario);
                command.Parameters.AddWithValue("@IdProfesor", profesor);
                command.Parameters.AddWithValue("@horario", resultado);
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

        public static List<string> GetRecursos()
        {
            List<string> lista = new List<string>();
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetRecursos", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string descripcion = Convert.ToString(reader["descripcion"]);
                    lista.Add(descripcion);
                }
                return lista;
            }
        }

        public static int Eliminar(int id)
        {
            
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("deleteReserva", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                try
                {
                    return Convert.ToInt32(command.ExecuteScalar()); 
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
    }
}
