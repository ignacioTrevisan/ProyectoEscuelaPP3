using EntidadAlumno;
using EntidadNota;
using NegocioAlumnos;
using NotasAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using Negocio;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoEscuela.consulta;
using static ProyectoEscuela.inicioSesion;
using iTextSharp.text.pdf.codec.wmf;
using System.Data.SqlClient;
using Org.BouncyCastle.Asn1.Crmf;


namespace ProyectoEscuela
{
    public partial class consultaAlumnoParticular : Form
    {
        List<Faltas> faltas = new List<Faltas>();
        List<string> etapa = new List<string>();
        List<Nota> alumno = new List<Nota>();
        List<string> materias = new List<string>();
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
            materias = NegocioProfesor.getMaterias(año, division, ciclo);
            for (int i = 0; i < materias.Count; i++) 
            {
                comboBox1.Items.Add(materias[i]);
            }
            if (faltas.Count > 0) 
            {
                dataGridView1.DataSource = faltas;
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = "Condicion: ";
            alumno = NotasNegocio.GetNotasXAlumno(dni, comboBox1.Text, GlobalVariables.id, año, division, ciclo);
            dataGridView2.DataSource = null;
            List<string>etapas= new List<string>();
            etapa = Negocio.NegocioAlumnos.getEtapas(dni, comboBox1.Text, GlobalVariables.id, año, division, ciclo);
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            for (int i = 0; i < etapa.Count; i++)
            {
                comboBox2.Items.Add(etapa[i]);
            }
            dataGridView2.Rows.Clear();
            if (alumno.Count > 0)
            {
                dataGridView2.DataSource = alumno;
            }
            evaluarCondicion(alumno);
        }

        private void evaluarCondicion(List<Nota> alumno)
        {
            float promedio = sacarPromedioTrimestres(alumno);
            if (promedio < 6 && promedio != 0)
            {
                for (int i = 0; i < alumno.Count; i++)
                {
                    if (alumno[i].etapa == "Semana extra-febrero")
                    {
                        if (Convert.ToInt32(alumno[i].Calificacion) > 5)
                        {
                            label7.Text = "Condicion: Aprobado";
                        }
                        else
                        {
                            label7.Text = "Condicion: Desaprobado";
                        }
                    }
                    else
                    {
                        if (alumno[i].etapa == "Semana extra-diciembre")
                        {
                            if (Convert.ToInt32(alumno[i].Calificacion) > 5)
                            {
                                label7.Text = "Condicion: Aprobado";
                            }
                        }
                    }
                }
            }
            if (promedio > 5 && promedio != 0)
            {
                label7.Text = "Condicion: Aprobado";
            }
            
        }

        private float sacarPromedioTrimestres(List<Nota> alumno)
        {
            float promedio = 0;
            int cantidad = 0;
            for (int i = 0; i < alumno.Count; i++) 
            {
                if (alumno[i].comentario == "Nota final-trimestre") 
                {
                    promedio = promedio + Convert.ToInt32(alumno[i].Calificacion);
                    cantidad++;
                }
            }
            if (cantidad == 3) 
            {
                promedio = promedio / 3;
            }
            return promedio;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultaPorTrimestre();
        }

        private void consultaPorTrimestre()
        {
            List<Nota> lista = new List<Nota>();
            if (comboBox1.Text != "") 
            {
                string query = "select * from notas where etapa = '"+comboBox2.Text+"' and DniAlumno= '"+dni+"'";
                
                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Nota n = new Nota();
                        n.Calificacion = Convert.ToString(reader["Nota"]);
                        n.fecha = Convert.ToString(reader["fecha"]);
                        n.etapa = Convert.ToString(reader["etapa"]);
                        n.comentario = Convert.ToString(reader["Comentario"]);

                        lista.Add(n);
                    }
                    reader.Close();
                    con.Close();
                }
            }
            dataGridView2.DataSource = lista;
        }
    }
}
