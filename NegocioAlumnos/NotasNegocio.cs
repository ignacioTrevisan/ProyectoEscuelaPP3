﻿using DatosNotas;
using EntidadAlumno;
using EntidadNota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasAlumnos
{
    public class NotasNegocio
    {
        public static List<Nota> GetNotas(string curso, string division, string materia, int idProfesor)
        {
            List<Nota> nuevaLista = new List<Nota>();
            return nuevaLista = NotasDatos.GetNotas(curso, division, materia, idProfesor);
        }

        public static List<Nota> GetNotasXAlumno(string dni, string materia, int idProfesor, string curso, string division)
        {
            List<Nota> alumno = new List<Nota>();
            return alumno = NotasDatos.GetNotasXAlumno(dni, materia, idProfesor, curso, division);
        }

        public static int registrarNotas(string materia, string alumno, string nota, int profesor, DateTime fecha, string comentario)
     {
            int id = 0;
            return id = NotasDatos.registroNotas(materia, alumno, nota, profesor, fecha, comentario);
        }
        public static int eliminarNota(int id) 
        {
            int i = 0;
            return NotasDatos.Eliminar(id);
        }

        public static List<Nota> GetNotasXdni(string dni, string v)
        {
            return DatosNotas.NotasDatos.GetNotasXdni(dni, v);
        }

        public static List<boletin> armarboletin(string dni)
        {
            return NotasDatos.armarboletin(dni);
        }
    }
}
