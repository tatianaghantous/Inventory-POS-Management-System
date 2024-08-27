namespace SM
{
    partial class ProductsForm
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
            this.ProdFLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.categoryLabel = new SM.Customization.CustomLabel();
            this.customLabel2 = new SM.Customization.CustomLabel();
            this.customLabel3 = new SM.Customization.CustomLabel();
            this.productNameSearchTextBox = new SM.Customization.CustomTextBox();
            this.productDescSearchTextBox = new SM.Customization.CustomTextBox();
            this.productBarcodeSearchTextBox = new SM.Customization.CustomTextBox();
            this.categoryNameSearchTextBox = new SM.Customization.CustomTextBox();
            this.ProductsDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.customLabel5 = new SM.Customization.CustomLabel();
            this.customLabel4 = new SM.Customization.CustomLabel();
            this.exitLabel = new SM.Customization.CustomLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 48);
            this.backButton.TabIndex = 26;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ProdFLabel
            // 
            this.ProdFLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProdFLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ProdFLabel, 3);
            this.ProdFLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.ProdFLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.ProdFLabel.Location = new System.Drawing.Point(491, 3);
            this.ProdFLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ProdFLabel.Name = "ProdFLabel";
            this.ProdFLabel.Size = new System.Drawing.Size(287, 66);
            this.ProdFLabel.TabIndex = 28;
            this.ProdFLabel.Text = "PRODUCTS";
            this.ProdFLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProdFLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.categoryLabel, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel2, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.productNameSearchTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.productDescSearchTextBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.productBarcodeSearchTextBox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.categoryNameSearchTextBox, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.ProductsDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.customLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.exitLabel, 8, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.857497F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.432475F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.71003F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 747);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // categoryLabel
            // 
            this.categoryLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.categoryLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.categoryLabel.Location = new System.Drawing.Point(1009, 91);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(97, 26);
            this.categoryLabel.TabIndex = 42;
            this.categoryLabel.Text = "Category";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel2
            // 
            this.customLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customLabel2.AutoSize = true;
            this.customLabel2.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel2.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel2.Location = new System.Drawing.Point(731, 91);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(88, 26);
            this.customLabel2.TabIndex = 41;
            this.customLabel2.Text = "Barcode";
            this.customLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel3
            // 
            this.customLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customLabel3.AutoSize = true;
            this.customLabel3.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel3.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel3.Location = new System.Drawing.Point(432, 91);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(122, 26);
            this.customLabel3.TabIndex = 40;
            this.customLabel3.Text = "Description";
            this.customLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productNameSearchTextBox
            // 
            this.productNameSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productNameSearchTextBox.Location = new System.Drawing.Point(290, 90);
            this.productNameSearchTextBox.Name = "productNameSearchTextBox";
            this.productNameSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.productNameSearchTextBox.PlaceholderText = null;
            this.productNameSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.productNameSearchTextBox.TabIndex = 43;
            this.productNameSearchTextBox.TextChanged += new System.EventHandler(this.productNameSearchTextBox_TextChanged);
            // 
            // productDescSearchTextBox
            // 
            this.productDescSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productDescSearchTextBox.Location = new System.Drawing.Point(572, 90);
            this.productDescSearchTextBox.Name = "productDescSearchTextBox";
            this.productDescSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.productDescSearchTextBox.PlaceholderText = null;
            this.productDescSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.productDescSearchTextBox.TabIndex = 44;
            this.productDescSearchTextBox.TextChanged += new System.EventHandler(this.productDescSearchTextBox_TextChanged);
            // 
            // productBarcodeSearchTextBox
            // 
            this.productBarcodeSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productBarcodeSearchTextBox.Location = new System.Drawing.Point(854, 90);
            this.productBarcodeSearchTextBox.Name = "productBarcodeSearchTextBox";
            this.productBarcodeSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.productBarcodeSearchTextBox.PlaceholderText = null;
            this.productBarcodeSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.productBarcodeSearchTextBox.TabIndex = 45;
            this.productBarcodeSearchTextBox.TextChanged += new System.EventHandler(this.productBarcodeSearchTextBox_TextChanged);
            // 
            // categoryNameSearchTextBox
            // 
            this.categoryNameSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoryNameSearchTextBox.Location = new System.Drawing.Point(1136, 90);
            this.categoryNameSearchTextBox.Name = "categoryNameSearchTextBox";
            this.categoryNameSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.categoryNameSearchTextBox.PlaceholderText = null;
            this.categoryNameSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.categoryNameSearchTextBox.TabIndex = 46;
            this.categoryNameSearchTextBox.TextChanged += new System.EventHandler(this.CategoryNameSearchTextBox_TextChanged);
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProductsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ProductsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ProductsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProductsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.ProductsDataGridView, 9);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductsDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.ProductsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductsDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.ProductsDataGridView.IsCustomScroll = true;
            this.ProductsDataGridView.Location = new System.Drawing.Point(10, 145);
            this.ProductsDataGridView.Margin = new System.Windows.Forms.Padding(10);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.RowHeadersVisible = false;
            this.ProductsDataGridView.RowHeadersWidth = 51;
            this.ProductsDataGridView.RowTemplate.Height = 29;
            this.ProductsDataGridView.Size = new System.Drawing.Size(1249, 592);
            this.ProductsDataGridView.TabIndex = 37;
            this.ProductsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductsDataGridView_CellContentClick_1);
            // 
            // customLabel5
            // 
            this.customLabel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customLabel5.AutoSize = true;
            this.customLabel5.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel5.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel5.Location = new System.Drawing.Point(14, 91);
            this.customLabel5.Name = "customLabel5";
            this.customLabel5.Size = new System.Drawing.Size(112, 26);
            this.customLabel5.TabIndex = 38;
            this.customLabel5.Text = "Search By:";
            this.customLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel4
            // 
            this.customLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customLabel4.AutoSize = true;
            this.customLabel4.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel4.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel4.Location = new System.Drawing.Point(177, 91);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(68, 26);
            this.customLabel4.TabIndex = 39;
            this.customLabel4.Text = "Name";
            this.customLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitLabel.AutoSize = true;
            this.exitLabel.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.exitLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.exitLabel.Location = new System.Drawing.Point(1243, 0);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(23, 26);
            this.exitLabel.TabIndex = 47;
            this.exitLabel.Text = "x";
            this.exitLabel.Click += new System.EventHandler(this.exitLabel_Click);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1269, 747);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button backButton;
        private Label ProdFLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private DoubleBufferAndCustomScrollDataGrid ProductsDataGridView;
        private Customization.CustomLabel customLabel5;
        private Customization.CustomLabel customLabel4;
        private Customization.CustomLabel customLabel3;
        private Customization.CustomLabel customLabel2;
        private Customization.CustomLabel categoryLabel;
        private Customization.CustomTextBox productNameSearchTextBox;
        private Customization.CustomTextBox productDescSearchTextBox;
        private Customization.CustomTextBox productBarcodeSearchTextBox;
        private Customization.CustomTextBox categoryNameSearchTextBox;
        private Customization.CustomLabel exitLabel;
    }
}