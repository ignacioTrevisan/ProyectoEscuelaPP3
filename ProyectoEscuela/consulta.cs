using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NegocioAlumnos;
using EntidadAlumno;
using static Negocio.NegocioAlumnos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static ProyectoEscuela.inicioSesion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;
using NotasAlumnos;
using System.Data.SqlClient;
using EntidadNota;

namespace ProyectoEscuela
{
    public partial class consulta : Form
    {
        List<Alumno> ListaAlumnos = new List<Alumno>();
        List<Alumno> alumnoInforme = new List<Alumno>();
        List <Faltas> faltas = new List<Faltas>();
        List <boletin> boletin = new List <boletin>();
        public consulta()
        {
            InitializeComponent();
            buscarAlumnos(0);
        }

     
        private void mostrarAlumnos()
        {
            DataTable dt = Negocio.NegocioAlumnos.buscarinasistencias();
            dataGridView1.DataSource = dt;
            
        } 

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // verificar si se hizo clic en una celda válida
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null) // verificar si la celda tiene algún valor
                {
                    string nombre = cell.Value.ToString();
                    MessageBox.Show("Hola " + nombre + "!");
                }
            }
        }

        
        private void buscarAlumnos(double dni)
        {
           
            string curso = txtCurso.Text;
            string division = txtDivision.Text;


            if (string.IsNullOrEmpty(curso) || string.IsNullOrEmpty(division))
            {
                ListaAlumnos = Negocio.NegocioAlumnos.Get(dni);
            }
            else
            {
                ListaAlumnos = Negocio.NegocioAlumnos.Get(dni, curso, division);
            }

            refreshgrid();

        }
        private void refreshgrid()
        {
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = ListaAlumnos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDni.Text))
            {
                double dni = Convert.ToDouble(txtDni.Text);
                buscarAlumnos(dni);
            }
            else
            {
                double dni = 0;
                buscarAlumnos(dni);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double dni = Convert.ToInt64(textBox1.Text);
            alumnoInforme = Negocio.NegocioAlumnos.Get(dni);
            string nombre = alumnoInforme[0].Nombre;
            string apellido = alumnoInforme[0].Apellido;
            string curso = alumnoInforme[0].Curso;
            string division = alumnoInforme[0].division;
            int cantidadDeFaltas = alumnoInforme[0].cantidadFaltas;
            GenerarInforme(nombre, apellido, dni.ToString(), curso, division, cantidadDeFaltas);
            DialogResult res = MessageBox.Show("¿Desea tambien enviar el informe del alumno: " + dni + " a su familia?", "Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                envioDeInforme(dni.ToString());
            }
        }

        private void envioDeInforme(string dni) 
        {
            Comunicado c = new Comunicado();
            c.ruta = @"C:\Users\nacho\Documentos\informes\"+dni+".pdf";
            c.error = "";
            StringBuilder mensajeBuilder = new StringBuilder();
            mensajeBuilder.Append("Se adjunta informe oficial correspondiente del alumno con dni de: "+dni);
            c.de = "nachotizii988@gmail.com";
            c.para = Negocio.NegocioAlumnos.getgmail(dni);
            c.asunto = "Informe oficial";
            c.fecha = DateTime.Now.Date;
            DialogResult res = MessageBox.Show("¿El correo electronico se enviar a: " + c.para + " confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                comunicado.enviarCorreo(mensajeBuilder, c);
            }
        }

        public void GenerarInforme(string nombre, string apellido, string dni, string curso, string division, int cantidadDeFaltas)
        {
            FileStream fs = new FileStream(@"C:\Users\nacho\Documentos\informes\" + dni + ".pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            buscarFaltas(dni);
            armarBoletin(dni);
            doc.Open();

            doc.AddAuthor("autor");
            doc.AddTitle("Informe");

            iTextSharp.text.Font stamdarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font Titulos = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 48, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            doc.Add(new Paragraph("Alumno: " + apellido + " " + nombre + " dni: " + dni));
            doc.Add(Chunk.NEWLINE);
            
            doc.Add(new Paragraph("Faltas: "));
           
            int i = 0;
            PdfPTable tablaejemplo = new PdfPTable(2); 
            tablaejemplo.WidthPercentage = 100;
            PdfPCell clfecha = new PdfPCell(new Phrase("Fecha", stamdarFont));
            clfecha.BorderWidth = 0;
            clfecha.BorderWidthBottom = 0.75f;

            PdfPCell clestado = new PdfPCell(new Phrase("Estado", stamdarFont));
            clestado.BorderWidth = 0;
            clestado.BorderWidthBottom = 0.75f;
            tablaejemplo.AddCell(clfecha);
            tablaejemplo.AddCell(clestado);

            while (i < faltas.Count)
            {
                if (faltas[i].fecha.Length == 17)
                {
                    clfecha = new PdfPCell(new Phrase(faltas[i].fecha.Substring(0, 9), stamdarFont));
                    clfecha.BorderWidth = 1;
                }
                else 
                {
                    clfecha = new PdfPCell(new Phrase(faltas[i].fecha.Substring(0, 10), stamdarFont));
                    clfecha.BorderWidth = 1;
                }

                clestado = new PdfPCell(new Phrase(faltas[i].estado, stamdarFont));
                clestado.BorderWidth = 1;

                tablaejemplo.AddCell(clfecha);
                tablaejemplo.AddCell(clestado);
                i++;
            }
            doc.Add(tablaejemplo);
            i = 0;
            doc.Add(new Paragraph("cantidad de faltas: " + cantidadDeFaltas));
            //
            //
            //
            // CON ESTO CONCLUYE LA BUSQUEDA Y CREACION DE LA TABLA DE FALTAS
            //
            //
            //

            // Agrega la tabla al documento antes de cerrar el documento
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("NOTAS: "));
            List<string> mat = cantidaddematerias(dni);
            List<Nota> notas = new List<Nota>();
            
            
            int cantidadMaterias = mat.Count();
            while (i < cantidadMaterias) 
            {
                notas = NotasAlumnos.NotasNegocio.GetNotasXdni(dni, mat[i]);
                doc.Add(new Paragraph(mat[i]));
                PdfPTable tablaNotas = new PdfPTable(3);
                tablaNotas.WidthPercentage = 100;

                PdfPCell notafecha = new PdfPCell(new Phrase("Fecha", stamdarFont));
                notafecha.BorderWidth = 0;
                notafecha.BorderWidthBottom = 0.75f;

                PdfPCell notacomentario = new PdfPCell(new Phrase("Comentario", stamdarFont));
                notacomentario.BorderWidth = 0;
                notacomentario.BorderWidthBottom = 0.75f;

                PdfPCell nota = new PdfPCell(new Phrase("Nota", stamdarFont));
                nota.BorderWidth = 0;
                nota.BorderWidthBottom = 0.75f;


                tablaNotas.AddCell(notafecha);
                tablaNotas.AddCell(notacomentario);
                tablaNotas.AddCell(nota);
                int o = 0;
                while (o < notas.Count)
                {
                  
                    notafecha = new PdfPCell(new Phrase(notas[o].fecha, stamdarFont));
                    notafecha.BorderWidth = 1;

                    notacomentario = new PdfPCell(new Phrase(notas[o].comentario, stamdarFont));
                    notacomentario.BorderWidth = 1;

                    nota = new PdfPCell(new Phrase(notas[o].Calificacion, stamdarFont));
                    nota.BorderWidth = 1;


                    tablaNotas.AddCell(notafecha);
                    tablaNotas.AddCell(notacomentario);
                    tablaNotas.AddCell(nota);
                    o++;
                }
                doc.Add(tablaNotas);

                i++;
            }
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("Boletin: "));
            i = 0;
           
                boletin = NotasAlumnos.NotasNegocio.armarboletin(dni);
                PdfPTable Tablaboletin = new PdfPTable(2);
                Tablaboletin.WidthPercentage = 100;

                PdfPCell Materia = new PdfPCell(new Phrase("Materia", stamdarFont));
                Materia.BorderWidth = 0;
                Materia.BorderWidthBottom = 0.75f;

                PdfPCell NotaFinal = new PdfPCell(new Phrase("NotaFinal", stamdarFont));
                NotaFinal.BorderWidth = 0;
                NotaFinal.BorderWidthBottom = 0.75f;


            Tablaboletin.AddCell(Materia);
            Tablaboletin.AddCell(NotaFinal);
            while (i < boletin.Count)
            {
                Materia = new PdfPCell(new Phrase(boletin[i].materia, stamdarFont));
                Materia.BorderWidth = 1;

                NotaFinal = new PdfPCell(new Phrase(boletin[i].nota, stamdarFont));
                NotaFinal.BorderWidth = 1;

                Tablaboletin.AddCell(Materia);
                Tablaboletin.AddCell(NotaFinal);
                
                i++;
            }
            doc.Add(Tablaboletin);
            i = 0;
            doc.Close();
            pw.Close();
            MessageBox.Show("Informe para el alumno " + nombre + " " + apellido + " generado exitosamente!" + cantidadMaterias);
        }

        private List<boletin> armarBoletin(string dni)
        {
            return boletin = NotasNegocio.armarboletin(dni);
        }

        private List<string> cantidaddematerias(string dni)
        {
            List<string> mat = new List<string>();
            string consulta = "SELECT mat.Denominación from Materias mat, Materia_curso mc, alumnos al where mc.IdCurso = al.curso and mc.IdMateria = mat.id and al.dni = @dni";
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString;
            using (SqlConnection Connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand(consulta, Connection);
             
                command.Parameters.AddWithValue("@dni", dni);
                try
                {
                    Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        mat.Add(Convert.ToString(reader["Denominación"]));

                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    throw;
                }
                return mat;
            }
        }

        public void buscarFaltas(string dni) 
        {
            faltas = BuscarFaltas(dni);

        }
    }
}
