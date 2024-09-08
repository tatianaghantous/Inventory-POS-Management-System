using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMDataLayer.Models;
using SM;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Microsoft.EntityFrameworkCore.Storage;
using SM.Common_Functions;
using SM.ViewModels;



namespace SM
{
    public partial class NewOrderForm : Form
    {
        private ClothingStoreContext _dbContext;
        private OrderSummary orderSummary;
        private List<Category> categoriesList;
        private List<OrderItem> orderItems;
        BindingList<OrderViewModel> bindingList;
        BindingSource source;
        private System.Threading.Timer changeDetectionTimer;
        private double? total = 0;
        Account seller;
        string imagePath = "Assets\\bin.png";
        private object originalValue;
        public NewOrderForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            categoriesList = _dbContext.Categories.ToList();
            seller = loginForm.currentUser;
            orderItems = new List<OrderItem>();
            InitializeCategoriesTableLayoutPanel(categoriesList.Where(c => c.DisplayInPos == 1).ToList());
            dateTextBox.Text = DateTime.Now.ToLongDateString();
            sellerNameLabel.Text = seller.Username;
            scannedBarcode.TextChanged += scannedBarcode_TextChanged;
            InitializeChangeDetection();
            InitializeOrderItemsDGV();
            NewOrderDataGridView.DefaultCellStyle.SelectionBackColor = NewOrderDataGridView.DefaultCellStyle.BackColor;
            NewOrderDataGridView.DefaultCellStyle.SelectionForeColor = NewOrderDataGridView.DefaultCellStyle.ForeColor;
            NewOrderDataGridView.CellFormatting += NewOrderDataGridView_CellFormatting;
            NewOrderDataGridView.CellEndEdit += NewOrderDataGridView_CellEndEdit;
            NewOrderDataGridView.CellBeginEdit += NewOrderDataGridView_CellBeginEdit;

        }
        private void NewOrderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, NewOrderDataGridView);
        }
        private void NewOrderDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            originalValue = NewOrderDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        private void NewOrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                DataGridViewCell editedCell = NewOrderDataGridView.Rows[rowIndex].Cells[columnIndex];
                object cellValue = editedCell.Value;
                int selectedIndex = NewOrderDataGridView.CurrentRow.Index;
                OrderViewModel selectedOrderItem = bindingList[selectedIndex];

                if (NewOrderDataGridView.Columns[columnIndex].Name == "UnitPriceAfterDiscount")
                {
                    selectedOrderItem.UnitPriceAfterDiscount= ValidateAndReturnPropertyValue(editedCell, cellValue, originalValue);
                    if (selectedOrderItem.UnitPriceAfterDiscount != null) {
                        OrderItem? itemToUpdate = orderItems.FirstOrDefault(oitem => oitem.Item.BarcodeId == selectedOrderItem.Barcode);
                        itemToUpdate.UnitPriceAfterDiscount = selectedOrderItem.UnitPriceAfterDiscount;
                        itemToUpdate.TotalPriceAfterDiscount = selectedOrderItem.UnitPriceAfterDiscount*itemToUpdate.Quantity;
                        selectedOrderItem.TotalPriceAfterDiscount = itemToUpdate.TotalPriceAfterDiscount;
                        totalAfterDiscountTxtBox.Text = CalculateTotalAfterDiscount().ToString();
                        source.DataSource = bindingList;
                        NewOrderDataGridView.DataSource = source;
                    }
                }
                else if (NewOrderDataGridView.Columns[columnIndex].Name == "TotalPriceAfterDiscount")
                {
                    selectedOrderItem.TotalPriceAfterDiscount = ValidateAndReturnPropertyValue(editedCell, cellValue, originalValue);
                    if (selectedOrderItem.TotalPriceAfterDiscount != null)
                    {
                        OrderItem? itemToUpdate = orderItems.FirstOrDefault(oitem => oitem.Item.BarcodeId == selectedOrderItem.Barcode);
                        itemToUpdate.TotalPriceAfterDiscount = selectedOrderItem.TotalPriceAfterDiscount;
                        itemToUpdate.UnitPriceAfterDiscount = itemToUpdate.TotalPriceAfterDiscount/itemToUpdate.Quantity;
                        selectedOrderItem.UnitPriceAfterDiscount = itemToUpdate.UnitPriceAfterDiscount;
                        totalAfterDiscountTxtBox.Text = CalculateTotalAfterDiscount().ToString();
                        source.DataSource = bindingList;
                        NewOrderDataGridView.DataSource = source;
                    }
                }

        }
        private double? CalculateTotalAfterDiscount()
        {
            double? totalSum = 0;

            foreach (var item in bindingList)
            {
                if (item.TotalPriceAfterDiscount != null)
                {
                    totalSum += item.TotalPriceAfterDiscount.Value;
                }
                else
                {
                    totalSum += item.TotalPrice;
                }
            }
            return totalSum;

        }
        private double? ValidateAndReturnPropertyValue(DataGridViewCell editedCell, object cellValue, object previousValue)
        {

          if (double.TryParse(cellValue.ToString(), out double price))
            {
                return price;
            }
            else
            {
                MessageBox.Show("Please enter a valid Price (decimal).");
                editedCell.Value = previousValue;
                return null;
            }
        }

        public void setFocusToTextBox()
        {
            scannedBarcode.Focus();
        }
        private void InitializeChangeDetection()
        {
            changeDetectionTimer = new System.Threading.Timer(OnTimerElapsed, null, Timeout.Infinite, Timeout.Infinite);
            scannedBarcode.TextChanged += scannedBarcode_TextChanged;
        }
        private void OnTimerElapsed(object state)
        {
            if (scannedBarcode.Text != "")
            {
                Console.WriteLine("User stopped changing the value.");

                string finalvalue = null;

                scannedBarcode.Invoke((MethodInvoker)(() =>
                {
                    finalvalue = scannedBarcode.Text;
                    scannedBarcode.Text = "";
                    AddOrderItemByBarcode(finalvalue);
                    scannedBarcode.Focus();

                }));
            }
        }

        private void scannedBarcode_TextChanged(object? sender, EventArgs e)
        {
            changeDetectionTimer.Change(1700, Timeout.Infinite);

        }
        public void InitializeOrderItemsDGV()
        {

                NewOrderDataGridView.AutoGenerateColumns = false;

                NewOrderDataGridView.Columns.Clear();

                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Barcode",
                    DataPropertyName = "Barcode",
                    Name = "Barcode",
                    ReadOnly = true
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Product Name",
                    DataPropertyName = "ProductName",
                    Name = "ProductName",
                    ReadOnly = true
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Product Description",
                    DataPropertyName = "ProductDescription",
                    Name = "ProductDescription",
                    ReadOnly = true
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Quantity",
                    DataPropertyName = "Quantity",
                    Name = "Quantity",
                    ReadOnly = true
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Unit Price",
                    DataPropertyName = "ProductPrice",
                    Name = "ProductPrice",
                    ReadOnly = true
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Discounted Unit Price",
                    DataPropertyName = "UnitPriceAfterDiscount",
                    Name = "UnitPriceAfterDiscount",
                    ReadOnly = false
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Total Price",
                    DataPropertyName = "TotalPrice",
                    Name = "TotalPrice",
                    ReadOnly = true
                });
                NewOrderDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Discounted Total Price",
                    DataPropertyName = "TotalPriceAfterDiscount",
                    Name = "TotalPriceAfterDiscount",
                    ReadOnly = false

                });
                NewOrderDataGridView.Columns.Add(new DataGridViewImageColumn
                {
                    HeaderText = " ",
                    Name = "DeleteButtonColumn",
                    Width = 100
                });
            bindingList = new BindingList<OrderViewModel>();
                 source = new BindingSource(bindingList, null);

                NewOrderDataGridView.DataSource = source;
            
        }

        public void InitializeCategoriesTableLayoutPanel(List<Category> categoriesToDisplay)
        {
            if (newOrderTableLayoutPanel.GetControlFromPosition(3, 3) != null)
            {
                newOrderTableLayoutPanel.Controls.Remove(newOrderTableLayoutPanel.GetControlFromPosition(3, 3));
            }
            int numButtons = categoriesToDisplay.Count();
            if (numButtons != 0)
            {
                int numRows = (int)Math.Ceiling(Math.Sqrt(numButtons));
                int numCols = (int)Math.Ceiling((double)numButtons / numRows);
                float rowPercentage = 100f / numRows;
                float colPercentage = 100f / numCols;
                TableLayoutPanel ItemsTableLayoutPanel = new TableLayoutPanel();
                ItemsTableLayoutPanel.Dock = DockStyle.Fill; 

                ItemsTableLayoutPanel.SetColumnSpan(ItemsTableLayoutPanel, 3);
                newOrderTableLayoutPanel.Controls.Add(ItemsTableLayoutPanel, 3, 3); 
                ItemsTableLayoutPanel.RowCount = numRows;
                ItemsTableLayoutPanel.ColumnCount = numCols;

                for (int i = 0; i < numRows; i++)
                {
                    ItemsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                }
                for (int j = 0; j < numCols; j++)
                {
                    ItemsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                }

                int index = 0;
                foreach (Category category in categoriesToDisplay)
                {
                    Button button = CreateCategoryButton(category);

                    ItemsTableLayoutPanel.Controls.Add(button, index % numCols, index / numCols);
                    index++;
                }
            }
        }

        private Button CreateCategoryButton(Category category)
        {
            Button button = new Button();
            button.Text = category.Name;
            button.ForeColor = Color.FloralWhite;
            button.Font = new Font("Sylfaen", 21, FontStyle.Regular);
            button.Dock = DockStyle.Fill;

            button.MouseEnter += (sender, e) =>
            {
                ((Button)sender).Cursor = Cursors.Hand;
                ((Button)sender).Paint += Button_Paint;

            };

            button.MouseLeave += (sender, e) =>
            {
                ((Button)sender).Paint -= Button_Paint;
            };
            button.MouseClick += (sender, e) =>
            {
                ProductsForm productsForm = new ProductsForm(_dbContext, category);

                if (productsForm.ShowDialog() == DialogResult.OK)
                {
                    AddOrderItemByBarcode(productsForm.chosenProductBarcode);

                }

            };
            void Button_Paint(object sender, PaintEventArgs e)
            {

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0x92, 0x9c, 0xb0)))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, button.Width, button.Height);
                }
            }

            return button;
        }

        private void AddOrderItemByBarcode(string scannedData)
        {

                var product = _dbContext.Products.FirstOrDefault(p => p.BarcodeId == scannedData);

                if (product != null)
                {                 
                    var orderItem = orderItems.FirstOrDefault(o => o.Item.BarcodeId == scannedData);
                    AddOrderItemToList(scannedData, product, orderItem);
                    totalAfterDiscountTxtBox.Text = CalculateTotalAfterDiscount().ToString();
                }
                else
                {
                    MessageBox.Show("Product not found.");
                }
        }

        private void AddOrderItemToList(string scannedData, Product? product, OrderItem? orderItem)
        {
            if (orderItem != null)
            {

                        orderItem.Quantity++;
                        total = total + orderItem.Item.SellingPrice;
                        totalTextBox.Text = total.ToString();
                        IncrementCellContentDgv(orderItem);


            }
            else
            {

                        var newOrderItem = new OrderItem
                        {
                            Item = product,
                            PriceUsd = product.SellingPrice,
                            InitialCost = product.InitialPrice,
                            Description = product.Description,
                            // Modify price in case there exist sale
                            Quantity = 1
                        };

                        orderItems.Add(newOrderItem);
                    double? totalPrice = newOrderItem.Item.SellingPrice;
                        total = total + totalPrice;
                        totalTextBox.Text = total.ToString();
                    OrderViewModel orderViewModel = new OrderViewModel
                    {
                        Product = product,
                        ItemId = product.ProductId,
                        ProductName = product.Name,
                        ProductPrice = product.SellingPrice,
                        Barcode = product.BarcodeId,
                        ProductDescription = product.Description,
                        Quantity = 1,
                        TotalPrice = product.SellingPrice,
                    };
                    bindingList.Add(orderViewModel);
                    source.DataSource = bindingList;
                    NewOrderDataGridView.DataSource = source;
            }
        }

        private void DecrementProductQuantityInDb(OrderItem orderItem, IDbContextTransaction transaction)
        {

                var foundProductId = orderItem.Item.ProductId;
                var productInInventory = _dbContext.Inventories.FirstOrDefault(product => product.ProductId == foundProductId);
                if (productInInventory != null)
                {
                    productInInventory.QuantityInStock = productInInventory.QuantityInStock - orderItem.Quantity;
                }
                _dbContext.SaveChanges();
        }

        private void IncrementCellContentDgv(OrderItem existingOrderItem)
        {

                double? totalPrice = existingOrderItem.Item.SellingPrice * existingOrderItem.Quantity;

                var itemToUpdate = bindingList.FirstOrDefault(item => item.Barcode == existingOrderItem.Item.BarcodeId);
                if (itemToUpdate != null)
                {

                    itemToUpdate.Quantity += 1;
                    itemToUpdate.TotalPrice = totalPrice;

                    source.ResetBindings(false);
                    totalAfterDiscountTxtBox.Text = CalculateTotalAfterDiscount().ToString();

                }
        }

        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {

                using (var transaction = _dbContext.Database.BeginTransaction())
                {

                        CreatingAndAddingOS(seller.LoginId);
                        Customer customer = new Customer();
                        customer.Name = customerNameTextBox.Text;
                        _dbContext.Add(customer);

                        orderSummary.Buyer = customer;

                        NewOrderDataGridView.Rows.Clear();

                        double totalGainInUSD = 0;
                        double totalInitialCost = 0;
                        double totalSalesInUSD = 0;
                        double sellingPrice = 0;
                        double initialCost = 0;

                        foreach (OrderItem orderItem in orderItems)
                        {
                            orderItem.OrderId = orderSummary.OrderId;
                            DecrementProductQuantityInDb(orderItem, transaction);
                             sellingPrice = (double)(orderItem.Item.SellingPrice);
                             initialCost = (double)(orderItem.Item.InitialPrice);
                            totalGainInUSD = (double)(totalGainInUSD + ((sellingPrice - initialCost) * orderItem.Quantity));
                            totalSalesInUSD = totalSalesInUSD + sellingPrice;
                            totalInitialCost += initialCost;
                        }

                        _dbContext.OrderItems.AddRange(orderItems);

                        if (totalAfterDiscountTxtBox.Text != "")
                        {
                            double totalAfterDiscount = double.Parse(totalAfterDiscountTxtBox.Text);
                            //decimal discountedMoney = totalSalesInUSD - totalAfterDiscount;
                            totalGainInUSD = totalAfterDiscount - totalInitialCost;
                           // totalSalesInUSD = totalSalesInUSD - discountedMoney;
                            orderSummary.GainInUsd = totalGainInUSD;
                            orderSummary.TotalInUsd = totalSalesInUSD;
                            orderSummary.TotalAfterDiscountInUsd = totalAfterDiscount;
                            _dbContext.SaveChanges();
                            totalSalesInUSD = totalAfterDiscount;
                        }
                        else
                        {
                            orderSummary.GainInUsd = totalGainInUSD;
                            orderSummary.TotalInUsd = totalSalesInUSD;
                            _dbContext.SaveChanges();
                        }
                        if (notPaidCheckBox != null && notPaidCheckBox.Checked)
                        {
                            foreach (var orderItem in orderSummary.OrderItems)
                            {
                                orderItem.IsPaid = 0;
                            }
                            orderSummary.IsPaid = 0;
                            _dbContext.SaveChanges();
                        }

                        AddingOSToDailySales(totalGainInUSD, totalSalesInUSD);
                        transaction.Commit();
                        customerNameTextBox.Text = "";
                        navigateToIntroForm();
                        _dbContext.SaveChanges();

                }

        }

        private void AddingOSToDailySales(double totalGainInUSD, double totalSalesInUSD)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            var todaysSale = _dbContext.DailySales.FirstOrDefault(s => s.Date == today);
            if (todaysSale != null)
            {
                todaysSale.Profit = todaysSale.Profit + totalGainInUSD;
                todaysSale.TotalSales = todaysSale.TotalSales + totalSalesInUSD;
                _dbContext.SaveChanges();
            }
            else
            {
                DailySale newDailySale = new DailySale
                {
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Profit = totalGainInUSD,
                    TotalSales = totalSalesInUSD,
                    StartingBalance = 0,
                    EndBalance = 0
                };
                _dbContext.DailySales.Add(newDailySale);
                _dbContext.SaveChanges();
            }
        }
        private void CreatingAndAddingOS(long sellerId)
        {
                    orderSummary = new OrderSummary
                    {
                        OrderDateTime = DateTime.Now.ToString("dd/MM/yyyy"),
                        SellerId = sellerId,
                        OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        TotalInUsd = 0,
                        GainInUsd = 0,
                        BuyerId = null,
                    };
                    _dbContext.OrderSummaries.Add(orderSummary);
                    _dbContext.SaveChanges();
            
        }
        private void NewOrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                if (e.ColumnIndex == NewOrderDataGridView.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0)
                {
                    string productBarcode = NewOrderDataGridView.Rows[e.RowIndex].Cells["Barcode"].Value.ToString();

                    var orderItem = orderItems.FirstOrDefault(o => o.Item.BarcodeId == productBarcode);

                    if (orderItem != null)
                    {
                        total = total - orderItem.Item.SellingPrice * orderItem.Quantity;
                        orderItems.Remove(orderItem);
                        RemovingOrderItemFromBindingSource();
                    }
                        totalTextBox.Text = total.ToString();
                        setFocusToTextBox();
                }
        }

        private void RemovingOrderItemFromBindingSource()
        {
            int selectedIndex = NewOrderDataGridView.CurrentRow.Index;

            // Get the corresponding item from the BindingList
            OrderViewModel selectedOrderItem = bindingList[selectedIndex];

            // Remove the item from the BindingList
            bindingList.RemoveAt(selectedIndex);

            // Refresh the DataGridView
            source.DataSource = bindingList;
            NewOrderDataGridView.DataSource = source;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CheckAndConfirmCancellation();
        }
        private void CheckAndConfirmCancellation()
        {

                if (NewOrderDataGridView.Rows.Count > 0)
                {
                    DialogResult result = MessageBox.Show("You didn't complete your order. Do you want to cancel it?", "Cancel Order Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        orderItems.Clear();
                        navigateToIntroForm();
                    }
                }
                else
                    navigateToIntroForm();

        }
        private void DeleteAllOrderItemsFromDatabase()
        {
            try
            {
                List<OrderItem> orderItems = _dbContext.OrderItems.Where(item => item.OrderId == orderSummary.OrderId).ToList();
                if (orderItems.Any())
                {

                    foreach (OrderItem orderItem in orderItems)
                    {
                        using (var transaction = _dbContext.Database.BeginTransaction())
                        {
                            try
                            {
                                if (orderItem != null)
                                {
                                    var productInInventory = _dbContext.Inventories.FirstOrDefault(product => product.ProductId == orderItem.Item.ProductId);
                                    productInInventory.QuantityInStock = productInInventory.QuantityInStock + orderItem.Quantity;
                                    _dbContext.OrderItems.Remove(orderItem);
                                    _dbContext.SaveChanges();
                                    transaction.Commit();

                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error: " + ex.Message);

                            }
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void navigateToIntroForm()
        {
            IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            this.Hide();

        }

        private void totalAfterDiscountTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ItemsFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void scannedBarcode_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void editCategoriesButton_Click(object sender, EventArgs e)
        {
            CategoriesListForm categoriesListForm = new CategoriesListForm (_dbContext, this);
            categoriesListForm.Show();
        }
    }
}
