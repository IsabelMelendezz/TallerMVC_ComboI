using Microsoft.Reporting.WinForms;
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

namespace CapaVista_prototipoumg2k26.Reportes
{
    public partial class frmReporteEmpleados : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();
        public frmReporteEmpleados()
        {
            InitializeComponent();
        }

        private void frmReporteEmpleados_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", empleado.GetAll()); 
            reportViewer1.LocalReport.ReportEmbeddedResource = "CapaVista_prototipoumg2k26.Reportes.ReportEmpleados.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.RefreshReport();
        }
    }
}
