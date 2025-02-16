using ClosedXML.Excel;
using ProjectPI_Building.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPI_Building
{
    public partial class Frm_ReporteVentas : Form
    {
        private ReciboService reporteService = new ReciboService();
        public Frm_ReporteVentas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;
            string tipoRecibo = cbTipoRecibo.SelectedItem?.ToString() ?? "";

            DataTable dt = reporteService.ObtenerReportes(fechaInicio, fechaFin, tipoRecibo);
            MessageBox.Show("Registros obtenidos: " + dt.Rows.Count);
            dgvReportes.DataSource = dt;
        }
        private void ExportarExcel(DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Reporte");
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        wb.SaveAs(sfd.FileName);
                        MessageBox.Show("Reporte exportado correctamente.", "Éxito");
                    }
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvReportes.Rows.Count > 0)
            {
                ExportarExcel((DataTable)dgvReportes.DataSource);
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.");
            }
        }
    }
}
