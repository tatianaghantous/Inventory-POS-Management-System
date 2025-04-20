using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SM
{
    public partial class SearchByUC : UserControl
    {
        public SearchByUC()
        {
            InitializeComponent();
            InitializingChooseFilterComboBox();

        }

        private void InitializingChooseFilterComboBox()
        {
            chooseFilterCb.Items.Add("Select an option...");

            chooseFilterCb.SelectedIndex = 0;

            chooseFilterCb.SelectedIndexChanged += (sender, e) =>
            {
                if (chooseFilterCb.SelectedIndex == 0)
                {
                    chooseFilterCb.SelectedIndex = -1;
                }
            };
        }
        private void chooseFilterCb_SelectedIndexChanged(object sender, EventArgs e)
        {

            //LabelAndTextBoxUC labelAndTextBoxUC = new LabelAndTextBoxUC();

            //// Set specific arguments based on the selected option
            //switch (chooseFilterCb.SelectedIndex)
            //{
            //    case 0: // Option 1
            //        labelAndTextBoxUC.customLabel.Text = "Label for Option 1";
            //        labelAndTextBoxUC.customTextBox.PlaceholderText = "Placeholder for Option 1";
            //        break;
            //    case 1: // Option 2
            //        labelAndTextBoxUC.customLabel.Text = "Label for Option 2";
            //        labelAndTextBoxUC.customTextBox.PlaceholderText = "Placeholder for Option 2";
            //        break;
            //}


            //tableLayoutPanel1.Controls.Add(labelAndTextBoxUC);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
