using EntidadPermiso;
using EntidadAlumno;
using EntidadNota;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ProyectoEscuela.Front;
using NotasAlumnos;
using static ProyectoEscuela.inicioSesion;
using NegocioAlumnos;
using System.Data.SqlClient;
using iTextSharp.text.pdf.codec.wmf;
using iTextSharp.text.pdf.qrcode;
using System.Security.Cryptography;

namespace ProyectoEscuela
{
    public partial class RegistrarNota : Form
    {
        public List<Nota> notas = new List<Nota>();
        public List<Nota> lista = new List<Nota>();
        public List <Alumno> alumnos = new List<Alumno> ();
        List<Nota> alumno = new List<Nota>();
        int i = 0;
        public string materia = "";
        public string curso = "";
        public int ciclo = 0;
        public string division = "";
        public string etapa = "";
        public string estado = "";

        public RegistrarNota()
        {
            InitializeComponent();
            lista = GetCursos(GlobalVariables.id);
            
            int tam = lista.Count;
            while (i < tam)
            {
                comboBox1.Items.Add("curso: " + lista[i].Curso + " Division: " + lista[i].Division + " materia: " + lista[i].Materia);
                i++;
            }
        }

        private void btnConfirmarMateria_Click(object sender, EventArgs e)
        {
            

        }
        public static List<Nota> GetCursos(int id)
        {
            List<Nota> lista = new List<Nota>();
            lista = NegocioProfesor.GetCursos(id);
            int tam = lista.Count;
            
            return lista;
        }

        private void refreshGrid()
        {

            bindingSource1.DataSource = null;
            bindingSource1.DataSource = notas;
            dataGridView1.DataSource = bindingSource1;
            int i = 0;
            int tamaño = alumnos.Count;
            while (i < tamaño) 
            {
                comboBox2.Items.Add(alumnos[i].Apellido +" " + alumnos[i].Nombre);
                i++;
            }
        }

        private List<Nota> getnotas()
        {
            int i = comboBox1.SelectedIndex;
            materia = lista[i].Materia;
            curso = lista[i].Curso;
            division = lista[i].Division;
            int ciclo = GlobalVariables.ciclo;
            return notas = NotasNegocio.GetNotas(curso, division, materia, ciclo);
        }

        private List <Alumno>GetAlumnos() 
        {
            int i = comboBox1.SelectedIndex;
            materia = lista[i].Materia;
            curso = lista[i].Curso;
            division = lista[i].Division;
            string dni = "0";
            return alumnos = Negocio.NegocioAlumnos.GetXCurso(dni, curso, division, GlobalVariables.ciclo);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
           
            int ciclo = GlobalVariables.ciclo;
            string nota = txtNota.Text;
            string comentario = "";
            comentario = textBox2.Text;
            if (!string.IsNullOrEmpty(comboBox1.Text) && (!string.IsNullOrEmpty(comboBox2.Text)) && (!string.IsNullOrEmpty(txtNota.Text)))
            {
                registrar(nota, comentario);
                actualizarPorAlumno();
            }
            else 
            {
                MessageBox.Show("Para registrar notas primero debe ingresar el curso, materia, alumno y su nota ");
            }
           
        }

        public void registrar(string nota, string comentario)
        {
            int i = comboBox1.SelectedIndex;
            curso = lista[i].Curso;
            division = lista[i].Division;
            int id = comboBox2.SelectedIndex;
            DateTime fecha = dateTimePicker1.Value.Date;
            NotasNegocio.registrarNotas(materia, alumnos[id].Dni, nota, GlobalVariables.id, fecha, comentario, curso, division, GlobalVariables.ciclo, comboBox3.Text);
            actualizarPorAlumno();
        }

