using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Customization;

namespace SM
{
    public partial class LabelAndTextBoxUC : UserControl
    {
        public CustomLabel customLabel;
        public CustomTextBox customTextBox; // Removed nullable annotation

        public LabelAndTextBoxUC(string customLabelText)
        {
            InitializeComponent();

            customLabel = new CustomLabel(customLabelText); // Initialize customLabel
            customTextBox = new CustomTextBox(); // Initialize customTextBox
            customTextBox.PlaceholderText = "Enter your text here...";
            customTextBox.Size = new Size(200, 30);
            tableLayoutPanel1.Controls.Add(customLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(customTextBox, 0, 1);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Implement painting logic if needed
        }
    }

}
