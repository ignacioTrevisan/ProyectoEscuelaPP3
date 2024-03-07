using EntidadAlumno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoEscuela.consulta;


namespace ProyectoEscuela
{
    public partial class consultaAlumnoParticular : Form
    {
        List<Faltas> faltas = new List<Faltas>();
        string dni = VaribalesParaConsultaParticular.dni;
        string nombre = VaribalesParaConsultaParticular.nombre;
        string apellido = VaribalesParaConsultaParticular.apellido;
        string año = VaribalesParaConsultaParticular.año;
        string division = VaribalesParaConsultaParticular.division;
        int ciclo = VaribalesParaConsultaParticular.ciclo;
        public consultaAlumnoParticular()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            faltas = Negocio.NegocioAlumnos.BuscarFaltas(dni, ciclo, año, division);
            label1.Text = nombre + " " + apellido + " (" + dni + ")";
            label2.Text = "año: " + año + " division: " + division + " (" + ciclo + ")";
            dataGridView1.DataSource = faltas;
        }
    }
}