        public void actualizarPorAlumno() 
        {
            if (comboBox2.Text != "")
            {


                int id = comboBox2.SelectedIndex;
                int ciclo = GlobalVariables.ciclo;
                alumno = NotasNegocio.GetNotasXAlumno(alumnos[id].Dni, materia, GlobalVariables.id, alumnos[id].Curso, alumnos[id].division, ciclo);
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = alumno;
                dataGridView1.DataSource = bindingSource1;
                int cantidadDeNotas = alumno.Count();
                int r = 0;
                float nota = 0;
                float promedio = 0;
                int cantidad = 0;
                for (int i = 0; i < alumno.Count; i++)
                {

                    if (alumno[i].comentario == "Nota final-trimestre")
                    {
                        cantidad++;
                        promedio = Convert.ToInt64(alumno[i].Calificacion) + promedio;
                    }
                    if (cantidad == 3)
                    {
                        promedio = promedio / 3;
                        if (promedio > 5)
                        {
                            txt_condicion.Visible = true;
                            txt_condicion.Text = "Condicion: Aprobado por promedio";
                            estado = "aprobado por promedio";
                            break;
                        }
                        else
                        {
                            for (int ir = 0; ir < alumno.Count; ir++)
                            {
                                if (alumno[ir].comentario == "Nota final-diciembre")
                                {
                                    if (Convert.ToInt32(alumno[ir].Calificacion) > 5)
                                    {
                                        txt_condicion.Visible = true;
                                        txt_condicion.Text = "Condicion: Aprobado por diciembre";
                                        estado = "aprobado en diciembre";
                                        break;
                                    }

                                }
                                if (alumno[ir].comentario == "Nota final-febrero")
                                {
                                    if (Convert.ToInt32(alumno[ir].Calificacion) > 5)
                                    {
                                        txt_condicion.Visible = true;
                                        txt_condicion.Text = "Condicion: Aprobado por febrero";
                                        estado = "aprobado en febrero";
                                        break;
                                    }
                                    else
                                    {
                                        txt_condicion.Visible = true;
                                        txt_condicion.Text = "Condicion: Desaprobado";
                                        estado = "desaprobado";
                                    }
                                }

                            }
                        }

                    }
                }
                if (comboBox3.Text != "")
                {
                    if (alumno.Count > 0) 
                    {
                        nota = Negocio.NegocioAlumnos.getPromedio(alumno[id].Dni, materia, curso, division, ciclo, etapa);
                        label7.Visible = true;
                        Promedio_trimestre.Visible = true;
                        if (nota == 100)
                        {
                            Promedio_trimestre.Text = "N/A";
                        }
                        else
                        {
                            Promedio_trimestre.Text = nota.ToString();

                        }
                    }
                   


                }

            }
            else 
            {
                MessageBox.Show("Seleccione un alumno");
                comboBox3.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            i = 0;
            getnotas();
            GetAlumnos();

            if (!string.IsNullOrEmpty(materia) || (!string.IsNullOrEmpty(curso)) || (!string.IsNullOrEmpty(division)))
            {
                if (alumnos.Count < 1)
                {
                    MessageBox.Show("No se encontraron datos, probablemente no tenga permisos para acceder a datos de esta materia y curso " + GlobalVariables.id);
                }
                else
                {
                    if (notas.Count < 1)
                    {
                        MessageBox.Show("Aún no hay notas cargadas. ");
                    }
                    else 
                    {
                        txtNota.Text = notas[i].Calificacion;
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los datos ");
            }
            refreshGrid();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarPorAlumno();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (cell.Value != null) 
                    {
                        int j = cell.RowIndex;


                    DialogResult result = MessageBox.Show("¿Seguro que desea eliminar esta nota?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        NotasNegocio.eliminarNota(alumno[j].id);
                        string nombre = alumno[j].Nombre;
                        string apellido = alumno[j].Apellido;
                    }
                }
                }
            actualizarPorAlumno();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ésta opción es para registrar notas finales de cierre de materia, recomendamos generar informe para tener seguimiento. ¿Esta seguro que desea registrar la nota final?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                panel1.Visible = true;
                button2.Visible = false;

            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nota = textBox1.Text;
            string comentario = "Nota final-trimestre";
            if (comboBox3.Text == "Semana extra-diciembre") 
            {
                 comentario = "Nota final-diciembre";
            }
            if (comboBox3.Text == "Semana extra-febrero")
            {
                comentario = "Nota final-febrero";
            }
            if (!string.IsNullOrEmpty(comboBox1.Text) && (!string.IsNullOrEmpty(comboBox2.Text)) && (!string.IsNullOrEmpty(txtNota.Text)))
            {
                registrar(nota, comentario);
            }
            else
            {
                MessageBox.Show("Para registrar notas primero debe ingresar el curso, materia, alumno y su nota ");
            }
            panel1.Visible = false;
            button2.Visible = true;
            comboBox3.Text = "";
        }

        private void RegistrarNota_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = true;
            button2.Enabled = true;
            if (comboBox3.SelectedIndex == 3 && estado == "aprobado por promedio") 
            {
                btnConfirmar.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("El alumno no necesita notas en diciembre ni en febrero por que ya esta aprobado por promedio. ");
            }
            if (comboBox3.SelectedIndex == 4 && estado == "aprobado por promedio")
            {
                btnConfirmar.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("El alumno no necesita notas en febrero por que ya esta aprobado por promedio. ");
            }
            if (comboBox3.SelectedIndex == 4 && estado == "aprobado en diciembre")
            {
                btnConfirmar.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("El alumno no necesita notas en febrero por que ya esta aprobado en diciembre. ");
            }
            bool hayFecha = false;
            int i = comboBox1.SelectedIndex;
            DateTime nulla = new DateTime(0-0-0);
            //esta variable "nulla" es para poder mandar al sp cambiarPermisoParaRegistrarNota cuando se descubre que finalizo la el tiempo para registrar notas en una etapa
            //por que si le ponemos 0-0-0 manda valor null (ver en datos.Profesores)
            int cantidad = 0;
            curso = lista[i].Curso;
            division = lista[i].Division;
            ciclo = lista[i].ciclo;
            materia = lista[i].Materia;
            etapa = comboBox3.Text;
            DateTime hasta = DateTime.MaxValue;
            string dni = GlobalVariables.dni;
            actualizarPorAlumno();
           
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))

