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
            prevRButton = new Button();
            dSButton = new Button();
            servicesButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            promotionsButton = new Button();
            AllOrdersBtn = new Button();
            ProductsBtn = new Button();
            InventoryBtn = new Button();
            SuppliersBtn = new Button();
            categoriesButton = new Button();
            sellersButton = new Button();
            button1 = new Button();
            button3 = new Button();
            customersBtn = new Button();
            button4 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // StoreNameLabel
            // 
            StoreNameLabel.Anchor = AnchorStyles.None;
            StoreNameLabel.AutoSize = true;
            StoreNameLabel.BackColor = Color.Transparent;
            StoreNameLabel.Font = new Font("Sylfaen", 30F);
            StoreNameLabel.ForeColor = Color.FloralWhite;
            StoreNameLabel.Location = new Point(417, 20);
            StoreNameLabel.Margin = new Padding(23, 13, 23, 13);
            StoreNameLabel.Name = "StoreNameLabel";
            StoreNameLabel.Size = new Size(333, 66);
            StoreNameLabel.TabIndex = 1;
            StoreNameLabel.Text = "GALAXY SAT";
            StoreNameLabel.TextAlign = ContentAlignment.TopCenter;
            StoreNameLabel.Click += StoreNameLabel_Click;
            // 
            // unpaidOrdersButton
            // 
            unpaidOrdersButton.Anchor = AnchorStyles.None;
            unpaidOrdersButton.BackColor = SystemColors.ButtonFace;
            unpaidOrdersButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            unpaidOrdersButton.ForeColor = Color.Black;
            unpaidOrdersButton.Location = new Point(103, 652);
            unpaidOrdersButton.Margin = new Padding(23, 13, 23, 13);
            unpaidOrdersButton.Name = "unpaidOrdersButton";
            unpaidOrdersButton.Size = new Size(183, 80);
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
            logoutButton.Location = new Point(881, 652);
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
            ReturnsBtn.Location = new Point(412, 119);
            ReturnsBtn.Margin = new Padding(23, 13, 23, 13);
            ReturnsBtn.Name = "ReturnsBtn";
            ReturnsBtn.Size = new Size(343, 80);
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
            NewOrderBtn.Location = new Point(23, 119);
            NewOrderBtn.Margin = new Padding(23, 13, 23, 13);
            NewOrderBtn.Name = "NewOrderBtn";
            NewOrderBtn.Size = new Size(343, 80);
            NewOrderBtn.TabIndex = 10;
            NewOrderBtn.Text = "New Order";
            NewOrderBtn.UseVisualStyleBackColor = false;
            NewOrderBtn.Click += NewOrderBtn_Click;
            // 
            // prevRButton
            // 
            prevRButton.BackColor = SystemColors.ButtonFace;
            prevRButton.Dock = DockStyle.Fill;
            prevRButton.Font = new Font("Segoe UI", 20F);
            prevRButton.ForeColor = Color.Black;
            prevRButton.Location = new Point(412, 331);
            prevRButton.Margin = new Padding(23, 13, 23, 13);
            prevRButton.Name = "prevRButton";
            prevRButton.Size = new Size(343, 80);
            prevRButton.TabIndex = 19;
            prevRButton.Text = "Previous Returns";
            prevRButton.UseVisualStyleBackColor = false;
            // 
            // dSButton
            // 
            dSButton.BackColor = SystemColors.ButtonFace;
            dSButton.Dock = DockStyle.Fill;
            dSButton.Font = new Font("Segoe UI", 20F);
            dSButton.ForeColor = Color.Black;
            dSButton.Location = new Point(23, 331);
            dSButton.Margin = new Padding(23, 13, 23, 13);
            dSButton.Name = "dSButton";
            dSButton.Size = new Size(343, 80);
            dSButton.TabIndex = 20;
            dSButton.Text = "Daily Sales";
            dSButton.UseVisualStyleBackColor = false;
            // 
            // servicesButton
            // 
            servicesButton.BackColor = SystemColors.ButtonFace;
            servicesButton.Dock = DockStyle.Fill;
            servicesButton.Font = new Font("Segoe UI", 20F);
            servicesButton.ForeColor = Color.Black;
            servicesButton.Location = new Point(412, 225);
            servicesButton.Margin = new Padding(23, 13, 23, 13);
            servicesButton.Name = "servicesButton";
            servicesButton.Size = new Size(343, 80);
            servicesButton.TabIndex = 23;
            servicesButton.Text = "Services";
            servicesButton.UseVisualStyleBackColor = false;
            servicesButton.Click += servicesButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(55, 58, 81);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.Controls.Add(prevRButton, 1, 3);
            tableLayoutPanel1.Controls.Add(promotionsButton, 0, 4);
            tableLayoutPanel1.Controls.Add(dSButton, 0, 3);
            tableLayoutPanel1.Controls.Add(AllOrdersBtn, 0, 2);
            tableLayoutPanel1.Controls.Add(NewOrderBtn, 0, 1);
            tableLayoutPanel1.Controls.Add(ProductsBtn, 2, 1);
            tableLayoutPanel1.Controls.Add(InventoryBtn, 2, 2);
            tableLayoutPanel1.Controls.Add(SuppliersBtn, 2, 4);
            tableLayoutPanel1.Controls.Add(categoriesButton, 2, 3);
            tableLayoutPanel1.Controls.Add(sellersButton, 1, 4);
            tableLayoutPanel1.Controls.Add(servicesButton, 1, 2);
            tableLayoutPanel1.Controls.Add(ReturnsBtn, 1, 1);
            tableLayoutPanel1.Controls.Add(StoreNameLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(logoutButton, 2, 6);
            tableLayoutPanel1.Controls.Add(button1, 1, 6);
            tableLayoutPanel1.Controls.Add(button3, 2, 5);
            tableLayoutPanel1.Controls.Add(customersBtn, 1, 5);
            tableLayoutPanel1.Controls.Add(button4, 0, 5);
            tableLayoutPanel1.Controls.Add(unpaidOrdersButton, 0, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.28571F));
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
            // promotionsButton
            // 
            promotionsButton.BackColor = SystemColors.ButtonFace;
            promotionsButton.Dock = DockStyle.Fill;
            promotionsButton.Font = new Font("Segoe UI", 20F);
            promotionsButton.ForeColor = Color.Black;
            promotionsButton.Location = new Point(23, 437);
            promotionsButton.Margin = new Padding(23, 13, 23, 13);
            promotionsButton.Name = "promotionsButton";
            promotionsButton.Size = new Size(343, 80);
            promotionsButton.TabIndex = 18;
            promotionsButton.Text = "Promotions";
            promotionsButton.UseVisualStyleBackColor = false;
            promotionsButton.Click += categoriesButton_Click;
            // 
            // AllOrdersBtn
            // 
            AllOrdersBtn.BackColor = SystemColors.ButtonFace;
            AllOrdersBtn.Dock = DockStyle.Fill;
            AllOrdersBtn.Font = new Font("Segoe UI", 20F);
            AllOrdersBtn.ForeColor = Color.Black;
            AllOrdersBtn.Location = new Point(23, 225);
            AllOrdersBtn.Margin = new Padding(23, 13, 23, 13);
            AllOrdersBtn.Name = "AllOrdersBtn";
            AllOrdersBtn.Size = new Size(343, 80);
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
            ProductsBtn.Location = new Point(801, 119);
            ProductsBtn.Margin = new Padding(23, 13, 23, 13);
            ProductsBtn.Name = "ProductsBtn";
            ProductsBtn.Size = new Size(344, 80);
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
            InventoryBtn.Location = new Point(801, 225);
            InventoryBtn.Margin = new Padding(23, 13, 23, 13);
            InventoryBtn.Name = "InventoryBtn";
            InventoryBtn.Size = new Size(344, 80);
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
            SuppliersBtn.Location = new Point(801, 437);
            SuppliersBtn.Margin = new Padding(23, 13, 23, 13);
            SuppliersBtn.Name = "SuppliersBtn";
            SuppliersBtn.Size = new Size(344, 80);
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
            categoriesButton.Location = new Point(801, 331);
            categoriesButton.Margin = new Padding(23, 13, 23, 13);
            categoriesButton.Name = "categoriesButton";
            categoriesButton.Size = new Size(344, 80);
            categoriesButton.TabIndex = 21;
            categoriesButton.Text = "Categories";
            categoriesButton.UseVisualStyleBackColor = false;
            categoriesButton.Click += categoriesButton_Click;
            // 
            // sellersButton
            // 
            sellersButton.BackColor = SystemColors.ButtonFace;
            sellersButton.Dock = DockStyle.Fill;
            sellersButton.Font = new Font("Segoe UI", 20F);
            sellersButton.ForeColor = Color.Black;
            sellersButton.Location = new Point(412, 437);
            sellersButton.Margin = new Padding(23, 13, 23, 13);
            sellersButton.Name = "sellersButton";
            sellersButton.Size = new Size(343, 80);
            sellersButton.TabIndex = 22;
            sellersButton.Text = "Sellers";
            sellersButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = SystemColors.ButtonFace;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(492, 652);
            button1.Margin = new Padding(23, 13, 23, 13);
            button1.Name = "button1";
            button1.Size = new Size(183, 80);
            button1.TabIndex = 24;
            button1.Text = "Check-In Check-Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += checkInButton_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ButtonFace;
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Segoe UI", 20F);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(801, 543);
            button3.Margin = new Padding(23, 13, 23, 13);
            button3.Name = "button3";
            button3.Size = new Size(344, 80);
            button3.TabIndex = 27;
            button3.Text = "Purchases";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // customersBtn
            // 
            customersBtn.BackColor = SystemColors.ButtonFace;
            customersBtn.Dock = DockStyle.Fill;
            customersBtn.Font = new Font("Segoe UI", 20F);
            customersBtn.ForeColor = Color.Black;
            customersBtn.Location = new Point(412, 543);
            customersBtn.Margin = new Padding(23, 13, 23, 13);
            customersBtn.Name = "customersBtn";
            customersBtn.Size = new Size(343, 80);
            customersBtn.TabIndex = 26;
            customersBtn.Text = "Customers";
            customersBtn.UseVisualStyleBackColor = false;
            customersBtn.Click += customersBtn_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ButtonFace;
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Segoe UI", 20F);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(23, 543);
            button4.Margin = new Padding(23, 13, 23, 13);
            button4.Name = "button4";
            button4.Size = new Size(343, 80);
            button4.TabIndex = 29;
            button4.Text = "Currency";
            button4.UseVisualStyleBackColor = false;
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
        private Button prevRButton;
        private Button dSButton;
        private Button servicesButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Button categoriesButton;
        private Button AllOrdersBtn;
        private Button SuppliersBtn;
        private Button InventoryBtn;
        private Button ProductsBtn;
        private Button promotionsButton;
        private Button sellersButton;
        private Button button1;
        private Button button3;
        private Button customersBtn;
        private Button button4;
    }
}