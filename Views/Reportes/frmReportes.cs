using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCursosOnline.Views.Reportes
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sistemaCursosOnlineDataSet.VistaCursos' table. You can move, or remove it, as needed.
            this.vistaCursosTableAdapter.Fill(this.sistemaCursosOnlineDataSet.VistaCursos);
            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //this.vistaCursosTableAdapter.FillByStudentName(this.sistemaCursosOnlineDataSet.VistaCursos, txtBuscar.Text);
            this.vistaCursosTableAdapter.FillByStudentCedula(this.sistemaCursosOnlineDataSet.VistaCursos, txtBuscar.Text);
            this.reportViewer1.RefreshReport();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
