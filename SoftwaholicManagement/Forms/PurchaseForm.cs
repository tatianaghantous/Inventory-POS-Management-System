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
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();

            tableLayoutPanel2.Margin = new Padding(5);

            this.Load += (sender, e) => AdjustTableLayoutPanelSize(tableLayoutPanel4);
            this.Load += (sender, e) => AdjustTableLayoutPanelSize(tableLayoutPanel2);
            this.Load += (sender, e) => AdjustTableLayoutPanelSize(tableLayoutPanel3);
            this.Load += (sender, e) => AdjustTableLayoutPanelSize(tableLayoutPanel5);
            this.Load += (sender, e) => AdjustDgv();

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Adjust the size whenever the form resizes
            AdjustTableLayoutPanelSize(tableLayoutPanel4);
            AdjustTableLayoutPanelSize(tableLayoutPanel2);
            AdjustTableLayoutPanelSize(tableLayoutPanel3);
            AdjustTableLayoutPanelSize(tableLayoutPanel5);
            AdjustDgv();
        }
        private void AdjustTableLayoutPanelSize(TableLayoutPanel tableLayoutPanel)
        {
            // Assuming shadowPanel and tbl1 have already been created and added to the form

            // Margin around tbl1 inside shadowPanel, set as needed
            int margin = 4; // This margin will act as the "shadow"

            tableLayoutPanel.Location = new Point(margin, margin);
            // Set the size of tbl1 to be smaller than shadowPanel by the margin on all sides
            tableLayoutPanel.Size = new Size(panel1.Width - 2 * margin, panel1.Height - 2 * margin);
            tableLayoutPanel.Anchor = AnchorStyles.None;
            // Optionally, if you need to refresh or redraw the panel to see changes
            tableLayoutPanel.Refresh();
            panel1.Refresh();
        }
        private void AdjustDgv()
        {
            // Assuming shadowPanel and tbl1 have already been created and added to the form

            // Margin around tbl1 inside shadowPanel, set as needed
            int margin = 4; // This margin will act as the "shadow"

            doubleBufferAndCustomScrollDataGrid1.Location = new Point(margin, margin);
            // Set the size of tbl1 to be smaller than shadowPanel by the margin on all sides
            doubleBufferAndCustomScrollDataGrid1.Size = new Size(panel4.Width - 2 * margin, panel4.Height - 2 * margin);
            doubleBufferAndCustomScrollDataGrid1.Anchor = AnchorStyles.None;
            // Optionally, if you need to refresh or redraw the panel to see changes
            doubleBufferAndCustomScrollDataGrid1.Refresh();
            panel1.Refresh();
        }
        // You should call this method after initializing your form or when resizing the form, etc.

        private void customLabel9_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel2.Margin = new Padding(5);
            tableLayoutPanel3.Margin = new Padding(5);
            tableLayoutPanel4.Margin = new Padding(5);
            tableLayoutPanel5.Margin = new Padding(5);
            doubleBufferAndCustomScrollDataGrid1.Margin = new Padding(5);

        }


        private void customLabel3_Click(object sender, EventArgs e)
        {

        }

        private void customLabel5_Click(object sender, EventArgs e)
        {

        }

        private void customLabel15_Click(object sender, EventArgs e)
        {

        }

        private void customLabel16_Click(object sender, EventArgs e)
        {

        }

        private void customLabel2_Click(object sender, EventArgs e)
        {

        }

        private void customLabel21_Click(object sender, EventArgs e)
        {

        }

        private void customLabel4_Click(object sender, EventArgs e)
        {

        }

        private void customLabel11_Click(object sender, EventArgs e)
        {

        }

        private void customLabel17_Click(object sender, EventArgs e)
        {

        }

        private void customLabel7_Click(object sender, EventArgs e)
        {

        }

        private void customLabel8_Click(object sender, EventArgs e)
        {

        }

        private void customLabel12_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customLabel18_Click(object sender, EventArgs e)
        {

        }

        private void customLabel19_Click(object sender, EventArgs e)
        {

        }

        private void customLabel20_Click(object sender, EventArgs e)
        {

        }

        private void customLabel22_Click(object sender, EventArgs e)
        {

        }

        private void customLabel23_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void doubleBufferAndCustomScrollDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
