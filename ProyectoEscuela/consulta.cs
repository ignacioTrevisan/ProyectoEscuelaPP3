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
        List<Nota> lista = new List<Nota>();
        public consulta()
        {
            InitializeComponent();
            buscarAlumnos("0");
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

        
        private void buscarAlumnos(string nombre)
        {
           
            string curso = comboBox1.Text;
            


            if (string.IsNullOrEmpty(curso) )
            {
                ListaAlumnos = Negocio.NegocioAlumnos.Get("0",nombre, GlobalVariables.ciclo);
            }
            else
            {
                ListaAlumnos = Negocio.NegocioAlumnos.Get(nombre, curso,  GlobalVariables.ciclo);
            }

            lblResultados.Text = dataGridView1.Rows.Count.ToString();
            int i = 0;
            comboBox1.Items.Clear();
            lista = NegocioProfesor.GetPermisosPreceptor(10);
            while (i < lista.Count()) 
            {
                comboBox1.Items.Add("año: "+lista[i].Curso+" division: " + lista[i].Division + "(" + lista[i].ciclo +")");
                i++;
            }
            refreshgrid();

        }
        private void refreshgrid()
        {
            bindingSource1.DataSource = null;
            bindingSource1.DataSource = ListaAlumnos;
            lblResultados.Text = dataGridView1.Rows.Count.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                if (string.IsNullOrEmpty(textBox3.Text))
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        string query = "select nombre, apellido, dni, estadofrom alumnos where nombre = '" + textBox1.Text + "'";
                    }
                    else
                    {
                        MessageBox.Show("Complete algun campo");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        string query = "select nombre, apellido, dni, estadofrom alumnos where nombre = '" + textBox1.Text + "' and apellido ='" + textBox3.Text + "'";
                    }
                    else
                    {
                        string query = "select nombre, apellido, dni, estadofrom alumnos where apellido = '" + textBox3.Text + "'";
                    }
                }
            }
            else 
            {
                if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox3.Text)) 
                {
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dni = textBox1.Text;
            int i = comboBox1.SelectedIndex;
            alumnoInforme = Get(dni, "-", 2023);
            int ciclo = alumnoInforme[0].ciclo;
            string nombree = alumnoInforme[0].Nombre;
            string apellido = alumnoInforme[0].Apellido;
            string curso = alumnoInforme[0].Curso;
            string division = alumnoInforme[0].division;
            int cantidadDeFaltas = alumnoInforme[0].cantidadFaltas;
            GenerarInforme(nombree, apellido, dni.ToString(), curso, division, cantidadDeFaltas, ciclo);
            DialogResult res = MessageBox.Show("¿Desea tambien enviar el informe del alumno: " + dni + " a su familia?", "Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                envioDeInforme(dni.ToString(), ciclo);
            }

        }

        private void envioDeInforme(string dni, int ciclo)
        {
            Comunicado c = new Comunicado();
            c.ruta = @"C:\Users\nacho\Documentos\informes\" + dni + "(" + ciclo + ")" + ".pdf";
            c.error = "";
            StringBuilder mensajeBuilder = new StringBuilder();
            mensajeBuilder.Append("Se adjunta informe oficial correspondiente del alumno con dni de: " + dni);
            c.de = "nachotizii988@gmail.com";
            string[] para = Negocio.NegocioAlumnos.getgmail(textBox1.Text).Split(',');
            c.asunto = "Informe oficial";
            c.fecha = DateTime.Now.Date;
            DialogResult res = MessageBox.Show("¿El correo electronico se enviar a: " + c.para + " confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                comunicado.enviarCorreo(mensajeBuilder, c, para, 0);
            }
        }

        public void GenerarInforme(string nombre, string apellido, string dni, string curso, string division, int cantidadDeFaltas, int ciclo)
        {
            FileStream fs = new FileStream(@"C:\Users\nacho\Documentos\informes\" + dni +"("+ciclo+")"+".pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);
            buscarFaltas(dni, ciclo, Convert.ToInt32(curso), Convert.ToInt32(division));
            
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
            doc.Add(new Paragraph("cantidad de faltas: " + faltas.Count()));
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
                notas = NotasAlumnos.NotasNegocio.GetNotasXdni(dni, mat[i], Convert.ToInt32(curso), Convert.ToInt32(division), ciclo);
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
                
                boletin = NotasAlumnos.NotasNegocio.armarboletin(dni, Convert.ToInt32(curso), Convert.ToInt32(division), ciclo);
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

       

        private List<string> cantidaddematerias(string dni)
        {
            List<string> mat = new List<string>();
            string dnii = textBox1.Text;
            int i = comboBox1.SelectedIndex;
            mat = NotasNegocio.getMateriasxCurso(lista[i].Curso, lista[i].Division, lista[i].ciclo, dnii);
            return mat;
            
        }

        public void buscarFaltas(string dni, int ciclo, int curso, int division) 
        {
            faltas = BuscarFaltas(dni, ciclo, curso, division);

        }

        private void consulta_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            ListaAlumnos = GetXCurso("", lista[i].Curso, lista[i].Division, lista[i].ciclo);
            dataGridView1.DataSource = ListaAlumnos;
            lblResultados.Text = ListaAlumnos.Count.ToString();
        }
    }
}
