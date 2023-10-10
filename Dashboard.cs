using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;

        private void openChildForm(Form childform, Guna2Button button)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                if (activeForm.Tag is Guna2Button activeButton)
                {
                    activeButton.Checked = false;
                }
            }
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childform);
            pnlChildForm.Tag = childform;
            button.Checked = true;
            childform.BringToFront();
            childform.Show();

            childform.Tag = button;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            openChildForm(new Views.InventoryView(), btnInventory);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new Views.CustomersView(), btnCustomers);
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            openChildForm(new Views.InvoicesView(), btnInvoices);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
