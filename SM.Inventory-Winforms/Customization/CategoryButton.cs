using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Customization
{
    public class CategoryButton : Button
    {
        public bool DisplayOnPOS { get; set; }
        public bool IsSelected { get; set; } = false;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (DisplayOnPOS || IsSelected)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Gray)))
                {
                    pevent.Graphics.FillRectangle(brush, 0, 0, this.Width, this.Height);
                }

                using (Font font = new Font("Arial", 12, FontStyle.Bold))
                {
                    TextRenderer.DrawText(pevent.Graphics, "✔", font, new Point(5, 5), Color.White);
                }
            }
        }

        public void ToggleSelection()
        {
            IsSelected = !IsSelected;
            DisplayOnPOS = !DisplayOnPOS;
            this.Invalidate(); // Forces the control to be redrawn
        }
    }

}
