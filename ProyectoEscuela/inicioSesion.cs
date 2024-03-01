using EntidadAlumno;
using EntidadPermiso;
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

namespace ProyectoEscuela
{
    public partial class inicioSesion : Form
    {
        public List<Alumno> lista = new List<Alumno>();
        public List<Alumno> listaAsistenciasTomadas = new List<Alumno>();

        public inicioSesion()
        {
            InitializeComponent();
            privadas();
            label6.Visible = false;
        }
        public static class GlobalVariables
        {
            public static int ciclo = 2024;
            public const string usuario = "Luggrenadriana@gmail.com";
            public const string password = "jyfi avhd kalc fgqp";
            public static string cargo = "";
            public static string apellido = "";
            public static string nombre = "";
            public static string año = "";
            public static string division = "";
            public static int id;
            public static DateTime fecha;
           

        }
        private void privadas() 
        {
            GlobalVariables.fecha = DateTime.Now.Date;
            lista = Negocio.NegocioAlumnos.getPorcentaje();
            listaAsistenciasTomadas = Negocio.NegocioAlumnos.getPorcentajeTomado(GlobalVariables.fecha);
            if (lista.Count > 0) 
            {
                float porcentaje = (Convert.ToInt32(listaAsistenciasTomadas.Count) * 100) / Convert.ToInt32(lista.Count);
                label6.Text= porcentaje+"% de asistencias tomada el dia de hoy";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Permisos p = new Permisos();
            p.dni = Convert.ToDouble(txt_dni.Text);
            p.pass = txt_contraseña.Text;
            buscarcargo(p);
            
        }
        public void buscarcargo(Permisos p)
        {

            Permisos idEmp = Negocio.NegocioAlumnos.buscarCargo(p);
             

            if (p.Desc == "profesor" || p.Desc == "director" || p.Desc=="preceptor")
            {
                GlobalVariables.cargo = p.Desc;
                GlobalVariables.id = p.id;
                buscarProfesor(GlobalVariables.id);
                inicioSesion formulario2 = new inicioSesion();
                formulario2.Hide();
                Front formulario = new Front();
                formulario.ShowDialog();
                txt_contraseña.Text = "";
                txt_dni.Text = "";

            }
            else
            {
                MessageBox.Show("No se ha encontrado registro de un cargo con el dni " + p.dni + " o la contraseña es incorrecta");
            }

        }

        private void buscarProfesor(int id)
        {
            string query = ("select apellido, nombre from directivos where id = @id");
            string conString = System.Configuration.ConfigurationManager.
                                             ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    GlobalVariables.nombre = Convert.ToString(reader["nombre"]);
                    GlobalVariables.apellido = Convert.ToString(reader["apellido"]);
                }
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Antes de ingresar un nuevo profesor, por favor, ingresa con la cuenta de el director de el instituto. ");
            pre_registroProfesor formulario = new pre_registroProfesor();
            formulario.ShowDialog();

        }
    }
}
