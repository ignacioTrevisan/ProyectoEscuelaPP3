using EntidadAlumno;
using EntidadNota;
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
using static ProyectoEscuela.Front;
using static ProyectoEscuela.inicioSesion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NegocioAlumnos;

namespace ProyectoEscuela
{
    public partial class comunicado : Form


    {

        public List<Nota> lista = new List<Nota>();

        public comunicado()
        {
            InitializeComponent();

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
        public int todos = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() => enviar());
        }
        private void enviar() 
        {

            if (checkBox1.Checked == false && checkBox2.Checked == false)
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

                if (res == DialogResult.Yes)
                {
                    enviarCorreo(mensajeBuilder, c, para, 0);
                }

            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false)
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
                    DialogResult res = MessageBox.Show("¿El correo electronico se enviar a todos los correos registrados por alumnos, confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        enviarCorreo(mensajeBuilder, c, para, 0);

                    }
                }

            } 
            else if (checkBox1.Checked == false && checkBox2.Checked == true)
            {
                Comunicado c = new Comunicado();
                c.error = "";
                StringBuilder mensajeBuilder = new StringBuilder();
                mensajeBuilder.Append(textBox3.Text);
                c.de = "nachotizii988@gmail.com";
                List<string> correos = new List<string>();
                correos = Negocio.NegocioAlumnos.getaAllgmailDoc("-");
                string correosConcatenados = string.Join(",", correos.SelectMany(ca => ca.Split(',')));
                int i = 0;
                string[] para = correosConcatenados.Split(',');
                c.asunto = textBox3.Text;
                c.fecha = DateTime.Now.Date;
                c.ruta = txtRutaArchivo.Text;
                if (i == 0)
                {
                    DialogResult res = MessageBox.Show("¿El correo electronico se enviar a todos los correos registrados por docentes, confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = comboBox1.SelectedIndex;
            string curso = lista[a].Curso;
            string division = lista[a].Division;
            if (cursosGlobal.modo == 1)
            {
                curso = cursosGlobal.curso;
                division = cursosGlobal.division;
            }
            if (GlobalVariables.cargo == "director" || GlobalVariables.cargo == "preceptor")
            {
                GlobalVariables.ciclo = lista[a].ciclo;
            }
            Int32 año = GlobalVariables.ciclo;

            seleccionarCurso(curso, division, año);
        }

        public void seleccionarCurso(string curso, string division, int ciclo)
        {
            
            

            Comunicado c = new Comunicado();
            c.error = "";
            StringBuilder mensajeBuilder = new StringBuilder();
            mensajeBuilder.Append(textBox3.Text);
            c.de = "nachotizii988@gmail.com";
            List<string> correos = new List<string>();
            correos = Negocio.NegocioAlumnos.getAllGmailCurso(curso, division,ciclo);
            string correosConcatenados = string.Join(",", correos.SelectMany(ca => ca.Split(',')));
            int i = 0;
            string[] para = correosConcatenados.Split(',');
            c.asunto = textBox3.Text;
            c.fecha = DateTime.Now.Date;
            c.ruta = txtRutaArchivo.Text;
            if (i == 0)
            {
                DialogResult res = MessageBox.Show("¿El correo electronico se enviar a todos los correos registrados para el curso seleccionado, confirma enviar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    enviarCorreo(mensajeBuilder, c, para, 0);

                }

            }


        }
    }
}
