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


namespace ProyectoEscuela
{
    public partial class pre_registroProfesor : Form
    {
        public pre_registroProfesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dni = textBox1.Text;
            string pass= textBox2.Text;
            busquedadirectivo(dni, pass);
        }

        private void busquedadirectivo(string dni, string pass)
        {
            int bol = NegocioProfesor.buscarDirectivo(dni,pass);

            if (bol == 1)
            {
                CrearProfesor formulario = new CrearProfesor();
                formulario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Los datos son incorrectos, por favor ingrese con la cuenta con cargo directivo");
            }
        }
    }
}
