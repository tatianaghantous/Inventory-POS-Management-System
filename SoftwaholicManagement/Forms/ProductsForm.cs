using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Common_Functions;
using SM.Customization;
using SM.ViewModels;
using SMDataLayer.Models;
using static SM.Common_Functions.DataGridViewFunctions;
using SM.ViewModels;

namespace SM
{
    public partial class ProductsForm : Form
    {
        private ClothingStoreContext _dbContext;
        List<Product> _products;
        static BindingList<ProductViewModel>? bindingList;
        static BindingSource source;
        long? selectedProductId;
        public string? chosenProductBarcode;
        private int? previouslySelectedRowIndex = null;
        public ProductsForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _products = _dbContext.Products.ToList();
            bindingList = new BindingList<ProductViewModel>(
            _products.Select(product => new ProductViewModel
            {
                ProductId = product.ProductId,
                BarcodeId = product.BarcodeId,
                Name = product.Name,
                Description = product.Description,
                Size = product.Size,
                Color = product.Color,
                SellingPrice = product.SellingPrice,
                InitialPrice = product.InitialPrice,
                CategoryName = product?.Category?.Name,
            }).ToList());
            exitLabel.Hide();
                InitializeDataGridViewEditMode();
            ProductsDataGridView.DefaultCellStyle.SelectionBackColor = ProductsDataGridView.DefaultCellStyle.BackColor;
            ProductsDataGridView.DefaultCellStyle.SelectionForeColor = ProductsDataGridView.DefaultCellStyle.ForeColor;
            ProductsDataGridView.CellMouseMove += new DataGridViewCellMouseEventHandler(ProductsDataGridView_CellMouseMove); 
            ProductsDataGridView.CellMouseLeave += new DataGridViewCellEventHandler(ProductsDataGridView_CellMouseLeave);

            //// Create new Product instances from ProductViewModel
            //var productList = bindingList.ToList();
            //foreach (var entry in _dbContext.ChangeTracker.Entries<Product>().ToList())
            //{
            //    _dbContext.Entry(entry.Entity).State = EntityState.Detached;
            //}

            //_dbContext.Update(productList.Where(p=>p.ProductId == 1));


        }
        public ProductsForm(ClothingStoreContext dbContext, long? productId) : this(dbContext)
        {
            if (productId.HasValue)
            {
                selectedProductId = productId.Value;
                SelectProduct(productId.Value);
            }
        }
        public ProductsForm(ClothingStoreContext dbContext,Category category) 
        {
            InitializeComponent();
            _dbContext = dbContext;
            _products = _dbContext.Products.ToList();
            InitializeDataGridViewViewMode(category.CategoryId);
            DesignForViewMode();

        }
        private void InitializeDataGridViewEditMode()
        {
            LoadProducts(_products, ProductsDataGridView);
            ProductsDataGridView.CellClick += ProductsDataGridView_CellClick;
            ProductsDataGridView.CellContentClick += ProductsDataGridView_CellContentClick;
            ProductsDataGridView.CellEndEdit += ProductsDataGridView_CellEndEdit;
            ProductsDataGridView.CellBeginEdit += ProductsDataGridView_CellBeginEdit;
            ProductsDataGridView.CellFormatting += ProductsDataGridView_CellFormatting;
            ProductsDataGridView.DataError += ProductsDataGridView_DataError;
        }
        private void InitializeDataGridViewViewMode(long categoryId)
        {
            ProductsDataGridView.CellClick += ProductsDataGridView_RowClick;
            ProductsDataGridView.DefaultCellStyle.SelectionBackColor = ProductsDataGridView.DefaultCellStyle.BackColor;
            ProductsDataGridView.DefaultCellStyle.SelectionForeColor = ProductsDataGridView.DefaultCellStyle.ForeColor;
            ProductsDataGridView.CellMouseMove += new DataGridViewCellMouseEventHandler(ProductsDataGridView_CellMouseMove);
            ProductsDataGridView.CellMouseLeave += new DataGridViewCellEventHandler(ProductsDataGridView_CellMouseLeave);
            LoadProductsForNewOrder(_products.Where(p => p.CategoryId == categoryId).ToList(), ProductsDataGridView);

        }


