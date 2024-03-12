using EntidadAlumno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helpers
{
    public class ConvertirFaltas
    {
        public static float conversion (List<Faltas> faltas)
        {
            float contador = 0;
            for (int i = 0; i< faltas.Count; i++) 
            {
                if (faltas[i].estado == "ausente")
                {
                    contador++;
                }
                if (faltas[i].estado == "media falta")
                {
                    contador = (float)(contador +0.5);
                }
            }
            return contador;
        }
    }
}
