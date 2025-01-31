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

namespace SistemaCursosOnline.Views.Estudiantes
{
    //estudiante_model IdEstudiante,Cedula,Nombre,Email,Telefono,FechaNacimiento,Direccion
    public partial class frmEstudiantes : Form
    {
        public bool modoEdision = false;
        public int id = 0;
        public frmEstudiantes(string modo)
        {
            InitializeComponent();
            if (modo != "n")
            {
                this.modoEdision = true;
                this.id = int.Parse(modo);
            }
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            if (!this.modoEdision)
            {
                lblFrm.Text = "Ingreso de Nuevo Estudiante";
            }
            else
            {
                lblFrm.Text = " Actualizacion de Estudiante";
                var estudianteController = new estudiante_controller();
                var estudiante = estudianteController.ObtenerPorId(this.id);
                txtCedula.Text = estudiante.Cedula;
                txtNombre.Text = estudiante.Nombre;
                txtEmail.Text = estudiante.Email;   
                txtTelefono.Text = estudiante.Telefono;
                dtpFechaNacimiento.Value = estudiante.FechaNacimiento;
                txtDireccion.Text = estudiante.Direccion;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtCedula.Text == "" || txtNombre.Text == "" || txtEmail.Text == "" || txtTelefono.Text == "" || txtDireccion.Text == "" || dtpFechaNacimiento.Value == null)
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.");
                return;
            }

            try
            {
                var estudiante = new estudiante_model()
                {
                    Cedula = txtCedula.Text,
                    Nombre = txtNombre.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text
                };

                var controller = new estudiante_controller();

                if (!this.modoEdision)
                {
                    var resultado = controller.Insertar(estudiante);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Estudiante guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    estudiante.IdEstudiante = this.id;
                    var resultado = controller.Actualizar(estudiante);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Estudiante actualizado con éxito");
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
