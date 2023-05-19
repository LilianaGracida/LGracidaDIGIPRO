using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class AlumnoMateria
    {
        public int IdAlumnoMateria { get; set; }
        public ML.Alumno alumno { get; set; }
        public ML.Materia materia { get; set; }
        public List<object> AlumnoMaterias { get; set; }
    }
}
