using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursosOnline.Models
{
    class inscripcion_model
    {
        public int IdInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}
