namespace SM
{
    partial class IntroForm
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
            StoreNameLabel = new Label();
            unpaidOrdersButton = new Button();
            logoutButton = new Button();
            ReturnsBtn = new Button();
            NewOrderBtn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            AllOrdersBtn = new Button();
            ProductsBtn = new Button();
            InventoryBtn = new Button();
            SuppliersBtn = new Button();
            categoriesButton = new Button();
            customersBtn = new Button();
            button1 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // StoreNameLabel
            // 
            StoreNameLabel.Anchor = AnchorStyles.None;
            StoreNameLabel.AutoSize = true;
            StoreNameLabel.BackColor = Color.Transparent;
            tableLayoutPanel1.SetColumnSpan(StoreNameLabel, 3);
            StoreNameLabel.Font = new Font("Sylfaen", 30F);
            StoreNameLabel.ForeColor = Color.FloralWhite;
            StoreNameLabel.Location = new Point(253, 41);
            StoreNameLabel.Margin = new Padding(23, 13, 23, 13);
            StoreNameLabel.Name = "StoreNameLabel";
            StoreNameLabel.Size = new Size(662, 66);
            StoreNameLabel.TabIndex = 1;
            StoreNameLabel.Text = "Inventory Managment System";
            StoreNameLabel.TextAlign = ContentAlignment.TopCenter;
            StoreNameLabel.Click += StoreNameLabel_Click;
            // 
            // unpaidOrdersButton
            // 
            unpaidOrdersButton.BackColor = SystemColors.ButtonFace;
            unpaidOrdersButton.Dock = DockStyle.Fill;
            unpaidOrdersButton.Font = new Font("Segoe UI", 20F);
            unpaidOrdersButton.ForeColor = Color.Black;
            unpaidOrdersButton.Location = new Point(23, 460);
            unpaidOrdersButton.Margin = new Padding(23, 13, 23, 13);
            unpaidOrdersButton.Name = "unpaidOrdersButton";
            unpaidOrdersButton.Size = new Size(343, 123);
            unpaidOrdersButton.TabIndex = 17;
            unpaidOrdersButton.Text = "Unpaid Orders";
            unpaidOrdersButton.UseVisualStyleBackColor = false;
            unpaidOrdersButton.Click += unpaidOrdersButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Anchor = AnchorStyles.None;
            logoutButton.BackColor = SystemColors.ButtonFace;
            logoutButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            logoutButton.ForeColor = Color.Black;
            logoutButton.Location = new Point(881, 632);
            logoutButton.Margin = new Padding(23, 13, 23, 13);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(183, 80);
            logoutButton.TabIndex = 16;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            logoutButton.Click += logoutButton_Click;
            // 
            // ReturnsBtn
            // 
            ReturnsBtn.BackColor = SystemColors.ButtonFace;
            ReturnsBtn.Dock = DockStyle.Fill;
            ReturnsBtn.Font = new Font("Segoe UI", 20F);
            ReturnsBtn.ForeColor = Color.Black;
            ReturnsBtn.Location = new Point(412, 162);
            ReturnsBtn.Margin = new Padding(23, 13, 23, 13);
            ReturnsBtn.Name = "ReturnsBtn";
            ReturnsBtn.Size = new Size(343, 123);
            ReturnsBtn.TabIndex = 14;
            ReturnsBtn.Text = "New Returns";
            ReturnsBtn.UseVisualStyleBackColor = false;
            ReturnsBtn.Click += ReturnsBtn_Click;
            // 
            // NewOrderBtn
            // 
            NewOrderBtn.BackColor = SystemColors.ButtonFace;
            NewOrderBtn.Dock = DockStyle.Fill;
            NewOrderBtn.Font = new Font("Segoe UI", 20F);
            NewOrderBtn.ForeColor = Color.Black;
            NewOrderBtn.Location = new Point(23, 162);
            NewOrderBtn.Margin = new Padding(23, 13, 23, 13);
            NewOrderBtn.Name = "NewOrderBtn";
            NewOrderBtn.Size = new Size(343, 123);
            NewOrderBtn.TabIndex = 10;
            NewOrderBtn.Text = "New Order";
            NewOrderBtn.UseVisualStyleBackColor = false;
            NewOrderBtn.Click += NewOrderBtn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(55, 58, 81);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Controls.Add(AllOrdersBtn, 0, 2);
            tableLayoutPanel1.Controls.Add(NewOrderBtn, 0, 1);
            tableLayoutPanel1.Controls.Add(ProductsBtn, 2, 1);
            tableLayoutPanel1.Controls.Add(InventoryBtn, 2, 2);
            tableLayoutPanel1.Controls.Add(ReturnsBtn, 1, 1);
            tableLayoutPanel1.Controls.Add(StoreNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(SuppliersBtn, 1, 3);
            tableLayoutPanel1.Controls.Add(categoriesButton, 2, 3);
            tableLayoutPanel1.Controls.Add(customersBtn, 1, 2);
            tableLayoutPanel1.Controls.Add(unpaidOrdersButton, 0, 3);
            tableLayoutPanel1.Controls.Add(button1, 0, 4);
            tableLayoutPanel1.Controls.Add(logoutButton, 2, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1168, 749);
            tableLayoutPanel1.TabIndex = 24;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint_1;
            // 
            // AllOrdersBtn
            // 
            AllOrdersBtn.BackColor = SystemColors.ButtonFace;
            AllOrdersBtn.Dock = DockStyle.Fill;
            AllOrdersBtn.Font = new Font("Segoe UI", 20F);
            AllOrdersBtn.ForeColor = Color.Black;
            AllOrdersBtn.Location = new Point(23, 311);
            AllOrdersBtn.Margin = new Padding(23, 13, 23, 13);
            AllOrdersBtn.Name = "AllOrdersBtn";
            AllOrdersBtn.Size = new Size(343, 123);
            AllOrdersBtn.TabIndex = 11;
            AllOrdersBtn.Text = "All Orders";
            AllOrdersBtn.UseVisualStyleBackColor = false;
            AllOrdersBtn.Click += AllOrdersBtn_Click;
            // 
            // ProductsBtn
            // 
            ProductsBtn.BackColor = SystemColors.ButtonFace;
            ProductsBtn.Dock = DockStyle.Fill;
            ProductsBtn.Font = new Font("Segoe UI", 20F);
            ProductsBtn.ForeColor = Color.Black;
            ProductsBtn.Location = new Point(801, 162);
            ProductsBtn.Margin = new Padding(23, 13, 23, 13);
            ProductsBtn.Name = "ProductsBtn";
            ProductsBtn.Size = new Size(344, 123);
            ProductsBtn.TabIndex = 15;
            ProductsBtn.Text = "Products";
            ProductsBtn.UseVisualStyleBackColor = false;
            ProductsBtn.Click += ProductsBtn_Click;
            // 
            // InventoryBtn
            // 
            InventoryBtn.BackColor = SystemColors.ButtonFace;
            InventoryBtn.Dock = DockStyle.Fill;
            InventoryBtn.Font = new Font("Segoe UI", 20F);
            InventoryBtn.ForeColor = Color.Black;
            InventoryBtn.Location = new Point(801, 311);
            InventoryBtn.Margin = new Padding(23, 13, 23, 13);
            InventoryBtn.Name = "InventoryBtn";
            InventoryBtn.Size = new Size(344, 123);
            InventoryBtn.TabIndex = 12;
            InventoryBtn.Text = "Inventory";
            InventoryBtn.UseVisualStyleBackColor = false;
            InventoryBtn.Click += InventoryBtn_Click;
            // 
            // SuppliersBtn
            // 
            SuppliersBtn.BackColor = SystemColors.ButtonFace;
            SuppliersBtn.Dock = DockStyle.Fill;
            SuppliersBtn.Font = new Font("Segoe UI", 20F);
            SuppliersBtn.ForeColor = Color.Black;
            SuppliersBtn.Location = new Point(412, 460);
            SuppliersBtn.Margin = new Padding(23, 13, 23, 13);
            SuppliersBtn.Name = "SuppliersBtn";
            SuppliersBtn.Size = new Size(343, 123);
            SuppliersBtn.TabIndex = 13;
            SuppliersBtn.Text = "Suppliers";
            SuppliersBtn.UseVisualStyleBackColor = false;
            SuppliersBtn.Click += SuppliersBtn_Click;
            // 
            // categoriesButton
            // 
            categoriesButton.BackColor = SystemColors.ButtonFace;
            categoriesButton.Dock = DockStyle.Fill;
            categoriesButton.Font = new Font("Segoe UI", 20F);
            categoriesButton.ForeColor = Color.Black;
            categoriesButton.Location = new Point(801, 460);
            categoriesButton.Margin = new Padding(23, 13, 23, 13);
            categoriesButton.Name = "categoriesButton";
            categoriesButton.Size = new Size(344, 123);
            categoriesButton.TabIndex = 21;
            categoriesButton.Text = "Categories";
            categoriesButton.UseVisualStyleBackColor = false;
            categoriesButton.Click += categoriesButton_Click;
            // 
            // customersBtn
            // 
            customersBtn.BackColor = SystemColors.ButtonFace;
            customersBtn.Dock = DockStyle.Fill;
            customersBtn.Font = new Font("Segoe UI", 20F);
            customersBtn.ForeColor = Color.Black;
            customersBtn.Location = new Point(412, 311);
            customersBtn.Margin = new Padding(23, 13, 23, 13);
            customersBtn.Name = "customersBtn";
            customersBtn.Size = new Size(343, 123);
            customersBtn.TabIndex = 26;
            customersBtn.Text = "Customers";
            customersBtn.UseVisualStyleBackColor = false;
            customersBtn.Click += customersBtn_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(103, 632);
            button1.Margin = new Padding(23, 13, 23, 13);
            button1.Name = "button1";
            button1.Size = new Size(183, 80);
            button1.TabIndex = 24;
            button1.Text = "Check-In Check-Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += checkInButton_Click;
            // 
            // IntroForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InfoText;
            ClientSize = new Size(1168, 749);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "IntroForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Load += IntroForm1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label StoreNameLabel;
        private Button unpaidOrdersButton;
        private Button logoutButton;
        private Button ReturnsBtn;
        private Button NewOrderBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private Button categoriesButton;
        private Button AllOrdersBtn;
        private Button SuppliersBtn;
        private Button InventoryBtn;
        private Button ProductsBtn;
        private Button button1;
        private Button customersBtn;
    }
}