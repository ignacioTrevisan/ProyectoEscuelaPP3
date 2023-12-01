using EntidadAlumno;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using NegocioAlumnos;
using EntidadNota;
using static ProyectoEscuela.inicioSesion;
using System.Net;
namespace ProyectoEscuela
{
    public partial class Inscripciones : Form
    {
        List<Alumno> alumnos = new List<Alumno>();
        int modo = 0;
        List<Nota> cursos = new List<Nota>();

        
        public Inscripciones()
        {
            InitializeComponent();
            getCursos();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int i = comboBox2.SelectedIndex;
            Inscribir(comboBox1.Text, cursos[i].Curso , cursos[i].Division, cursos[i].ciclo);
            MessageBox.Show("Inscripcion hecha correctamente. ");
        }
        private void getCursos() 
        {
            cursos = NegocioProfesor.GetPermisosPreceptor(1);
            int i = 0;
            while (i < cursos.Count) 
            {
                comboBox2.Items.Add("año: "+cursos[i].Curso +" divsion "+ cursos[i].Division+ " ciclo ("+ cursos[i].ciclo+")");
                i++;
            }
        }

        private void Inscribir(string dni, string curso, string division, int ciclo)
        {
            Negocio.NegocioAlumnos.inscribir(dni, curso, division, ciclo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            modo = 1;
            cambiarPermisos();
        }
        public void cambiarPermisos() 
        {
            if (modo == 0)
            {
                panel1.Visible = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                
                button1.Enabled = true;
            }
            else 
            {
                panel1.Visible = true;
                comboBox1.Enabled=false;
                comboBox2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_nombre.Text) || (string.IsNullOrEmpty(txt_apellido.Text)))
            {
                MessageBox.Show("Ingrese nombre y apellido del alumno a buscar ");

            }
            else
            {

                if (verificarExistencia() == true)
                {
                    Alumno a = new Alumno();
                    string nombre = Convert.ToString(txt_nombre.Text);
                    string apellido = txt_apellido.Text;
                    string dni = "0";
                    buscar(nombre, apellido, dni);
                }
                else
                {
                    MessageBox.Show("No existe el alumno " + txt_nombre.Text + " " + txt_apellido.Text);
                }
            }
        }

        private void buscar(string nombre, string apellido, string dni)
        {
            alumnos = Negocio.NegocioAlumnos.buscar(nombre, apellido, dni);
            dataGridView1.DataSource=alumnos;
        }

        public Boolean verificarExistencia()
        {
            string query = "SELECT COUNT(*) FROM Alumnos WHERE nombre = @nombre AND apellido = @apellido";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", txt_nombre.Text);
                cmd.Parameters.AddWithValue("@apellido", txt_apellido.Text);
                int count = (int)cmd.ExecuteScalar();
                if (count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int j = cell.RowIndex;
                   
                    comboBox1.Text = alumnos[j].Dni;
                   


                }
            }
            modo = 0;
            cambiarPermisos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            int i = comboBox2.SelectedIndex;
            buscarCurso(0, cursos[i].Curso, cursos[i].Division, cursos[i].ciclo);
        }

        private void buscarCurso(int v, string curso, string division, int ciclo)
        {
            alumnos = Negocio.NegocioAlumnos.GetXCurso(v.ToString(), curso, division, ciclo);
           
            dataGridView2.DataSource = alumnos;
        }
    }
}
