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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ClothingStore.UI
{
    public partial class ReturnsForm : Form
    {
        private System.Threading.Timer changeDetectionTimer;
        private ClothingStoreContext _dbContext;
        private double? profitFromReturnedProduct = 0;
        private double? profitFromNewProduct = 0;
        private double? spOfReturnedProduct = 0;
        private double? spOfNewProduct = 0;
        private Product returnedProduct;
        private Product newProduct;
        private DailySale? dailySale;
        private double? refund;
        private double? differencePaid;
        public ReturnsForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            long sellerId = loginForm.currentUser.LoginId;
            DateTime today = DateTime.Now.Date;
            dailySale = _dbContext.DailySales.FirstOrDefault(s => s.Date == today.ToString());
            if (dailySale == null)
                newDailySale();
            InitializingFields();
        }
        private void newDailySale()
        {

                using (var transaction = _dbContext.Database.BeginTransaction())
                {

                        DailySale dailySale = new DailySale
                        {
                            Date = DateTime.Now.Date.ToString(),
                            StartingBalance = 0,
                            EndBalance = 0,
                            Profit = 0,
                            TotalSales = 0,
                        };

                        _dbContext.DailySales.Add(dailySale);
                        _dbContext.SaveChanges();
                        transaction.Commit();

                }
        }
        private void InitializingFields()
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            sellerLabel.Text = loginForm.currentUser.Username.ToString();

        }

        public void setFocusToTextBox()
        {
            returnedItemTextBox.Focus();
        }

        private void DiscountProductQtyFromDb(long productId)
        {

                            var productInInventory = _dbContext.Inventories.FirstOrDefault(product => product.ProductId == productId);
                            if (productInInventory != null)
                            {
                                productInInventory.QuantityInStock = productInInventory.QuantityInStock - 1;
                            }
                            _dbContext.SaveChanges();

                    
        }



        private void IncrementProductQtyFromDb(long productId)
        {

                    var productInInventory = _dbContext.Inventories.FirstOrDefault(product => product.ProductId == productId);
                    if (productInInventory != null)
                    {
                        productInInventory.QuantityInStock = productInInventory.QuantityInStock + 1;
                    }
                    _dbContext.SaveChanges();
                    MessageBox.Show("Product Returned!");
      
        }

        private void navigateToIntroForm()
        {
            IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            this.Hide();
        }

        private void doneButton_Click(object sender, EventArgs e)
        {

                using (var transaction = _dbContext.Database.BeginTransaction())
                {   
                            
                            if(newItemTextBox.Text != "" && refundTextBox.Text != "")
                        {
                            MessageBox.Show("Please remove the new item or the refund.");
                            return;
                        }

                            int result = SetTheProducts();
                            if (result == 0) return;
                        double? lostProfit = 0;
                        double? refund = 0;
                        if (differencePaidTextBox.Text == "")
                        {
                            if (newProduct != null)
                            {
                                differencePaid = spOfNewProduct - spOfReturnedProduct;
                            }
                        }
                        else
                            differencePaid = double.Parse(differencePaidTextBox.Text);
                            Return newReturnItem = new Return
                            {
                                ReturnDate = DateTime.Now.ToString(),
                                ReturnedProductId = returnedProduct.ProductId,
                                NewProductId = newProduct?.ProductId,
                                PaidDifference = differencePaid,
                            };
                            if (refundTextBox.Text != "")
                            {
                                refund = double.Parse(refundTextBox.Text);
                                newReturnItem.Refund = refund;
                                if(newProduct == null)
                                    spOfNewProduct = 0;

                            }

                            _dbContext.Returns.Add(newReturnItem);

                            lostProfit = GetLostProfit();
                            var newProfit =  - lostProfit;
                           if (differencePaid == null)
                            differencePaid = 0;
                            var newTotalSale = spOfNewProduct - spOfReturnedProduct - ((spOfNewProduct - spOfReturnedProduct) - differencePaid) - refund;
                           
                            if (dailySale != null)
                            {
                                dailySale.Profit = dailySale.Profit + newProfit;
                                dailySale.TotalSales = dailySale.TotalSales + newTotalSale;
                                _dbContext.SaveChanges();
                            }

                            if(newProduct != null)
                            DiscountProductQtyFromDb(newProduct.ProductId);

                            IncrementProductQtyFromDb(returnedProduct.ProductId);

                            _dbContext.SaveChanges();
                            transaction.Commit();

                    }
                 
                //ADD CUSTOMER NAME
                navigateToIntroForm();
           
        }

        private double? GetLostProfit()
        {
            double? lostAmount = 0;
            double? lostProfit = 0;
            if (differencePaidTextBox.Text != "")
            {
                differencePaid = double.Parse(differencePaidTextBox.Text);
                if (differencePaid < spOfNewProduct - spOfReturnedProduct)
                {
                    if(differencePaid > 0)
                    lostAmount = (spOfNewProduct - spOfReturnedProduct) - differencePaid;
                }
            }

            if (newProduct != null)
            {
                    lostProfit = profitFromReturnedProduct - profitFromNewProduct + lostAmount;
            }

            else
                lostProfit = profitFromReturnedProduct; // Case of REFUND

            return lostProfit; // if - => gain, if + => loss
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (returnedItemTextBox.Text != null || newItemTextBox.Text != null)
            {
                DialogResult result = MessageBox.Show("You didn't complete your request. Do you want to cancel it?", "Cancel Return Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    navigateToIntroForm();

                }
            }
            navigateToIntroForm();
        }

        private void calculateDiffPaidBtn_Click(object sender, EventArgs e)
        {
 
                if(refundTextBox.Text != "")
                {
                    MessageBox.Show("Please remove the refund to calculate the difference to be paid.");
                    return;
                }
                    int result = SetTheProducts();
                if (result == 0) return;
                differencePaidTextBox.Text = (spOfNewProduct - spOfReturnedProduct).ToString();

        }

        private int SetTheProducts()
        {

                if (returnedItemTextBox.Text != "")
                {
                    var returnedItemBarcode = returnedItemTextBox.Text;
                int setOldPResult = SetOldProduct(returnedItemBarcode);
                if (setOldPResult == 0) return setOldPResult;
            }
                else
                {
                    MessageBox.Show("Please enter the returned product");
                    return 0;
                }
                if(refundTextBox.Text != "")
                   return 1;
                if (newItemTextBox.Text != "")
                    {

                        var newItemBarcode = newItemTextBox.Text;
                       int setNewPResult= SetNewProduct(newItemBarcode);
                if (setNewPResult == 0) return setNewPResult;
                    }
                else
                {
                    MessageBox.Show("Please enter the new product");
                    return 0;
                }

            return 1;
        }

        private int SetNewProduct(string scannedData)
        {
                var product = _dbContext.Products.FirstOrDefault(p => p.BarcodeId == scannedData);

                if (product != null)
                {
                    var foundProductId = product.ProductId;
                    profitFromNewProduct = product.SellingPrice - product.InitialPrice;
                    spOfNewProduct = product.SellingPrice;
                    newProduct = product;
                    return 1;
                }
                else
                {
                    MessageBox.Show("New Product Not Found");
                    return 0;
                }

        }
        private int SetOldProduct(string scannedData)
        {

                var product = _dbContext.Products.FirstOrDefault(p => p.BarcodeId == scannedData);

                if (product != null)
                {
                    var foundProductId = product.ProductId;
                    profitFromReturnedProduct = product.SellingPrice - product.InitialPrice;
                    spOfReturnedProduct = product.SellingPrice;
                    returnedProduct = product;
                }
                else
                {
                    MessageBox.Show("Returned Product Not Found");
                    return 0;
                }
                return 1;

        }

        private void calcRefundBtn_Click(object sender, EventArgs e)
        {
            if (newItemTextBox.Text != "")
            {
                MessageBox.Show("Please remove the New Product Barcode to Refund the item.");
                return;
            }

            if (returnedItemTextBox.Text != "")
            {
                var returnedItemBarcode = returnedItemTextBox.Text;
                SetOldProduct(returnedItemBarcode);
            }
            else
            {
                MessageBox.Show("Please enter the returned product");
                return;
            }

            refundTextBox.Text = returnedProduct.SellingPrice.ToString();
            differencePaidTextBox.Text = "";
        }
    }
}
