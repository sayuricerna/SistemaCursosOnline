using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaCursosOnline.Controllers;

namespace SistemaCursosOnline.Views
{
    public partial class CUEstudiantes : UserControl
    {
        public CUEstudiantes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Estudiantes.frmEstudiantes frm = new Estudiantes.frmEstudiantes("n");
            frm.Text = "Formulario de Estudiantes";
            frm.ShowDialog();
        }

        private void CUEstudiantes_Load(object sender, EventArgs e)
        {
            var logicaEstudiantes = new estudiante_controller();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = logicaEstudiantes.ObtenerTodos();
            this.cargaGrilla(1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(2);

        }

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cargaGrilla(2);

        }
        public void cargaGrilla(int numero)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var logicaEstudiantes = new estudiante_controller();
            var autoincremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(autoincremento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            if (numero == 1)
            {
                dataGridView1.DataSource = logicaEstudiantes.ObtenerTodos();
            }
            else
            {
                dataGridView1.DataSource = logicaEstudiantes.Buscar(txtBuscar.Text.Trim());
            }

            dataGridView1.Columns["cedula"].HeaderText = "Cédula";
            dataGridView1.Columns["nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["telefono"].HeaderText = "Teléfono";
            dataGridView1.Columns["fechaNacimiento"].HeaderText = "Fecha Nacimiento";
            dataGridView1.Columns["direccion"].HeaderText = "Dirección";
            dataGridView1.Columns["IdEstudiante"].Visible = false;

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }

        public void EditarEstudiante(int id)
        {
            Estudiantes.frmEstudiantes frmEstudiante = new Estudiantes.frmEstudiantes(id.ToString());
            frmEstudiante.ShowDialog();
            this.cargaGrilla(1);
        }

        public void EliminarEstudiante(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este estudiante?",
                "Eliminar Estudiante", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var clsEstudiantes = new estudiante_controller();
                if (clsEstudiantes.Eliminar(id))
                {
                    MessageBox.Show("El registro se ha eliminado con éxito.");
                    this.cargaGrilla(1);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar.");
                }
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                var IdEstudiante = filaSeleccionada.Cells["IdEstudiante"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarEstudiante((int)IdEstudiante);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarEstudiante((int)IdEstudiante);
                }
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(1);
        }
    }
}