        private void DesignForViewMode()
        {

            backButton.Hide();
            categoryNameSearchTextBox.Hide();
            categoryLabel.Hide();
            ProdFLabel.Hide();

            CustomLabel titleLabel = new CustomLabel("CHOOSE PRODUCT");
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Sylfaen", 21, FontStyle.Bold);
            tableLayoutPanel1.SetColumnSpan(titleLabel, 3);
            tableLayoutPanel1.Controls.Add(titleLabel, 3, 0);

        }
        private void ProductsDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Change row color and cursor on hover
            if (e.RowIndex >= 0)
            {
                ProductsDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(179, 186, 200);
                ProductsDataGridView.Cursor = Cursors.Hand;
            }
        }

        protected new void ProductsDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Reset row color and cursor when the mouse leaves
            if (e.RowIndex >= 0)
            {
                ProductsDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = ProductsDataGridView.DefaultCellStyle.BackColor;
                ProductsDataGridView.Cursor = Cursors.Default;
            }
        }
        private void ProductsDataGridView_RowClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ProductsDataGridView.Rows.Count - 1 && ProductsDataGridView.Rows[e.RowIndex].Cells["BarcodeId"].Value != null)
            {
                DataGridViewRow selectedRow = ProductsDataGridView.Rows[e.RowIndex];

                chosenProductBarcode = selectedRow.Cells["BarcodeId"].Value.ToString();

                // Close the SupplierForm when the user clicks on a row
                DialogResult = DialogResult.OK;
                Close();               
            }
        }
            private void ProductsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, ProductsDataGridView);
            DataGridViewRow row = ProductsDataGridView.Rows[e.RowIndex];
            if (selectedProductId != null && e.ColumnIndex == ProductsDataGridView.Columns["ProductId"].Index && e.Value != null && (long)e.Value == selectedProductId)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 250); // Lighter blue color
                previouslySelectedRowIndex = e.RowIndex;

            }
        }
        private void ProductsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewFunctions.DataGridView_DataError(sender, e);
        }


        public static void LoadProducts(List<Product> _products, DataGridView dgv)
        {

            dgv.AutoGenerateColumns = false;

            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product ID",
                DataPropertyName = "ProductId",
                Name = "ProductId",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Barcode ID",
                DataPropertyName = "BarcodeId",
                Name = "BarcodeId"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                Name = "Name"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                DataPropertyName = "Description",
                Name = "Description"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Size",
                DataPropertyName = "Size",
                Name = "Size"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Color",
                DataPropertyName = "Color",
                Name = "Color"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Category Name",
                DataPropertyName = "CategoryName",
                Name = "CategoryName"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Selling Price",
                DataPropertyName = "SellingPrice",
                Name = "SellingPrice"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Initial Price",
                DataPropertyName = "InitialPrice",
                Name = "InitialPrice"
            });
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "GoToInventoryBtn",
                Text = "Go to Inventory",
                UseColumnTextForButtonValue = true
        });
            dgv.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = " ",
                Name = "DeleteButtonColumn",
                Width = 100 // Adjust width as needed
            });

            source = new BindingSource(bindingList, null);

            dgv.DataSource = source;

        }

        public static void LoadProductsForNewOrder(List<Product> _products, DataGridView dgv)
        {

            dgv.AutoGenerateColumns = false;

            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product ID",
                DataPropertyName = "ProductId",
                Name = "ProductId",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                ReadOnly = true,
                Visible = false,
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Barcode ID",
                DataPropertyName = "BarcodeId",
                Name = "BarcodeId",
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                Name = "Name",
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Description",
                DataPropertyName = "Description",
                Name = "Description",
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Size",
                DataPropertyName = "Size",
                Name = "Size",
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Color",
                DataPropertyName = "Color",
                Name = "Color",
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Category Name",
                DataPropertyName = "CategoryName",
                Name = "CategoryName",
                Visible = false,
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Selling Price",
                DataPropertyName = "SellingPrice",
                Name = "SellingPrice",
                ReadOnly = true
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Initial Price",
                DataPropertyName = "InitialPrice",
                Name = "InitialPrice",
                Visible = false,
            });
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "GoToInventoryBtn",
                Text = "Go to Inventory",
                UseColumnTextForButtonValue = true,
                Visible = false,
            });

            source = new BindingSource(_products, null);

            dgv.DataSource = source;


        }
        private void ProductsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (previouslySelectedRowIndex != null)
                {
                    DataGridViewRow row = ProductsDataGridView.Rows[previouslySelectedRowIndex.Value];
                    int productId = Convert.ToInt32(row.Cells["ProductId"].Value);

                    if (selectedProductId != null && selectedProductId == productId)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        selectedProductId = null;
                    }
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && ProductsDataGridView.Columns[e.ColumnIndex].Name == "CategoryName")
            {
                (int? CategoryId, string CategoryName) = OpenCategoriesForm();

                if (CategoryId != null)
                {
                    DataGridViewRow selectedRow = ProductsDataGridView.Rows[e.RowIndex];
                    var productIdCell = selectedRow.Cells["ProductId"].Value;
                    int? productId = DataGridViewFunctions.FormatIdToValidOne(productIdCell);

                    var product = _dbContext.Products.FirstOrDefault(o => o.ProductId == productId);

                    if (product != null)
                    {
                        product.CategoryId = (int)CategoryId;
                        _dbContext.SaveChanges();

                    }
                    else
                    {
                        CreateNewProduct(e.RowIndex, productIdCell, "CategoryId" , ProductsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex], CategoryId, "");
                    }
                    var selectedRowViewModel = bindingList[e.RowIndex];
                    selectedRowViewModel.CategoryName = CategoryName;
                    ProductsDataGridView.Refresh();
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == ProductsDataGridView.Columns["GoToInventoryBtn"].Index)
            {
                DataGridViewRow selectedRow = ProductsDataGridView.Rows[e.RowIndex];
                var productIdCell = selectedRow.Cells["ProductId"].Value;
                if (productIdCell != null)
                {
                    int? productId = DataGridViewFunctions.FormatIdToValidOne(productIdCell);
                    if (productId != null)
                    {
                        InventoryForm InventoryForm = new InventoryForm(_dbContext, false, (int)productId);
                        InventoryForm.Show();
                        this.Hide();
                    }
                }
            }
        }
        private void SelectProduct(long productId)
        {
            int index = bindingList.ToList().FindIndex(item => item.ProductId == productId);

            if (index != -1)
            {
                source.Position = index + 11;
            }
        }
        private (int? CategoryId, string CategoryName) OpenCategoriesForm()
        {
            IntroForm.cachedCategoriesForm = new CategoriesForm(_dbContext, false) as CategoriesForm;

            if (IntroForm.cachedCategoriesForm.ShowDialog() == DialogResult.OK)
            {
                int? CategoryId = DataGridViewFunctions.FormatIdToValidOne(IntroForm.cachedCategoriesForm.SelectedCategoryId);
                string CategoryName = IntroForm.cachedCategoriesForm.SelectedCategoryName;
                return (CategoryId, CategoryName);
            }
            return (null, null);
        }

        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
   
            if (e.RowIndex >= 0 && e.ColumnIndex == ProductsDataGridView.Columns["DeleteButtonColumn"].Index)
            {
   
                    var productIdCell = ProductsDataGridView.Rows[e.RowIndex].Cells["ProductId"].Value;
                    if (productIdCell != null)
                    {
                        string productIdString = productIdCell.ToString();
                        productIdString = productIdString.Replace(",", "").Replace(".", "").Replace(" ", "");

                        if (int.TryParse(productIdString, out int productId))
                        {

                            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {

                                bool isProductReferenced = _dbContext.OrderItems.Any(oi => oi.ItemId == productId) ||
                                                           _dbContext.Inventories.Any(inv => inv.ProductId == productId && inv.QuantityInStock != 0) ||
                                                           _dbContext.Returns.Any(ret => ret.ReturnedProductId == productId);
                                if (isProductReferenced)
                                {
                                    MessageBox.Show("You can't delete this product because it is referenced in Order Items, Inventory, or Returns.");
                                }
                                else
                                {
                                    var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
                                    if (product != null)
                                    {
                                        _dbContext.Products.Remove(product);
                                        _dbContext.SaveChanges();
                                        DataGridViewFunctions.DeleteRowFromDataGridView(e.RowIndex, ProductsDataGridView);
                                        MessageBox.Show("Product deleted successfully.");
                                    }
                                }
                            }
                        }
                    }
            }
        }
        private object originalValue;

        private void ProductsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            originalValue = ProductsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }
        private void ProductsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                var productIdCell = ProductsDataGridView.Rows[rowIndex].Cells["ProductId"].Value;
                string columnName = ProductsDataGridView.Columns[columnIndex].Name;
                DataGridViewCell editedCell = ProductsDataGridView.Rows[rowIndex].Cells[columnIndex];
                object cellValue = editedCell.Value;
                object previousValue = originalValue;
                if (productIdCell != null && previousValue != null && previousValue.ToString() != null && columnName == "ProductId")
                {
                    MessageBox.Show("Product Id cannot be modified, you have to delete the product and recreate it");
                    editedCell.Value = previousValue;
                }
                else
                {
                    if (productIdCell != null)
                    {

                        if (productIdCell.ToString() != "")
                        {
                            string productIdString = productIdCell.ToString();
                            productIdString = productIdString.Replace(",", "").Replace(".", "").Replace(" ", "");

                            if (int.TryParse(productIdString, out int productId))
                            {

                                bool productIdAlreadyExist = SearchInColumn(productId, rowIndex);
                                if (productIdAlreadyExist)
                                {
                                    MessageBox.Show("Product Id already exists");
                                    editedCell.Value = previousValue != null ? previousValue : "";
                                }
                                else
                                {
                                    bool productExist = _dbContext.Products.Any(oi => oi.ProductId == productId);
                                    if (!productExist)
                                    {
                                        CreateNewProduct(rowIndex, productIdCell, columnName, editedCell, cellValue, previousValue);
                                    }
                                    else
                                    {
                                        var selectedProduct = _dbContext.Products.Where(s => s.ProductId == productId).FirstOrDefault();
                                        if (selectedProduct != null)
                                        {
                                            ValidateAndSetPropertyValue(selectedProduct, editedCell, columnName, cellValue, previousValue);
                                            _dbContext.SaveChanges();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a Product Id to add your product");
                    }
                
                }

        }

        private void CreateNewProduct(int rowIndex, object? productIdCell, string columnName, DataGridViewCell editedCell, object cellValue, object previousValue)
        {
            var barcodeIdCell = ProductsDataGridView.Rows[rowIndex].Cells["BarcodeId"];
            var barcodeIdCellValue = barcodeIdCell.Value;
            var categoryIdCell = ProductsDataGridView.Rows[rowIndex].Cells["CategoryName"];
            var categoryIdCellValue = categoryIdCell.Value;
            if (!int.TryParse(productIdCell.ToString(), out int pId))
            {
                MessageBox.Show("Please enter a valid ProductId (integer).");
                editedCell.Value = previousValue;
            }
            else if (barcodeIdCellValue == null || barcodeIdCellValue.ToString() == "")
            {
                MessageBox.Show("Please Enter The Barcode Id to add your product");
            }
            else if ((categoryIdCellValue == null || categoryIdCellValue.ToString() == "") && columnName != "CategoryId")
            {
                MessageBox.Show("Please Enter The Category to add your product");
            }
            else
            {
                Product newProduct = new Product();
                var nameCell = ProductsDataGridView.Rows[rowIndex].Cells["Name"];
                var descIdCell = ProductsDataGridView.Rows[rowIndex].Cells["Description"];
                var sizeCell = ProductsDataGridView.Rows[rowIndex].Cells["Size"];
                var colorCell = ProductsDataGridView.Rows[rowIndex].Cells["Color"];
                var sellingPCell = ProductsDataGridView.Rows[rowIndex].Cells["SellingPrice"];
                var initialPCell = ProductsDataGridView.Rows[rowIndex].Cells["InitialPrice"];
                newProduct = ValidateAndSetPropertyValue(newProduct, barcodeIdCell, "BarcodeId", barcodeIdCellValue, "");

                if (newProduct != null)
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, editedCell, columnName, cellValue, previousValue);
                }
                if (newProduct != null && nameCell != null && nameCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, nameCell, "Name", nameCell.Value, "");

                }
                if (newProduct != null && descIdCell != null && descIdCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, descIdCell, "Description", descIdCell.Value, "");
                }
                if (newProduct != null && sizeCell != null && sizeCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, sizeCell, "Size", sizeCell.Value, "");
                }
                if (newProduct != null && colorCell != null && colorCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, colorCell, "Color", colorCell.Value, "");
                }
                if (newProduct != null && sellingPCell != null && sellingPCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, sellingPCell, "SellingPrice", sellingPCell.Value, "");
                }
                if (newProduct != null && initialPCell != null && initialPCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, initialPCell, "InitialPrice", initialPCell.Value, "");
                }
                if (newProduct != null && initialPCell != null && initialPCell.ToString() != "")
                {
                    newProduct = ValidateAndSetPropertyValue(newProduct, initialPCell, "CategoryId", initialPCell.Value, "");
                }
                if (newProduct != null)
                {
                    //newProduct.ProductId = productId;
                    _dbContext.Products.Add(newProduct);
                    _dbContext.SaveChanges();
                    ProductsDataGridView.Rows[rowIndex].Cells["ProductId"].Value = newProduct.ProductId;
                    Inventory newInventoryEntry = new Inventory
                    {
                        ProductId = newProduct.ProductId,
                        QuantityInStock = 0
                    };

                    _dbContext.Inventories.Add(newInventoryEntry);
                    _dbContext.SaveChanges();
                }
            }
        }

        private Product ValidateAndSetPropertyValue(Product newProduct, DataGridViewCell editedCell, string columnName, object cellValue, object previousValue)
        {
            if (cellValue != null && columnName != null && editedCell != null)
            {
                switch (columnName)
                {
                    case "ProductId":

                        if (int.TryParse(cellValue.ToString(), out int productId))
                        {
                            int? productID = DataGridViewFunctions.FormatIdToValidOne(cellValue);
                            newProduct.ProductId = (int)productID;

                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid ProductId (integer).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "BarcodeId":
                        if (cellValue != null)
                        {
                            string newBarcodeId = cellValue.ToString();

                            if (!string.IsNullOrEmpty(newBarcodeId) && newBarcodeId.Length <= 50)
                            {
                                if (_dbContext.Products.Any(p => p.ProductId != newProduct.ProductId && p.BarcodeId == newBarcodeId))
                                {
                                    MessageBox.Show("BarcodeId already exists for another product.");
                                    editedCell.Value = previousValue != null ? previousValue : "";
                                    return null;
                                }
                                else
                                {
                                    newProduct.BarcodeId = newBarcodeId;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Barcode Id (maximum length: 50).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "Name":
                        if (cellValue != null)
                        {
                            string newName = cellValue.ToString();

                            if (!string.IsNullOrEmpty(newName) && newName.Length <= 50)
                            {
                                newProduct.Name = newName;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Name (maximum length: 50).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "CategoryId":
                        if (int.TryParse(cellValue.ToString(), out int categoryId))
                        {
                            int? categoryID = DataGridViewFunctions.FormatIdToValidOne(cellValue);
                            newProduct.CategoryId = (int)categoryID;

                        }
                        else
                        {
                            MessageBox.Show("Please enter a Valid Category.");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;



                    case "Description":
                        if (cellValue != null)
                        {
                            string newDescription = cellValue.ToString();

                            if (!string.IsNullOrEmpty(newDescription) && newDescription.Length <= 50)
                            {
                                newProduct.Description = newDescription;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Description (maximum length: 50).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "Size":
                        if (cellValue != null)
                        {
                            string newSize = cellValue.ToString();

                            if (!string.IsNullOrEmpty(newSize) && newSize.Length <= 50)
                            {
                                newProduct.Size = newSize;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Size (maximum length: 50).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "Color":
                        if (cellValue != null)
                        {
                            string newColor = cellValue.ToString();

                            if (!string.IsNullOrEmpty(newColor) && newColor.Length <= 50)
                            {
                                newProduct.Color = newColor;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Color (maximum length: 50).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "SellingPrice":
                        if (double.TryParse(cellValue.ToString(), out double sellingPrice))
                        {
                            newProduct.SellingPrice = sellingPrice;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Selling Price (decimal).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;

                    case "InitialPrice":
                        if (double.TryParse(cellValue.ToString(), out double initialPrice))
                        {
                            newProduct.InitialPrice = initialPrice;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Initial Price (decimal).");
                            editedCell.Value = previousValue != null ? previousValue : "";
                            return null;
                        }
                        break;
                }
            }
            return newProduct;
        }

        private bool SearchInColumn(int searchValue, int index)
        {

            string columnName = "ProductId";
            int columnIndexToSearch = ProductsDataGridView.Columns[columnName].Index;
            ProductsDataGridView.ClearSelection();


            foreach (DataGridViewRow row in ProductsDataGridView.Rows)
            {
                if (row.Cells[columnIndexToSearch].Value != null &&
                int.TryParse(row.Cells[columnIndexToSearch].Value.ToString(), out int cellValue) &&
                cellValue.Equals(searchValue) && row.Index != index)
                {
                    return true;
                }
            }
            return false;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
           GeneralFunctions.NavigateToIntroForm(_dbContext, this);

        }

        private void productNameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterProducts<ProductViewModel>(productNameSearchTextBox.Text, InventoryViewModel.FilterType.ProductName, ProductsDataGridView, bindingList);
        }

        private void productDescSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterProducts<ProductViewModel>(productDescSearchTextBox.Text, InventoryViewModel.FilterType.ProductDescription, ProductsDataGridView, bindingList);
        }

        private void productBarcodeSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterProducts<ProductViewModel>(productBarcodeSearchTextBox.Text, InventoryViewModel.FilterType.BarcodeId, ProductsDataGridView, bindingList);
        }

        private void CategoryNameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            DataGridViewFunctions.FilterProducts<ProductViewModel>(categoryNameSearchTextBox.Text, InventoryViewModel.FilterType.CategoryName, ProductsDataGridView, bindingList);
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProductsDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
