using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadRecursosSalas
{
    public class ReservasRecursosSalas
    {
        public int id { get; set; }
	    public DateTime fecha { get; set; }
        public string Hora { get; set; }
        public string estado { get; set; }
        public string recurso { get; set; }
        public string dniProfesor { get;set; }
        public string comentario { get; set; }
       

    }
}
