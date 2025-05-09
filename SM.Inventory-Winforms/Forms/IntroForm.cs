﻿using ClothingStore.UI;
using Microsoft.EntityFrameworkCore;
using SM.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.DataLayer.Models;

namespace SM
{
    public partial class IntroForm : Form
    {
        private ClothingStoreContext _dbContext;
        public static ProductsForm cachedProductsForm;
        private NewOrderForm cachedNewOrderForm;
        private ReturnsForm cachedReturnsForm;
        private checkInOutForm cachedCheckInOutForm;
        private loginForm cachedLoginForm;
        public static SuppliersForm cachedSuppliersForm;
        public static CategoriesForm cachedCategoriesForm;
        public static AllOrdersForm cachedAllOrdersForm;
        public static InventoryForm cachedInventoryForm;
        public static UnpaidOrdersForm cachedUnpaidOrdersForm;
        public static CustomersForm cachedCustomersForm;
        public static ServicesForm cachedServicesForm;

        public IntroForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        public static Form ShowForm<T>(T cachedForm, Func<T> createForm) where T : Form
        {          
            if(cachedForm == null || cachedForm.IsDisposed)
            {
                cachedForm = createForm();
                cachedForm.FormClosing += (sender, args) =>
                {
                    args.Cancel = true;
                    cachedForm.Hide();
                };
            }

            if (!cachedForm.Visible)
            {
                cachedForm.Show();
            }
            else
            {
                cachedForm.BringToFront();
            }

            return cachedForm;
        }

        private void IntroForm1_Load(object sender, EventArgs e)
        {

        }

        private void StoreNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void NewOrderBtn_Click(object sender, EventArgs e)
        {
            cachedNewOrderForm = ShowForm(cachedNewOrderForm, () => new NewOrderForm(_dbContext)) as NewOrderForm;
            this.Hide();
            cachedNewOrderForm.setFocusToTextBox();
        }

        private void ReturnsBtn_Click(object sender, EventArgs e)
        {
            ReturnsForm cachedReturnsForm = new ReturnsForm(_dbContext);
            cachedReturnsForm.Show();
            cachedReturnsForm.setFocusToTextBox();
            this.Hide();
        }

        private void checkInButton_Click(object sender, EventArgs e)
        {
            checkInOutForm cachedCheckInOutForm = new checkInOutForm(_dbContext);
            cachedCheckInOutForm.Show();
            this.Hide();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            cachedLoginForm = ShowForm(cachedLoginForm, () => new loginForm(_dbContext)) as loginForm;
            this.Hide();
        }

        private void SuppliersBtn_Click(object sender, EventArgs e)
        {
            if (loginForm.currentUser.HasPermission == 1)
            {
                cachedSuppliersForm = ShowForm(cachedSuppliersForm, () => new SuppliersForm(_dbContext, true)) as SuppliersForm;
                this.Hide();
            }
        }

        private void InventoryBtn_Click(object sender, EventArgs e)
        {
            if (loginForm.currentUser.HasPermission == 1)
            {
                InventoryForm inventoryForm = new InventoryForm(_dbContext, true, 0);
                inventoryForm.Show();
                this.Hide();
            }
        }

        private void AllOrdersBtn_Click(object sender, EventArgs e)
        {
            if (loginForm.currentUser.HasPermission == 1)
            {
                AllOrdersForm cachedAllOrdersForm = new AllOrdersForm(_dbContext);
                cachedAllOrdersForm.Show();
                cachedAllOrdersForm.InitializeForm();
                this.Hide();
            }
        }

        private void ProductsBtn_Click(object sender, EventArgs e)
        {
            if (loginForm.currentUser.HasPermission == 1)
            {
                ProductsForm productsForm = new ProductsForm(_dbContext);
                productsForm.Show();
                this.Hide();
  
            }
        }

        private void categoriesButton_Click(object sender, EventArgs e)
        {
            if (loginForm.currentUser.HasPermission == 1)
            {
                CategoriesForm cachedCategoriesForm = new CategoriesForm(_dbContext, true);
                cachedCategoriesForm.Show();
                this.Hide();
            }
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void unpaidOrdersButton_Click(object sender, EventArgs e)
        {
            if (loginForm.currentUser.HasPermission == 1)
            {
                UnpaidOrdersForm cachedUnpaidOrdersForm = new UnpaidOrdersForm(_dbContext);
                cachedUnpaidOrdersForm.Show();
                cachedUnpaidOrdersForm.InitializeData();
                this.Hide();
            }
        }
        private void customersBtn_Click(object sender, EventArgs e)
        {
            //cachedCustomersForm = ShowForm(cachedCustomersForm, () => new CustomersForm(_dbContext)) as CustomersForm;
            CustomersForm customerForm = new CustomersForm(_dbContext);
            customerForm.Show();
            this.Hide();
        }

        private void servicesButton_Click(object sender, EventArgs e)
        {
            cachedServicesForm = ShowForm(cachedServicesForm, () => new ServicesForm(_dbContext)) as ServicesForm;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.Show();
            this.Hide();
        }
    }
}
