using EntidadPermiso;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadProfesor;
using NotasAlumnos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static ProyectoEscuela.inicioSesion;
using NegocioAlumnos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;

namespace ProyectoEscuela
{
    public partial class Front : Form
    {
        string cargo = GlobalVariables.cargo;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/DocumentosPDF";
        public Front()
        {
            InitializeComponent();
            int i = GlobalVariables.id;


        }

        public static class cursosGlobal
        {
            public static string curso = "";
            public static string division = "";
            public static int modo = 0;
        }


        private void btn_nuevoAlumno_Click(object sender, EventArgs e)
        {
            if (cargo == "director" || cargo == "preceptor")
            {
                NuevoAlumno formulario = new NuevoAlumno();
                formulario.ShowDialog();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a este area ");
            }
        }

        private void btn_asistencias_Click(object sender, EventArgs e)
        {
            TomarAsistencia formulario = new TomarAsistencia();
            formulario.ShowDialog();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (cargo == "director" || cargo == "preceptor")
            {
                consulta f = new consulta();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("No posee permisos para acceder a este area ");
            }
        }

        private void Front_Load(object sender, EventArgs e)
        {
            if (cargo == "director")
            {
                button3.Enabled = false;

            }

            if (cargo == "profesor")
            {
                btn_nuevoAlumno.Enabled = false;
                button2.Enabled = false;
            }

            if (cargo == "preceptor")
            {
                btn_nuevoAlumno.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cargo == "profesor" || cargo == "preceptor")
            {
                RegistrarNota formulario = new RegistrarNota();
                formulario.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecursosSalas formulario = new RecursosSalas();
            formulario.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"C:\Users\nacho\Documentos\informes\pdfGenerado.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            doc.AddAuthor(cargo);
            doc.AddTitle(GlobalVariables.cargo);

            iTextSharp.text.Font stamdarFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            doc.Add(new Paragraph(GlobalVariables.cargo));
            doc.Add(Chunk.NEWLINE);

            PdfPTable tablaejemplo = new PdfPTable(3);
            tablaejemplo.WidthPercentage = 100;

            PdfPCell clnombre = new PdfPCell(new Phrase("Nombre", stamdarFont));
            clnombre.BorderWidth = 0;
            clnombre.BorderWidthBottom = 0.75f;


            PdfPCell clapellido = new PdfPCell(new Phrase("Apellido", stamdarFont));
            clapellido.BorderWidth = 0;
            clapellido.BorderWidthBottom = 0.75f;

            PdfPCell clEdad = new PdfPCell(new Phrase("Edad", stamdarFont));
            clEdad.BorderWidth = 0;
            clEdad.BorderWidthBottom = 0.75f;

            tablaejemplo.AddCell(clnombre);
            tablaejemplo.AddCell(clapellido);
            tablaejemplo.AddCell(clEdad);
            doc.Add(tablaejemplo);
            doc.Close();
            pw.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comunicado c = new comunicado();
            c.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (cargo == "preceptor")
            {
                Inscripciones i = new Inscripciones();
                i.ShowDialog();
            }
        }
    }
}
