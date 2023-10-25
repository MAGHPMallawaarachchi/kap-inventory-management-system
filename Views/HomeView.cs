using Guna.UI2.AnimatorNS;
using inventory_management_system_kap.Controllers;
using inventory_management_system_kap.Models;
using inventory_management_system_kap.Repositories;
using InventoryManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class HomeView : Form
    {
        UIHelper UIHelper = new UIHelper();
        private InvoiceController controller;
        private readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public HomeView()
        {
            InitializeComponent();
            controller = new InvoiceController(new InvoiceRepository(sqlConnectionString));
        }

        private void HomeView_Load(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlQuickActions);
            UIHelper.UpdatePanelRegion(pnlSalesOverview);
            UIHelper.UpdatePanelRegion(pnlTopSellingItems);
            UIHelper.UpdatePanelRegion(panel3);
            UIHelper.UpdatePanelRegion(panel5);
            populateChart();
            LoadSalesOverview();
        }

        private void pnlQuickActions_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlQuickActions);
        }

        private void pnlSalesOverview_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlSalesOverview);
        }

        private void pnlTopSellingItems_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(pnlTopSellingItems);
        }

        private void panel3_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(panel3);
        }

        private void panel5_SizeChanged(object sender, EventArgs e)
        {
            UIHelper.UpdatePanelRegion(panel5);
        }

        private void populateChart()
        {
            IEnumerable<InvoiceModel> invoicesThisMonth = controller.GetInvoicesForCurrentMonth();
            IEnumerable<InvoiceModel> invoicesLastMonth = controller.GetInvoicesForPreviousMonth();

            var dailyTotalAmountsThisMonth = invoicesThisMonth
                .GroupBy(i => i.Date.Day)
                .OrderBy(group => group.Key)
                .Select(group => new EarningSummaryChartDataModel
                {
                    Date = group.Key,
                    TotalAmount = group.Sum(i => i.TotalAmount)
                })
                .ToList();

            var dailyTotalAmountsLastMonth = invoicesLastMonth
                .GroupBy(i => i.Date.Day)
                .OrderBy(group => group.Key)
                .Select(group => new EarningSummaryChartDataModel
                {
                    Date = group.Key,
                    TotalAmount = group.Sum(i => i.TotalAmount)
                })
                .ToList();

            chartEarningsSummary.Series["ThisMonth"].Points.DataBind(dailyTotalAmountsThisMonth, "Date", "TotalAmount", "");
            chartEarningsSummary.Series["LastMonth"].Points.DataBind(dailyTotalAmountsLastMonth, "Date", "TotalAmount", "");

            chartEarningsSummary.ChartAreas["ChartArea"].AxisY.Minimum = 0;

            double maxThisMonth = (double)dailyTotalAmountsThisMonth.Max(d => d.TotalAmount);
            double maxLastMonth = (double)dailyTotalAmountsLastMonth.Max(d => d.TotalAmount);
            chartEarningsSummary.ChartAreas["ChartArea"].AxisY.Maximum = Math.Max(maxThisMonth, maxLastMonth);

            chartEarningsSummary.ChartAreas["ChartArea"].AxisX.Minimum = 1;
            chartEarningsSummary.ChartAreas["ChartArea"].AxisX.Maximum = 31;
        }

        private void LoadSalesOverview()
        {
            DateTime startDate = new DateTime(2010,1,1);
            DateTime endDate = DateTime.Now.Date;

            lblSales.Text = controller.GetTotalSales().ToString();
            lblRevenue.Text = "Rs. "+controller.GetTotalRevenue(startDate, endDate).ToString("N2");
            lblCost.Text = "Rs. "+controller.GetTotalCost(startDate, endDate).ToString("N2");
        }

    }
}
