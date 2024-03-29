﻿using EntidadAlumno;
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
        public List<barrios> barriosLista = new List<barrios>();
        
        string modo = "nada";
        public List<Alumno> alumnos = new List<Alumno>();
        public List<Cursos> cursos = new List<Cursos>();
       
        public NuevoAlumno()
        {
            InitializeComponent();
            barriosLista = Negocio.NegocioAlumnos.getBarrios();

           
            foreach (var barrio in barriosLista)
            {
                txt_barrio.Items.Add(barrio.descripcion);
            }
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
                    a.barrio = txt_barrio.Text;
                    a.calle = txt_calle.Text;
                    a.altura= txt_altura.Text;
                    a.edificio=txt_edificio.Text;
                    a.piso = txt_piso.Text;
                    a.numero_dpto = txt_numero_dpto.Text;
                    a.Telefono = txt_telefono.Text;
                    a.Email = txt_email.Text;
                    a.estado = txt_estado.Text;
                    a.indicacion = txt_indicacion.Text;


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
            txt_calle.Text = "";
            txt_telefono.Text = "";
            txt_email.Text = "";
            txt_altura.Text = "";
            txt_barrio.Text = "";
            txt_calle.Text = "";
            txt_edificio.Text = "";
            txt_estado.Text = "";
            txt_numero_dpto.Text = "";
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

            else if (txt_telefono.TextLength < 8 && txt_telefono.TextLength > 11)
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
                a.barrio = txt_barrio.Text;
                a.calle = txt_calle.Text;
                a.altura = txt_altura.Text;
                a.edificio = txt_edificio.Text;
                a.piso = txt_piso.Text;
                a.numero_dpto = txt_numero_dpto.Text;
                a.indicacion = txt_indicacion.Text;
                a.estado = txt_estado.Text;
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
            if (string.IsNullOrEmpty(txt_nombre.Text) && (string.IsNullOrEmpty(txt_apellido.Text)))
            {
                MessageBox.Show("Ingrese nombre o apellido para buscar");
            }
            else 
            {
                alumnos = helpers.busqueda.buscar(txt_nombre.Text, txt_apellido.Text);
                if (alumnos.Count >0) 
                {
                    if (alumnos.Count < 2)
                    {
                        cargar(alumnos[0]);
                        
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
            }
                
        }

        private void cargar(Alumno alumno)
        {
            txt_nombre.Text = alumno.Nombre;
            txt_apellido.Text = alumno.Apellido;
            DateTime fecha = alumno.FechaNacimiento;
            txt_fechaNacimiento.Value = alumno.FechaNacimiento;
            txt_barrio.Text = alumno.barrio;
            txt_calle.Text = alumno.calle;
            txt_altura.Text = alumno.altura;
            txt_edificio.Text = alumno.edificio;
            txt_piso.Text = alumno.piso;
            txt_numero_dpto.Text = alumno.numero_dpto;
            txt_estado.Text = alumno.estado;
            txt_telefono.Text = alumno.Telefono;
            txt_email.Text = alumno.Email;
            txt_dni.Text = alumno.Dni;
            txt_indicacion.Text = alumno.indicacion;
            cursos = Negocio.NegocioAlumnos.GetCursos(Convert.ToInt32(alumno.Dni));
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
                    
                    List<Alumno> lista = Negocio.NegocioAlumnos.buscar(Nombre, Apellido, Dni);
                    
                    cargar(lista[0]);
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
                        List<Alumno> a = Negocio.NegocioAlumnos.buscar("-", "-", txt_dni.Text);
                cargar(a[0]);
                    }
                    else
                    {
                        MessageBox.Show("No existe el alumno con dni: " + txt_dni.Text);
                    }
                
            }
            
        }
    }

