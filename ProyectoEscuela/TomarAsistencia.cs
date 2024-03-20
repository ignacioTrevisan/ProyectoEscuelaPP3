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
using System.Reflection.Emit;
using NotasAlumnos;
using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace ProyectoEscuela
{
    public partial class TomarAsistencia : Form
    {
        
        public int id = 1;
        public int al = 0;
        public List<Nota> lista = new List<Nota>();
        public List<Alumno> alumnos = new List<Alumno>();
        public List<Alumno> asistencias = new List<Alumno>();
        public List<int> Ciclos = new List<int>();
        public List<Faltas> faltas = new List<Faltas>();
        public TomarAsistencia()
        {
            InitializeComponent();
            
            if (GlobalVariables.cargo == "profesor")
            {
                dateTimePicker1.Enabled = false;
            }

            lista = GetCursos(GlobalVariables.id);

            int i = 0;
            int o = 1;
            
            i = 0;
            o = 1;
            if (GlobalVariables.cargo == "profesor") 
            {
                if (lista.Count > 0)
                {
                    while (i < lista.Count)
                    {

                        while (o != lista.Count)
                        {
                            if (lista[i].id == lista[o].id && i != o)
                            {
                                lista.RemoveAt(o);
                            }
                            else
                            {
                                o++;
                            }
                        }
                        o = 0;
                        i++;
                    }
                }
            }
           
            
            i = 0;

            while (i != lista.Count)
            {
                comboBox1.Items.Add("curso: " + lista[i].Curso + " Division: " + lista[i].Division + "(" + lista[i].ciclo + ")");
                i++;
            }
        }



        public static List<Nota> GetCursos(int id)
        {
            List<Nota> lista = new List<Nota>();
            if (GlobalVariables.cargo == "preceptor" || GlobalVariables.cargo == "director")
            {
                lista = NegocioProfesor.GetPermisosPreceptor(10);
            }
            else
            {
                lista = NegocioProfesor.GetCursos(id);

            }
            int tam = lista.Count;
            return lista;
        }


        private void btn_buscarAlumno_Click(object sender, EventArgs e)
        {
            buscar();
        }
        public void buscar()
        {

            if (textBox1.Text != "")
            {
                string nombre = textBox1.Text;
                int a = comboBox1.SelectedIndex;
                string curso = lista[a].Curso;
                string division = lista[a].Division;

                alumnos = Negocio.NegocioAlumnos.Get(nombre, curso, division, GlobalVariables.ciclo);
                if (alumnos.Count > 0)
                {
                    refreshgrid();
                }
                else
                {
                    MessageBox.Show("No se encuentra este alumno, ten en cuenta de seleccionar bien el curso ");
                    buscarCurso();
                }
            }
            else
            {
                if (comboBox1.Text != "")
                {
                    buscarCurso();
                }
                
            }

        }

        private void btn_prese_Click(object sender, EventArgs e)
        {
            string estado = "presente";
            string comentario = textBox2.Text;
            DateTime fecha = dateTimePicker1.Value.Date;
            string fechaConvertida = fecha.ToString("dd/MM/yyyy");
            int a = comboBox1.SelectedIndex;
            int dni = Convert.ToInt32(label1.Text);
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            DateTime fechaActual = DateTime.Today;
            DateTime fechaHace7Dias = fechaActual.AddDays(-7);
            if (fecha <= fechaHace7Dias)
            {
                MessageBox.Show("No es posible modificar una asistencia en un rango anterior a una semana");
            }
            else if (fecha > fechaActual)
            {
                MessageBox.Show("No es posible determinar asistencias de días futuros");
            }
            else
            {
                if (comprobarCambio(asistencias) == true)
                {
                    DialogResult resultado = MessageBox.Show("El alumno ya cuenta con una asistencia registrada. ¿Está seguro que desea modificar el estado?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (resultado == DialogResult.Yes)
                    {
                        Task.Run(() => enviar());
                    }
                    else
                    {
                        return;
                    }
                }
                registrarestado(estado, Convert.ToDateTime(fechaConvertida), dni, curso, division, GlobalVariables.ciclo, comentario);


                asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
                refreshgrid();

            }
        }

        private void registrarestado(string estado, DateTime fecha, int dni, string curso, string division, int ciclo, string comentario)
        {
            Negocio.NegocioAlumnos.registrarEstado(estado, fecha, dni, curso, division, ciclo, comentario);

        }

        private void btn_ausente_Click(object sender, EventArgs e)
        {
            string estado = "ausente";
            string comentario = textBox2.Text;
            int dni = 0;
            try
            {
                dni = Convert.ToInt32(label1.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            
            DateTime fecha = dateTimePicker1.Value.Date;
            int  a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            DateTime fechaActual = DateTime.Today;
            DateTime fechaHace7Dias = fechaActual.AddDays(-7);
            if (fecha <= fechaHace7Dias)
            {
                MessageBox.Show("No es posible modificar una asistencia en un rango anterior a una semana");
            }
            else if (fecha>fechaActual) {
                MessageBox.Show("No es posible determinar asistencias de días futuros");
            }
            else 
            {
                
                if (comprobarCambio( asistencias) == true)
                {
                    DialogResult resultado = MessageBox.Show("El alumno ya cuenta con una asistencia registrada. ¿Está seguro que desea modificar el estado?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (resultado == DialogResult.Yes)
                    {
                        Task.Run(() => enviar());
                    }
                    else
                    {
                        return;
                    }
                }
               registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo, comentario);
                
                
                asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
            refreshgrid();
               
            }
        }

        private bool comprobarCambio( List<Alumno> asistencias)
        {
            
            // Verificar si hay alguna fila seleccionada en el DataGridView
           
                
                // Iterar sobre todas las asistencias para comprobar si el alumno ya tiene asistencia registrada
                foreach (Alumno asistencia in asistencias)
                {
                    if (label1.Text == asistencia.Dni && asistencia.estado != string.Empty)
                    {
                        return true; // El alumno ya tiene asistencia registrada
                    }
                }

            // Si se recorren todas las asistencias y no se encuentra coincidencia, devolver false
                return false;
            }

        private void enviar()
        {

            
                Comunicado c = new Comunicado();
                c.error = "";
                StringBuilder mensajeBuilder = new StringBuilder();
                mensajeBuilder.Append("El usuario: "+ GlobalVariables.usuario + "cambió la asistencia de día: " + dateTimePicker1.Value.Date 
                    + " para el alumno con dni: "+ label1.Text);
                c.de = "bauermaia1@gmail.com";
                c.para = "Nachotizii988@gmail.com";
                c.asunto = "Cambio en asistencias";
                c.fecha = DateTime.Now.Date;
                c.ruta ="";
               
                    enviarCorreo(mensajeBuilder, c, 0);
                

            }

        public static void enviarCorreo(StringBuilder mensaje, Comunicado c, int confirmacion)
        {
            c.error = "";
            try
            {
                mensaje.Append(Environment.NewLine);
                mensaje.Append(Environment.NewLine);
                MailMessage ms = new MailMessage();
                ms.From = new MailAddress(c.de);
                ms.CC.Add(new MailAddress(c.para));
                ms.Subject = c.asunto;
                
                string extension = Path.GetExtension(c.ruta);
                ms.Body = mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(GlobalVariables.usuario, GlobalVariables.password);
                smtp.EnableSsl = true;
                smtp.Send(ms);

            }
            catch (Exception ex)
            {
                c.error = "Error: " + ex.Message;
                MessageBox.Show(c.error);
                return;
            }
        }


        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarCurso();
        }

        private void buscarCurso()
        {
            int a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            if (cursosGlobal.modo == 1)
            {
                curso = cursosGlobal.curso;
                division = cursosGlobal.division;
            }
            seleccionarCurso(curso, division);
        }

        public void seleccionarCurso(string curso, string division)
        {

           
            dateTimePicker1.MinDate = new DateTime(2000, 6, 1);
            dateTimePicker1.MaxDate = new DateTime(3000, 1, 1);

            int a = comboBox1.SelectedIndex;
            if (GlobalVariables.cargo == "director" || GlobalVariables.cargo == "preceptor")
            {
                GlobalVariables.ciclo = lista[a].ciclo;
            }
            Int32 año = GlobalVariables.ciclo;
            if (GlobalVariables.cargo != "profesor")
            {
                dateTimePicker1.Value = new DateTime(año, 6, 1);
                dateTimePicker1.MaxDate = new DateTime(año, 12, 31);
                dateTimePicker1.MinDate = new DateTime(año, 1, 1);
            }
            if (GlobalVariables.cargo == "profesor") 
            {
                dateTimePicker1.Value = DateTime.Now;
            }



            alumnos = Negocio.NegocioAlumnos.GetXCurso("", curso, division, GlobalVariables.ciclo);
            int i = 0;
            float contador = 0;
            while (i < alumnos.Count)
            {
               
                faltas = Negocio.NegocioAlumnos.BuscarFaltas(alumnos[i].Dni, lista[comboBox1.SelectedIndex].ciclo, lista[comboBox1.SelectedIndex].Curso, division);
                contador = helpers.ConvertirFaltas.conversion(faltas);
                if (contador > 24)
                {
                    MessageBox.Show("ATENCIÓN, el alumno: " + alumnos[i].Nombre + " llego las 25 faltas");
                }
                i++;
            }
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
            refreshgrid();
        }

        private void refreshgrid()
        {
            if (alumnos.Count > 0) {
                lbl_alumno.Visible = true;
                label1.Visible = true;
                lbl_alumno.Text = alumnos[0].Nombre;
                label1.Text = alumnos[0].Dni;
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = alumnos;
                bindingSource2.DataSource = null;
                bindingSource2.DataSource = asistencias;
                obtenerListaDeAlumnosSinTomarAsistencia(alumnos, asistencias);
            }
            else {
                MessageBox.Show("No se encontraron alumnos inscriptos a este curso");
            }
        }

        private void obtenerListaDeAlumnosSinTomarAsistencia(List<Alumno> alumnos, List<Alumno> asistencias)
        {
            //este metodo sirve para obtener una lista nueva de todos los alumnos a los cuales no se les paso asistencias
            //para asi poder cambiar el color en su grid en un nuevo metodo
            List<Alumno> nuevaLista = new List<Alumno>(alumnos);
            int e = 0;
            int a = 0;
            
            
            
            while (e < asistencias.Count) 
            {
               
                a = 0;
                while (a < nuevaLista.Count) 
                {
                    if (nuevaLista[a].Dni == asistencias[e].Dni)
                    {
                        nuevaLista.RemoveAt(a);
                    }
                    else 
                    {
                        a++;
                    }
                }
                e++;
            }
            a = 0;
           
            cambiarColor(nuevaLista, alumnos);
        }

        private void cambiarColor(List<Alumno> nuevaLista, List<Alumno> alumnos)
        {
            //teniendo la lista de los alumnos a los que no se les paso asistencia podemos comparar
            //con la lista de alumnos del curso, por lo cual podemos trabajar estos datos de manera mas particular
            int i = 0;
            int a = 0;
            while (i < alumnos.Count) 
            {
                a = 0;
                while (a < nuevaLista.Count) 
                {
                    if (alumnos[i].Dni == nuevaLista[a].Dni)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    }
                    a++;
                }
                i++;
                
                                 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int j = cell.RowIndex;
                    string Nombre = alumnos[j].Nombre;
                    string Apellido = alumnos[j].Apellido;
                    string Dni = alumnos[j].Dni;
                    
                    label1.Text = Dni;
                    lbl_alumno.Text = Nombre + "  "+ Apellido;

                }
            }
            
            
        }

        private void TomarAsistencia_Load(object sender, EventArgs e)
        {
            if (GlobalVariables.cargo == "director")
            {
                btn_ausente.Enabled = false;
                btn_prese.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int a = 0;
            a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            if (GlobalVariables.cargo == "director" || GlobalVariables.cargo == "preceptor")
            {
                GlobalVariables.ciclo = lista[a].ciclo;
            }
            alumnos = Negocio.NegocioAlumnos.GetXCurso("", curso, division, GlobalVariables.ciclo);
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
            refreshgrid();
        }

        private void btn_media_Click(object sender, EventArgs e)
        {
            string estado = "media falta";
            string comentario = textBox2.Text;
            int dni = Convert.ToInt32(label1.Text);
            DateTime fecha = dateTimePicker1.Value.Date;
            int a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            DateTime fechaActual = DateTime.Today;
            DateTime fechaHace7Dias = fechaActual.AddDays(-7);
            if (fecha <= fechaHace7Dias)
            {
                MessageBox.Show("No es posible modificar una asistencia en un rango anterior a una semana");
            }
            else if (fecha > fechaActual)
            {
                MessageBox.Show("No es posible determinar asistencias de días futuros");
            }
            else
            {
                if (comprobarCambio(asistencias) == true)
                {
                    DialogResult resultado = MessageBox.Show("El alumno ya cuenta con una asistencia registrada. ¿Está seguro que desea modificar el estado?", "Confirmar Modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                    if (resultado == DialogResult.Yes)
                    {
                        Task.Run(() => enviar());
                    }
                    else
                    {
                        return;
                    }
                }
                registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo, comentario);


                asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
                refreshgrid();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
            
        }   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buscar();
            }
        }
    }
}
