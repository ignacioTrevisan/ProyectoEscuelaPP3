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

        private void button1_Click(object sender, EventArgs e)
        {
                Comunicado c = new Comunicado();
                c.error = "";
                StringBuilder mensajeBuilder = new StringBuilder();
                mensajeBuilder.Append(textBox3.Text);
                c.de = "nachotizii988@gmail.com";
                c.para = Negocio.NegocioAlumnos.getgmail(textBox1.Text);
                c.asunto = textBox3.Text;
                c.fecha = DateTime.Now.Date;
                c.ruta = txtRutaArchivo.Text;
                DialogResult res = MessageBox.Show("¿El correo electronico se enviar a: " + c.para + " confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    enviarCorreo(mensajeBuilder, c);
                }

            
        }
        public static void enviarCorreo(StringBuilder mensaje, Comunicado c)
        {
            c.error = "";
            try
            {
                mensaje.Append(Environment.NewLine);
                mensaje.Append(Environment.NewLine);
                MailMessage ms = new MailMessage();
                ms.From = new MailAddress(c.de);
                ms.To.Add(c.para);
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
                if (extension == ".pdf" || extension == ".jpg" || extension == ".png" || extension == ".pptx" || extension == ".xlsx" ||  extension == ".mp4")
                {
                    smtp.Send(ms);
                    c.error = "Correo enviado exitosamente ";
                    MessageBox.Show(c.error);
                }
                else 
                {
                    MessageBox.Show("No se permite enviar archivos que no sean .pdf o .jpg");
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
