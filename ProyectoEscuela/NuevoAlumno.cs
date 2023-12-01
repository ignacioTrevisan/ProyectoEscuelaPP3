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
using NotasAlumnos;

namespace ProyectoEscuela
{
    public partial class NuevoAlumno : Form
    {
        string modo = "nada";
        public List<Alumno> alumnos = new List<Alumno>();
        public List<Cursos> cursos = new List<Cursos>();
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
            string query = "SELECT COUNT(*) FROM Alumnos WHERE nombre = @nombre AND apellido = @apellido";
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
                    MessageBox.Show("Se generó el alumno con dni " + a.Dni + "Nombre: " + a.Nombre + " Apellido: " + a.Apellido);
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
            string dni = txt_dni.Text;

            if (dni.Length != 7 && dni.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 7 u 8 caracteres.");
                return false;
            }

            if (!int.TryParse(dni, out _))
            {
                MessageBox.Show("El DNI debe contener solo números.");
                return false;
            }

            else if (txt_apellido.Text == "")
            {
                MessageBox.Show("El APELLIDO está mal ingresado o no se ingresó");
                return false;
            }
            else if (txt_nombre.Text == "")
            {
                MessageBox.Show("El NOMBRE está mal ingresado o no se ingresó");
                return false;
            }

            else if (txt_telefono.Text == "")
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

                if (verificarExistenciaDni() == true)
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
            if (string.IsNullOrEmpty(txt_nombre.Text) || (string.IsNullOrEmpty(txt_apellido.Text)))
            {
                MessageBox.Show("Ingrese nombre y apellido del alumno a buscar ");
            }
            else 
            {

                if (verificarExistencia() == true)
                {
                    Alumno a = new Alumno();
                    string nombre = Convert.ToString(txt_nombre.Text);
                    string apellido = txt_apellido.Text;
                    string dni = "0";
                    buscar(nombre, apellido, dni);
                }
                else 
                {
                    MessageBox.Show("No existe el alumno " + txt_nombre.Text + " " + txt_apellido.Text);
                }
            }
        }
        public void buscar(string nombre, string apellido, string dni)
        {
            
               
                alumnos = Negocio.NegocioAlumnos.buscar(nombre, apellido, dni);
               
                if (alumnos.Count < 2)
                {
                    
                    txt_nombre.Text = alumnos[0].Nombre;
                    txt_apellido.Text = alumnos[0].Apellido;
                    DateTime fecha = alumnos[0].FechaNacimiento;
                    txt_fechaNacimiento.Value = alumnos[0].FechaNacimiento;
                    txt_domicilio.Text = alumnos[0].Domicilio;
                    txt_telefono.Text = alumnos[0].Telefono;
                    txt_email.Text = alumnos[0].Email;
                    txt_dni.Text = alumnos[0].Dni;
                    cursos = Negocio.NegocioAlumnos.GetCursos(Convert.ToInt32(alumnos[0].Dni));
                    dataGridView2.DataSource = cursos;
                   
                    alumnos.Clear();
                }
                else
                {
                    
                    MessageBox.Show("Hubo mas de una coincidencia, por favor selecciona el alumno a buscar ");
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = alumnos;
                   
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
            MessageBox.Show("Se eliminó el alumno " + nombre + " " + apellido + " con dni " + txt_dni.Text);
            limpiarControles();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int j = cell.RowIndex;
                    Alumno a = new Alumno();
                    string Nombre = alumnos[j].Nombre;
                    string Apellido = alumnos[j].Apellido;
                    string Dni = alumnos[j].Dni;
                    
                    buscar(Nombre, Apellido, Dni);
                    dataGridView1.Visible = false;
                   

                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dni = txt_dni.Text;
            if (string.IsNullOrEmpty(txt_dni.Text))
            {
                MessageBox.Show("Ingrese dni");
            }
            else if(!int.TryParse(dni, out _))
                {
                    MessageBox.Show("El DNI debe contener solo números.");

                }
                else if (dni.Length != 7 && dni.Length != 8)
                    {
                        MessageBox.Show("El DNI debe tener 7 u 8 caracteres.");

                    }
                
                else if (verificarExistenciaDni() == true)
                    {
                        buscar("-", "-", txt_dni.Text);
                    }
                    else
                    {
                        MessageBox.Show("No existe el alumno con dni: " + txt_dni.Text);
                    }
                
            }
            
        }
    }

