using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using EntidadAlumno;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html.head;
using EntidadNota;
using NotasAlumnos;
using iTextSharp.tool.xml.html.table;
using System.Runtime.InteropServices;
namespace helpers
{
    public class creacionInforme
    {

        public static string generarPdf(string cargo, List<Faltas> faltas, string nombre, string apellido, string dni, string año, string division, int ciclo, int idProfesor, List<string> materias)
        {
            string paginaHtml = Properties.Resources.informe.ToString();
            string materiaString = "<table border-top='1' border-left='1' border-right='1' style='width: 100%; border-collapse: collapse;'><tr style='border: 1px solid black; background-color: rgb(169, 169, 169); height:50px'><td style='width: 33.33%; border: 1px solid black;'>Comentario</td><td style='width: 33.33%; border: 1px solid black;'>Nota</td><td style='width: 33.33%; border: 1px solid black;'>Fecha</td><td style='width: 33.33%; border: 1px solid black;'>Etapa</td></tr></table>";
            paginaHtml = paginaHtml.Replace("@dni", dni);
            paginaHtml = paginaHtml.Replace("@nombre", nombre);
            paginaHtml = paginaHtml.Replace("@Apellido", apellido);
            paginaHtml = paginaHtml.Replace("@curso", año);
            paginaHtml = paginaHtml.Replace("@division", division);
            paginaHtml = paginaHtml.Replace("@ciclo", ciclo.ToString());
            
            string filasFaltas = "";
            foreach (Faltas falta in faltas)
            {
                filasFaltas += "<tr><td>" + falta.estado + "</td><td>" + falta.fecha + "</td></tr>";
            }

            paginaHtml = paginaHtml.Replace("@filas", filasFaltas);
            string txto = "";
            for (int i = 0; i < materias.Count; i++) 
            {
                List<Nota> lista = new List<Nota>();
                lista = NotasNegocio.GetNotasXAlumno(dni, materias[i], idProfesor, año, division, ciclo);
                
                string nuevaTablaNotas = "<table border='1' style='width: 100%; border-collapse: collapse;'>";
                string materiaDatosString = "";
               
                foreach (Nota nota in lista)
                {
                    materiaDatosString += "<tr style='border: 1px solid black;'><td style='width: 33.33%; border: 1px solid black;'>" + nota.comentario + "</td><td style='width: 33.33%; border: 1px solid black;'>" + nota.Calificacion + "</td><td style='width: 33.33%; border: 1px solid black;'>" + nota.fecha + "</td><td style='width: 33.33%; border: 1px solid black;'>" + nota.etapa + "</td></tr>";
                }

                if (lista.Count == 0)
                {
                    materiaDatosString += "<tr style='border: 1px solid black;'><td style='width: 33.33%; border: 1px solid black;'> N/A </td><td style='width: 33.33%; border: 1px solid black;'> N/A </td><td style='width: 33.33%; border: 1px solid black;'> N/A </td><td style='width: 33.33%; border: 1px solid black;'> N/A </td></tr>";
                }

                string tablaCompleta = materiaString+nuevaTablaNotas + materiaDatosString + "</table>";
                txto = txto + materias[i] +"<br />" + tablaCompleta;

            }
            paginaHtml =paginaHtml.Replace("@materia", txto);

            
            paginaHtml = paginaHtml.Replace("@filas", filasFaltas);

            using (FileStream stream = new FileStream(@"C:\Users\nacho\Documentos\informes\pdfGenerado.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.Open();

                using (StringReader sr = new StringReader(paginaHtml))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.logoEscuela, System.Drawing.Imaging.ImageFormat.Png);
                img.ScaleToFit(180, 160);
                img.Alignment = iTextSharp.text.Image.UNDERLYING;
                img.SetAbsolutePosition(pdfDoc.Right -100, pdfDoc.Top - 60);
                pdfDoc.Add(img);
                pdfDoc.Close();
                stream.Close();
            }
            return "a";
        }

        public List<Nota> getNotasXMateria(string dni, string año, string division, int ciclo, string materia, int idProfesor) 
        {
            List<Nota> notas = new List<Nota>();
            NotasNegocio.GetNotasXAlumno(dni,materia,idProfesor,año, division, ciclo);
            return notas;
        }

    }
}


