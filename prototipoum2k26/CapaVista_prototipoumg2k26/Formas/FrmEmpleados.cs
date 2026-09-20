using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControlador_prototipoumg2k26;
using CapaVista_prototipoumg2k26.Reportes;

namespace CapaVista_prototipoumg2k26.Formas
{
    public partial class FrmEmpleados : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();
        public FrmEmpleados()
        {
            InitializeComponent();
            panIngresoDatos.Enabled = false;
            CargarDatos();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            listaEmpleados();
        }
        private void listaEmpleados()
        {
            try
            {
                dgvEmpleados.DataSource = empleado.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleado.FindbyId(txtSearch.Text);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvEmpleados.DataSource = empleado.FindbyId(txtSearch.Text);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            empleado.IdTipoEmpleado = Convert.ToInt32(cmbTipoEmpleado.SelectedValue);
            empleado.IdEstadoEmpleado = Convert.ToInt32(cmbEstadoEmpleado.SelectedValue);
            empleado.NombreEmpleado = txtNombre.Text;
            empleado.ApellidoEmpleado = txtApellido.Text;
            empleado.DpiEmpleado = txtDpi.Text;
            empleado.NitEmpleado = txtNit.Text;
            empleado.TelefonoEmpleado = txtTelefono.Text;
            empleado.DireccionEmpleado = txtDireccion.Text;
            empleado.FechaNacimientoEmpleado = txtFechaNacimiento.Value;
            empleado.FechaContratacionEmpleado = txtFechaContratacion.Value;

            bool valido = new Ayudas.ValidacionDatos(empleado).Validar();
            if (valido == true)
            {
                string resultado = empleado.GrabarCambios();
                MessageBox.Show(resultado);
                listaEmpleados();
                Reinicio();
            }
        }
        private void Reinicio()
        {
            panIngresoDatos.Enabled = false;
            txtNombre.Clear();
            txtApellido.Clear();
            txtDpi.Clear();
            txtNit.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtFechaNacimiento.Value = DateTime.Today;
            txtFechaContratacion.Value = DateTime.Today;
            cmbTipoEmpleado.SelectedIndex = -1;
            cmbEstadoEmpleado.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            panIngresoDatos.Enabled = true;
            empleado.Estado = EstadoEntidad.Added;
            cmbTipoEmpleado.SelectedIndex = 0;
            cmbEstadoEmpleado.SelectedIndex = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                panIngresoDatos.Enabled = true;
                empleado.Estado = EstadoEntidad.Modified;
                empleado.IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
                cmbTipoEmpleado.SelectedValue = dgvEmpleados.CurrentRow.Cells["IdTipoEmpleado"].Value;
                cmbEstadoEmpleado.SelectedValue = dgvEmpleados.CurrentRow.Cells["IdEstadoEmpleado"].Value;
                txtNombre.Text = dgvEmpleados.CurrentRow.Cells["NombreEmpleado"].Value.ToString();
                txtApellido.Text = dgvEmpleados.CurrentRow.Cells["ApellidoEmpleado"].Value.ToString();
                txtDpi.Text = dgvEmpleados.CurrentRow.Cells["DpiEmpleado"].Value?.ToString();
                txtNit.Text = dgvEmpleados.CurrentRow.Cells["NitEmpleado"].Value?.ToString();
                txtTelefono.Text = dgvEmpleados.CurrentRow.Cells["TelefonoEmpleado"].Value?.ToString();
                txtDireccion.Text = dgvEmpleados.CurrentRow.Cells["DireccionEmpleado"].Value?.ToString();

                var fechaNac = dgvEmpleados.CurrentRow.Cells["FechaNacimientoEmpleado"].Value;
                txtFechaNacimiento.Value = fechaNac != DBNull.Value && fechaNac != null ? Convert.ToDateTime(fechaNac) : DateTime.Today;

                var fechaContrat = dgvEmpleados.CurrentRow.Cells["FechaContratacionEmpleado"].Value;
                txtFechaContratacion.Value = fechaContrat != DBNull.Value && fechaContrat != null ? Convert.ToDateTime(fechaContrat) : DateTime.Today;
            }
            else MessageBox.Show("Seleccione una fila");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                empleado.Estado = EstadoEntidad.Deleted;
                empleado.IdEmpleado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["IdEmpleado"].Value);
                string resultado = empleado.GrabarCambios();
                MessageBox.Show(resultado);
                listaEmpleados();
            }
            else MessageBox.Show("Seleccione una fila");
        }
        void CargarDatos()
        {
            comboI1.llenarCombo("tbl_empleadospuestos", "codigo_empleado", "puesto");

            cmbTipoEmpleado.DataSource = empleado.GetTiposEmpleado();
            cmbTipoEmpleado.DisplayMember = "NombreTipoEmpleado";
            cmbTipoEmpleado.ValueMember = "IdTipoEmpleado";

            cmbEstadoEmpleado.DataSource = empleado.GetEstadosEmpleado();
            cmbEstadoEmpleado.DisplayMember = "NombreEstadoEmpleado";
            cmbEstadoEmpleado.ValueMember = "IdEstadoEmpleado";
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
                        frmReporteEmpleados reporte = new frmReporteEmpleados();
                        reporte.Show();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\CAPACITACION\\TallerMVC_ComboI\\AyudaRisko\\CapaRisko.chm", "Cliente.html");
        }
    }
}