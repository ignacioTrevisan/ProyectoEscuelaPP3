﻿using EntidadAlumno;
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
            txt_curso.Text = "";
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            button1.Visible = true;
            int modo = txt_opcion.SelectedIndex+1;
            if (modo == 1)
            {
                lbl_profesor.Visible = true;
                lbl_curso.Visible = false;
                txt_curso.Visible = false;
                txt_profesor.Visible = true;
                txt_profesor.Items.Clear();
                lbl_curso.Location = new Point(44, 173);
                txt_curso.Location = new Point(45, 189);
                for (int i = 0; i < listaProfesores.Count; i++) 
                {
                    txt_profesor.Items.Add(listaProfesores[i].Nombre+" "+listaProfesores[i].Apellido+" ("+listaProfesores[i].Dni+")");
                }
            }
            if (modo == 2) 
            {
                lbl_curso.Visible = true;
                cursos.Clear();
                txt_curso.Items.Clear();
                txt_curso.Visible = true;
                lbl_profesor.Visible = false;
                txt_profesor.Visible = false;
                lbl_materia.Visible = false;
                txt_materia.Visible = false;
                lbl_curso.Location = new Point(44,119);
                txt_curso.Location = new Point(45, 134);
                cursos = Negocio.NegocioAlumnos.GetCursosActivos();
                for (int i = 0; i < cursos.Count; i++) 
                {
                    txt_curso.Items.Add("Año " + cursos[i].año + " división: " + cursos[i].division + " (" + cursos[i].ciclo + ")");
                }
            }
            if (modo == 3) 
            {
                lbl_curso.Visible = false;
                txt_curso.Visible = false;
                lbl_profesor.Visible = false;
                txt_profesor.Visible = false;
                lbl_materia.Visible = false;
                txt_materia.Visible = false;
                
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
            if (txt_opcion.SelectedIndex+1 == 1) 
            {
                int i = txt_profesor.SelectedIndex;
                string dni = listaProfesores[i].Dni;
                lbl_materia.Visible = true;
                txt_materia.Visible = true;
                materias = NegocioProfesor.getMateriasXProfesor(dni);
                for (int a = 0; a < materias.Count; a++)
                {
                    txt_materia.Items.Add(materias[a]);
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int modo = txt_opcion.SelectedIndex + 1;
            string etapa = txt_etapa.Text;
            
            string estado = txt_modificacion.Text;
            DateTime desde = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime hasta = Convert.ToDateTime(dateTimePicker2.Text);
            if (modo == 1)
            {
                string año = cursos[txt_curso.SelectedIndex].año;
                string division = cursos[txt_curso.SelectedIndex].division;
                string ciclo = cursos[txt_curso.SelectedIndex].ciclo;
                string materia = materias[txt_materia.SelectedIndex];
                string dniProfesor = listaProfesores[txt_profesor.SelectedIndex].Dni;
                MessageBox.Show(NegocioProfesor.cambiarPermisosParaRegistrarNotas(modo, etapa, dniProfesor, año, division, ciclo, materia, estado, desde, hasta));
            }
            else if (modo == 2)
            {
                string año = cursos[txt_curso.SelectedIndex].año;
                string division = cursos[txt_curso.SelectedIndex].division;
                string ciclo = cursos[txt_curso.SelectedIndex].ciclo;
                MessageBox.Show(NegocioProfesor.cambiarPermisosParaRegistrarNotas(estado, desde, hasta, año, division, ciclo, etapa, modo));
            }
            else if (modo == 3) 
            {
                MessageBox.Show(estado+ desde + hasta + etapa + modo);
                MessageBox.Show(NegocioProfesor.cambiarPermisosParaRegistrarNotas(estado, desde, hasta, etapa, modo));

            }


        }
    }
}

