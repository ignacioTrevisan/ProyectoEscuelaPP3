using EntidadAlumno;
using EntidadNota;
using EntidadProfesor;
using NegocioAlumnos;
using NotasAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoEscuela
{
    public partial class Form1 : Form
    {
        List<profesor> profesores = new List<profesor>();
        List<Nota> lista = new List<Nota>();
        int idProfesor = 0;
        List<Nota> cursos = new List<Nota>();
        List<string> materias = new List<string>();
        public Form1()
        {

            InitializeComponent();
            TraerProfesores();
            getMaterias();
            getCursos();
        }

        private void TraerProfesores()
        {
            profesor p = new profesor();
            profesores = NegocioProfesor.GetProfesores();
            int i = 0;
            while (i < profesores.Count)
            {
                comboBox1.Items.Add(profesores[i].Nombre + " " + profesores[i].Apellido);
                i++;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = comboBox1.SelectedIndex;
            idProfesor = profesores[a].Id;

            lista = NegocioProfesor.GetPermisos(idProfesor);
            refreshGrid();
        }
        private void refreshGrid()
        {

            bindingSource1.DataSource = null;
            bindingSource1.DataSource = lista;
            dataGridView1.DataSource = bindingSource1;
            int i = 0;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int j = cell.RowIndex;


                    DialogResult result = MessageBox.Show("¿Seguro que desea eliminar los permisos de este profesor con esta materia en este curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string materia = lista[j].Materia;
                        string curso = lista[j].Curso;
                        string division = lista[j].Division;
                        NegocioProfesor.eliminarRelacionProfMat(idProfesor, materia, curso, division);

                    }
                }

            }
            lista = NegocioProfesor.GetPermisos(idProfesor);
            refreshGrid();
        }
        private void getMaterias() 
        {
            {
                
                materias = NegocioProfesor.getMaterias();
                int i = 0;
                while (i < materias.Count)
                {
                    comboBox2.Items.Add(materias[i]);
                    i++;
                }
            }
        }
        private void getCursos() 
        {
           
            cursos = NegocioProfesor.GetCursos();
            int i = 0;
            while (i < cursos.Count)
            {
                comboBox3.Items.Add("año: "+cursos[i].Curso +" division: "+ cursos[i].Division);
                i++;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string error = "";
                int a = comboBox1.SelectedIndex;
                idProfesor = profesores[a].Id;
                int es = comboBox3.SelectedIndex;
                string año = cursos[es].Curso;
                string division = cursos[es].Division;
                int i = comboBox2.SelectedIndex;
                string materia = materias[i];
                error = NegocioProfesor.ConfigurarCursoProfesor(idProfesor, año, division, materia, error);
                
                    MessageBox.Show(error);
                lista = NegocioProfesor.GetPermisos(idProfesor);
                refreshGrid();
            }
            else 
            {
                MessageBox.Show("Debe seleccionar el profesor a asignar. ");
            }
        }
    }
}
