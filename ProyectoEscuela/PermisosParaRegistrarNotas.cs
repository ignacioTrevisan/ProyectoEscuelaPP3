using EntidadAlumno;
using EntidadProfesor;
using NegocioAlumnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoEscuela
{
    public partial class PermisosParaRegistrarNotas : Form
    {
        List<profesor> listaProfesores = new List<profesor>();
        List<Cursos> cursos = new List<Cursos>();
        List<string> materias = new List<string>();
        public PermisosParaRegistrarNotas()
        {
            InitializeComponent();
            listaProfesores = NegocioProfesor.getProfesoresConCursosActivos();
        }

        private void txt_opcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            button1.Visible = true;
            int modo = txt_opcion.SelectedIndex+1;
            if (modo == 1)
            {
                lbl_profesor.Visible = true;
                txt_profesor.Visible = true;
                txt_profesor.Items.Clear();
                for (int i = 0; i < listaProfesores.Count; i++) 
                {
                    txt_profesor.Items.Add(listaProfesores[i].Nombre+" "+listaProfesores[i].Apellido+" ("+listaProfesores[i].Dni+")");
                }
            }
        }
        private void visibilidad(int modo)
        {
           
        }

        private void txt_profesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_curso.Items.Clear();
            txt_curso.Text = "";
            txt_materia.Items.Clear();
            lbl_materia.Visible = false;
            txt_materia.Visible = false;
            lbl_curso.Visible = true;
            txt_curso.Visible = true;
            txt_materia.Text = "";
            int i = txt_profesor.SelectedIndex;
            string dni = listaProfesores[i].Dni;
            cursos = NegocioProfesor.GetCursosPorProfesor(dni);
            
            for (int a=0; a < cursos.Count; a++) 
            {
                txt_curso.Items.Add("Año " + cursos[a].año + " división: " + cursos[a].division + " (" + cursos[a].ciclo + ")");
            }
        }

        private void txt_curso_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = txt_profesor.SelectedIndex;
            string dni = listaProfesores[i].Dni;
            lbl_materia.Visible = true;
            txt_materia.Visible=true;
            materias = NegocioProfesor.getMateriasXProfesor(dni);
            for (int a = 0; a < materias.Count; a++) 
            {
                txt_materia.Items.Add(materias[a]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int modo = txt_opcion.SelectedIndex + 1;
            string etapa = txt_etapa.Text;
            string dniProfesor = listaProfesores[txt_profesor.SelectedIndex].Dni;
            string año = cursos[txt_curso.SelectedIndex].año;
            string division = cursos[txt_curso.SelectedIndex].division;
            string ciclo = cursos[txt_curso.SelectedIndex].ciclo;
            string materia = materias[txt_materia.SelectedIndex];
            string estado = txt_modificacion.Text;
            DateTime desde = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime hasta = Convert.ToDateTime(dateTimePicker2.Text);
            MessageBox.Show(NegocioProfesor.cambiarPermisosParaRegistrarNotas(modo, etapa, dniProfesor, año, division, ciclo, materia, estado, desde, hasta));

        }
    }
}


