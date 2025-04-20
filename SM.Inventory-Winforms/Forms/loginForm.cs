using System.Security.Principal;
using SM.DataLayer.Models;
using SM;
using Microsoft.EntityFrameworkCore;

namespace SM
{
    public partial class loginForm : Form
    {
        private ClothingStoreContext _dbContext;
        public static Account currentUser = new Account();
        public loginForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            passwordTextBox.PasswordChar = '*';
        }

        public void navigateToIntroForm()
        {
            IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Account user = _dbContext.Accounts
                .FirstOrDefault(a => a.Username.ToLower() == usernameTextBox.Text.ToLower()
                                     && a.Password.ToLower() == passwordTextBox.Text.ToLower());

            if (user == null)
                MessageBox.Show("Invalid Username or Password");
            else
            {
                navigateToIntroForm();
                currentUser = user;
                Program.UpdateMyApp();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void storeNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}