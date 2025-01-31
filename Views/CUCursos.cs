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
    public partial class CUCursos : UserControl
    {
        public CUCursos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cursos.frmCursos frm = new Cursos.frmCursos("n");
            frm.Text = "Formulario de Cursos";
            frm.ShowDialog();
        }

        private void CUCursos_Load(object sender, EventArgs e)
        {
            var logica = new curso_controller();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = logica.ObtenerTodos();
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

            var logicaCursos = new curso_controller();
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
                dataGridView1.DataSource = logicaCursos.ObtenerTodos();
            }
            else
            {
                dataGridView1.DataSource = logicaCursos.Buscar(txtBuscar.Text.Trim());
            }

            dataGridView1.Columns["IdCurso"].Visible = false;
            dataGridView1.Columns["NombreCurso"].HeaderText = "Nombre del Curso";
            dataGridView1.Columns["Descripcion"].HeaderText = "Descripción";
            dataGridView1.Columns["FechaInicio"].HeaderText = "Fecha de Inicio";
            dataGridView1.Columns["FechaFin"].HeaderText = "Fecha de Fin";
            //dataGridView1.Columns["IdProfesor"].HeaderText = "Cod";
            dataGridView1.Columns["IdProfesor"].Visible = false;
            dataGridView1.Columns["NombreProfesor"].HeaderText = "Profesor";

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }

        public void EditarCurso(int id)
        {
            Cursos.frmCursos frmCurso = new Cursos.frmCursos(id.ToString());
            frmCurso.ShowDialog();
            this.cargaGrilla(1);
        }

        public void EliminarCurso(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este curso?",
                "Eliminar Curso", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var clsCursos = new curso_controller();
                if (clsCursos.Eliminar(id))
                {
                    MessageBox.Show("El curso se ha eliminado con éxito.");
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
                var IdCurso = filaSeleccionada.Cells["IdCurso"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarCurso((int)IdCurso);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarCurso((int)IdCurso);
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
    }
}
