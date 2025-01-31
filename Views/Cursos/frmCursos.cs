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
using SistemaCursosOnline.Models;

namespace SistemaCursosOnline.Views.Cursos
{
    public partial class frmCursos : Form
    {
        public bool modoEdision = false;
        public int id = 0;
        public frmCursos(string modo)
        {
            InitializeComponent();
            if (modo != "n")
            {
                this.modoEdision = true;
                this.id = int.Parse(modo);
            }
        }
        public void cargaProfesor()
        {
            var listaprofes = new profesor_controller();
            cmbProfesor.DataSource = listaprofes.ObtenerTodos();
            cmbProfesor.ValueMember = "IdProfesor";
            cmbProfesor.DisplayMember = "Nombre";
        }
        private void frmCursos_Load(object sender, EventArgs e)
        {
            cargaProfesor();
            if (!this.modoEdision)
            {
                lblFrm.Text = "Ingreso de Nuevo Curso";
            }
            else
            {
                lblFrm.Text = " Actualización de Curso";
                var cursoController = new curso_controller();
                var curso = cursoController.ObtenerPorId(this.id);
                txtNombre.Text = curso.NombreCurso;
                txtDescripcion.Text = curso.Descripcion;
                dtpInicio.Value = curso.FechaInicio;
                dtpFin.Value = curso.FechaFin;
                cmbProfesor.SelectedValue = curso.IdProfesor;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtDescripcion.Text == "" || dtpInicio.Value == null || dtpFin.Value == null || cmbProfesor.SelectedValue == null)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var curso = new curso_model()
                {
                    NombreCurso = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    FechaInicio = dtpInicio.Value,
                    FechaFin = dtpFin.Value,
                    IdProfesor = Convert.ToInt32(cmbProfesor.SelectedValue)
                };

                var controller = new curso_controller();

                if (!this.modoEdision)
                {
                    var resultado = controller.Insertar(curso);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Curso guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    curso.IdCurso = this.id;
                    var resultado = controller.Actualizar(curso);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Curso actualizado con éxito");
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




    }
}
