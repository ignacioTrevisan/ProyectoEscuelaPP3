using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NegocioAlumnos;
using EntidadAlumno;
using static Negocio.NegocioAlumnos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static ProyectoEscuela.inicioSesion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;
using NotasAlumnos;
using System.Data.SqlClient;
using EntidadNota;
using System.Net;
using System.Collections;

namespace ProyectoEscuela
{
    public partial class consulta : Form
    {
        List<Alumno> ListaAlumnos = new List<Alumno>();
        List<Alumno> alumnoInforme = new List<Alumno>();
        List<Faltas> faltas = new List<Faltas>();
        List<boletin> boletin = new List<boletin>();
        List<Nota> lista = new List<Nota>();
        public consulta()
        {
            InitializeComponent();
            buscarAlumnos("0");
        }

        public static class VaribalesParaConsultaParticular
        {
            public static int ciclo = 0;
            public static string dni = "";
            public static string apellido = "";
            public static string nombre = "";
            public static string año = "";
            public static string division = "";
        }
        private void mostrarAlumnos()
        {
            DataTable dt = Negocio.NegocioAlumnos.buscarinasistencias();
            dataGridView1.DataSource = dt;

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string dni = "";
            string query = "";
            List<Nota> listaRepetida = new List<Nota>();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // verificar si se hizo clic en una celda válida
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row != null)
                {
                    dni = row.Cells[2].Value.ToString();
                    query = "select *, año, division, ciclo , nombre, apellido from Inscripciones i, Cursos c , alumnos where i.dniAlumno = '" + dni + "' and idCurso=c.id and alumnos.dni = i.dniAlumno";
                }
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(conString))

                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Nota b = new Nota();
                        b.Dni = Convert.ToString(reader["dniAlumno"]);
                        b.Nombre = Convert.ToString(reader["nombre"]);
                        b.Apellido = Convert.ToString(reader["apellido"]);
                        b.Curso = Convert.ToString(reader["año"]);
                        b.Division = Convert.ToString(reader["division"]);
                        b.ciclo = Convert.ToInt32(reader["ciclo"]);
                        listaRepetida.Add(b);
                    }
                    connection.Close();
                    reader.Close();
                }
                
                if (listaRepetida.Count > 1)
                {
                    cambiarVisibilidad(true);
                    dataGridView1.DataSource = null;
                    dataGridView2.DataSource = listaRepetida;
                    
                }
                else
                {
                    if (listaRepetida.Count == 1)
                    {
                        VaribalesParaConsultaParticular.nombre = listaRepetida[0].Nombre;
                        VaribalesParaConsultaParticular.apellido = listaRepetida[0].Apellido;
                        VaribalesParaConsultaParticular.dni = listaRepetida[0].Dni;
                        VaribalesParaConsultaParticular.año = listaRepetida[0].Curso;
                        VaribalesParaConsultaParticular.division = listaRepetida[0].Division;
                        VaribalesParaConsultaParticular.ciclo = listaRepetida[0].ciclo;
                        consultaAlumnoParticular cap = new consultaAlumnoParticular();
                        cap.ShowDialog();
                    }
                    else 
                    {
                        MessageBox.Show("Parece que esta alumno nunca fue registrado en un curso, por lo tanto, no hay datos para revisar. ");
                    }
                }


            }
        }


        private void buscarAlumnos(string nombre)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaAlumnos.Clear();
            string query = "";
            if (string.IsNullOrEmpty(txt_apellido.Text) && string.IsNullOrEmpty(txt_Nombre.Text))
            {
                query = "select * from alumnos order by nombre, apellido asc";
            }
            else
            {
                if (!string.IsNullOrEmpty(txt_apellido.Text) && !string.IsNullOrEmpty(txt_Nombre.Text))
                {
                    query = "select * from alumnos where nombre = '" + txt_Nombre.Text + "' and apellido = '" + txt_apellido.Text + "' order by nombre, apellido asc";
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_apellido.Text))
                    {
                        query = "select * from alumnos where nombre = '" + txt_Nombre.Text + "' order by nombre, apellido asc";
                    }
                    else
                    {
                        query = "select * from alumnos where apellido = '" + txt_apellido.Text + "' order by apellido, nombre asc";
                    }
                }

            }
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))

            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Alumno b = new Alumno();
                    b.Nombre = Convert.ToString(reader["nombre"]);
                    b.Dni = Convert.ToString(reader["dni"]);
                    b.Apellido = Convert.ToString(reader["apellido"]);
                    b.FechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    b.Email = Convert.ToString(reader["email"]);
                    b.barrio = Convert.ToString(reader["barrio"]);
                    b.calle = Convert.ToString(reader["calle"]);
                    b.altura = Convert.ToString(reader["altura"]);
                    b.edificio = Convert.ToString(reader["edificio"]);
                    b.piso = Convert.ToString(reader["piso"]);
                    b.numero_dpto = Convert.ToString(reader["numero_dpto"]);
                    b.indicacion = Convert.ToString(reader["indicacion"]);
                    b.estado = Convert.ToString(reader["estado"]);
                    b.Telefono = Convert.ToString(reader["telefono"]);
                    b.Id = Convert.ToInt32(reader["id"]);
                    ListaAlumnos.Add(b);
                }
                connection.Close();
                reader.Close();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaAlumnos;
        }



        private void consulta_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cambiarVisibilidad(false);
        }

        private void cambiarVisibilidad(bool v)
        {
            if (v)
            {
                dataGridView1.Visible = false;
                panel1.Visible = true;
                button3.Visible = true;
                groupBox1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
                panel1.Visible = false;
                button3.Visible = false;
                groupBox1.Visible = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // verificar si se hizo clic en una celda válida
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                if (row != null)
                {
                    VaribalesParaConsultaParticular.nombre = row.Cells[3].Value.ToString();
                    VaribalesParaConsultaParticular.apellido = row.Cells[4].Value.ToString();
                    VaribalesParaConsultaParticular.dni = row.Cells[5].Value.ToString();
                    VaribalesParaConsultaParticular.año = row.Cells[1].Value.ToString();
                    VaribalesParaConsultaParticular.division = row.Cells[2].Value.ToString();
                    VaribalesParaConsultaParticular.ciclo = Convert.ToInt32(row.Cells[6].Value.ToString());
                    consultaAlumnoParticular cap = new consultaAlumnoParticular();
                    cap.ShowDialog();
                }
            ;
            }
        }
    }
}
