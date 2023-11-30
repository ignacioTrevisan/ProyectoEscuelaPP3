using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadRecursosSalas;
using Negocio;
using NegocioAlumnos;
using static ProyectoEscuela.inicioSesion;

namespace ProyectoEscuela
{
    public partial class RecursosSalas : Form
    {
        List<ReservasRecursosSalas> lista = new List<ReservasRecursosSalas>();
        public RecursosSalas()
        {
            InitializeComponent();
            getRecursos();
            getdos();
            numericUpDown1.Maximum = 20;
            numericUpDown1.Minimum = 7;
            /*
             string hora = Convert.ToString(dateTimePicker2.Value.AddHours(2).AddMinutes(5));
             //MessageBox.Show(hora);
            */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RecursosSalas_Load(object sender, EventArgs e)
        {

            lista = NegociosRecursosSalas.GetReservas(lista);
            refreshgrid();
        }
        private void refreshgrid()
        {
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = lista;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string recurso = comboBox2.Text;
            DateTime fecha = dateTimePicker1.Value.Date;
            string horario = Convert.ToString(numericUpDown1.Value);
            string fechados = Convert.ToString(fecha);
            int id = GlobalVariables.id;
            string comentarios = textBox3.Text;
           
            if (comentarios == "") 
            {
                comentarios = "--";
            }
            
            if (!string.IsNullOrEmpty(recurso) && !string.IsNullOrEmpty(horario))
            {
                int res = NegociosRecursosSalas.RegistrarReservas(recurso, fechados,horario, comentarios, id);
                dataGridView1.Rows.Clear();
                lista = NegociosRecursosSalas.GetReservas(lista);
                refreshgrid();
                if (res == 1)
                {
                    MessageBox.Show("Carga exitosa");
                }
                else 
                {
                    MessageBox.Show("Este recurso ya esta reservado para ese dia y horario. ");
                    DialogResult result = MessageBox.Show("¿Desea modificar crear otra reserva?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        textBox3.Text = "";
                        textBox4.Text = "";
                        panel1.Visible = false;
                        button3.Visible = true;
                    }
                    
                }
            }
            else 
            {
                MessageBox.Show("Complete todas las casillas, por favor. ");
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void getdos()
        {
            int i = 0;
            List<string> lista = new List<string>();
            lista = getRecursos();
            while (i < lista.Count)
            {
                comboBox2.Items.Add(lista[i]);
                i++;
            }

        }
        public List<string> getRecursos() 
        {
           
            List<string> lista = new List<string>();
            
            return lista = NegociosRecursosSalas.GetRecursos();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox4.Text);
            int a;
            a = NegociosRecursosSalas.Eliminar(id, GlobalVariables.id, GlobalVariables.cargo);
            if (a == 1)
            {
                MessageBox.Show("Reserva eliminada correctamente");
            }
            else 
            {
                MessageBox.Show("Solo el director y los preceptores pueden eliminar reservas hechas por otros profesores. ");
            }
            dataGridView1.Rows.Clear();
            lista = NegociosRecursosSalas.GetReservas(lista);
            refreshgrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button3.Visible = false;
        }
    }
}
