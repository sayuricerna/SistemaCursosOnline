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
    public partial class CUProfesores : UserControl
    {
        public CUProfesores()
        {
            InitializeComponent();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Profesores.frmProfesores frm = new Profesores.frmProfesores("n");
            frm.Text = "Formulario de Profesor";
            frm.ShowDialog();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }
        public void cargaGrilla(int numero)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var logicaProfesor = new profesor_controller();
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
                dataGridView1.DataSource = logicaProfesor.ObtenerTodos();
            }
            else
            {
                dataGridView1.DataSource = logicaProfesor.Buscar(txtBuscar.Text.Trim());
            }

            dataGridView1.Columns["cedula"].HeaderText = "Cédula";
            dataGridView1.Columns["nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["email"].HeaderText = "Email";
            dataGridView1.Columns["telefono"].HeaderText = "Teléfono";
            dataGridView1.Columns["fechaNacimiento"].HeaderText = "Fecha Nacimiento";
            dataGridView1.Columns["direccion"].HeaderText = "Dirección";
            dataGridView1.Columns["IdProfesor"].Visible = false;

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }
        public void EditarProfesor(int id)
        {
            Profesores.frmProfesores frmProfesor = new Profesores.frmProfesores(id.ToString());
            frmProfesor.ShowDialog();
            this.cargaGrilla(1);
        }

        public void EliminarProfesor(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este Profesor?",
                "Eliminar Profesor", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var clsProfesores = new profesor_controller();
                if (clsProfesores.Eliminar(id))
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
                var IdProfesor = filaSeleccionada.Cells["IdProfesor"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarProfesor((int)IdProfesor);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarProfesor((int)IdProfesor);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(2);
        }

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.cargaGrilla(2);
        }
        private void CUProfesores_Load(object sender, EventArgs e)
        {
            var logicaProfesor = new profesor_controller();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = logicaProfesor.ObtenerTodos();
            this.cargaGrilla(1);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(1);
        }
    }
}
