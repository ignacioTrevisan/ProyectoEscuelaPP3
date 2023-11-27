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

namespace ProyectoEscuela
{
    public partial class TomarAsistencia : Form
    {
        public int id = 1;
        int i = 0;
        public int al = 0;
        public List<Nota> lista = new List<Nota>();
        public List<Alumno> alumnos = new List<Alumno>();
        public TomarAsistencia()
        {
            InitializeComponent();

            lista = GetCursos(GlobalVariables.id);


            i = 0;
            int o = 1;
            if (GlobalVariables.cargo != "preceptor")
            {
                // Utiliza LINQ para encontrar los elementos duplicados
                var duplicados = lista.GroupBy(item => new { item.Curso, item.Division })
                                     .Where(grp => grp.Count() > 1)
                                     .SelectMany(grp => grp.Skip(1));

                // Elimina los elementos duplicados de la lista
                lista.RemoveAll(item => duplicados.Contains(item));
            }

            i = 0;
            while (i < lista.Count)
            {
                comboBox1.Items.Add("curso: " + lista[i].Curso + " Division: " + lista[i].Division);
                i++;
            }
        }


        public static List<Nota> GetCursos(int id)
        {
            List<Nota> lista = new List<Nota>();
            if (GlobalVariables.cargo == "preceptor")
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
            string dni = textBox1.Text;
            int a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            buscar(dni, curso, division);
        }
        public void buscar(string dni, string curso, string division)
        {
            List<Alumno> a = new List<Alumno>();
            double dnis = Convert.ToInt64(textBox1.Text);
            a = Negocio.NegocioAlumnos.Get(dnis, curso, division);
            if (a.Count > 0)
            {
                lbl_alumno.Text = a[0].Nombre + " " + a[0].Apellido;
                label1.Text = a[0].Dni;
                al = 0;
                bool comprobar = false;
                while (comprobar == false)
                {
                    if (alumnos[al].Dni != a[0].Dni)
                    {
                        al++;
                    }
                    else
                    {
                        comprobar = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encuentra este alumno, ten en cuenta de seleccionar bien el curso ");
            }

        }
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

        private void btn_prese_Click(object sender, EventArgs e)
        {
            string estado = "presente";
            DateTime fechacompleta = dateTimePicker1.Value.Date;
            string fecha = Convert.ToString(fechacompleta);
            string dni = label1.Text;
            registrarestado(estado, fecha, dni);

        }

        private void registrarestado(string estado, string fecha, string dni)
        {

            Negocio.NegocioAlumnos.registrarEstado(estado, fecha, dni);
            MessageBox.Show(dni + " fue registrado como " + estado + " el dia " + fecha + " exitosamente");

        }

        private void btn_ausente_Click(object sender, EventArgs e)
        {
            string estado = "ausente";
            string dni = label1.Text;
            DateTime fechacompleta = dateTimePicker1.Value.Date;
            string fecha = Convert.ToString(fechacompleta);
            registrarestado(estado, fecha, dni);

        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = 0;
            a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            alumnos = Negocio.NegocioAlumnos.Get(0, curso, division);
            lbl_alumno.Text = alumnos[0].Nombre + " " + alumnos[0].Apellido;
            label1.Text = alumnos[0].Dni;
        }

        private void btn_presente_Click(object sender, EventArgs e)
        {
            int cantidad = alumnos.Count();
            if (al < cantidad - 1)
            {
                al++;
                lbl_alumno.Text = alumnos[al].Nombre + " " + alumnos[al].Apellido;
                label1.Text = alumnos[al].Dni;

            }
        }
    }
}