            {
                connection.Open();

                SqlCommand command = new SqlCommand("verificarPermisoParaRegistrarNota", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dniProfesor", dni);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                command.Parameters.AddWithValue("@materia", materia);
                command.Parameters.AddWithValue("@etapa", etapa);

                SqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    if (Convert.IsDBNull(reader["hasta"]))
                    {
                         hayFecha = false;
                    }
                    else 
                    {
                        hasta = Convert.ToDateTime(reader["hasta"]);
                        
                        hayFecha = true;
                    }
                    cantidad = Convert.ToInt32(reader["cantidad"]);
                }
                connection.Close();
                reader.Close();
            }
            if ( cantidad == 1)
            {
                if ( DateTime.Now < hasta)
                {
                    
                    for (int ia = 0; ia < alumno.Count; ia++)
                    {
                        if (alumno[ia].etapa == etapa)
                        {
                            if (alumno[ia].comentario == "Nota final-trimestre")
                            {
                                MessageBox.Show("La nota para este alumno en esta etapa ya esta cerrada ");
                                btnConfirmar.Enabled = false;
                                button2.Enabled = false;
                                break;
                            }
                            else if (alumno[ia].comentario == "Nota final-diciembre")
                            {
                                MessageBox.Show("La nota para este alumno en esta etapa ya esta cerrada ");
                                btnConfirmar.Enabled = false;
                                button2.Enabled = false;
                                break;
                            }
                            else if (alumno[ia].comentario == "Nota final-febrero")
                            {
                                MessageBox.Show("La nota para este alumno en esta etapa ya esta cerrada ");
                                btnConfirmar.Enabled = false;
                                button2.Enabled = false;
                                break;
                            }
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("No posee permisos para registrar notas en esta etapa. Finalizo el " + hasta.ToString("d/M/yyyy") + " Soliciteselo al director. ");
                    string a = NegocioProfesor.cambiarPermisosParaRegistrarNotas(1, etapa, dni, curso, division, ciclo.ToString(), materia, "Deshabilitado", nulla, nulla);
                    btnConfirmar.Enabled = false;
                    button2.Enabled = false;
                }
            }
            else
            {

                btnConfirmar.Enabled = false;
                button2.Enabled = false; 
                MessageBox.Show("No posee permisos para registrar notas en esta etapa. Soliciteselo al director. ");
            }
           
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
