using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Introduzca el nombre de la materia"), MaxLength(15)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Introduzca el precio"),MaxLength(5)]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage="Solo se aceptan numeros")]
        public decimal Costo { get; set; }
        public List<object>Materias { get; set; }
    }
}
