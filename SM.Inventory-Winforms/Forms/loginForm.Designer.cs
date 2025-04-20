namespace SM
{
    partial class loginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            storeNameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            UserNameLabel = new Label();
            passwordLabel = new Label();
            loginButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // storeNameLabel
            // 
            storeNameLabel.Anchor = AnchorStyles.None;
            storeNameLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(storeNameLabel, 2);
            storeNameLabel.Font = new Font("Microsoft Sans Serif", 30F);
            storeNameLabel.ForeColor = Color.FloralWhite;
            storeNameLabel.Location = new Point(219, 76);
            storeNameLabel.Margin = new Padding(34, 27, 34, 27);
            storeNameLabel.Name = "storeNameLabel";
            storeNameLabel.Size = new Size(691, 58);
            storeNameLabel.TabIndex = 5;
            storeNameLabel.Text = "Inventory Managment System";
            storeNameLabel.Click += storeNameLabel_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.None;
            usernameTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            usernameTextBox.ForeColor = SystemColors.ControlDarkDark;
            usernameTextBox.Location = new Point(650, 253);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(223, 30);
            usernameTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.None;
            passwordTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            passwordTextBox.ForeColor = SystemColors.ControlDarkDark;
            passwordTextBox.Location = new Point(650, 368);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(223, 30);
            passwordTextBox.TabIndex = 7;
            // 
            // UserNameLabel
            // 
            UserNameLabel.Anchor = AnchorStyles.Right;
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            UserNameLabel.ForeColor = Color.FloralWhite;
            UserNameLabel.Location = new Point(263, 252);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(128, 32);
            UserNameLabel.TabIndex = 8;
            UserNameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.Anchor = AnchorStyles.Right;
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            passwordLabel.ForeColor = Color.FloralWhite;
            passwordLabel.Location = new Point(269, 367);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(122, 32);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Password";
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.SetColumnSpan(loginButton, 2);
            loginButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            loginButton.ForeColor = Color.Green;
            loginButton.Location = new Point(411, 494);
            loginButton.Margin = new Padding(411, 53, 411, 53);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(307, 59);
            loginButton.TabIndex = 11;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.88372F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.11628F));
            tableLayoutPanel1.Controls.Add(storeNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(UserNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(passwordLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(usernameTextBox, 1, 1);
            tableLayoutPanel1.Controls.Add(passwordTextBox, 1, 2);
            tableLayoutPanel1.Controls.Add(loginButton, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 32.38342F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.61658F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.61658F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 32.38342F));
            tableLayoutPanel1.Size = new Size(1130, 653);
            tableLayoutPanel1.TabIndex = 12;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // loginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(55, 58, 81);
            ClientSize = new Size(1130, 653);
            Controls.Add(tableLayoutPanel1);
            Name = "loginForm";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private Label storeNameLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label UserNameLabel;
        private Label passwordLabel;
        private Button loginButton;
        private TableLayoutPanel tableLayoutPanel1;
    }
}