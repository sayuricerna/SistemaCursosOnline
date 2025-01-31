using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCursosOnline.Config
{
    internal class conexion
    {
        private readonly string varconexion = "Server=localhost\\SQLEXPRESS;Database=SistemaCursosOnline;Trusted_Connection=True";
        public SqlConnection obtenerConexion()
        {
            return new SqlConnection(varconexion);
        }
    }
}
