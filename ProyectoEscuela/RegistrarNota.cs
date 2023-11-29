using EntidadPermiso;
using EntidadAlumno;
using EntidadNota;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ProyectoEscuela.Front;
using NotasAlumnos;
using static ProyectoEscuela.inicioSesion;
using NegocioAlumnos;

namespace ProyectoEscuela
{
    public partial class RegistrarNota : Form
    {
        public List<Nota> notas = new List<Nota>();
        public List<Nota> lista = new List<Nota>();
        public List <Alumno> alumnos = new List<Alumno> ();
        List<Nota> alumno = new List<Nota>();
        int i = 0;
        public string materia = "";
        public string curso = "";
        public string division = "";

        public RegistrarNota()
        {
            InitializeComponent();
            lista = GetCursos(GlobalVariables.id);
            
            int tam = lista.Count;
            while (i < tam)
            {
                comboBox1.Items.Add("curso: " + lista[i].Curso + " Division: " + lista[i].Division + " materia: " + lista[i].Materia);
                i++;
            }
        }

        private void btnConfirmarMateria_Click(object sender, EventArgs e)
        {
            

        }
        public static List<Nota> GetCursos(int id)
        {
            List<Nota> lista = new List<Nota>();
            lista = NegocioProfesor.GetPermisos(id);
            int tam = lista.Count;
            int i = 0;
            
            return lista;
        }

        private void refreshGrid()
        {

            bindingSource1.DataSource = null;
            bindingSource1.DataSource = notas;
            dataGridView1.DataSource = bindingSource1;
            int i = 0;
            int tamaño = alumnos.Count;
            while (i < tamaño) 
            {
                comboBox2.Items.Add(alumnos[i].Apellido +" " + alumnos[i].Nombre);
                i++;
            }
        }

        private List<Nota> getnotas()
        {
            int i = comboBox1.SelectedIndex;
            materia = lista[i].Materia;
            curso = lista[i].Curso;
            division = lista[i].Division;
            int ciclo = GlobalVariables.ciclo;
            return notas = NotasNegocio.GetNotas(curso, division, materia, ciclo);
        }

        private List <Alumno>GetAlumnos() 
        {
            int i = comboBox1.SelectedIndex;
            materia = lista[i].Materia;
            curso = lista[i].Curso;
            division = lista[i].Division;
            string dni = "0";
            return alumnos = Negocio.NegocioAlumnos.GetXCurso(dni, curso, division, GlobalVariables.ciclo);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
           
            int ciclo = GlobalVariables.ciclo;
            string nota = txtNota.Text;
            string comentario = "";
            comentario = textBox2.Text;
            if (!string.IsNullOrEmpty(comboBox1.Text) && (!string.IsNullOrEmpty(comboBox2.Text)) && (!string.IsNullOrEmpty(txtNota.Text)))
            {
                registrar(nota, comentario);
            }
            else 
            {
                MessageBox.Show("Para registrar notas primero debe ingresar el curso, materia, alumno y su nota ");
            }
            actualizarPorAlumno();
        }

        public void registrar(string nota, string comentario)
        {
            int i = comboBox1.SelectedIndex;
            curso = lista[i].Curso;
            division = lista[i].Division;
            int id = comboBox2.SelectedIndex;
            DateTime fecha = dateTimePicker1.Value.Date;
            NotasNegocio.registrarNotas(materia, alumnos[id].Dni, nota, GlobalVariables.id, fecha, comentario, curso, division, GlobalVariables.ciclo);
            actualizarPorAlumno();
        }

        public void actualizarPorAlumno() 
        {
            int id = comboBox2.SelectedIndex;
            int ciclo = GlobalVariables.ciclo;
            alumno = NotasNegocio.GetNotasXAlumno(alumnos[id].Dni, materia, GlobalVariables.id, alumnos[id].Curso, alumnos[id].division, ciclo);
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = alumno;
            dataGridView1.DataSource = bindingSource1;
            int cantidadDeNotas = alumno.Count();
            int r = 0;
            float nota = 0;
            while (r < cantidadDeNotas)
            {
                 nota = nota + Convert.ToInt64(alumno[r].Calificacion);
                 r++;
            }
            nota = nota / alumno.Count();
            label1.Visible = true;
            label1.Text = "Promedio parcial: "+ nota.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            i = 0;
            getnotas();
            GetAlumnos();

            if (!string.IsNullOrEmpty(materia) || (!string.IsNullOrEmpty(curso)) || (!string.IsNullOrEmpty(division)))
            {
                if (alumnos.Count < 1)
                {
                    MessageBox.Show("No se encontraron datos, probablemente no tenga permisos para acceder a datos de esta materia y curso " + GlobalVariables.id);
                }
                else
                {
                    if (notas.Count < 1)
                    {
                        MessageBox.Show("Aún no hay notas cargadas. ");
                    }
                    else 
                    {
                        txtNota.Text = notas[i].Calificacion;
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los datos ");
            }
            refreshGrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarPorAlumno();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (cell.Value != null) 
                    {
                        int j = cell.RowIndex;


                    DialogResult result = MessageBox.Show("¿Seguro que desea eliminar esta nota?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        NotasNegocio.eliminarNota(alumno[j].id);
                        string nombre = alumno[j].Nombre;
                        string apellido = alumno[j].Apellido;
                    }
                }
                }
            actualizarPorAlumno();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ésta opción es para registrar notas finales de cierre de materia, recomendamos generar informe para tener seguimiento. ¿Esta seguro que desea registrar la nota final?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                panel1.Visible = true;
                button2.Visible = false;

            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nota = textBox1.Text;
            string comentario = "nota final";
            if (!string.IsNullOrEmpty(comboBox1.Text) && (!string.IsNullOrEmpty(comboBox2.Text)) && (!string.IsNullOrEmpty(txtNota.Text)))
            {
                registrar(nota, comentario);
            }
            else
            {
                MessageBox.Show("Para registrar notas primero debe ingresar el curso, materia, alumno y su nota ");
            }
        }

        private void RegistrarNota_Load(object sender, EventArgs e)
        {

        }
    }
}
