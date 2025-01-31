using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursosOnline.Models
{
    //estudiante_model IdEstudiante,Cedula,Nombre,Email,Telefono,FechaNacimiento,Direccion
    class estudiante_model
    {
        public int IdEstudiante { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
    }
}
