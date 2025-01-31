using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCursosOnline.Views
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            CUInscripciones frmNueva = new CUInscripciones();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            CUCursos frmNueva = new CUCursos();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            CUEstudiantes frmNueva = new CUEstudiantes();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            CUProfesores frmNueva = new CUProfesores();
            pnlGeneral.Controls.Clear();
            frmNueva.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(frmNueva);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes.frmReportes frm = new Reportes.frmReportes();
            frm.Text = "Reportes de Cursos por Estudiante";
            frm.ShowDialog();
        }
    }
}
