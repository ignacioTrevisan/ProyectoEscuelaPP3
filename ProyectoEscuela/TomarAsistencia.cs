using EntidadAlumno;
using Negocio;
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
using static ProyectoEscuela.Front;
using NegocioAlumnos;
using EntidadNota;
using static ProyectoEscuela.inicioSesion;
using System.Reflection.Emit;
using NotasAlumnos;
using System.Runtime.CompilerServices;

namespace ProyectoEscuela
{
    public partial class TomarAsistencia : Form
    {
        public int id = 1;
        int i = 0;
        public int al = 0;
        public List<Nota> lista = new List<Nota>();
        public List<Alumno> alumnos = new List<Alumno>();
        public List<Alumno> asistencias = new List<Alumno>();
        public List<int> Ciclos = new List<int>();
        public TomarAsistencia()
        {
            InitializeComponent();
            if (GlobalVariables.cargo == "profesor")
            {
                dateTimePicker1.Enabled = false;
                
            }
            lista = GetCursos(GlobalVariables.id);



            int i = 0;
            int o = 1;
            

            i = 0;
            if (lista[i].ciclo != 0)
            {
                while (i < lista.Count)
                {
                    comboBox1.Items.Add("curso: " + lista[i].Curso + " Division: " + lista[i].Division + "(" + lista[i].ciclo + ")");
                    i++;
                }
            }
            else 
            {
                while (i < lista.Count)
                {
                    comboBox1.Items.Add("curso: " + lista[i].Curso + " Division: " + lista[i].Division );
                    i++;
                }
            }

            i = 0;
            o = 1;
            while (i < lista.Count) 
            {
                Ciclos.Add(lista[i].ciclo);
                i++;
            }
            
            i = 0;
            while (i < Ciclos.Count)
            {
                o = i + 1; // Comienza a comparar con el siguiente elemento
                while (o < Ciclos.Count)
                {
                    if (Ciclos[i] == Ciclos[o])
                    {
                        Ciclos.RemoveAt(o); // Elimina el elemento duplicado
                    }
                    else
                    {
                        o++;
                    }
                }
                i++;
            }
            i = 0;
           

        }



        public static List<Nota> GetCursos(int id)
        {
            List<Nota> lista = new List<Nota>();
            if (GlobalVariables.cargo == "preceptor" || GlobalVariables.cargo == "director")
            {
                lista = NegocioProfesor.GetPermisosPreceptor();

            }
            else
            {
                lista = NegocioProfesor.GetPermisos(id);

            }
            int tam = lista.Count;
            int i = 0;
            return lista;
        }


        private void btn_buscarAlumno_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.cargo == "profesor") 
            {
                string ciclo = "2023";
            }
            if (textBox1.Text != "")
            {

            
            string nombre = textBox1.Text;
            int a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            
                buscar(nombre, curso, division);
            }
            else
            {
                int a = 0;
                a = comboBox1.SelectedIndex;
                string curso = lista[a].Curso;
                string division = lista[a].Division;
                alumnos = Negocio.NegocioAlumnos.Get("0", curso, division, GlobalVariables.ciclo);
                refreshgrid();
            }
        }
        public void buscar(string nombre, string curso, string division)
        {
            
           
            alumnos = Negocio.NegocioAlumnos.Get(nombre, curso, division, GlobalVariables.ciclo);
            if (alumnos.Count > 0)
            {
                refreshgrid();
            }
            else
            {
                MessageBox.Show("No se encuentra este alumno, ten en cuenta de seleccionar bien el curso ");
            }

        }
        
        /*
        private Boolean verificarRegistro()
        {
            string query = "SELECT COUNT(*) FROM asistencias WHERE DNI = @dni AND fecha = @fecha";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@dni", label1.Text);
                string fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@fecha", fecha);
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

        */

        private void btn_prese_Click(object sender, EventArgs e)
        {
            string estado = "presente";
            DateTime fecha = dateTimePicker1.Value.Date;
           int a = comboBox1.SelectedIndex;

            int dni = Convert.ToInt32(label1.Text);
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo);
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value);
            refreshgrid();
        }

        private void registrarestado(string estado, DateTime fecha, int dni, string curso, string division, int ciclo)
        {
            MessageBox.Show(dni.ToString());
            Negocio.NegocioAlumnos.registrarEstado(estado, fecha, dni, curso, division, ciclo);
            MessageBox.Show(dni + " fue registrado como " + estado + " el dia " + fecha + " exitosamente");

        }

        private void btn_ausente_Click(object sender, EventArgs e)
        {
            string estado = "ausente";
            int dni = Convert.ToInt32(label1.Text);
            DateTime fecha = dateTimePicker1.Value.Date;
           int  a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo);
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value);
            refreshgrid();
        }

       


        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = 0;
            
            a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            MessageBox.Show(lista[a].ciclo.ToString());
            if (GlobalVariables.cargo == "Director") 
            {
                GlobalVariables.ciclo = lista[a].ciclo;
            }
            if (lista[a].ciclo == 2023)
            {
                dateTimePicker1.MaxDate = new DateTime(2023, 12, 31);
                dateTimePicker1.MinDate = new DateTime(2023, 1, 1);
                
            }
            else 
            {
                dateTimePicker1.MinDate = new DateTime(2022, 1, 1);
                dateTimePicker1.MaxDate = new DateTime(2022, 12, 31);
               
            }

            alumnos = Negocio.NegocioAlumnos.GetXCurso("", curso, division, GlobalVariables.ciclo);
            int i = 0;
            while (i < alumnos.Count) 
            {
                if (alumnos[i].cantidadFaltas > 24) 
                {
                    MessageBox.Show("ATENCIÓN, el alumno: " + alumnos[i].Nombre + " llego las 25 faltas");
                    

                }
                i++;
            }
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value);
            refreshgrid();
           
        }

        private void refreshgrid()
        {
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = alumnos;
            bindingSource2.DataSource = null;
            bindingSource2.DataSource = asistencias;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int j = cell.RowIndex;
                    string Nombre = alumnos[j].Nombre;
                    string Apellido = alumnos[j].Apellido;
                    string Dni = alumnos[j].Dni;
                    
                    label1.Text = Dni;
                    lbl_alumno.Text = Nombre + "  "+ Apellido;

                }
            }
            
            
        }

        private void TomarAsistencia_Load(object sender, EventArgs e)
        {
            if (GlobalVariables.cargo == "director")
            {
                btn_ausente.Enabled = false;
                btn_prese.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int a = 0;
            a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            if (GlobalVariables.cargo == "Director")
            {
                GlobalVariables.ciclo = lista[a].ciclo;
            }
            alumnos = Negocio.NegocioAlumnos.GetXCurso("", curso, division, GlobalVariables.ciclo);
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value);
            refreshgrid();
        }
    }
}
