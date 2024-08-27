namespace SM
{
    partial class UnpaidOrdersForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backButton = new System.Windows.Forms.Button();
            this.ProdFLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.clearSelectionButton = new System.Windows.Forms.Button();
            this.UnpaidOrdersDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.toggleBtn = new SM.Customization.CustomButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnpaidOrdersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ProdFLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.customerComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.clearSelectionButton, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.UnpaidOrdersDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toggleBtn, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.57895F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.473685F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.94736F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 747);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 51);
            this.backButton.TabIndex = 30;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ProdFLabel
            // 
            this.ProdFLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProdFLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ProdFLabel, 2);
            this.ProdFLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.ProdFLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.ProdFLabel.Location = new System.Drawing.Point(466, 10);
            this.ProdFLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ProdFLabel.Name = "ProdFLabel";
            this.ProdFLabel.Size = new System.Drawing.Size(336, 66);
            this.ProdFLabel.TabIndex = 29;
            this.ProdFLabel.Text = "Unpaid Orders";
            this.ProdFLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 15F);
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(3, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 33);
            this.label1.TabIndex = 31;
            this.label1.Text = "Search For Customer Name: ";
            // 
            // customerComboBox
            // 
            this.customerComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(400, 107);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(151, 28);
            this.customerComboBox.TabIndex = 34;
            this.customerComboBox.SelectedValueChanged += new System.EventHandler(this.customerComboBox_SelectedValueChanged);
            // 
            // clearSelectionButton
            // 
            this.clearSelectionButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clearSelectionButton.Font = new System.Drawing.Font("Sylfaen", 13F);
            this.clearSelectionButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.clearSelectionButton.Location = new System.Drawing.Point(637, 100);
            this.clearSelectionButton.Name = "clearSelectionButton";
            this.clearSelectionButton.Size = new System.Drawing.Size(216, 41);
            this.clearSelectionButton.TabIndex = 35;
            this.clearSelectionButton.Text = "Clear Selection";
            this.clearSelectionButton.UseVisualStyleBackColor = true;
            this.clearSelectionButton.Click += new System.EventHandler(this.clearSelectionButton_Click);
            // 
            // UnpaidOrdersDataGridView
            // 
            this.UnpaidOrdersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UnpaidOrdersDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.UnpaidOrdersDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.UnpaidOrdersDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UnpaidOrdersDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.UnpaidOrdersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.UnpaidOrdersDataGridView, 4);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sylfaen", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UnpaidOrdersDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.UnpaidOrdersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnpaidOrdersDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.UnpaidOrdersDataGridView.IsCustomScroll = true;
            this.UnpaidOrdersDataGridView.Location = new System.Drawing.Point(10, 166);
            this.UnpaidOrdersDataGridView.Margin = new System.Windows.Forms.Padding(10);
            this.UnpaidOrdersDataGridView.Name = "UnpaidOrdersDataGridView";
            this.UnpaidOrdersDataGridView.RowHeadersVisible = false;
            this.UnpaidOrdersDataGridView.RowHeadersWidth = 51;
            this.UnpaidOrdersDataGridView.RowTemplate.Height = 29;
            this.UnpaidOrdersDataGridView.Size = new System.Drawing.Size(1249, 571);
            this.UnpaidOrdersDataGridView.TabIndex = 36;
            this.UnpaidOrdersDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UnpaidOrdersDataGridView_CellContentClick);
            // 
            // toggleBtn
            // 
            this.toggleBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toggleBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.toggleBtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toggleBtn.Location = new System.Drawing.Point(1025, 98);
            this.toggleBtn.Name = "toggleBtn";
            this.toggleBtn.Size = new System.Drawing.Size(170, 46);
            this.toggleBtn.TabIndex = 37;
            this.toggleBtn.Text = "View Services";
            this.toggleBtn.UseVisualStyleBackColor = true;
            this.toggleBtn.Click += new System.EventHandler(this.toggleBtn_Click);
            // 
            // UnpaidOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1269, 747);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "UnpaidOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnpaidOrdersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label ProdFLabel;
        private Button backButton;
        private Label label1;
        private ComboBox customerComboBox;
        private Button clearSelectionButton;
        private DoubleBufferAndCustomScrollDataGrid UnpaidOrdersDataGridView;
        private Customization.CustomButton toggleBtn;
    }
}