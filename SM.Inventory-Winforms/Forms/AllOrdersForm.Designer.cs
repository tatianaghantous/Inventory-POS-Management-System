namespace SM
{
    partial class AllOrdersForm
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
            this.AllOrdersDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.backButton = new System.Windows.Forms.Button();
            this.StoreNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.customLabel1 = new SM.Customization.CustomLabel();
            this.ViewServicesBtn = new SM.Customization.CustomButton();
            this.viewOrdersBtn = new SM.Customization.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.AllOrdersDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllOrdersDataGridView
            // 
            this.AllOrdersDataGridView.AllowUserToOrderColumns = true;
            this.AllOrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AllOrdersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.AllOrdersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.AllOrdersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AllOrdersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.AllOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.AllOrdersDataGridView, 4);
            this.AllOrdersDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sylfaen", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AllOrdersDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.AllOrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllOrdersDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.AllOrdersDataGridView.IsCustomScroll = true;
            this.AllOrdersDataGridView.Location = new System.Drawing.Point(21, 183);
            this.AllOrdersDataGridView.Margin = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.AllOrdersDataGridView.Name = "AllOrdersDataGridView";
            this.AllOrdersDataGridView.RowHeadersVisible = false;
            this.AllOrdersDataGridView.RowHeadersWidth = 51;
            this.AllOrdersDataGridView.RowTemplate.Height = 29;
            this.AllOrdersDataGridView.Size = new System.Drawing.Size(1267, 544);
            this.AllOrdersDataGridView.TabIndex = 7;
            this.AllOrdersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllOrdersDataGridView_CellContentClick);
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
            // StoreNameLabel
            // 
            this.StoreNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StoreNameLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.StoreNameLabel, 2);
            this.StoreNameLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.StoreNameLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.StoreNameLabel.Location = new System.Drawing.Point(494, 21);
            this.StoreNameLabel.Margin = new System.Windows.Forms.Padding(10, 20, 3, 0);
            this.StoreNameLabel.Name = "StoreNameLabel";
            this.StoreNameLabel.Size = new System.Drawing.Size(326, 66);
            this.StoreNameLabel.TabIndex = 29;
            this.StoreNameLabel.Text = "ALL ORDERS";
            this.StoreNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StoreNameLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AllOrdersDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.datePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.customLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ViewServicesBtn, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.viewOrdersBtn, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1309, 747);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // datePicker
            // 
            this.datePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datePicker.Location = new System.Drawing.Point(330, 133);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(250, 27);
            this.datePicker.TabIndex = 30;
            // 
            // customLabel1
            // 
            this.customLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.customLabel1.AutoSize = true;
            this.customLabel1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold);
            this.customLabel1.ForeColor = System.Drawing.Color.FloralWhite;
            this.customLabel1.Location = new System.Drawing.Point(162, 137);
            this.customLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 30, 0);
            this.customLabel1.Name = "customLabel1";
            this.customLabel1.Size = new System.Drawing.Size(135, 26);
            this.customLabel1.TabIndex = 31;
            this.customLabel1.Text = "Choose Date:";
            // 
            // ViewServicesBtn
            // 
            this.ViewServicesBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ViewServicesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ViewServicesBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ViewServicesBtn.Location = new System.Drawing.Point(660, 114);
            this.ViewServicesBtn.Name = "ViewServicesBtn";
            this.ViewServicesBtn.Size = new System.Drawing.Size(314, 46);
            this.ViewServicesBtn.TabIndex = 32;
            this.ViewServicesBtn.Text = "View Services";
            this.ViewServicesBtn.UseVisualStyleBackColor = true;
            this.ViewServicesBtn.Click += new System.EventHandler(this.ViewServicesBtn_Click);
            // 
            // viewOrdersBtn
            // 
            this.viewOrdersBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.viewOrdersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.viewOrdersBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.viewOrdersBtn.Location = new System.Drawing.Point(988, 114);
            this.viewOrdersBtn.Name = "viewOrdersBtn";
            this.viewOrdersBtn.Size = new System.Drawing.Size(314, 46);
            this.viewOrdersBtn.TabIndex = 33;
            this.viewOrdersBtn.Text = "View Orders";
            this.viewOrdersBtn.UseVisualStyleBackColor = true;
            this.viewOrdersBtn.Click += new System.EventHandler(this.viewOrdersBtn_Click);
            // 
            // AllOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1309, 747);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AllOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AllOrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AllOrdersDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferAndCustomScrollDataGrid AllOrdersDataGridView;
        private Button backButton;
        private Label StoreNameLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn OrderItemId;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn SellerName;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn OrderDateTime;
        private DataGridViewTextBoxColumn TotalInUSD;
        private DataGridViewImageColumn DeleteButtonColumn;
        private DateTimePicker datePicker;
        private Customization.CustomLabel customLabel1;
        private Customization.CustomButton ViewServicesBtn;
        private Customization.CustomButton viewOrdersBtn;
    }
}