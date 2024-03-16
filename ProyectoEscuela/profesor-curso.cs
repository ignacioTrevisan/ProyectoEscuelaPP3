using EntidadAlumno;
using EntidadNota;
using EntidadProfesor;
using NegocioAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class profesor_curso : Form
    {
        public List<string> Listamaterias = new List<string>();
        public List<profesor> ListaProfesor = new List<profesor> ();
        public List<Nota> ListaCursos = new List<Nota>();
        
        public profesor_curso()
        {
            InitializeComponent();
            traerProfesores();
            traerCursos();
        }

        private void traerCursos()
        {
            ListaCursos = NegocioProfesor.GetPermisosPreceptor(1    );
            foreach (var curso in ListaCursos)
            {
                
                comboBox3.Items.Add("año "+curso.Curso + " division " + curso.Division + " (" + curso.ciclo + ")");
            }
        }

        
        public void traerProfesores()
        {
            string query = "select * from directivos where cargo = 'profesor'";
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
                    p.Apellido = Convert.ToString(reader["apellido"]);
                    p.Nombre = Convert.ToString(reader["nombre"]);
                    p.Dni = Convert.ToString(reader["dni"]);

                    ListaProfesor.Add(p);
                }
                connection.Close();
                reader.Close();
                foreach (var profesor in ListaProfesor)
                {
                    comboBox1.Items.Add(profesor.Apellido+" "+ profesor.Nombre+" ("+profesor.Dni+")");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            int idProfesor = ListaProfesor[i].Id;
            int o = comboBox3.SelectedIndex;
            string añoCurso = ListaCursos[o].Curso;
            string divisionCurso = ListaCursos[o].Division;
            int ciclo = ListaCursos[o].ciclo;
            string materia = comboBox2.Text;
            MessageBox.Show (NegocioProfesor.ConfigurarCursoProfesor(idProfesor, añoCurso, divisionCurso, ciclo, materia, ""));
            actualizarGrila();
            cambiarVisibilidad(false);
        }
        public void cambiarVisibilidad(Boolean visible) 
        {
            if (visible == true)
            {
                panel1.Visible = true;
                dataGridView1.Visible = false;
            }
            else 
            {
                panel1.Visible = false;
                dataGridView1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarGrila();
            
        }

        private void actualizarGrila()
        {
            dataGridView1.DataSource = NegocioProfesor.GetCursos(ListaProfesor[comboBox1.SelectedIndex].Id);
        }

        private void profesor_curso_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cambiarVisibilidad(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cambiarVisibilidad(false) ;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> materias = new List<string>();
            comboBox2.Items.Clear();
            int o = comboBox3.SelectedIndex;
            string añoCurso = ListaCursos[o].Curso;
            string divisionCurso = ListaCursos[o].Division;
            int ciclo = ListaCursos[o].ciclo;
            materias = NegocioProfesor.getMaterias(añoCurso, divisionCurso, ciclo);
            for (int i = 0; i < materias.Count; i++) 
            {
                comboBox2.Items.Add(materias[i]);
            }
        }
    }
}
