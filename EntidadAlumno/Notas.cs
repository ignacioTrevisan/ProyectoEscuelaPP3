using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNota
{
    public class Nota
    {
        public int id { get; set; }
        public string Materia { get; set; }
        public string Curso { get; set; }
        public string Division { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Calificacion { get; set; }

        public string comentario { get; set; }

        public string fecha { get; set; }
        
    }
}
