using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management_system_kap.Views
{
    public partial class NewCustomerModalView : Form
    {
        public NewCustomerModalView()
        {
            InitializeComponent();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
