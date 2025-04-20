using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Customization
{
    public class CustomTextBox : TextBox
    {
        private string placeholderText;
        public Color PlaceholderColor { get; set; }
        public string? PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                Invalidate();
            }
        }

        public CustomTextBox()
        {
            PlaceholderColor = Color.Gray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the placeholder text if the TextBox is empty and does not have focus
            if (string.IsNullOrEmpty(Text) && !Focused)
            {
                using (var brush = new SolidBrush(PlaceholderColor))
                {
                    e.Graphics.DrawString(PlaceholderText, Font, brush, Padding.Left, (Height - Font.Height) / 2);
                }
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }

    }
}
