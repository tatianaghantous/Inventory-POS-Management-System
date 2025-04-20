namespace SM
{
    partial class InventoryForm
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
            this.InventoryDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.backButton = new System.Windows.Forms.Button();
            this.InvFLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.customLabel1 = new SM.Customization.CustomLabel();
            this.customLabel2 = new SM.Customization.CustomLabel();
            this.customLabel3 = new SM.Customization.CustomLabel();
            this.customLabel4 = new SM.Customization.CustomLabel();
            this.customLabel5 = new SM.Customization.CustomLabel();
            this.categoryNameSearchTextBox = new SM.Customization.CustomTextBox();
            this.productBarcodeSearchTextBox = new SM.Customization.CustomTextBox();
            this.productDescSearchTextBox = new SM.Customization.CustomTextBox();
            this.productNameSearchTextBox = new SM.Customization.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InventoryDataGridView
            // 
            this.InventoryDataGridView.AllowUserToOrderColumns = true;
            this.InventoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InventoryDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.InventoryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.InventoryDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InventoryDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.InventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.InventoryDataGridView, 9);
            this.InventoryDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sylfaen", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InventoryDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.InventoryDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InventoryDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.InventoryDataGridView.IsCustomScroll = true;
            this.InventoryDataGridView.Location = new System.Drawing.Point(21, 138);
            this.InventoryDataGridView.Margin = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.InventoryDataGridView.Name = "InventoryDataGridView";
            this.InventoryDataGridView.RowHeadersVisible = false;
            this.InventoryDataGridView.RowHeadersWidth = 51;
            this.InventoryDataGridView.RowTemplate.Height = 29;
            this.InventoryDataGridView.Size = new System.Drawing.Size(1227, 589);
            this.InventoryDataGridView.TabIndex = 7;
            this.InventoryDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InventoryDataGridView_CellContentClick);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 51);
            this.backButton.TabIndex = 24;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // InvFLabel
            // 
            this.InvFLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InvFLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.InvFLabel, 3);
            this.InvFLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.InvFLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.InvFLabel.Location = new System.Drawing.Point(475, 4);
            this.InvFLabel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.InvFLabel.Name = "InvFLabel";
            this.InvFLabel.Size = new System.Drawing.Size(318, 66);
            this.InvFLabel.TabIndex = 29;
            this.InvFLabel.Text = "INVENTORY";
            this.InvFLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.tableLayoutPanel1.Controls.Add(this.InventoryDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.InvFLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.customLabel1, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel2, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.categoryNameSearchTextBox, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.productBarcodeSearchTextBox, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.productDescSearchTextBox, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.productNameSearchTextBox, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 747);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // customLabel1
            // 
            this.customLabel1.AutoSize = true;
            this.customLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabel1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel1.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel1.Location = new System.Drawing.Point(990, 74);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(135, 44);
            this.customLabel1.TabIndex = 30;
            this.customLabel1.Text = "Category";
            this.customLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel2
            // 
            this.customLabel2.AutoSize = true;
            this.customLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabel2.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel2.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel2.Location = new System.Drawing.Point(708, 74);
            this.customLabel2.Name = "customLabel2";
            this.customLabel2.Size = new System.Drawing.Size(135, 44);
            this.customLabel2.TabIndex = 31;
            this.customLabel2.Text = "Barcode";
            this.customLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel3
            // 
            this.customLabel3.AutoSize = true;
            this.customLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabel3.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel3.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel3.Location = new System.Drawing.Point(426, 74);
            this.customLabel3.Name = "customLabel3";
            this.customLabel3.Size = new System.Drawing.Size(135, 44);
            this.customLabel3.TabIndex = 32;
            this.customLabel3.Text = "Description";
            this.customLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel4
            // 
            this.customLabel4.AutoSize = true;
            this.customLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabel4.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel4.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel4.Location = new System.Drawing.Point(144, 74);
            this.customLabel4.Name = "customLabel4";
            this.customLabel4.Size = new System.Drawing.Size(135, 44);
            this.customLabel4.TabIndex = 33;
            this.customLabel4.Text = "Name";
            this.customLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabel5
            // 
            this.customLabel5.AutoSize = true;
            this.customLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabel5.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel5.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel5.Location = new System.Drawing.Point(3, 74);
            this.customLabel5.Name = "customLabel5";
            this.customLabel5.Size = new System.Drawing.Size(135, 44);
            this.customLabel5.TabIndex = 34;
            this.customLabel5.Text = "Search By:";
            this.customLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // categoryNameSearchTextBox
            // 
            this.categoryNameSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.categoryNameSearchTextBox.Location = new System.Drawing.Point(1136, 82);
            this.categoryNameSearchTextBox.Name = "categoryNameSearchTextBox";
            this.categoryNameSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.categoryNameSearchTextBox.PlaceholderText = null;
            this.categoryNameSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.categoryNameSearchTextBox.TabIndex = 35;
            this.categoryNameSearchTextBox.TextChanged += new System.EventHandler(this.CategoryNameSearchTextBox_TextChanged);
            // 
            // productBarcodeSearchTextBox
            // 
            this.productBarcodeSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productBarcodeSearchTextBox.Location = new System.Drawing.Point(854, 82);
            this.productBarcodeSearchTextBox.Name = "productBarcodeSearchTextBox";
            this.productBarcodeSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.productBarcodeSearchTextBox.PlaceholderText = null;
            this.productBarcodeSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.productBarcodeSearchTextBox.TabIndex = 36;
            this.productBarcodeSearchTextBox.TextChanged += new System.EventHandler(this.productBarcodeSearchTextBox_TextChanged);
            // 
            // productDescSearchTextBox
            // 
            this.productDescSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productDescSearchTextBox.Location = new System.Drawing.Point(572, 82);
            this.productDescSearchTextBox.Name = "productDescSearchTextBox";
            this.productDescSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.productDescSearchTextBox.PlaceholderText = null;
            this.productDescSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.productDescSearchTextBox.TabIndex = 37;
            this.productDescSearchTextBox.TextChanged += new System.EventHandler(this.productDescSearchTextBox_TextChanged);
            // 
            // productNameSearchTextBox
            // 
            this.productNameSearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productNameSearchTextBox.Location = new System.Drawing.Point(290, 82);
            this.productNameSearchTextBox.Name = "productNameSearchTextBox";
            this.productNameSearchTextBox.PlaceholderColor = System.Drawing.Color.Gray;
            this.productNameSearchTextBox.PlaceholderText = null;
            this.productNameSearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.productNameSearchTextBox.TabIndex = 38;
            this.productNameSearchTextBox.TextChanged += new System.EventHandler(this.productNameSearchTextBox_TextChanged);
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1269, 747);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FloralWhite;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InventoryDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferAndCustomScrollDataGrid InventoryDataGridView;
        private Button backButton;
        private DataGridViewTextBoxColumn ProductBarcode;
        private DataGridViewComboBoxColumn supplierName;
        private Label InvFLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Customization.CustomLabel customLabel1;
        private Customization.CustomLabel customLabel2;
        private Customization.CustomLabel customLabel3;
        private Customization.CustomLabel customLabel4;
        private Customization.CustomLabel customLabel5;
        private Customization.CustomTextBox categoryNameSearchTextBox;
        private Customization.CustomTextBox productBarcodeSearchTextBox;
        private Customization.CustomTextBox productDescSearchTextBox;
        private Customization.CustomTextBox productNameSearchTextBox;
    }
}