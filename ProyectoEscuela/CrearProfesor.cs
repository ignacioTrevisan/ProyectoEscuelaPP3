using EntidadAlumno;
using EntidadProfesor;
using NegocioAlumnos;
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
    public partial class CrearProfesor : Form
    {
        public List<barrios> barriosLista = new List<barrios>();
        public CrearProfesor()
        {
            InitializeComponent();
            barriosLista = Negocio.NegocioAlumnos.getBarrios();
            foreach (var barrio in barriosLista)
            {
                txt_barrio.Items.Add(barrio.descripcion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        public void guardar()
        {
            try
            {
                profesor p = new profesor();
                if (!VerificacionDeDatosLogicos()) return;
                if (verificarExistencia() == false)
                {
                    string cargo = "";
                    p.Nombre = txt_nombre.Text;
                    p.Apellido = txt_apellido.Text;
                    p.Dni = txt_dni.Text;
                    p.FechaNacimiento = txt_fechaNacimiento.Value;
                    p.barrio = txt_barrio.Text;
                    p.calle = txt_calle.Text;
                    p.altura = txt_altura.Text;
                    p.edificio = txt_edificio.Text;
                    p.piso = txt_piso.Text;
                    p.numero_dpto = txt_numero_dpto.Text;
                    p.indicacion = txt_indicacion.Text;
                    p.Telefono = txt_telefono.Text;
                    p.Email = txt_email.Text;
                    p.contraseña = txt_contraseña.Text;
                    p.estado = txt_estado.Text;
                    if (caja.Checked == true)
                    {
                        cargo = "preceptor";
                    }
                    else
                    {
                        cargo = "profesor";
                    }

                    DialogResult res = MessageBox.Show("¿Confirma guardar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No) { return; }
                    int idEmp = NegocioProfesor.insertar(p, cargo);
                    MessageBox.Show("Se generó el profesor con el dni:" + p.Dni);
                    limpiarControles();
                }
                else
                {
                    MessageBox.Show("No se puede generar el docente porque ya existe registrado el deni " + txt_dni.Text);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool verificarExistencia() {
            string query = "SELECT COUNT (*) FROM directivos WHERE DNI = @dni";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@dni", txt_dni.Text);
                int count = (int)cmd.ExecuteScalar();
                if (count ==0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool VerificacionDeDatosLogicos()
        {
            int caracter = txt_dni.Text.Length;
            if (caracter >8 || caracter<7)
            {
                MessageBox.Show("El dni está mal ingresado o no se ingresó");
                return false;
            } else
            if (txt_apellido.Text=="")
            {
                MessageBox.Show("El apelldio está mal ingresado o no se ingresó");
                return false;
            }else
            if (txt_nombre.Text == "")
            {
                MessageBox.Show("El nombre está mal ingresado o no se ingresó");
                return false;
            }
            else
                if (txt_telefono.Text=="")
            {
                MessageBox.Show("El teléfono está mal ingresado o no se ingresó");
                return false;
            }
            else
               

            return true;
        }


        public void limpiarControles()
        {
            txt_nombre.Text = string.Empty;
            txt_apellido.Text = string.Empty;
            txt_telefono.Text = string.Empty;
            txt_email.Text = string.Empty;
            
            txt_dni.Text = string.Empty;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string dni = txt_dni.Text;
            profesor pro = new profesor();
            pro = NegocioProfesor.getProfesor(dni);
            if (pro.Dni != null)
            {
                txt_nombre.Text = pro.Nombre;
                txt_apellido.Text = pro.Apellido;
                txt_dni.Text = pro.Dni;
               
                txt_telefono.Text = pro.Telefono;
                if (pro.FechaNacimiento != DateTime.MinValue)
                {
                    txt_fechaNacimiento.Text = pro.FechaNacimiento.ToString();
                }
                else
                {


                }

                txt_email.Text = pro.Email;
            }
            else
            {
                MessageBox.Show("No existe tal profesor. ");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            profesor p = new profesor();
            p.Nombre = txt_nombre.Text;
            p.Apellido = txt_apellido.Text;
            p.Dni = txt_dni.Text;
            p.FechaNacimiento = txt_fechaNacimiento.Value;
            p.barrio = txt_barrio.Text;
            p.calle = txt_calle.Text;
            p.altura = txt_altura.Text;
            p.edificio = txt_edificio.Text;
            p.piso = txt_piso.Text;
            p.numero_dpto = txt_numero_dpto.Text;
            p.indicacion = txt_indicacion.Text;
            p.Telefono = txt_telefono.Text;
            p.Email = txt_email.Text;
            p.contraseña = txt_contraseña.Text;
            p.estado = txt_estado.Text;
            DialogResult res = MessageBox.Show("¿Confirma modificar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) { return; }
            int idEmp = NegocioProfesor.modificar(p);
            MessageBox.Show("Se generó el modifico con el dni:" + p.Dni);
            limpiarControles();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Confirma eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                NegocioProfesor.eliminar(txt_dni.Text);
            }
            MessageBox.Show("Profesor eliminado correctamente. ");
            limpiarControles();
        }
    }


    
}
