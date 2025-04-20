using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Common_Functions;
using SM.Customization;
using SM.DataLayer.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SM
{
    public partial class ServicesForm : Form
    {
        ClothingStoreContext _dbContext;

        public enum MyEnum
        {
            CableVision,
            AlfaCard,
            AlfaDays,
            AlfaDollars,
            MtcCard,
            MtcDays,
            MtcDollars,
            Other
        }
        LabelAndTextBoxUC serviceDescription;
        LabelAndTextBoxUC serviceDuration;

        public ServicesForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            Service newService = new Service();
            double? serviceCost = ParseAndValidateDecimal(serviceCostTextBox.Text);
            if (serviceCost == null)
                return;
            newService.ServiceCost = (double)serviceCost;

            double? serviceSP = ParseAndValidateDecimal(serviceSPTextBox.Text);
            if (serviceSP == null)
                return;
            newService.ServiceSellingPrice = (double)serviceSP;

            newService.ServiceType = serviceTypeCb.SelectedItem.ToString();
            newService.ServiceProfit = serviceSP - serviceCost;
            newService.ServiceDate = DateTime.Today.ToString();
            if (notPaidCheckBox != null && notPaidCheckBox.Checked)
            {
                newService.IsPaid = 0;
            }
            newService.ServiceDuration = serviceDurationTxtBox.Text;
            newService.Description = serviceDescriptionTxtBox.Text;
            _dbContext.Services.Add(newService);
            _dbContext.SaveChanges();
            MessageBox.Show("Service Added");
            GeneralFunctions.NavigateToIntroForm(_dbContext, this);
            serviceCostTextBox.Text = "";
            serviceSPTextBox.Text = "";
            serviceDurationTxtBox.Text = "";
            serviceDescriptionTxtBox.Text = "";
            notPaidCheckBox.Checked = false;
        }
        public double? ParseAndValidateDecimal(string input)
        {
            if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                MessageBox.Show("Invalid decimal format. Please enter a valid number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            else
            {
                return result;
            }
        }

        private void ServicesForm_Load(object sender, EventArgs e)
        {


            serviceTypeCb.DataSource = Enum.GetValues(typeof(MyEnum));


        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GeneralFunctions.NavigateToIntroForm(_dbContext, this);
        }
    }
}
