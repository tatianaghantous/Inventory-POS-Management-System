using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace SM.Customization
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            this.ForeColor = Color.FloralWhite;

            this.Font = new Font("Sylfaen", 12, FontStyle.Bold);

            this.Anchor = AnchorStyles.None;
        }
            public CustomLabel(string text)
        {
            this.ForeColor = Color.FloralWhite;

            this.Text = text;

            this.Font = new Font("Sylfaen", 12, FontStyle.Bold);

            this.Anchor = AnchorStyles.None;
        }
        public void SetColumnSpan(int span)
        {
            // Set the column span
            if (this.Parent != null && this.Parent is TableLayoutPanel)
            {
                TableLayoutPanelCellPosition currentPosition = ((TableLayoutPanel)this.Parent).GetCellPosition(this);
                TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)this.Parent;
                tableLayoutPanel.SetColumnSpan(this, span);
            }
        }


    }
}
