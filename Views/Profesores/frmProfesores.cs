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

namespace SistemaCursosOnline.Views.Profesores
{
    public partial class frmProfesores : Form
    {
        public bool modoEdision = false;
        public int id = 0;
        public frmProfesores(string modo)
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

        private void frmProfesores_Load(object sender, EventArgs e)
        {
            if (!this.modoEdision)
            {
                lblFrm.Text = "Ingreso de Nuevo Profesor";
            }
            else
            {
                lblFrm.Text = " Actualizacion de Profesor";
                var profesorController = new profesor_controller();
                var profesor = profesorController.ObtenerPorId(this.id);
                txtCedula.Text = profesor.Cedula;
                txtNombre.Text = profesor.Nombre;
                txtEmail.Text = profesor.Email;
                txtTelefono.Text = profesor.Telefono;
                dtpFechaNacimiento.Value = profesor.FechaNacimiento;
                txtDireccion.Text = profesor.Direccion;
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
                var profesor = new profesor_model()
                {
                    Cedula = txtCedula.Text,
                    Nombre = txtNombre.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    Direccion = txtDireccion.Text
                };

                var controller = new profesor_controller();

                if (!this.modoEdision)
                {
                    var resultado = controller.Insertar(profesor);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Profesor guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else
                {
                    profesor.IdProfesor = this.id;
                    var resultado = controller.Actualizar(profesor);
                    if (resultado == "ok")
                    {
                        MessageBox.Show("Profesor actualizado con éxito");
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

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
