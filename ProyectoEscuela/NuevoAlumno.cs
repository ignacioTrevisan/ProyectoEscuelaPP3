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
using System.Text.RegularExpressions;

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
            string query = "SELECT COUNT(*) FROM Alumnos WHERE nombre = @nombre AND apellido = @apellido" ;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", txt_nombre.Text);
                cmd.Parameters.AddWithValue("@apellido", txt_apellido.Text);
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

        public Boolean verificarExistenciaDni()
        {
            string query = "SELECT COUNT(*) FROM Alumnos WHERE dni = @dni";
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
                if (verificarExistenciaDni() == false)
                {
                    a.Nombre = txt_nombre.Text;
                    a.Apellido = txt_apellido.Text;
                    a.Dni = txt_dni.Text;
                    a.FechaNacimiento = txt_fechaNacimiento.Value;
                    a.Domicilio = txt_domicilio.Text;
                    a.Telefono = txt_telefono.Text;
                    a.Email = txt_email.Text;
                    
                    DialogResult res = MessageBox.Show("¿Confirma guardar ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                        return;
                    }
                    int idEmp = Negocio.NegocioAlumnos.insertar(a);
                    MessageBox.Show("Se generó el alumno con dni " + a.Dni + "Nombre: " +a.Nombre + " Apellido: " + a.Apellido);
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
           
            txt_dni.Text = "";
        }

        public bool VerificacionDeDatosLogicos()
        {
            string patronCorreoElectronico = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
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
            else if (!Regex.IsMatch(txt_email.Text, patronCorreoElectronico))
            {
                MessageBox.Show("El EMAIL debe tener el formato correcto");
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
                a.Nombre = Convert.ToString(txt_nombre.Text);
                a.Apellido = txt_apellido.Text;
                int idEmp = Negocio.NegocioAlumnos.buscar(a,"-","-");
                txt_nombre.Text = a.Nombre;
                txt_apellido.Text = a.Apellido;
                DateTime fecha = a.FechaNacimiento;
                MessageBox.Show(a.FechaNacimiento.ToString());
                txt_fechaNacimiento.Value = a.FechaNacimiento;
                txt_domicilio.Text = a.Domicilio;
                txt_telefono.Text = a.Telefono;
                txt_email.Text = a.Email;
                txt_dni.Text = a.Dni;
            }
            else 
            {
                MessageBox.Show("No existe el alumno con el nombre " + txt_nombre.Text + " " + txt_apellido.Text ); 
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dni = txt_dni.Text;
            string nombre = txt_nombre.Text;
            string apellido = txt_apellido.Text;
            DialogResult res = MessageBox.Show("¿Está seguro que desea eliminar el alumno ? ", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                return;
            }
            Negocio.NegocioAlumnos.eliminar(dni);
            MessageBox.Show("Se eliminó el alumno "+nombre+" "+apellido+ " con dni " + txt_dni.Text);
            limpiarControles();
           
        }
    }
}
