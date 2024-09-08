using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Common_Functions;
using SM.ViewModels;
using SMDataLayer.Models;
using System.Globalization;

namespace SM
{
    public partial class AllOrdersForm : Form
    {
        private ClothingStoreContext _dbContext;
        private object originalValue;
        List<OrderSummary> orderSummaries;
        BindingList<OrderViewModel> orderViewModels;
        BindingList<OrderViewModel> filteredOrderViewModels;
        List<Service> filteredServices;
        List<Service> _services = new List<Service>();

        public AllOrdersForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            AllOrdersDataGridView.CellEndEdit += AllOrdersDataGridView_CellEndEdit;
            AllOrdersDataGridView.CellBeginEdit += AllOrdersDataGridView_CellBeginEdit;
            AllOrdersDataGridView.CellFormatting += AllOrdersDataGridView_CellFormatting;
            AllOrdersDataGridView.DefaultCellStyle.SelectionBackColor = AllOrdersDataGridView.DefaultCellStyle.BackColor;
            AllOrdersDataGridView.DefaultCellStyle.SelectionForeColor = AllOrdersDataGridView.DefaultCellStyle.ForeColor;
        }

        public void InitializeForm()
        {
            orderSummaries = _dbContext.OrderSummaries.ToList();
            _services = _dbContext.Services.ToList();
            LoadAllOrders();
            InitializeDateTimePicker();
        }
            public void LoadAllOrders()
            {

            foreach (var orderSummary in orderSummaries)
            {
                _dbContext.Entry(orderSummary).Collection(os => os.OrderItems).Load();
            }

           orderViewModels = new BindingList<OrderViewModel>();

            foreach (var orderSummary in orderSummaries)
            {
                foreach (var orderItem in orderSummary.OrderItems)
                {
                    var sellerName = orderSummary.Seller != null ? orderSummary.Seller.Username : "";
                    var buyerName = orderSummary.Buyer != null ? orderSummary.Buyer.Name : "";

                    OrderViewModel viewModel = new OrderViewModel
                    {
                        OrderId = orderSummary.OrderId,
                        OrderItemId = orderItem.OrderItemId,
                        ItemId = orderItem.ItemId,
                        Barcode = orderItem.Item.BarcodeId,
                        ProductName = orderItem.Item?.Name,
                        ProductPrice = orderItem.Item?.SellingPrice,
                        Quantity = orderItem.Quantity,
                        SellerName = sellerName,
                        BuyerName = buyerName,
                        OrderDateTime = DateTime.ParseExact(orderSummary.OrderDateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        TotalPrice = orderItem?.Item?.SellingPrice*orderItem?.Quantity,
                        TotalPriceAfterDiscount = orderItem.TotalPriceAfterDiscount
                    };

                    orderViewModels.Add(viewModel);
                }
            }
            InitializeDataGridView();
        }
        public void LoadAllServices()
        {

            AllOrdersDataGridView.AutoGenerateColumns = false;

            AllOrdersDataGridView.Columns.Clear();

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ServiceId",
                DataPropertyName = "ServiceId",
                Name = "ServiceId",
                ReadOnly = true,
                Visible = false
            }); 

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Service Type",
                DataPropertyName = "ServiceType",
                Name = "ServiceType",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Service Duration",
                DataPropertyName = "ServiceDuration",
                Name = "ServiceDuration",
                ReadOnly = true
            });
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Service Description",
                DataPropertyName = "Description",
                Name = "Description",
                ReadOnly = true
            });

            //AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    HeaderText = "Service Profit",
            //    DataPropertyName = "ServiceProfit",
            //    Name = "ServiceProfit",
            //    ReadOnly = true
            //});

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Service Date",
                DataPropertyName = "ServiceDate",
                Name = "ServiceDate",
                ReadOnly = true
            });

            //AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            //{
            //    HeaderText = "Service Cost",
            //    DataPropertyName = "ServiceCost",
            //    Name = "ServiceCost",
            //    ReadOnly = true
            //});
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Service Price",
                DataPropertyName = "ServiceSellingPrice",
                Name = "ServiceSellingPrice",
                ReadOnly = true
            });
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Paid",
                DataPropertyName = "IsPaid",
                Name = "IsPaid",
                ReadOnly = true
            });


            AllOrdersDataGridView.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = " ",
                Name = "DeleteButtonColumn",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 100 // Adjust width as needed
            });

            var bindingList = new BindingList<Service>(_services);
            var source = new BindingSource(bindingList, null);

            AllOrdersDataGridView.DataSource = source;

        }
    
        private void InitializeDateTimePicker()
        {
            datePicker.Value = DateTime.Today;
            int orderItemIdColumnIndex = AllOrdersDataGridView.Columns["OrderItemId"]?.Index ?? -1;
            int serviceIdColumnIndex = AllOrdersDataGridView.Columns["ServiceId"]?.Index ?? -1;
            if(orderItemIdColumnIndex != -1)
            filteredOrderViewModels = FilterOrdersByDate(datePicker.Value);
            else if (serviceIdColumnIndex != -1)
                filteredServices = FilterServicesByDate(datePicker.Value);
            PopulateDataGridView(filteredOrderViewModels);
            datePicker.ValueChanged += DatePicker_ValueChanged;
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Value;
            int orderItemIdColumnIndex = AllOrdersDataGridView.Columns["OrderItemId"]?.Index ?? -1;
            int serviceIdColumnIndex = AllOrdersDataGridView.Columns["ServiceId"]?.Index ?? -1;
            if (orderItemIdColumnIndex != -1)
            {
                filteredOrderViewModels = FilterOrdersByDate(selectedDate);
                PopulateDataGridView(filteredOrderViewModels);
            }

            else if (serviceIdColumnIndex != -1)
            {
                filteredServices = FilterServicesByDate(selectedDate);
                PopulateDataGridView(filteredServices);
            }


        }
        private void PopulateDataGridView<T>(IEnumerable<T> filteredData)
        {
            AllOrdersDataGridView.DataSource = filteredData.ToList();
        }

        public BindingList<OrderViewModel> FilterOrdersByDate(DateTime date)
        {
            return new BindingList<OrderViewModel>(
                orderViewModels
                .Where(os => os.OrderDateTime?.Date == date.Date)
                .ToList()
            );
        }

        public List<Service> FilterServicesByDate(DateTime date)
        {
            return new List<Service>( _services
                .Where(s => s.ServiceDate == date.Date.ToString("yyyy-MM-dd"))
                .ToList()
                );
        }

        public void InitializeDataGridView()
        {
            AllOrdersDataGridView.Columns.Clear();
            AllOrdersDataGridView.AutoGenerateColumns = false;
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Order ID",
                DataPropertyName = "OrderId",
                Name = "OrderId",
                ReadOnly = true,
                Visible = false
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Order Item ID",
                DataPropertyName = "OrderItemId",
                Name = "OrderItemId",
                ReadOnly = true,
                Visible = false
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Item ID",
                DataPropertyName = "ItemId",
                Name = "ItemId",
                ReadOnly = true,
                Visible = false
            });
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Barcode",
                DataPropertyName = "Barcode",
                Name = "Barcode",
                ReadOnly = true
            });
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product Name",
                DataPropertyName = "ProductName",
                Name = "ProductName",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product Price",
                DataPropertyName = "ProductPrice",
                Name = "ProductPrice",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity",
                Name = "Quantity",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Seller Name",
                DataPropertyName = "SellerName",
                Name = "SellerName",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Buyer Name",
                DataPropertyName = "BuyerName",
                Name = "BuyerName",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Order Date Time",
                DataPropertyName = "OrderDateTime",
                Name = "OrderDateTime",
                ReadOnly = true
            });

            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = " Total Price (USD)",
                DataPropertyName = "TotalPrice",
                Name = "TotalPrice",
                ReadOnly = true
            });
            AllOrdersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = " Total Price After Discount (USD)",
                DataPropertyName = "TotalPriceAfterDiscount",
                Name = "TotalPriceAfterDiscount"
            });
            AllOrdersDataGridView.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = " ",
                Name = "DeleteButtonColumn",
                Width = 100
            });
        }

        private void AllOrdersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, AllOrdersDataGridView);
        }


        private void AllOrdersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
 

                int orderItemIdColumnIndex = AllOrdersDataGridView.Columns["OrderItemId"]?.Index ?? -1;
                int serviceIdColumnIndex = AllOrdersDataGridView.Columns["ServiceId"]?.Index ?? -1;

                if (e.RowIndex >= 0 && e.ColumnIndex == AllOrdersDataGridView.Columns["DeleteButtonColumn"].Index && orderItemIdColumnIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var orderItemIdCell = AllOrdersDataGridView.Rows[e.RowIndex].Cells["OrderItemId"].Value;
                        if (orderItemIdCell != null)
                        {
                            int orderItemId = int.Parse(orderItemIdCell.ToString());
                            var orderItem = _dbContext.OrderItems.FirstOrDefault(o => o.OrderItemId == orderItemId);
                            if (orderItem != null)
                            {
                                Inventory? correspondindInventory = _dbContext.Inventories.FirstOrDefault(p => p.ProductId == orderItem.ItemId);
                                if (correspondindInventory != null)
                                {
                                    correspondindInventory.QuantityInStock = +orderItem.Quantity;
                                }

                                    var orderDate = orderItem.Order.OrderDate;
                                    double profitImpact = CalculateProfitImpact(orderItem); 

                                    var dailySale = _dbContext.DailySales.FirstOrDefault(ds => ds.Date == orderDate);

                                    if (dailySale != null)
                                    {
                                        dailySale.Profit -= profitImpact;

                                    }
                                double orderItemsTotalPrice = 0;
                                if (orderItem.InitialCost != null)
                                {
                                    double? discountUnitPrice = orderItem.UnitPriceAfterDiscount;
                                    if (discountUnitPrice != null && discountUnitPrice > 0)
                                    {
                                        orderItemsTotalPrice = (double)((discountUnitPrice) * orderItem.Quantity);
                                    }
                                    else
                                    {
                                        orderItemsTotalPrice = (double)((orderItem.Item.SellingPrice) * orderItem.Quantity);
                                    }
                                }
                                RemovingSalesFromTodaysSales(orderItemsTotalPrice);
                                _dbContext.OrderItems.Remove(orderItem);
                                _dbContext.SaveChanges();
                                filteredOrderViewModels.RemoveAt(e.RowIndex);
                                AllOrdersDataGridView.DataSource = filteredOrderViewModels;
                                var orderItemVM = orderViewModels.FirstOrDefault(o => o.OrderItemId == orderItemId);
                                if (orderItemVM != null)
                                {
                                    orderViewModels.Remove(orderItemVM);
                                }


                            }
                        }
                    }                    
                } else if (e.RowIndex >= 0 && e.ColumnIndex == AllOrdersDataGridView.Columns["DeleteButtonColumn"].Index && serviceIdColumnIndex != -1)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var serviceIdCell = AllOrdersDataGridView.Rows[e.RowIndex].Cells["ServiceId"].Value;
                        if (serviceIdCell != null)
                        {
                            int serviceId = int.Parse(serviceIdCell.ToString());
                            var service = _dbContext.Services.FirstOrDefault(o => o.ServiceId == serviceId);
                            if (service != null)
                            {
                                double? profitImpact = service.ServiceProfit;
                                if (profitImpact != null)
                                {
                                    var dailySale = _dbContext.DailySales.FirstOrDefault(ds => ds.Date == service.ServiceDate);

                                    if (dailySale != null)
                                    {
                                        dailySale.Profit -= profitImpact;

                                    }
                                }
                                RemovingSalesFromTodaysSales(service.ServiceSellingPrice);
                                _dbContext.Services.Remove(service);
                                _dbContext.SaveChanges();
                                filteredServices.RemoveAt(e.RowIndex);
                                AllOrdersDataGridView.DataSource = filteredServices;
                                _services.Remove(service);
                            }
                        }
                    }
                }
        }
        public double CalculateProfitImpact(OrderItem orderItem)
        {
            if (orderItem.InitialCost != null)
            {
                double? discountUnitPrice = orderItem.UnitPriceAfterDiscount;
                if (discountUnitPrice != null && discountUnitPrice > 0)
                {
                    return (double)((discountUnitPrice - orderItem.InitialCost) * orderItem.Quantity);
                }
                return (double)((orderItem.Item.SellingPrice - orderItem.InitialCost) * orderItem.Quantity);
            }
            return 0;
        }
        private void RemovingSalesFromTodaysSales(double totalSalesInUSD)
        {
            var todaysSale = _dbContext.DailySales.FirstOrDefault(s => s.Date == DateTime.Today.ToString("yyyy-MM-dd"));
            if (todaysSale != null)
            {
                todaysSale.TotalSales = todaysSale.TotalSales - totalSalesInUSD;
                _dbContext.SaveChanges();
            }
            else
            {
                DailySale newDailySale = new DailySale
                {
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    Profit = 0,
                    TotalSales = -totalSalesInUSD,
                    StartingBalance = 0,
                    EndBalance = 0
                };
                _dbContext.DailySales.Add(newDailySale);
                _dbContext.SaveChanges();
            }
        }
        private void AllOrdersDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            originalValue = AllOrdersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        private void AllOrdersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                var orderItemIdCell = AllOrdersDataGridView.Rows[rowIndex].Cells["OrderItemId"].Value;
                string columnName = AllOrdersDataGridView.Columns[columnIndex].Name;
                DataGridViewCell editedCell = AllOrdersDataGridView.Rows[rowIndex].Cells[columnIndex];
                object cellValue = editedCell.Value;
                object previousValue = originalValue;
                if (orderItemIdCell != null)
                {
                    if (orderItemIdCell.ToString() != "")
                    {
                        int orderItemId = int.Parse(orderItemIdCell.ToString());
                        var selectedOi = _dbContext.OrderItems.Where(s => s.OrderItemId == orderItemId).FirstOrDefault();
                        if (selectedOi != null)
                        {
                            selectedOi = ValidateAndSetPropertyValue(selectedOi, editedCell, columnName, cellValue, previousValue);
                            _dbContext.SaveChanges();
                        }
                    }
                }
        }

        private OrderItem ValidateAndSetPropertyValue(OrderItem newOi, DataGridViewCell editedCell, string columnName, object cellValue, object previousValue)
        {
            if (cellValue != null && columnName != null && editedCell != null)
            {
                switch (columnName)
                {
                    case "TotalPriceAfterDiscount":
                        if (double.TryParse(cellValue.ToString(), out double price))
                        {
                            newOi.TotalPriceAfterDiscount = price;
                            var dailySale = _dbContext.DailySales.FirstOrDefault(ds => ds.Date == newOi.Order.OrderDate);

                            if (dailySale != null)
                            {
                                dailySale.Profit += price / newOi.Quantity - newOi.UnitPriceAfterDiscount;

                            }
                            var todaysSale = _dbContext.DailySales.FirstOrDefault(s => s.Date == DateTime.Today.ToString("yyyy-MM-dd"));
                            if (todaysSale != null)
                            {
                                todaysSale.TotalSales = todaysSale.TotalSales + price / newOi.Quantity - newOi.UnitPriceAfterDiscount;
                                _dbContext.SaveChanges();
                            }
                            else
                            {
                                DailySale newDailySale = new DailySale
                                {
                                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                                    Profit = 0,
                                    TotalSales = price / newOi.Quantity - newOi.UnitPriceAfterDiscount,
                                    StartingBalance = 0,
                                    EndBalance = 0
                                };
                                _dbContext.DailySales.Add(newDailySale);
                                _dbContext.SaveChanges();
                            }
                            newOi.UnitPriceAfterDiscount = price / newOi.Quantity;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Total In Usd (decimal).");
                            editedCell.Value = previousValue;
                            return null;
                        }
                        break;
                }
            }
            return newOi;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            GeneralFunctions.NavigateToIntroForm(_dbContext, this);
        }

        private void ViewServicesBtn_Click(object sender, EventArgs e)
        {
            
            //datePicker.Value = DateTime.Today;
            LoadAllServices();
            filteredServices = FilterServicesByDate(datePicker.Value);
            PopulateDataGridView(filteredServices);
           
        }

        private void viewOrdersBtn_Click(object sender, EventArgs e)
        {
            //datePicker.Value = DateTime.Today;
            LoadAllOrders();
            filteredOrderViewModels = FilterOrdersByDate(datePicker.Value);
            PopulateDataGridView(filteredOrderViewModels);

        }

        private void AllOrdersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
