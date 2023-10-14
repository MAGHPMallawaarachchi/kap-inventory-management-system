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
    public partial class ItemDetailsView : Form
    {
        public string PartNo { get => lblIPartNo.Text ; set { lblIPartNo.Text = value; } }

        public ItemDetailsView(string partNo)
        {
            InitializeComponent();
            PartNo = partNo;
        }
    }
}
