using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Common_Functions;
using SM.ViewModels;
using SMDataLayer.Models;

namespace SM
{
    public partial class InventoryForm : Form
    {
        private ClothingStoreContext _dbContext;
        List<Inventory> inventories;
        List<Supplier> suppliers;
        BindingList<InventoryViewModel> bindingList;
        private bool OpenMode = true;
        BindingSource source;
        int? selectedProductId;
        //private bool enterKeyPressed = false;
        public bool SelectedRow = false;
        private int? previouslySelectedRowIndex = null;
        public InventoryForm(ClothingStoreContext dbContext, bool openMode, int productId)
        {
            InitializeComponent();
            _dbContext = dbContext;
            OpenMode = openMode;
            inventories = _dbContext.Inventories.ToList();
            var sortedInventories = inventories.OrderBy(inventory => inventory.QuantityInStock == 0 ? 0 : 1)
                                                  .ThenBy(inventory => inventory.QuantityInStock);
            bindingList = new BindingList<InventoryViewModel>(
            sortedInventories.Select(inventory => new InventoryViewModel
            {
                InventoryId = inventory.InventoryId,
                ProductId = inventory.ProductId,
                ProductName = inventory.Product?.Name,
                ProductDescription = inventory.Product?.Description,
                BarcodeId = inventory.Product?.BarcodeId,
                SupplierName = inventory.Supplier?.Name,
                SupplierId = inventory.Supplier?.SupplierId,
                QuantityInStock = inventory.QuantityInStock,
                CategoryName = inventory.Product?.Category?.Name
            }).ToList());


            LoadInventories();
           // InventoryDataGridView.KeyPress += InventoryDataGridView_KeyPress;
            InventoryDataGridView.CellClick += InventoryDataGridView_CellClick;
            InventoryDataGridView.CellEndEdit += InventoryDataGridView_CellEndEdit;
            InventoryDataGridView.CellBeginEdit += InventoryDataGridView_CellBeginEdit;
            InventoryDataGridView.CellFormatting += InventoryDataGridView_CellFormatting;
            InventoryDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(179, 186, 200);
            InventoryDataGridView.DefaultCellStyle.SelectionForeColor = InventoryDataGridView.DefaultCellStyle.ForeColor;
            InventoryDataGridView.CellMouseMove += new DataGridViewCellMouseEventHandler(InventoryDataGridView_CellMouseMove);
            InventoryDataGridView.CellMouseLeave += new DataGridViewCellEventHandler(InventoryDataGridView_CellMouseLeave);
            if (openMode == false && productId != null)
            {
                selectedProductId = productId;
                SelectInventory(productId);
            }


        }
 

        private int? hoveredRowIndex = null;


        private void InventoryDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, InventoryDataGridView);
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = InventoryDataGridView.Rows[e.RowIndex];

