namespace SM
{
    partial class NewOrderForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backButton = new System.Windows.Forms.Button();
            this.scannedBarcode = new System.Windows.Forms.TextBox();
            this.NewOrderDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.totalAfterDiscountTxtBox = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalAfterDiscountlabel = new System.Windows.Forms.Label();
            this.ConfirmOrderButton = new System.Windows.Forms.Button();
            this.newOrderTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.notPaidCheckBox = new System.Windows.Forms.CheckBox();
            this.customLabel1 = new SM.Customization.CustomLabel();
            this.customLabel2 = new SM.Customization.CustomLabel();
            this.customTextBox2 = new SM.Customization.CustomTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.customLabel4 = new SM.Customization.CustomLabel();
            this.editCategoriesButton = new SM.Customization.CustomButton();
            this.sellerNameLabel = new SM.Customization.CustomLabel();
            this.productBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productSellingUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.NewOrderDataGridView)).BeginInit();
            this.newOrderTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 51);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // scannedBarcode
            // 
            this.scannedBarcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scannedBarcode.Location = new System.Drawing.Point(14, 134);
            this.scannedBarcode.Margin = new System.Windows.Forms.Padding(0);
            this.scannedBarcode.Name = "scannedBarcode";
            this.scannedBarcode.Size = new System.Drawing.Size(190, 27);
            this.scannedBarcode.TabIndex = 4;
            this.scannedBarcode.TextChanged += new System.EventHandler(this.scannedBarcode_TextChanged_1);
            // 
            // NewOrderDataGridView
            // 
            this.NewOrderDataGridView.AllowUserToAddRows = false;
            this.NewOrderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NewOrderDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.NewOrderDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.NewOrderDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewOrderDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.NewOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newOrderTableLayoutPanel.SetColumnSpan(this.NewOrderDataGridView, 3);
            this.NewOrderDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sylfaen", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.NewOrderDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.NewOrderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewOrderDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.NewOrderDataGridView.IsCustomScroll = true;
            this.NewOrderDataGridView.Location = new System.Drawing.Point(11, 189);
            this.NewOrderDataGridView.Margin = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.NewOrderDataGridView.Name = "NewOrderDataGridView";
            this.NewOrderDataGridView.RowHeadersVisible = false;
            this.NewOrderDataGridView.RowHeadersWidth = 51;
            this.NewOrderDataGridView.RowTemplate.Height = 29;
            this.NewOrderDataGridView.Size = new System.Drawing.Size(632, 429);
            this.NewOrderDataGridView.TabIndex = 5;
            this.NewOrderDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NewOrderDataGridView_CellContentClick);
            // 
            // dateTextBox
            // 
            this.dateTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newOrderTableLayoutPanel.SetColumnSpan(this.dateTextBox, 2);
            this.dateTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dateTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTextBox.Location = new System.Drawing.Point(965, 15);
            this.dateTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(250, 30);
            this.dateTextBox.TabIndex = 6;
            this.dateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerNameTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.customerNameTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customerNameTextBox.Location = new System.Drawing.Point(436, 15);
            this.customerNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(217, 30);
            this.customerNameTextBox.TabIndex = 9;
            this.customerNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalTextBox
            // 
            this.totalTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.totalTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.totalTextBox.Location = new System.Drawing.Point(1119, 644);
            this.totalTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(164, 30);
            this.totalTextBox.TabIndex = 11;
            // 
            // totalAfterDiscountTxtBox
            // 
            this.totalAfterDiscountTxtBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalAfterDiscountTxtBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.totalAfterDiscountTxtBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.totalAfterDiscountTxtBox.Location = new System.Drawing.Point(1119, 702);
            this.totalAfterDiscountTxtBox.Margin = new System.Windows.Forms.Padding(6, 7, 3, 7);
            this.totalAfterDiscountTxtBox.Name = "totalAfterDiscountTxtBox";
            this.totalAfterDiscountTxtBox.Size = new System.Drawing.Size(164, 30);
            this.totalAfterDiscountTxtBox.TabIndex = 12;
            this.totalAfterDiscountTxtBox.TextChanged += new System.EventHandler(this.totalAfterDiscountTxtBox_TextChanged);
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Sylfaen", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.totalLabel.Location = new System.Drawing.Point(1018, 644);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(3);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(69, 29);
            this.totalLabel.TabIndex = 13;
            this.totalLabel.Text = "Total";
            // 
            // totalAfterDiscountlabel
            // 
            this.totalAfterDiscountlabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.totalAfterDiscountlabel.AutoSize = true;
            this.totalAfterDiscountlabel.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAfterDiscountlabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.totalAfterDiscountlabel.Location = new System.Drawing.Point(879, 704);
            this.totalAfterDiscountlabel.Margin = new System.Windows.Forms.Padding(3);
            this.totalAfterDiscountlabel.Name = "totalAfterDiscountlabel";
            this.totalAfterDiscountlabel.Size = new System.Drawing.Size(208, 26);
            this.totalAfterDiscountlabel.TabIndex = 14;
            this.totalAfterDiscountlabel.Text = "Total After Discount";
            // 
            // ConfirmOrderButton
            // 
            this.ConfirmOrderButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newOrderTableLayoutPanel.SetColumnSpan(this.ConfirmOrderButton, 2);
            this.ConfirmOrderButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.ConfirmOrderButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ConfirmOrderButton.Location = new System.Drawing.Point(558, 662);
            this.ConfirmOrderButton.Margin = new System.Windows.Forms.Padding(0);
            this.ConfirmOrderButton.Name = "ConfirmOrderButton";
            this.newOrderTableLayoutPanel.SetRowSpan(this.ConfirmOrderButton, 2);
            this.ConfirmOrderButton.Size = new System.Drawing.Size(191, 53);
            this.ConfirmOrderButton.TabIndex = 15;
            this.ConfirmOrderButton.Text = "Confirm Order";
            this.ConfirmOrderButton.UseVisualStyleBackColor = true;
            this.ConfirmOrderButton.Click += new System.EventHandler(this.ConfirmOrderButton_Click);
            // 
            // newOrderTableLayoutPanel
            // 
            this.newOrderTableLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.newOrderTableLayoutPanel.ColumnCount = 6;
            this.newOrderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.newOrderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.newOrderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.newOrderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.newOrderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.newOrderTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.newOrderTableLayoutPanel.Controls.Add(this.backButton, 0, 0);
            this.newOrderTableLayoutPanel.Controls.Add(this.ConfirmOrderButton, 2, 4);
            this.newOrderTableLayoutPanel.Controls.Add(this.notPaidCheckBox, 0, 4);
            this.newOrderTableLayoutPanel.Controls.Add(this.NewOrderDataGridView, 0, 3);
            this.newOrderTableLayoutPanel.Controls.Add(this.scannedBarcode, 0, 2);
            this.newOrderTableLayoutPanel.Controls.Add(this.customLabel1, 1, 1);
            this.newOrderTableLayoutPanel.Controls.Add(this.customLabel2, 1, 0);
            this.newOrderTableLayoutPanel.Controls.Add(this.customTextBox2, 5, 1);
            this.newOrderTableLayoutPanel.Controls.Add(this.customerNameTextBox, 2, 0);
            this.newOrderTableLayoutPanel.Controls.Add(this.button1, 3, 0);
            this.newOrderTableLayoutPanel.Controls.Add(this.customLabel4, 4, 1);
            this.newOrderTableLayoutPanel.Controls.Add(this.dateTextBox, 4, 0);
            this.newOrderTableLayoutPanel.Controls.Add(this.totalTextBox, 5, 4);
            this.newOrderTableLayoutPanel.Controls.Add(this.totalAfterDiscountTxtBox, 5, 5);
            this.newOrderTableLayoutPanel.Controls.Add(this.totalLabel, 4, 4);
            this.newOrderTableLayoutPanel.Controls.Add(this.totalAfterDiscountlabel, 4, 5);
            this.newOrderTableLayoutPanel.Controls.Add(this.editCategoriesButton, 3, 2);
            this.newOrderTableLayoutPanel.Controls.Add(this.sellerNameLabel, 2, 1);
            this.newOrderTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newOrderTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.newOrderTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newOrderTableLayoutPanel.Name = "newOrderTableLayoutPanel";
            this.newOrderTableLayoutPanel.RowCount = 6;
            this.newOrderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13195F));
            this.newOrderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.13195F));
            this.newOrderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.511655F));
            this.newOrderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.98963F));
            this.newOrderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.617404F));
            this.newOrderTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.617404F));
            this.newOrderTableLayoutPanel.Size = new System.Drawing.Size(1309, 747);
            this.newOrderTableLayoutPanel.TabIndex = 16;
            // 
            // notPaidCheckBox
            // 
            this.notPaidCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notPaidCheckBox.AutoSize = true;
            this.notPaidCheckBox.Font = new System.Drawing.Font("Sylfaen", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notPaidCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.notPaidCheckBox.Location = new System.Drawing.Point(44, 642);
            this.notPaidCheckBox.Name = "notPaidCheckBox";
            this.notPaidCheckBox.Size = new System.Drawing.Size(129, 33);
            this.notPaidCheckBox.TabIndex = 16;
            this.notPaidCheckBox.Text = "Not Paid";
            this.notPaidCheckBox.UseVisualStyleBackColor = true;
            // 
            // customLabel1
            // 
            this.customLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.customLabel1.AutoSize = true;
            this.customLabel1.BackColor = System.Drawing.Color.Transparent;
            this.customLabel1.Font = new System.Drawing.Font("Sylfaen", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customLabel1.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel1.Location = new System.Drawing.Point(331, 67);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(102, 46);
            this.customLabel1.TabIndex = 20;
            this.customLabel1.Text = "Seller";
            // 
            // customLabel2
            // 
            this.customLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("Sylfaen", 21F);
            this.customLabel2.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel2.Location = new System.Drawing.Point(270, 7);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(163, 46);
            this.customLabel2.TabIndex = 23;
            this.customLabel2.Text = "Customer";
            // 
            // customTextBox2
            // 
            this.customTextBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customTextBox2.Location = new System.Drawing.Point(1104, 76);
            this.customTextBox2.Name = "customTextBox2";
            this.customTextBox2.PlaceholderColor = System.Drawing.Color.Gray;
            this.customTextBox2.PlaceholderText = null;
            this.customTextBox2.Size = new System.Drawing.Size(190, 27);
            this.customTextBox2.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(658, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 47);
            this.button1.TabIndex = 18;
            this.button1.Text = "Choose Customer";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // customLabel4
            // 
            this.customLabel4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.customLabel4.AutoSize = true;
            this.customLabel4.Font = new System.Drawing.Font("Sylfaen", 21F);
            this.customLabel4.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel4.Location = new System.Drawing.Point(1000, 67);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(87, 46);
            this.customLabel4.TabIndex = 25;
            this.customLabel4.Text = "Rate";
            // 
            // editCategoriesButton
            // 
            this.editCategoriesButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.editCategoriesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.editCategoriesButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.editCategoriesButton.Location = new System.Drawing.Point(658, 126);
            this.editCategoriesButton.Name = "editCategoriesButton";
            this.editCategoriesButton.Size = new System.Drawing.Size(210, 47);
            this.editCategoriesButton.TabIndex = 26;
            this.editCategoriesButton.Text = "Edit Categories";
            this.editCategoriesButton.UseVisualStyleBackColor = true;
            this.editCategoriesButton.Click += new System.EventHandler(this.editCategoriesButton_Click);
            // 
            // sellerNameLabel
            // 
            this.sellerNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sellerNameLabel.AutoSize = true;
            this.sellerNameLabel.Font = new System.Drawing.Font("Sylfaen", 20F, System.Drawing.FontStyle.Bold);
            this.sellerNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(184)))), ((int)(((byte)(224)))));
            this.sellerNameLabel.Location = new System.Drawing.Point(448, 68);
            this.sellerNameLabel.Name = "sellerNameLabel";
            this.sellerNameLabel.Size = new System.Drawing.Size(193, 44);
            this.sellerNameLabel.TabIndex = 27;
            this.sellerNameLabel.Text = "SellerName";
            // 
            // productBarcode
            // 
            this.productBarcode.HeaderText = "Barcode";
            this.productBarcode.MinimumWidth = 6;
            this.productBarcode.Name = "productBarcode";
            this.productBarcode.Width = 79;
            // 
            // productName
            // 
            this.productName.HeaderText = "Product Name";
            this.productName.MinimumWidth = 6;
            this.productName.Name = "productName";
            this.productName.Width = 79;
            // 
            // productSize
            // 
            this.productSize.HeaderText = "Size";
            this.productSize.MinimumWidth = 6;
            this.productSize.Name = "productSize";
            this.productSize.Width = 79;
            // 
            // productColor
            // 
            this.productColor.HeaderText = "Color";
            this.productColor.MinimumWidth = 6;
            this.productColor.Name = "productColor";
            this.productColor.Width = 79;
            // 
            // productQuantity
            // 
            this.productQuantity.HeaderText = "Quantity";
            this.productQuantity.MinimumWidth = 6;
            this.productQuantity.Name = "productQuantity";
            this.productQuantity.Width = 79;
            // 
            // productSellingUnitPrice
            // 
            this.productSellingUnitPrice.HeaderText = "Unit Price";
            this.productSellingUnitPrice.MinimumWidth = 6;
            this.productSellingUnitPrice.Name = "productSellingUnitPrice";
            this.productSellingUnitPrice.Width = 79;
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1309, 747);
            this.Controls.Add(this.newOrderTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "NewOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.NewOrderDataGridView)).EndInit();
            this.newOrderTableLayoutPanel.ResumeLayout(false);
            this.newOrderTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button backButton;
        private TextBox scannedBarcode;
        private DoubleBufferAndCustomScrollDataGrid NewOrderDataGridView;
        private TextBox dateTextBox;
        private TextBox customerNameTextBox;
        private TextBox totalTextBox;
        private TextBox totalAfterDiscountTxtBox;
        private Label totalLabel;
        private Label totalAfterDiscountlabel;
        private Button ConfirmOrderButton;
        private TableLayoutPanel newOrderTableLayoutPanel;
        private CheckBox notPaidCheckBox;
        private Button button1;
        private Customization.CustomLabel customLabel1;
        private Customization.CustomLabel customLabel2;
        private Customization.CustomTextBox customTextBox2;
        private Customization.CustomLabel customLabel4;
        private Customization.CustomButton editCategoriesButton;
        private Customization.CustomLabel sellerNameLabel;
        private DataGridViewTextBoxColumn productBarcode;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn productSize;
        private DataGridViewTextBoxColumn productColor;
        private DataGridViewTextBoxColumn productQuantity;
        private DataGridViewTextBoxColumn productSellingUnitPrice;
    }
}