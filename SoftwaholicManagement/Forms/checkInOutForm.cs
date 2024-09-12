using SMDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM;

namespace ClothingStore.UI
{
    public partial class checkInOutForm : Form
    {
        private ClothingStoreContext _dbContext;
        private DailySale? dailySale;
        public checkInOutForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;

            DateTime today = DateTime.Now.Date;
            dailySale = _dbContext.DailySales.FirstOrDefault(s => s.Date == today.ToString("yyyy-MM-dd"));
            InitializingFields(today);
            if (dailySale == null)
                fillDailySale();



        }

        private void InitializingFields(DateTime today)
        {

                dateLabel.Text = DateTime.Now.ToLongDateString();
                sellerLabel.Text = loginForm.currentUser.Username.ToString();
                if (dailySale != null)
                {
                    if (dailySale.StartingBalance != null)
                        startingBalanceTextBox.Text = dailySale.StartingBalance.ToString();
                    if (dailySale.EndBalance != null)
                        endBalanceTextBox.Text = dailySale.EndBalance.ToString();
                }

        }

        private void checkInOutForm_Load(object sender, EventArgs e)
        {

        }

        private void doneButton_Click(object sender, EventArgs e)
        {

                if (startingBalanceTextBox.Text != "")
                {
                    DateTime today = DateTime.Now.Date;

                    double startingBalance = double.Parse(startingBalanceTextBox.Text);

                    var totalSum = _dbContext.OrderSummaries
                        .Where(summary => summary.OrderDate == today.ToString("yyyy-MM-dd")) // Filter by OrderDate
                        .SelectMany(summary => summary.OrderItems) // Flatten to OrderItems
                        .Where(item => item.IsPaid == 1) // Filter by IsPaid
                        .Sum(item => item.Quantity * item.PriceUsd); // Calculate the total sum

                    var calculatedEndBalance = totalSum + startingBalance;

                        MessageBox.Show($"Your endBalance should be {calculatedEndBalance}");

                }

                    navigateToIntroForm();
                
        }

        private void fillDailySale()
        {

                using (var transaction = _dbContext.Database.BeginTransaction())
                {

                        DailySale dailySale = new DailySale
                        {
                            Date = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                            StartingBalance = 0,
                            EndBalance = 0,
                            Profit = 0,
                            TotalSales = 0,
                        };

                        if (!string.IsNullOrEmpty(startingBalanceTextBox.Text))
                        {
                            if (double.TryParse(startingBalanceTextBox.Text, out double startingBalance))
                            {
                                dailySale.StartingBalance = startingBalance;
                            }
                        }

                        if (!string.IsNullOrEmpty(endBalanceTextBox.Text))
                        {
                            if (double.TryParse(endBalanceTextBox.Text, out double endBalance))
                            {
                                dailySale.EndBalance = endBalance;
                            }
                        }

                        _dbContext.DailySales.Add(dailySale);
                        _dbContext.SaveChanges();
                        transaction.Commit();

                }
        }

        private void sbAddButton_Click(object sender, EventArgs e)
        {

                if (startingBalanceTextBox.Text != "")
                {

                    double startingBalance = double.Parse(startingBalanceTextBox.Text);
                    if (dailySale != null)
                    {
                        using (var transaction = _dbContext.Database.BeginTransaction())
                        {

                                dailySale.StartingBalance = startingBalance;
                                _dbContext.SaveChanges();
                                MessageBox.Show("ADDED SUCCESSFULLY");
                                transaction.Commit();

                        }
                    }

                }
        }


        private void ebAddbButton_Click(object sender, EventArgs e)
        {

                if (endBalanceTextBox.Text != "")
                {
                    double endBalance = double.Parse(endBalanceTextBox.Text);
                    if (dailySale != null)
                    {
                        using (var transaction = _dbContext.Database.BeginTransaction())
                        {

                                dailySale.EndBalance = endBalance;

                                _dbContext.SaveChanges();

                                MessageBox.Show("ADDED SUCCESSFULLY");
                                transaction.Commit();
                        }
                    }
                }

        }

        private void calculateButton_Click(object sender, EventArgs e)
        {

                if (loginForm.currentUser.HasPermission == 1)
                {

                    double? profit = 0;
                     string today = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    var todaysSale = _dbContext.DailySales.FirstOrDefault(s => s.Date == today);
                    if (todaysSale != null)
                    {
                        profit = todaysSale.Profit;
                    }
                    profitTextBox.Text = profit.ToString();

                }

        }

        private void checkInOutForm_Load_1(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            navigateToIntroForm();
        }
        private void navigateToIntroForm()
        {
            IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            this.Hide();
        }

        private void sellerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
