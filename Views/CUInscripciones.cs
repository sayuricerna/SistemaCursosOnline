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
    public partial class CUInscripciones : UserControl
    {
        public CUInscripciones()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Inscripciones.frmInscripciones frm = new Inscripciones.frmInscripciones("n");
            frm.Text = "Formulario de Inscripciones";
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.cargaGrilla(2);
        }

        private void CUInscripciones_Load(object sender, EventArgs e)
        {
            var logica = new inscripcion_controller();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = logica.ObtenerTodos();
            this.cargaGrilla(1);
        }
        public void cargaGrilla(int numero)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var logicaInscripciones = new inscripcion_controller();
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
                dataGridView1.DataSource = logicaInscripciones.ObtenerTodos();
            }
            else
            {
                dataGridView1.DataSource = logicaInscripciones.Buscar(txtBuscar.Text.Trim());
            }
            dataGridView1.Columns["IdEstudiante"].Visible = false;
            dataGridView1.Columns["IdCurso"].Visible = false;
            dataGridView1.Columns["IdInscripcion"].Visible = false;
            dataGridView1.Columns["fechaInscripcion"].HeaderText = "Fecha Inscripción";
            dataGridView1.Columns["NombreEstudiante"].HeaderText = "Estudiante";
            dataGridView1.Columns["NombreCurso"].HeaderText = "Curso";
            dataGridView1.Columns["CedulaEstudiante"].HeaderText = "Cédula";

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }

        public void EditarInscripcion(int id)
        {
            Inscripciones.frmInscripciones frmInscripcion = new Inscripciones.frmInscripciones(id.ToString());
            frmInscripcion.ShowDialog();
            this.cargaGrilla(1);
        }

        public void EliminarInscripcion(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar esta inscripción?",
                "Eliminar Inscripción", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var clsInscripciones = new inscripcion_controller();
                if (clsInscripciones.Eliminar(id))
                {
                    MessageBox.Show("La inscripción se ha eliminado con éxito.");
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
                var IdInscripcion = filaSeleccionada.Cells["IdInscripcion"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarInscripcion((int)IdInscripcion);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarInscripcion((int)IdInscripcion);
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
