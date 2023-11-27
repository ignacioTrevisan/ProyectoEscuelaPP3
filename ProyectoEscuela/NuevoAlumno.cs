using EntidadAlumno;
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
using System.Configuration;
using System.Net;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ProyectoEscuela
{
    public partial class NuevoAlumno : Form
    {
        string modo = "nada";
        public NuevoAlumno()
        {
            InitializeComponent();
        }

        private void btn_confirmarRegistroAlumno_Click(object sender, EventArgs e)
        {
             guardar();


        }
        public Boolean verificarExistencia()
        {
            string query = "SELECT COUNT(*) FROM Alumnos WHERE DNI = @dni";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@dni", txt_dni.Text);
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
        public void guardar()
        {
            try
            {
                Alumno a = new Alumno();
                if (!VerificacionDeDatosLogicos()) return;
                if (verificarExistencia() == false)
                {
                    a.Nombre = txt_nombre.Text;
                    a.Apellido = txt_apellido.Text;
                    a.Dni = txt_dni.Text;
                    a.FechaNacimiento = txt_fechaNacimiento.Value;
                    a.Domicilio = txt_domicilio.Text;
                    a.Telefono = txt_telefono.Text;
                    a.Email = txt_email.Text;
                    a.division = txt_division.Text;
                    a.Curso = txt_curso.Text;
                    DialogResult res = MessageBox.Show("¿Confirma guardar ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                    int idEmp = Negocio.NegocioAlumnos.insertar(a);
                    MessageBox.Show("Se generó el alumno con dni " + a.Dni);
                    limpiarControles();

                }
                else
                {

                    MessageBox.Show("No se puede generar el alumno por que ya existe registrado el dni " + txt_dni.Text);
                    
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void limpiarControles() 
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_domicilio.Text = "";
            txt_telefono.Text = "";
            txt_email.Text = "";
            txt_division.Text = "";
            txt_curso.Text = "";
            txt_dni.Text = "";
        }

        public bool VerificacionDeDatosLogicos()
        {
            int caracter = txt_dni.Text.Length;
            if (caracter > 8 || caracter < 7)
            {
                MessageBox.Show("El DNI está mal ingresado o no se ingresó");
                return false;
            }
            else if(txt_apellido.Text == "")
            {
                MessageBox.Show("El APELLIDO está mal ingresado o no se ingresó");
                return false;
            }
            else if(txt_nombre.Text == "")
            {
                MessageBox.Show("El NOMBRE está mal ingresado o no se ingresó");
                return false;
            }
            else if(txt_curso.Text == "")
            {
                MessageBox.Show("El CURSO está mal ingresado o no se ingresó");
                return false;
            }
            else if(txt_division.Text == "")
            {
                MessageBox.Show("El DIVISION está mal ingresado o no se ingresó");
                return false;
            }
            else if(txt_telefono.Text == "")
            {
                MessageBox.Show("El TELEFONO está mal ingresado o no se ingresó");
                return false;
            }
            else if (txt_email.Text == "")
            {
                MessageBox.Show("El EMAIL está mal ingresado o no se ingresó");
                return false;
            }
            else if (txt_domicilio.Text == "")
            {
                MessageBox.Show("El DOMICILIO está mal ingresado o no se ingresó");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modificar();
        }
        private void modificar() 
        {
         
            try
            {
                Alumno a = new Alumno();
                a.Nombre = txt_nombre.Text;
                a.Apellido = txt_apellido.Text;
                a.Dni = Convert.ToString(txt_dni.Text);
                a.FechaNacimiento = txt_fechaNacimiento.Value;
                a.Domicilio = txt_domicilio.Text;
                a.Telefono = txt_telefono.Text;
                a.Email = txt_email.Text;
                a.division = txt_division.Text;
                a.Curso = txt_curso.Text;
                
                    if (verificarExistencia()==true)
                    {
                        DialogResult res = MessageBox.Show("¿Confirma edicion ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                            return;
                        }
                        int idEmp = Negocio.NegocioAlumnos.editar(a);
                        MessageBox.Show("Se modifico el alumno con dni " + txt_dni.Text);
                        limpiarControles();

                    }
                    else 
                    {
                        MessageBox.Show("No existe el alumno con dni " + txt_dni.Text);
                       
                    }
                
                
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscarAlumno_Click(object sender, EventArgs e)
        {
            buscar();
        }
        private void buscar() 
        {
            
            if (verificarExistencia() == true)
            {
                Alumno a = new Alumno();
                a.Dni = Convert.ToString(txt_dni.Text);
                int idEmp = Negocio.NegocioAlumnos.buscar(a,"-","-");
                txt_nombre.Text = a.Nombre;
                txt_apellido.Text = a.Apellido;
                DateTime fecha = txt_fechaNacimiento.Value;
                txt_fechaNacimiento.Value = fecha;
                txt_domicilio.Text = a.Domicilio;
                txt_telefono.Text = a.Telefono;
                txt_email.Text = a.Email;
                txt_division.Text = a.division;
                txt_curso.Text = a.Curso;
            }
            else 
            {
                MessageBox.Show("No existe el alumno con dni " + txt_dni.Text); 
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dni = txt_dni.Text;
            Negocio.NegocioAlumnos.eliminar(dni);
        }
    }
}
