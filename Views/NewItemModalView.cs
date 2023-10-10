using Guna.UI2.WinForms.Suite;
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
    public partial class NewItemModalView : Form
    {
        public NewItemModalView()
        {
            InitializeComponent();
        }

        private void imgBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif)|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path
                string imagePath = openFileDialog.FileName;

                // Now you can do something with the imagePath, such as displaying the image in a PictureBox or processing it.

                // Example: Display the selected image in a PictureBox control
                picAddImage.Image = Image.FromFile(imagePath);
            }
        }
    }
}
