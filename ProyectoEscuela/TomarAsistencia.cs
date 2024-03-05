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
           
            if (textBox1.Text != "")
            {

            
            string nombre = textBox1.Text;
            int a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            
                buscar(nombre, curso, division);
            }
            else
            {
                int a = 0;
                a = comboBox1.SelectedIndex;
                string curso = lista[a].Curso;
                string division = lista[a].Division;
                alumnos = Negocio.NegocioAlumnos.Get("0", curso, division, GlobalVariables.ciclo);
                refreshgrid();
            }
        }
        public void buscar(string nombre, string curso, string division)
        {
            
           
            alumnos = Negocio.NegocioAlumnos.Get(nombre, curso, division, GlobalVariables.ciclo);
            if (alumnos.Count > 0)
            {
                refreshgrid();
            }
            else
            {
                MessageBox.Show("No se encuentra este alumno, ten en cuenta de seleccionar bien el curso ");
            }

        }

        private void btn_prese_Click(object sender, EventArgs e)
        {
            string estado = "presente";
            DateTime fecha = dateTimePicker1.Value.Date;
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
                registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo);
            asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
            refreshgrid();

            }
        }

        private void registrarestado(string estado, DateTime fecha, int dni, string curso, string division, int ciclo)
        {
            Negocio.NegocioAlumnos.registrarEstado(estado, fecha, dni, curso, division, ciclo);

        }

        private void btn_ausente_Click(object sender, EventArgs e)
        {
            string estado = "ausente";
            int dni = Convert.ToInt32(label1.Text);
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
                bool hasBackgroundColor = SelectedRowHasBackgroundColor(dataGridView1);
                if (hasBackgroundColor)
                {
                    MessageBox.Show("La fila seleccionada tiene el color de fondo blanco.");
                }
                else
                {
                    MessageBox.Show("La fila seleccionada no tiene el color de fondo blanco.");

                }

                registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo);
                //MessageBox.Show(estado + "-fecha:" + fecha.ToString()+ "-dni:" + dni.ToString()+ "-curso:" + curso.ToString() + "-division:" + division + "-ciclo:" + GlobalVariables.ciclo);
                
                asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
            refreshgrid();
               
            }
        }

        private bool SelectedRowHasBackgroundColor(DataGridView dataGridView)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Obtener el color de fondo de la fila seleccionada
                Color rowBackColor = selectedRow.DefaultCellStyle.BackColor;

                // Verificar si el color de fondo de la fila seleccionada es igual al color objetivo
                if (rowBackColor == Color.White)
                {
                    // La fila seleccionada tiene el color de fondo especificado
                    return true;
                }
            }

            // La fila seleccionada no tiene el color de fondo especificado
            return false;

        }



        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            while (i < alumnos.Count)
            {
                if (alumnos[i].cantidadFaltas > 24)
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
                registrarestado(estado, fecha, dni, curso, division, GlobalVariables.ciclo);
                //MessageBox.Show(estado + "-fecha:" + fecha.ToString()+ "-dni:" + dni.ToString()+ "-curso:" + curso.ToString() + "-division:" + division + "-ciclo:" + GlobalVariables.ciclo);
                asistencias = Negocio.NegocioAlumnos.TraerAsistenciasDeHoy(curso, division, dateTimePicker1.Value, GlobalVariables.ciclo);
                refreshgrid();
            }
        }
    }
}
