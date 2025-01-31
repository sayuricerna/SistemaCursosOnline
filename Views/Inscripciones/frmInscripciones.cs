using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaCursosOnline.Controllers;
using SistemaCursosOnline.Models;

namespace SistemaCursosOnline.Views.Inscripciones
{
    public partial class frmInscripciones : Form
    {
        public bool modoEdision = false;
        public int id = 0;
        public frmInscripciones(string modo)
        {
            InitializeComponent();
            if (modo != "n")
            {
                this.modoEdision = true;
                this.id = int.Parse(modo);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void cargaCursos()
        {
            var listacursos = new curso_controller();
            cmbCursos.DataSource = listacursos.ObtenerTodos();
            cmbCursos.ValueMember = "IdCurso";
            cmbCursos.DisplayMember = "NombreCurso";
        }
        public void cargaEstudiantes()
        {
            var listaestudiantes = new estudiante_controller();
            cmbEstudiantes.DataSource = listaestudiantes.ObtenerTodos();
            cmbEstudiantes.ValueMember = "IdEstudiante";
            cmbEstudiantes.DisplayMember = "Cedula";
            cmbEstudiantes.SelectedIndexChanged += new EventHandler(cmbEstudiantes_SelectedIndexChanged);

        }
        private void frmInscripciones_Load(object sender, EventArgs e)
        {
            cargaEstudiantes();
            cargaCursos();
            if (!this.modoEdision)
            {
                lblFrm.Text = "Ingreso de Nueva Incripción";
            }
            else
            {
                lblFrm.Text = " Actualizacion de Incripción";
                var inscripcionController = new inscripcion_controller();
                var inscripcion = inscripcionController.ObtenerPorId(this.id);
                cmbEstudiantes.SelectedValue = inscripcion.IdEstudiante;
                cmbCursos.SelectedValue = inscripcion.IdCurso;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiantes.SelectedValue == null || cmbCursos.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var inscripcion = new inscripcion_model()
                {
                    IdEstudiante = (int)cmbEstudiantes.SelectedValue,
                    IdCurso = (int)cmbCursos.SelectedValue,
                };

                var controller = new inscripcion_controller();

                if (!this.modoEdision && controller.verificarInscripcion(inscripcion.IdEstudiante, inscripcion.IdCurso))
                {
                    MessageBox.Show("Este estudiante ya está inscrito en este curso.");
                    return;
                }

                if (!this.modoEdision)
                {
                    var resultado = controller.Insertar(inscripcion);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Inscripción guardada con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    inscripcion.IdInscripcion = this.id;
                    var resultado = controller.Actualizar(inscripcion);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Inscripción actualizada con éxito.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {resultado}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void lblEstudianteEncontrado_Click(object sender, EventArgs e)
        {

        }

        private void cmbEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstudiantes.SelectedValue != null)
            {
                if (int.TryParse(cmbEstudiantes.SelectedValue.ToString(), out int estudianteId))
                {
                    var estudianteController = new estudiante_controller();
                    var estudiante = estudianteController.ObtenerPorId(estudianteId);

                    if (estudiante != null)
                    {
                        lblEstudianteEncontrado.Text = $"Estudiante: {estudiante.Nombre}";
                    }
                    else
                    {
                        lblEstudianteEncontrado.Text = "Estudiante no encontrado";
                    }
                }
                
            }
        }
    }
}
