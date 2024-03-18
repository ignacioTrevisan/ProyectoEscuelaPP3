using EntidadAlumno;
using EntidadNota;
using NegocioAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class configuracionCursos : Form
    {
        int modo = 0;
        int modoMaterias = 0;
        string año = "";
        string division = "";
        string Ciclo = "";
        string Estado = "";

    public configuracionCursos()
        {
            InitializeComponent();
            actualizarCursos();
            agregarMateriasACbox();
        }
        private void agregarMateriasACbox() 
        {
            List<string> materias = new List<string>();
            materias = NegocioProfesor.getAllMaterias();
            for (int i = 0; i < materias.Count; i++)
            {
                comboBox1.Items.Add(materias[i]);
            }
        }

        private void actualizarCursos()
        {
            List<Nota> cursos = new List<Nota>();
            
            
            cursos = Negocio.NegocioAlumnos.GetCursosDirector();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = cursos;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modo == 0)
            {
                modo = 1;
                MessageBox.Show("Selecciona el curso a modificar el estado ");
                button1.Text = "Seleccionar cursos";
            }
            else 
            {
                modo = 0;
                button1.Text = "Activar/Desactivar cursos";
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
            Estado = filaSeleccionada.Cells[3].Value.ToString();
            año = filaSeleccionada.Cells[0].Value.ToString();
            division = filaSeleccionada.Cells[1].Value.ToString();
            Ciclo = filaSeleccionada.Cells[2].Value.ToString();
            {
                if (modo == 1)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        
                        
                        MessageBox.Show(NegocioProfesor.cambiarEstadoCurso(año, division, Ciclo, Estado));
                        actualizarCursos();
                    }
                }
                else 
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        List<string> lista = NegocioProfesor.getMaterias(año, division, Convert.ToInt32(Ciclo));
                        List<Nota> materia = new List<Nota>();
                        for (int i = 0; i < lista.Count; i++) 
                        {
                            Nota a = new Nota();
                            a.Materia = lista[i];
                            materia.Add(a);
                        }
                        dataGridView2.DataSource = materia;
                       
                    }
                }
                
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Location = new Point(120, 84);
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel3.Location = new Point(150, 257);
            string año = textBox1.Text;
            string division = textBox2.Text;
            Ciclo = textBox3.Text;
            MessageBox.Show(NegocioProfesor.agregarNuevoCurso(año, division, Ciclo));
            actualizarCursos();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel3.Location = new Point(150, 257);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel2.Visible = false;
            panel1.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string materia = comboBox1.Text;
            MessageBox.Show(NegocioProfesor.agregarNuevaMateriaACurso(materia, año, division, Ciclo));
            panel4.Visible = false;
            panel2.Visible = true;
            panel1.Enabled = true;
            
        }

        

        private void button8_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = true;
            panel1.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione la materia que desee quitar.");
            modoMaterias = 1;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                
                DataGridViewRow filaSeleccionadados = dataGridView2.Rows[e.RowIndex];
                string materia = filaSeleccionadados.Cells[0].Value.ToString();
                MessageBox.Show(NegocioProfesor.eliminarMateriaDeCurso(año, division, Ciclo, materia));
            }
        }
    }
}
