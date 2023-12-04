using EntidadAlumno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoEscuela.inicioSesion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoEscuela
{
    public partial class comunicado : Form
    {
       
        public comunicado()
        {
            InitializeComponent();
        }
        public int todos = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => enviar());
        }
        private void enviar() 
        {

            if (checkBox1.Checked == false)
            {
                Comunicado c = new Comunicado();
                c.error = "";
                StringBuilder mensajeBuilder = new StringBuilder();
                mensajeBuilder.Append(textBox3.Text);
                c.de = "nachotizii988@gmail.com";
                string[] para = Negocio.NegocioAlumnos.getgmail(textBox1.Text).Split(',');
                c.asunto = textBox3.Text;
                c.fecha = DateTime.Now.Date;
                c.ruta = txtRutaArchivo.Text;
                DialogResult res = MessageBox.Show("¿El correo electronico se enviar a: " + c.para + " confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int i = 0;

                if (res == DialogResult.Yes)
                {
                    enviarCorreo(mensajeBuilder, c, para, 0);
                }

            }
            else
            {
                Comunicado c = new Comunicado();
                c.error = "";
                StringBuilder mensajeBuilder = new StringBuilder();
                mensajeBuilder.Append(textBox3.Text);
                c.de = "nachotizii988@gmail.com";
                List<string> correos = new List<string>();
                correos = Negocio.NegocioAlumnos.getaAllgmail("-");
                string correosConcatenados = string.Join(",", correos.SelectMany(ca => ca.Split(',')));
                int i = 0;
                string[] para = correosConcatenados.Split(',');
                c.asunto = textBox3.Text;
                c.fecha = DateTime.Now.Date;
                c.ruta = txtRutaArchivo.Text;
                if (i == 0)
                {
                    DialogResult res = MessageBox.Show("¿El correo electronico se enviar a todos los correos registrados por alumno, confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        enviarCorreo(mensajeBuilder, c, para, 0);

                    }
                }

            }
        }
        public static void enviarCorreo(StringBuilder mensaje, Comunicado c, string[] para, int confirmacion)
        {
            c.error = "";
            try
            {
                mensaje.Append(Environment.NewLine);
                mensaje.Append(Environment.NewLine);
                MailMessage ms = new MailMessage();
                ms.From = new MailAddress(c.de);
                foreach (string correo in para) if (correo != "") ms.CC.Add(new MailAddress(correo));
                ms.Subject = c.asunto;
                if (c.ruta.Equals("") == false)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(c.ruta);
                    ms.Attachments.Add(archivo);
                }
                string extension = Path.GetExtension(c.ruta);
                ms.Body = mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(GlobalVariables.usuario, GlobalVariables.password);
                smtp.EnableSsl = true;
                if (extension == "" || extension == ".pdf" || extension == ".jpg" || extension == ".png" || extension == ".pptx" || extension == ".xlsx" ||  extension == ".mp4" || extension == ".docx")
                {
                    smtp.Send(ms);
                    if (confirmacion == 0)
                    {
                        c.error = "Correo enviado exitosamente ";
                        MessageBox.Show(c.error);
                        
                    }
                }
                else 
                {
                    MessageBox.Show("Formato de archivo no permitido");
                }
            }
            catch (Exception ex)
            {
                c.error = "Error: " + ex.Message;
                MessageBox.Show(c.error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    txtRutaArchivo.Text = this.openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la ruta del archivo: " + ex.ToString());
            }
        }
    }
}
