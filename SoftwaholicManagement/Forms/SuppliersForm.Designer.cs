namespace SM
{
    partial class SuppliersForm
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
            this.SuppFLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.ProdFLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SuppliersDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteButtonColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 51);
            this.backButton.TabIndex = 23;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SuppFLabel
            // 
            this.SuppFLabel.AutoSize = true;
            this.SuppFLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.SuppFLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.SuppFLabel.Location = new System.Drawing.Point(491, 20);
            this.SuppFLabel.Margin = new System.Windows.Forms.Padding(10, 20, 3, 0);
            this.SuppFLabel.Name = "SuppFLabel";
            this.SuppFLabel.Size = new System.Drawing.Size(280, 66);
            this.SuppFLabel.TabIndex = 29;
            this.SuppFLabel.Text = "SUPPLIERS";
            this.SuppFLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.45874F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.54126F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 51);
            this.button1.TabIndex = 26;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProdFLabel
            // 
            this.ProdFLabel.AutoSize = true;
            this.ProdFLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.ProdFLabel.ForeColor = System.Drawing.Color.Green;
            this.ProdFLabel.Location = new System.Drawing.Point(84, 20);
            this.ProdFLabel.Margin = new System.Windows.Forms.Padding(10, 20, 3, 0);
            this.ProdFLabel.Name = "ProdFLabel";
            this.ProdFLabel.Size = new System.Drawing.Size(102, 264);
            this.ProdFLabel.TabIndex = 28;
            this.ProdFLabel.Text = "PRODUCTS";
            this.ProdFLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.98266F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.01734F));
            this.tableLayoutPanel2.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SuppFLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.SuppliersDataGridView, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1269, 747);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // SuppliersDataGridView
            // 
            this.SuppliersDataGridView.AllowUserToOrderColumns = true;
            this.SuppliersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SuppliersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.SuppliersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.SuppliersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SuppliersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.SuppliersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SuppliersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierId,
            this.SupplierName,
            this.ContactInformation,
            this.supplierLocation,
            this.DeleteButtonColumn});
            this.tableLayoutPanel2.SetColumnSpan(this.SuppliersDataGridView, 2);
            this.SuppliersDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sylfaen", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SuppliersDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.SuppliersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuppliersDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.SuppliersDataGridView.IsCustomScroll = true;
            this.SuppliersDataGridView.Location = new System.Drawing.Point(21, 113);
            this.SuppliersDataGridView.Margin = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.SuppliersDataGridView.Name = "SuppliersDataGridView";
            this.SuppliersDataGridView.RowHeadersVisible = false;
            this.SuppliersDataGridView.RowHeadersWidth = 51;
            this.SuppliersDataGridView.RowTemplate.Height = 29;
            this.SuppliersDataGridView.Size = new System.Drawing.Size(1227, 614);
            this.SuppliersDataGridView.TabIndex = 30;
            this.SuppliersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SuppliersDataGridView_CellContentClick);
            // 
            // SupplierId
            // 
            this.SupplierId.HeaderText = "Supplier Id";
            this.SupplierId.MinimumWidth = 6;
            this.SupplierId.Name = "SupplierId";
            this.SupplierId.ReadOnly = true;
            this.SupplierId.Visible = false;
            // 
            // SupplierName
            // 
            this.SupplierName.HeaderText = "Name";
            this.SupplierName.MinimumWidth = 6;
            this.SupplierName.Name = "SupplierName";
            // 
            // ContactInformation
            // 
            this.ContactInformation.HeaderText = "Contact Information";
            this.ContactInformation.MinimumWidth = 6;
            this.ContactInformation.Name = "ContactInformation";
            // 
            // supplierLocation
            // 
            this.supplierLocation.HeaderText = "Location";
            this.supplierLocation.MinimumWidth = 6;
            this.supplierLocation.Name = "supplierLocation";
            // 
            // DeleteButtonColumn
            // 
            this.DeleteButtonColumn.Description = "   ";
            this.DeleteButtonColumn.HeaderText = "";
            this.DeleteButtonColumn.MinimumWidth = 6;
            this.DeleteButtonColumn.Name = "DeleteButtonColumn";
            this.DeleteButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SuppliersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1269, 747);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SuppliersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuppliersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button backButton;
        private Label SuppFLabel;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private Label ProdFLabel;
        private DoubleBufferAndCustomScrollDataGrid SuppliersDataGridView;
        private DataGridViewTextBoxColumn SupplierId;
        private DataGridViewTextBoxColumn SupplierName;
        private DataGridViewTextBoxColumn ContactInformation;
        private DataGridViewTextBoxColumn supplierLocation;
        private DataGridViewImageColumn DeleteButtonColumn;
    }
}