                // Skip the custom formatting for the hovered row to allow the hover color to show
                if (hoveredRowIndex.HasValue && hoveredRowIndex.Value == e.RowIndex)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(179, 186, 200); ;
                    return;
                }

                DataGridViewColumn column = InventoryDataGridView.Columns[e.ColumnIndex];
                if (selectedProductId != null && e.ColumnIndex == InventoryDataGridView.Columns["ProductId"].Index && e.Value != null && (long)e.Value == selectedProductId)
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 250);
                    previouslySelectedRowIndex = e.RowIndex;
                    return;

                }
                else if (column.Name == "QuantityInStock" && e.RowIndex != previouslySelectedRowIndex)
                {
                    if (long.TryParse(e.Value?.ToString(), out long quantity) && quantity == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                    }

                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }


            }
        }

        private void InventoryDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                hoveredRowIndex = e.RowIndex; // Track the hovered row
                InventoryDataGridView.InvalidateRow(e.RowIndex); // Trigger a repaint for the row to apply hover color
            }
        }

        private void InventoryDataGridView_CellMouseLeave(object sender, EventArgs e)
        {
            if (hoveredRowIndex.HasValue)
            {
                int rowIndex = hoveredRowIndex.Value;
                hoveredRowIndex = null; // Reset the hover tracking
                InventoryDataGridView.InvalidateRow(rowIndex); // Trigger a repaint for the row to revert color
            }
        }

        private void LoadInventories()
        {

            InventoryDataGridView.AutoGenerateColumns = false;

            InventoryDataGridView.Columns.Clear();

            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Inventory ID",
                DataPropertyName = "InventoryId",
                Name = "InventoryId",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                ReadOnly = true,
                Visible = false
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product ID",
                DataPropertyName = "ProductId",
                Name = "ProductId",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Barcode ID",
                DataPropertyName = "BarcodeId",
                Name = "BarcodeId",
                ReadOnly = true
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product Name",
                DataPropertyName = "ProductName",
                Name = "ProductName",
                ReadOnly = true
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                DataPropertyName = "ProductDescription",
                Name = "ProductDescription",
                ReadOnly = true
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Supplier Name",
                DataPropertyName = "SupplierName",
                Name = "SupplierName",
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Category Name",
                DataPropertyName = "CategoryName",
                Name = "CategoryName",
                ReadOnly = true
            });
            InventoryDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity In Stock",
                DataPropertyName = "QuantityInStock",
                Name = "QuantityInStock"
            });
            InventoryDataGridView.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = " ",
                Name = "GoToProductBtn",
                Text = "Go to Product",
                UseColumnTextForButtonValue = true
            });
            InventoryDataGridView.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = " ",
                Name = "DeleteButtonColumn",
                Width = 100 
            });

            source = new BindingSource(bindingList, null);
            InventoryDataGridView.DataSource = source;

        }

        private void InventoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (previouslySelectedRowIndex != null)
                {
                    DataGridViewRow row = InventoryDataGridView.Rows[previouslySelectedRowIndex.Value];
                    int productId = Convert.ToInt32(row.Cells["ProductId"].Value);

                    if (selectedProductId != null && selectedProductId == productId)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        selectedProductId = null;
                    }
                }
            }
            // Check if a valid cell is clicked and it's not a header or empty row
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && InventoryDataGridView.Columns[e.ColumnIndex].Name == "SupplierName")
            {
                // Open the Supplier form and get the selected supplier ID and name
                (int? supplierID, string supplierName) = OpenSupplierForm();

                // If a supplier is selected, update the inventory row with the chosen supplier
                if (supplierID != null)
                {
                    DataGridViewRow selectedRow = InventoryDataGridView.Rows[e.RowIndex];
                    var inventoryIdCell = selectedRow.Cells["InventoryId"].Value;
                    int? inventoryId = DataGridViewFunctions.FormatIdToValidOne(inventoryIdCell);

                    // Retrieve the corresponding inventory object from the database
                    var inventory = _dbContext.Inventories.FirstOrDefault(o => o.InventoryId == inventoryId);

                    // If the inventory exists, update its supplier ID
                    if (inventory != null)
                    {
                        inventory.SupplierId = (int)supplierID;
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        CreateNewInventory(e.RowIndex, InventoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex], "SupplierName", supplierName, "");
                    }
                    var selectedRowViewModel = bindingList[e.RowIndex];
                    selectedRowViewModel.SupplierName = supplierName;
                }
                InventoryDataGridView.Refresh();
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == InventoryDataGridView.Columns["GoToProductBtn"].Index)
            {
                DataGridViewRow selectedRow = InventoryDataGridView.Rows[e.RowIndex];
                var productIdCell = selectedRow.Cells["ProductId"].Value;
                if (productIdCell != null)
                {
                    int? productId = DataGridViewFunctions.FormatIdToValidOne(productIdCell);
                    if (productId != null)
                    {
                        ProductsForm productsForm = new ProductsForm(_dbContext, productId);
                        productsForm.Show();
                        this.Hide();
                    }
                }
            }
            InventoryDataGridView.ClearSelection();
        }

        private void SelectInventory(int productId)
        {
            int index = bindingList.ToList().FindIndex(item => item.ProductId == productId);

            if (index != -1)
            {
                source.Position = index + 11;
            }
        }

        private (int? SupplierID, string SupplierName) OpenSupplierForm()
        {
            IntroForm.cachedSuppliersForm= new SuppliersForm(_dbContext, false) as SuppliersForm;

            if (IntroForm.cachedSuppliersForm.ShowDialog() == DialogResult.OK)
            {
                // Retrieve selected supplier data from SupplierForm
                int? supplierID = DataGridViewFunctions.FormatIdToValidOne(IntroForm.cachedSuppliersForm.SelectedSupplierId);
                string supplierName = IntroForm.cachedSuppliersForm.SelectedSupplierName;
                return (supplierID, supplierName);
            }
            return (null, null);
        }

        private void InventoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                if (e.RowIndex >= 0 && e.ColumnIndex == InventoryDataGridView.Columns["DeleteButtonColumn"].Index)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this inventory?","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var inventoryIdCell = InventoryDataGridView.Rows[e.RowIndex].Cells["InventoryId"].Value;

                        if (inventoryIdCell != null)
                        {
                            int? inventoryId = DataGridViewFunctions.FormatIdToValidOne(inventoryIdCell);

                            var inventory = _dbContext.Inventories.FirstOrDefault(o => o.InventoryId == inventoryId);

                            if (inventory != null)
                            {
                                _dbContext.Inventories.Remove(inventory);
                                _dbContext.SaveChanges();
                                DataGridViewFunctions.DeleteRowFromDataGridView(e.RowIndex, InventoryDataGridView);
                                MessageBox.Show("Inventory deleted successfully.");
                            }
                        }
                }
                }
                InventoryDataGridView.ClearSelection();
        }

        private object originalValue;

        private void InventoryDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            originalValue = InventoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        private void InventoryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                var inventoryIdCell = InventoryDataGridView.Rows[rowIndex].Cells["InventoryId"].Value;
                string columnName = InventoryDataGridView.Columns[columnIndex].Name;
                DataGridViewCell editedCell = InventoryDataGridView.Rows[rowIndex].Cells[columnIndex];
                object cellValue = editedCell.Value;
                object previousValue = originalValue;

                if (inventoryIdCell == null || int.Parse(inventoryIdCell?.ToString()) == 0)
                {
                    CreateNewInventory(rowIndex,editedCell, columnName, cellValue, previousValue);
                }
                else
                {
                    if (inventoryIdCell.ToString() != "")
                    {
                        int? inventoryId = DataGridViewFunctions.FormatIdToValidOne(inventoryIdCell);
                        var selectedInventory = _dbContext.Inventories.Where(s => s.InventoryId == inventoryId).FirstOrDefault();
                        if (selectedInventory != null)
                        {
                            ValidateAndSetPropertyValue(selectedInventory, editedCell, columnName, cellValue, previousValue);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                InventoryDataGridView.ClearSelection();

        }
        public void CreateNewInventory(int rowIndex, DataGridViewCell editedCell, string columnName, object cellValue, object? previousValue)
        {
            Inventory newInventory = new Inventory();
            if(columnName != "SupplierName")
            ValidateAndSetPropertyValue(newInventory, editedCell, columnName, cellValue, previousValue);
            var existingInventory = _dbContext.Inventories.FirstOrDefault(inv => inv.ProductId == newInventory.ProductId);

            if (existingInventory != null)
            {
                DialogResult result = MessageBox.Show("There is already an inventory for this product. Do you want to create a second one?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    InventoryDataGridView.Rows[rowIndex].Cells["ProductId"].Value = "";
                    return;
                }
                if (result == DialogResult.Yes)
                {
                    _dbContext.Inventories.Add(newInventory);
                    _dbContext.SaveChanges();
                    InventoryDataGridView.Rows[rowIndex].Cells["InventoryId"].Value = newInventory.InventoryId;
                }
            }
        }
        private void ValidateAndSetPropertyValue(Inventory newInventory, DataGridViewCell editedCell, string columnName, object cellValue, object previousValue)
        {
            if (cellValue != null && columnName != null && editedCell != null)
            {
                switch (columnName)
                {
                    case "ProductId":
                        if (int.TryParse(cellValue.ToString(), out int productId))
                        {
                            int? productID = DataGridViewFunctions.FormatIdToValidOne(cellValue);
                            var productExists = _dbContext.Products.Any(p => p.ProductId == productID);

                            if (!productExists)
                            {
                                MessageBox.Show("The product does not exist. Please enter a valid ProductId.");
                                editedCell.Value = previousValue;
                                return;
                            }
                            else
                            {
                                newInventory.ProductId = productID;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid ProductId (integer).");
                            editedCell.Value = previousValue;
                            return;
                        }
                        break;

                    case "QuantityInStock":
                        if (int.TryParse(cellValue.ToString(), out int quantityInStock))
                        {
                            newInventory.QuantityInStock = quantityInStock;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid QuantityInStock (integer).");
                            editedCell.Value = previousValue;
                            return;
                        }
                        break;

                    case "LastRestockedDate":
                        if (DateTime.TryParse(cellValue.ToString(), out DateTime lastRestockedDate))
                        {
                            newInventory.LastRestockedDate = lastRestockedDate.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid LastRestockedDate (date).");
                            editedCell.Value = previousValue;
                            return;
                        }
                        break;

                    case "ReorderThreshold":
                        if (DateTime.TryParse(cellValue.ToString(), out DateTime reorderThreshold))
                        {
                            newInventory.ReorderThreshold = reorderThreshold.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid ReorderThreshold (date).");
                            editedCell.Value = previousValue;
                            return;
                        }
                        break;

                    case "Price":
                        if (double.TryParse(cellValue.ToString(), out double price))
                        {
                            newInventory.Price = price;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Price (decimal).");
                            editedCell.Value = previousValue;
                            return;
                        }
                        break;

                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GeneralFunctions.NavigateToIntroForm(_dbContext, this);
        }

        private void productNameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterInventories<InventoryViewModel>(productNameSearchTextBox.Text, InventoryViewModel.FilterType.ProductName, InventoryDataGridView, bindingList);
        }

        private void productDescSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterInventories<InventoryViewModel>(productDescSearchTextBox.Text, InventoryViewModel.FilterType.ProductDescription, InventoryDataGridView, bindingList);
        }

        private void productBarcodeSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterInventories<InventoryViewModel>(productBarcodeSearchTextBox.Text, InventoryViewModel.FilterType.BarcodeId, InventoryDataGridView, bindingList);
        }

        private void CategoryNameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterInventories<InventoryViewModel>(categoryNameSearchTextBox.Text, InventoryViewModel.FilterType.CategoryName, InventoryDataGridView, bindingList);
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            InventoryDataGridView.ClearSelection();
        }

        //private void InventoryDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //    {
        //        InventoryDataGridView.ClearSelection();
        //        customLabel3.Select();
        //        e.Handled = true;
        //    }
        //}
    }
}
