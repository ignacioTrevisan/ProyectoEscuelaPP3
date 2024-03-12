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
            if (textBox2.Text == "Nota final-trimestre" || textBox2.Text == "Nota final-diciembre" || textBox2.Text == "Nota final-febrero")
            {
                MessageBox.Show("Este comentario es un comentario reservado para la carga de notas finales por etapa, por favor, cambielo. ");
            }
            else 
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
                cBox3();
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
          
        }

        public void actualizarPorAlumno() 
        {
            int id = comboBox2.SelectedIndex;
            int ciclo = GlobalVariables.ciclo;
            alumno = NotasNegocio.GetNotasXAlumno(alumnos[id].Dni, materia, GlobalVariables.id, alumnos[id].Curso, alumnos[id].division, ciclo);
            
            if (comboBox2.Text != "")
            {
                bindingSource1.DataSource = null;
                bindingSource1.DataSource = alumno;
                dataGridView1.DataSource = bindingSource1;
                int cantidadDeNotas = alumno.Count();
                txt_condicion.Text=evaluarCondicion(alumno);
                

            }
            else 
            {
                MessageBox.Show("Seleccione un alumno");
                comboBox3.Text = "";
            }
            VerEstado();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_condicion.Text = "";
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
            int id = comboBox2.SelectedIndex;
            int ciclo = GlobalVariables.ciclo;
            alumno = NotasNegocio.GetNotasXAlumno(alumnos[id].Dni, materia, GlobalVariables.id, alumnos[id].Curso, alumnos[id].division, ciclo);
            etapasDisponibles(alumno);
        }

        private void VerEstado()
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
            if (!string.IsNullOrEmpty(comboBox1.Text) && (!string.IsNullOrEmpty(comboBox2.Text)))
            {
                registrar(nota, comentario);
            }
            else
            {
                MessageBox.Show("Para registrar notas primero debe ingresar el curso, materia, alumno y su nota ");
            }
            panel1.Visible = false;
            button2.Visible = true;
            button2.Enabled = false;
            btnConfirmar.Enabled = false;
            comboBox3.Text = "";
            int id = comboBox2.SelectedIndex;
            int ciclo = GlobalVariables.ciclo;
            alumno = NotasNegocio.GetNotasXAlumno(alumnos[id].Dni, materia, GlobalVariables.id, alumnos[id].Curso, alumnos[id].division, ciclo);
            etapasDisponibles(alumno);
            actualizarPorAlumno();
        }

        private string evaluarCondicion(List<Nota> alumno)
        {
            float promedio = sacarPromedioTrimestres(alumno);
            if (promedio < 6 && promedio != 0)
            {
                for (int i = 0; i < alumno.Count; i++)
                {
                    if (alumno[i].etapa == "Semana extra-febrero")
                    {
                        if (Convert.ToInt32(alumno[i].Calificacion) > 5)
                        {
                            return "Condicion: Aprobado por febrero";
                        }
                        else
                        {
                            return "Condicion: Desaprobado";
                        }
                    }
                    else
                    {
                        if (alumno[i].etapa == "Semana extra-diciembre")
                        {
                            if (Convert.ToInt32(alumno[i].Calificacion) > 5)
                            {
                                estado = "aprobado en diciembre";
                                return "Condicion: Aprobado por diciembre";
                            }
                        }
                    }
                }
            }
            if (promedio > 5 && promedio != 0)
            {
                estado = "aprobado por promedio";
                return "Condicion: aprobado por promedio";
               
            }
            return "Cursando";
        }

        private float sacarPromedioTrimestres(List<Nota> alumno)
        {
            float promedio = 0;
            int cantidad = 0;
            for (int i = 0; i < alumno.Count; i++)
            {
                if (alumno[i].comentario == "Nota final-trimestre")
                {
                    promedio = promedio + Convert.ToInt32(alumno[i].Calificacion);
                    cantidad++;
                }
            }
            if (cantidad == 3)
            {
                promedio = promedio / 3;
                return promedio;
            }
            return 0;
        }

        private void RegistrarNota_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConfirmar.Enabled = true;
            button2.Enabled = true;
            verificarPermiso();
        }

        private void cBox3()
        {
            
            
            
            verificarPermiso();

            label7.Text = "Promedio: " + SacarPromedioSinNotaFinal(alumno, comboBox3.Text) + " (Exceptuando notas finales)";
        }

        private void verificarPermiso()
        {
            int cantidad = 0;
            int i = comboBox1.SelectedIndex;
            DateTime nulla = new DateTime(0 - 0 - 0);
            int idProfesor = GlobalVariables.id;
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
                command.Parameters.AddWithValue("@idProfesor", idProfesor);
                command.Parameters.AddWithValue("@año", curso);
                command.Parameters.AddWithValue("@division", division);
                command.Parameters.AddWithValue("@ciclo", ciclo);
                command.Parameters.AddWithValue("@materia", materia);
                command.Parameters.AddWithValue("@etapa", etapa);

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    cantidad = Convert.ToInt32(reader["cantidad"]);
                }
                connection.Close();
                reader.Close();
            }
            if (cantidad == 1)
            {
                if (DateTime.Now < hasta)
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
                    string a = NegocioProfesor.cambiarPermisosParaRegistrarNotas(1, etapa, dni, curso, division, ciclo.ToString(), materia, "Deshabilitado");
                    btnConfirmar.Enabled = false;
                    button2.Enabled = false;
                }
            }
            else
            {

                btnConfirmar.Enabled = false;
                button2.Enabled = false;
                MessageBox.Show("No posee permisos para registrar notas en esta etapa. Soliciteselo al director. " + cantidad);
            }
        }

        private float SacarPromedioSinNotaFinal(List<Nota> alumno, string etapa)
        {
            int cant = 0;
            float promedio = 0;
            for (int i = 0; i < alumno.Count; i++) 
            {
                if (alumno[i].comentario != "Nota final-trimestre" && alumno[i].comentario != "Nota final-febrero" && alumno[i].comentario != "Nota final-diciembre" && alumno[i].etapa == etapa) 
                {
                    cant++;
                    promedio = promedio + Convert.ToInt64(alumno[i].Calificacion);
                }

            }
            if (cant > 0)
            {
                label7.Visible = true;

            }
            else 
            {
                label7.Visible = false;
            }
            return promedio / cant;
            
        }

        private void etapasDisponibles(List<Nota> alumno)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            int cantidad = 0;
            string[] todasLasEtapas = new string[5]; 

            todasLasEtapas[0] = "Primer trimestre"; 
            todasLasEtapas[1] = "Segundo trimestre"; 
            todasLasEtapas[2] = "Tercer trimestre"; 
            todasLasEtapas[3] = "Semana extra-diciembre"; 
            todasLasEtapas[4] = "Semana extra-febrero";
            for (int i = 0; i < alumno.Count; i++)
            {
                if (alumno[i].comentario == "Nota final-trimestre" || alumno[i].comentario == "Nota final-diciembre" || alumno[i].comentario == "Nota final-febrero")
                {
                    cantidad++;
                }
            }
            
            
            int o = 0;
            while (o <= cantidad) 
            {
                if (o == 5) 
                {
                    break;
                }
                comboBox3.Items.Add(todasLasEtapas[o]);
                o++;
            }
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
