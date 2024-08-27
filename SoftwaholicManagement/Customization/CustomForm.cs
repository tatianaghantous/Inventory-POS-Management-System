using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Customization
{
    public class CustomForm : Form
    {
        public CustomForm()
        {
            this.BackColor = Color.FromArgb(255, 209, 184, 224);
            this.StartPosition = FormStartPosition.CenterScreen;

        }
    }
}
