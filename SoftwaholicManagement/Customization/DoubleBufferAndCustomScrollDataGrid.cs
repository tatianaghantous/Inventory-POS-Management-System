
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM
{
    public class DoubleBufferAndCustomScrollDataGrid : DataGridView
    {


        private bool isCustomScroll=true;
        public bool IsCustomScroll
        {
            get { return isCustomScroll; }
            set { isCustomScroll = value; }
        }

        public DataGridViewCellEventHandler CellMouseLeaveEventHandler { get; }

        public DoubleBufferAndCustomScrollDataGrid()
        {
            DoubleBuffered = true;
            DefaultCellStyle.Font = new Font("Sylfaen", 14);
            DefaultCellStyle.ForeColor = Color.FromArgb(55, 58, 81); 
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;//kermel yaamlo wrap kell el colunns li mawjudin aal sheshe w ma btaamil delay metel all cels, w eza hattina abel, it can cause us delays bel visible = false
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//kermel taamil stretch aa kell surface  horizontally
            DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            RowTemplate.MinimumHeight = 10;
            DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
            DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;
        }

    
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (IsCustomScroll)
            {
                if (e.Delta > 0)//Scroll up
                {
                    if (FirstDisplayedScrollingRowIndex > 0)
                    {
                        FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex - 1;
                    }
                }
                else//scroll down
                {
                    if(FirstDisplayedScrollingRowIndex + 1<this.RowCount)

                    FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex + 1;
                }

            }
            else
            {
                base.OnMouseWheel(e);
            }
        }

        protected new void CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Change row color and cursor on hover
            if (e.RowIndex >= 0)
            {
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(179, 186, 200);
                this.Cursor = Cursors.Hand;
            }
        }

        protected new void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Reset row color and cursor when the mouse leaves
            if (e.RowIndex >= 0)
            {
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor = DefaultCellStyle.BackColor;
                this.Cursor = Cursors.Default;
            }
        }
    }
}
