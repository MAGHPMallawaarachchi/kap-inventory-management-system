namespace inventory_management_system_kap.Views
{
    partial class CustomersView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCustomers = new System.Windows.Forms.Panel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSearchBar = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCustomersHeading = new System.Windows.Forms.Label();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCustomers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlCustomers.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlCustomers, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1054, 631);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.btnNext, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPageNumber, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnPrevious, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 592);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1048, 36);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnNext
            // 
            this.btnNext.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.btnNext.BorderRadius = 6;
            this.btnNext.BorderThickness = 1;
            this.btnNext.CheckedState.Parent = this.btnNext;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.CustomImages.Parent = this.btnNext;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.FillColor = System.Drawing.Color.Empty;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.btnNext.HoverState.Parent = this.btnNext;
            this.btnNext.Location = new System.Drawing.Point(945, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.ShadowDecoration.Parent = this.btnNext;
            this.btnNext.Size = new System.Drawing.Size(100, 30);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.lblPageNumber.Location = new System.Drawing.Point(107, 0);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(832, 36);
            this.lblPageNumber.TabIndex = 6;
            this.lblPageNumber.Text = "1 Of 10";
            this.lblPageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            this.btnPrevious.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.btnPrevious.BorderRadius = 6;
            this.btnPrevious.BorderThickness = 1;
            this.btnPrevious.CheckedState.Parent = this.btnPrevious;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.CustomImages.Parent = this.btnPrevious;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevious.FillColor = System.Drawing.Color.Empty;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.btnPrevious.HoverState.Parent = this.btnPrevious;
            this.btnPrevious.Location = new System.Drawing.Point(3, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.ShadowDecoration.Parent = this.btnPrevious;
            this.btnPrevious.Size = new System.Drawing.Size(98, 30);
            this.btnPrevious.TabIndex = 8;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pnlCustomers
            // 
            this.pnlCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlCustomers.Controls.Add(this.tableLayoutPanel13);
            this.pnlCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomers.Location = new System.Drawing.Point(0, 0);
            this.pnlCustomers.Margin = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Padding = new System.Windows.Forms.Padding(15);
            this.pnlCustomers.Size = new System.Drawing.Size(1054, 574);
            this.pnlCustomers.TabIndex = 1;
            this.pnlCustomers.SizeChanged += new System.EventHandler(this.pnlCustomers_SizeChanged);
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel14, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.dgvCustomers, 0, 1);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(1024, 544);
            this.tableLayoutPanel13.TabIndex = 4;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 4;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.28862F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.7439F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.231708F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.63415F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Controls.Add(this.txtSearchBar, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.lblCustomersHeading, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.btnFilter, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.btnAddCustomer, 3, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(1024, 29);
            this.tableLayoutPanel14.TabIndex = 1;
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.txtSearchBar.BorderRadius = 6;
            this.txtSearchBar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBar.DefaultText = "";
            this.txtSearchBar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBar.DisabledState.Parent = this.txtSearchBar;
            this.txtSearchBar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.txtSearchBar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(116)))), ((int)(((byte)(225)))));
            this.txtSearchBar.FocusedState.Parent = this.txtSearchBar;
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.txtSearchBar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(116)))), ((int)(((byte)(225)))));
            this.txtSearchBar.HoverState.Parent = this.txtSearchBar;
            this.txtSearchBar.IconLeft = global::inventory_management_system_kap.Properties.Resources.search;
            this.txtSearchBar.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearchBar.IconLeftSize = new System.Drawing.Size(14, 14);
            this.txtSearchBar.Location = new System.Drawing.Point(512, 0);
            this.txtSearchBar.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.PasswordChar = '\0';
            this.txtSearchBar.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.txtSearchBar.PlaceholderText = "Search here...";
            this.txtSearchBar.SelectedText = "";
            this.txtSearchBar.ShadowDecoration.Parent = this.txtSearchBar;
            this.txtSearchBar.Size = new System.Drawing.Size(270, 29);
            this.txtSearchBar.TabIndex = 22;
            this.txtSearchBar.TextOffset = new System.Drawing.Point(5, 0);
            this.txtSearchBar.TextChanged += new System.EventHandler(this.txtSearchBar_TextChanged);
            // 
            // lblCustomersHeading
            // 
            this.lblCustomersHeading.AutoSize = true;
            this.lblCustomersHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomersHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomersHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.lblCustomersHeading.Location = new System.Drawing.Point(3, 0);
            this.lblCustomersHeading.Name = "lblCustomersHeading";
            this.lblCustomersHeading.Size = new System.Drawing.Size(499, 29);
            this.lblCustomersHeading.TabIndex = 2;
            this.lblCustomersHeading.Text = "Customers";
            this.lblCustomersHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFilter
            // 
            this.btnFilter.BorderRadius = 6;
            this.btnFilter.CheckedState.Parent = this.btnFilter;
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.CustomImages.Parent = this.btnFilter;
            this.btnFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.btnFilter.HoverState.Parent = this.btnFilter;
            this.btnFilter.Image = global::inventory_management_system_kap.Properties.Resources.Filter;
            this.btnFilter.ImageSize = new System.Drawing.Size(14, 14);
            this.btnFilter.Location = new System.Drawing.Point(794, 0);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.btnFilter.ShadowDecoration.Parent = this.btnFilter;
            this.btnFilter.Size = new System.Drawing.Size(74, 29);
            this.btnFilter.TabIndex = 23;
            this.btnFilter.Text = "Filter";
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(116)))), ((int)(((byte)(225)))));
            this.btnAddCustomer.BorderRadius = 6;
            this.btnAddCustomer.CheckedState.Parent = this.btnAddCustomer;
            this.btnAddCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCustomer.CustomImages.Parent = this.btnAddCustomer;
            this.btnAddCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddCustomer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(116)))), ((int)(((byte)(225)))));
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.btnAddCustomer.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(116)))), ((int)(((byte)(225)))));
            this.btnAddCustomer.HoverState.Parent = this.btnAddCustomer;
            this.btnAddCustomer.Image = global::inventory_management_system_kap.Properties.Resources.Add;
            this.btnAddCustomer.ImageSize = new System.Drawing.Size(14, 14);
            this.btnAddCustomer.Location = new System.Drawing.Point(878, 0);
            this.btnAddCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.ShadowDecoration.Parent = this.btnAddCustomer;
            this.btnAddCustomer.Size = new System.Drawing.Size(141, 29);
            this.btnAddCustomer.TabIndex = 24;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCustomers.ColumnHeadersHeight = 18;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.customerId,
            this.name,
            this.address,
            this.city,
            this.contactNumber,
            this.edit,
            this.delete});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.dgvCustomers.Location = new System.Drawing.Point(0, 44);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1024, 500);
            this.dgvCustomers.TabIndex = 2;
            this.dgvCustomers.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvCustomers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvCustomers.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.dgvCustomers.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(59)))), ((int)(((byte)(60)))));
            this.dgvCustomers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.dgvCustomers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dgvCustomers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.dgvCustomers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvCustomers.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvCustomers.ThemeStyle.ReadOnly = true;
            this.dgvCustomers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.dgvCustomers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dgvCustomers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(179)))), ((int)(((byte)(184)))));
            this.dgvCustomers.ThemeStyle.RowsStyle.Height = 22;
            this.dgvCustomers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvCustomers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCustomers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCustomers_CellFormatting);
            this.dgvCustomers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomers_DataBindingComplete);
            // 
            // number
            // 
            this.number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.number.HeaderText = "No.";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Width = 53;
            // 
            // customerId
            // 
            this.customerId.DataPropertyName = "CustomerId";
            this.customerId.FillWeight = 101.963F;
            this.customerId.HeaderText = "Customer ID";
            this.customerId.Name = "customerId";
            this.customerId.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            this.name.FillWeight = 101.963F;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "Address";
            this.address.FillWeight = 101.963F;
            this.address.HeaderText = "Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // city
            // 
            this.city.DataPropertyName = "City";
            this.city.FillWeight = 101.963F;
            this.city.HeaderText = "City";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // contactNumber
            // 
            this.contactNumber.DataPropertyName = "ContactNo";
            this.contactNumber.FillWeight = 101.963F;
            this.contactNumber.HeaderText = "Contact No.";
            this.contactNumber.Name = "contactNumber";
            this.contactNumber.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.edit.FillWeight = 95.59032F;
            this.edit.HeaderText = "";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Width = 17;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delete.FillWeight = 94.5946F;
            this.delete.HeaderText = "";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Width = 5;
            // 
            // CustomersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1054, 631);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustomersView";
            this.Text = "CustomersView";
            this.Load += new System.EventHandler(this.CustomersView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlCustomers.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlCustomers;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.Label lblPageNumber;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBar;
        private System.Windows.Forms.Label lblCustomersHeading;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2Button btnAddCustomer;
        private Guna.UI2.WinForms.Guna2DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNumber;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}