namespace SM
{
    partial class CategoriesForm
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
            this.CategoriesDataGridView = new SM.DoubleBufferAndCustomScrollDataGrid();
            this.backButton = new System.Windows.Forms.Button();
            this.CatLabel = new System.Windows.Forms.Label();
            this.categorySearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.CategoriesDataGridView, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CatLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.categorySearchTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.FloralWhite;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.98566F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.22116F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.79318F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 747);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CategoriesDataGridView
            // 
            this.CategoriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoriesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.CategoriesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.CategoriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CategoriesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.CategoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.CategoriesDataGridView, 3);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sylfaen", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoriesDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.CategoriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoriesDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.CategoriesDataGridView.IsCustomScroll = true;
            this.CategoriesDataGridView.Location = new System.Drawing.Point(10, 153);
            this.CategoriesDataGridView.Margin = new System.Windows.Forms.Padding(10);
            this.CategoriesDataGridView.Name = "CategoriesDataGridView";
            this.CategoriesDataGridView.RowHeadersVisible = false;
            this.CategoriesDataGridView.RowHeadersWidth = 51;
            this.CategoriesDataGridView.RowTemplate.Height = 29;
            this.CategoriesDataGridView.Size = new System.Drawing.Size(1249, 584);
            this.CategoriesDataGridView.TabIndex = 37;
            this.CategoriesDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoriesDataGridView_CellContentClick);
            this.CategoriesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoriesDataGridView_CellEndEdit);
            this.CategoriesDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CategoriesDataGridView_CellFormatting);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.backButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(80, 51);
            this.backButton.TabIndex = 27;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // CatLabel
            // 
            this.CatLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CatLabel.AutoSize = true;
            this.CatLabel.Font = new System.Drawing.Font("Sylfaen", 30F);
            this.CatLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.CatLabel.Location = new System.Drawing.Point(468, 8);
            this.CatLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CatLabel.Name = "CatLabel";
            this.CatLabel.Size = new System.Drawing.Size(332, 66);
            this.CatLabel.TabIndex = 29;
            this.CatLabel.Text = "CATEGORIES";
            this.CatLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // categorySearchTextBox
            // 
            this.categorySearchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.categorySearchTextBox.Location = new System.Drawing.Point(426, 99);
            this.categorySearchTextBox.Name = "categorySearchTextBox";
            this.categorySearchTextBox.Size = new System.Drawing.Size(125, 27);
            this.categorySearchTextBox.TabIndex = 32;
            this.categorySearchTextBox.TextChanged += new System.EventHandler(this.categorySearchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 15F);
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(59, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 33);
            this.label1.TabIndex = 33;
            this.label1.Text = "Search For Category Name :";
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(81)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1269, 747);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CategoriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button backButton;
        private Label CatLabel;
        private TextBox categorySearchTextBox;
        private Label label1;
        private DoubleBufferAndCustomScrollDataGrid CategoriesDataGridView;
    }
}