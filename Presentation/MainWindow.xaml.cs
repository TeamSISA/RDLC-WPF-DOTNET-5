using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using Dominio;
using Microsoft.Reporting.WinForms;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ReportViewer reportViewer;
        private BindingSource SalesReportBindingSource;
        private BindingSource SalesListingBindingSource;
        private BindingSource NetSalesByPeriodBindingSource;

        private Stream getPathEmbedded()
        {
            Assembly assembly = typeof(Presentation.App).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Presentation.Reports.SalesReport.rdlc");
            return stream;
        }

        private void getSalesReport(DateTime startDate, DateTime endDate)
        {
            SalesReportBindingSource = new BindingSource();
            SalesListingBindingSource = new BindingSource();
            NetSalesByPeriodBindingSource = new BindingSource();
            SalesReport reportModel = new SalesReport();
            reportModel.createSalesOrderReport(startDate, endDate);
            SalesReportBindingSource.DataSource = reportModel;
            SalesListingBindingSource.DataSource = reportModel.salesListing;
            NetSalesByPeriodBindingSource.DataSource = reportModel.netSalesByPeriod;
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Clear();
            ReportDataSource rs1 = new ReportDataSource();
            rs1.Name = "salesReport";
            rs1.Value = SalesReportBindingSource;
            ReportDataSource rs2 = new ReportDataSource();
            rs2.Name = "salesListing";
            rs2.Value = SalesListingBindingSource;
            ReportDataSource rs3 = new ReportDataSource();
            rs3.Name = "netSalesByPeriod";
            rs3.Value = NetSalesByPeriodBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(rs1);
            this.reportViewer.LocalReport.DataSources.Add(rs2);
            this.reportViewer.LocalReport.DataSources.Add(rs3);
            // Para agregar el reporte a visualizar desde código se hace así:
            //reportViewer.LocalReport.ReportEmbeddedResource =  "Presentation.Reports.SalesReport.rdlc";
            //txt.Text = reportViewer.LocalReport.ReportEmbeddedResource;
            reportViewer.LocalReport.ReportPath = @"Reports\SalesReport.rdlc";
            this.reportViewer.RefreshReport();
        }

        public MainWindow()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            winformHost.Child = reportViewer;
            //reportViewer.LocalReport.ReportEmbeddedResource = @"Reports\SalesReport.rdlc";
        }

        private void btnToday_Click(object sender, RoutedEventArgs e)
        {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Now;
            getSalesReport(fromDate, toDate);
        }

        private void btnLast7Days_Click(object sender, RoutedEventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Now;
            getSalesReport(fromDate, toDate);
        }

        private void btnThisMonth_Click(object sender, RoutedEventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Now;
            getSalesReport(fromDate, toDate);
        }

        private void btnLast30Days_Click(object sender, RoutedEventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-30);
            var toDate = DateTime.Now;
            getSalesReport(fromDate, toDate);
        }

        private void btnThisYear_Click(object sender, RoutedEventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, 1, 1);
            var toDate = DateTime.Now;
            getSalesReport(fromDate, toDate);
        }

        private void btnApplyCustomDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime toDate, fromDate;
            if (datePickerFrom.Text is null) fromDate = DateTime.Now;
            else fromDate = DateTime.Parse(datePickerFrom.Text);
            if (datePickerTo.Text is null) toDate = DateTime.Now;
            else toDate = DateTime.Parse(datePickerTo.Text);
            getSalesReport(fromDate, new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59));
        }
    }
}
