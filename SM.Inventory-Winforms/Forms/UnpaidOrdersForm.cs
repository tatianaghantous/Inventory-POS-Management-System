using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Common_Functions;
using SM.DataLayer.Models;


namespace SM
{
    public partial class UnpaidOrdersForm : Form
    {
        private ClothingStoreContext _dbContext;
        List<OrderSummary>? _allUnpaidOrders;
        List<Service>? _allUnpaidServices;
        List<Customer>? _allCustomers;

        public UnpaidOrdersForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            UnpaidOrdersDataGridView.DataError += UnpaidOrdersDataGridView_DataError;
            UnpaidOrdersDataGridView.DefaultCellStyle.SelectionBackColor = UnpaidOrdersDataGridView.DefaultCellStyle.BackColor;
            UnpaidOrdersDataGridView.DefaultCellStyle.SelectionForeColor = UnpaidOrdersDataGridView.DefaultCellStyle.ForeColor;
        }
        private void UnpaidOrdersDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewFunctions.DataGridView_DataError(sender, e);
        }
        public void InitializeData()
        {
            _allUnpaidOrders = _dbContext.OrderSummaries.Include(os => os.OrderItems)
                                                        .Include(os => os.Buyer).ToList();
            _allUnpaidServices = _dbContext.Services.Include(os => os.Customer).ToList();

            _allCustomers = _dbContext.Customers.ToList();
            LoadUnpaidOrders(_allUnpaidOrders);
            FillComboBox();

        }

        private void FillComboBox()
        {

            if (_allCustomers != null)
            {
                if (_allCustomers.Any())
                {
                    foreach (var customer in _allCustomers)
                    {
                        if (!string.IsNullOrEmpty(customer.Name))
                            customerComboBox.Items.Add(customer.Name);
                    }
                }
            }
        }

        private void LoadUnpaidOrders(List<OrderSummary> _allUnpaidOrders)
        {
            UnpaidOrdersDataGridView.Columns.Clear();

            // Combine data from orders
            var orderData = _allUnpaidOrders
                .SelectMany(orderSummary => orderSummary.OrderItems
                    .Where(o => o.IsPaid == 0)
                    .Select(o => new
                    {
                        OrderId = o.OrderItemId,
                        ProductId = o.ItemId,
                        ProductName = o.Item != null ? o.Item.Name : "Unknown Product",
                        ProductPrice = o.Item?.SellingPrice,
                        Quantity = o.Quantity,
                        SellerName = orderSummary.Seller?.Username ?? "Unknown Seller",
                        BuyerName = orderSummary.Buyer?.Name ?? "Unknown Buyer",
                        OrderDateTime = orderSummary.OrderDateTime,
                        TotalInUsd = orderSummary.TotalInUsd,
                    }))
                .ToList();

            var bindingList = new BindingList<object>(orderData.Cast<object>().ToList());
            var source = new BindingSource(bindingList, null);
            UnpaidOrdersDataGridView.DataSource = source;
            AdjustColumnVisibility();
            // Add a column for the action (e.g., Pay button)
            UnpaidOrdersDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Pay",
                UseColumnTextForButtonValue = true,
                Name = "PayButton",
                DataPropertyName = "Pay",
            });
        }

        private void LoadUnpaidServices(List<Service> _allUnpaidServices)
        {
            UnpaidOrdersDataGridView.Columns.Clear();

            var serviceData = _allUnpaidServices
                .Where(service => service.IsPaid == 0)
                .Select(service => new
                {
                    ServiceId = service.ServiceId,
                    CustomerName = service.Customer?.Name ?? "Unknown Buyer",
                    ServiceType = service.ServiceType,
                    ServiceDuration = service.ServiceDuration,
                    Description = service.Description,
                    PurchaseDate = service.ServiceDate,
                    Price = service.ServiceSellingPrice
                });      

        var bindingList = new BindingList<object>(serviceData.Cast<object>().ToList());
            var source = new BindingSource(bindingList, null);
            UnpaidOrdersDataGridView.DataSource = source;
            UnpaidOrdersDataGridView.Columns["ServiceId"].Visible = false;

            UnpaidOrdersDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Action",
                Text = "Pay",
                UseColumnTextForButtonValue = true,
                Name = "PayButton",
                DataPropertyName = "Pay",
            });
        }

        private void AdjustColumnVisibility()
        {
            // Example: Hide the OrderId and ProductId columns
            if (UnpaidOrdersDataGridView.Columns["OrderId"] != null)
            UnpaidOrdersDataGridView.Columns["OrderId"].Visible = false;
                        if (UnpaidOrdersDataGridView.Columns["OrderId"] != null)
            UnpaidOrdersDataGridView.Columns["ProductId"].Visible = false;

            // Any other configuration for columns can be done here
        }


        private void DeleteRowFromDataGridView(int rowIndex)
        {

                if (rowIndex >= 0 && rowIndex < UnpaidOrdersDataGridView.Rows.Count)
                {

                    UnpaidOrdersDataGridView.Rows.RemoveAt(rowIndex);

                    UnpaidOrdersDataGridView.Refresh();
                }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            this.Hide();
        }
        private void FilterProductsOnCustomerName(string filter)
        {
            if (_allUnpaidOrders != null && _allUnpaidServices != null)
            {
                var filteredOrders = string.IsNullOrWhiteSpace(filter) ?
                    _allUnpaidOrders :
                    _allUnpaidOrders.Where(o => !string.IsNullOrWhiteSpace(o.Buyer?.Name) &&
                        o.Buyer.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

                var filteredServices = string.IsNullOrWhiteSpace(filter) ?
                    _allUnpaidServices :
                    _allUnpaidServices.Where(s => !string.IsNullOrWhiteSpace(s.Customer?.Name) &&
                        (bool)s.Customer?.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

                LoadUnpaidOrders(filteredOrders);
            }
        }

        private void customerComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            FilterProductsOnCustomerName(customerComboBox.SelectedItem.ToString());
        }

        private void UnpaidOrdersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderItemIdColumnIndex = UnpaidOrdersDataGridView.Columns["OrderId"]?.Index ?? -1;
            int serviceIdColumnIndex = UnpaidOrdersDataGridView.Columns["ServiceId"]?.Index ?? -1;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex == UnpaidOrdersDataGridView.Columns["PayButton"].Index && orderItemIdColumnIndex != -1)
            {

                    var orderIdCell = UnpaidOrdersDataGridView.Rows[e.RowIndex].Cells["OrderId"].Value;
                    if (orderIdCell != null)
                    {
                        int orderId = int.Parse(orderIdCell.ToString());

                        var order = _dbContext.OrderItems.FirstOrDefault(o => o.OrderItemId == orderId);
                        if (order != null)
                        {
                            order.IsPaid = 1;
                            _dbContext.SaveChanges();
                            DeleteRowFromDataGridView(e.RowIndex);
                            MessageBox.Show("Order Item Paid successfully.");
                        }

                    }

            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == UnpaidOrdersDataGridView.Columns["PayButton"].Index && serviceIdColumnIndex != -1)
            {


                    var serviceIdCell = UnpaidOrdersDataGridView.Rows[e.RowIndex].Cells["ServiceId"].Value;
                    if (serviceIdCell != null)
                    {
                        int serviceId = int.Parse(serviceIdCell.ToString());

                        var service = _dbContext.Services.FirstOrDefault(o => o.ServiceId == serviceId);
                        if (service != null)
                        {
                            service.IsPaid = 1;
                            _dbContext.SaveChanges();
                            DeleteRowFromDataGridView(e.RowIndex);
                            MessageBox.Show("Service Paid successfully.");
                        }

                    }
            }
            }

        private void clearSelectionButton_Click(object sender, EventArgs e)
        {
            LoadUnpaidOrders(_allUnpaidOrders);
        }


        private void toggleBtn_Click(object sender, EventArgs e)
        {
            if (toggleBtn.Text == "View Services")
            {
                toggleBtn.Text = "View Orders";
                LoadUnpaidServices(_allUnpaidServices);

            }
            else if (toggleBtn.Text == "View Orders")
            {
                toggleBtn.Text = "View Services";
                LoadUnpaidOrders(_allUnpaidOrders);

            }
        }
    }
}
