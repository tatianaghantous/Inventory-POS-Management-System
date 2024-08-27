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
using SMDataLayer.Models;

namespace SM
{
    public partial class CategoriesForm : Form
    {
        private ClothingStoreContext _dbContext;
        private List<Category> _categories;
        private bool OpenMode = true;
        public string? SelectedCategoryName { get; private set; }
        public string? SelectedCategoryId { get; private set; }
        public CategoriesForm(ClothingStoreContext dbContext, bool openMode)
        {
            InitializeComponent();
            _dbContext = dbContext;
            OpenMode = openMode;
            _categories = _dbContext.Categories.ToList();
            LoadCategories();
            if(!OpenMode)
            CategoriesDataGridView.CellClick += CategoryIdDataGridView_CellClick;
            CategoriesDataGridView.CellEndEdit += CategoriesDataGridView_CellEndEdit;
            CategoriesDataGridView.DefaultCellStyle.SelectionBackColor = CategoriesDataGridView.DefaultCellStyle.BackColor;
            CategoriesDataGridView.DefaultCellStyle.SelectionForeColor = CategoriesDataGridView.DefaultCellStyle.ForeColor;

        }

        private void CategoriesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, CategoriesDataGridView);
        }


        private void LoadCategories()
        {

                CategoriesDataGridView.AutoGenerateColumns = false;

                CategoriesDataGridView.Columns.Clear();

                CategoriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Category ID",
                    DataPropertyName = "CategoryId",
                    Name = "CategoryId",
                    ReadOnly = true,
                    Visible = false
                });

                CategoriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    DataPropertyName = "Name",
                    Name = "Name"
                });
                CategoriesDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Gender",
                    DataPropertyName = "Gender",
                    Name = "Gender"
                });

                CategoriesDataGridView.Columns.Add(new DataGridViewImageColumn
                {
                    HeaderText = " ",
                    Name = "DeleteButtonColumn",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 100 // Adjust width as needed
                });

                var bindingList = new BindingList<Category>(_categories);
                var source = new BindingSource(bindingList, null);

                CategoriesDataGridView.DataSource = source;

        }

        private void CategoryIdDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is clicked and it's not a header row
            if (e.RowIndex >= 0 && e.RowIndex < CategoriesDataGridView.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = CategoriesDataGridView.Rows[e.RowIndex];

                // Extract data from the selected row
                SelectedCategoryName = selectedRow.Cells["Name"].Value.ToString();
                SelectedCategoryId = selectedRow.Cells["CategoryId"].Value.ToString();

                // Close the SupplierForm when the user clicks on a row
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void CategoriesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                var catIdCell = CategoriesDataGridView.Rows[e.RowIndex].Cells["CategoryId"].Value;
                if (e.ColumnIndex == CategoriesDataGridView.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0 && catIdCell != null)
                {

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (catIdCell != null)
                        {
                            int? catId = DataGridViewFunctions.FormatIdToValidOne(catIdCell);

                            bool hasProduct = _dbContext.Products.Any(oi => oi.CategoryId == catId);
                            if (hasProduct)
                            {
                                MessageBox.Show("You can't delete this category because there is a product referencing it.");
                            }
                            else
                            {
                                var category = _dbContext.Categories.FirstOrDefault(o => o.CategoryId == catId);
                                if (category != null)
                                {
                                    _dbContext.Categories.Remove(category);
                                    _dbContext.SaveChanges();
                                    DataGridViewFunctions.DeleteRowFromDataGridView(e.RowIndex, CategoriesDataGridView);
                                }
                            }
                        }
                    }
                }
        }
  
        private void CategoriesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
 
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                var catIdCell = CategoriesDataGridView.Rows[rowIndex].Cells["CategoryId"].Value;
                string columnName = CategoriesDataGridView.Columns[columnIndex].Name;
                DataGridViewCell editedCell = CategoriesDataGridView.Rows[rowIndex].Cells[columnIndex];
                object cellValue = editedCell.Value;
                if (catIdCell == null || int.Parse(catIdCell.ToString()) == 0)
                {
                    Category newCategory = new Category();
                    switch (columnName)
                    {
                        case "Name": newCategory.Name = cellValue.ToString(); break;
                        case "Gender": newCategory.Gender = cellValue.ToString(); break;
                    }
                    _dbContext.Categories.Add(newCategory);
                    _dbContext.SaveChanges();
                    CategoriesDataGridView.Rows[rowIndex].Cells["CategoryId"].Value = newCategory.CategoryId;
                }
                else
                {
                    if (catIdCell.ToString() != "")
                    {
                        int? categoryId = DataGridViewFunctions.FormatIdToValidOne(catIdCell);
                        var selectedCategory = _dbContext.Categories.Where(s => s.CategoryId == categoryId).FirstOrDefault();
                        if (selectedCategory != null)
                        {
                            switch (columnName)
                            {
                                case "CatName": selectedCategory.Name = cellValue?.ToString(); break;
                                case "Gender": selectedCategory.Gender = cellValue?.ToString(); break;                              
                            }
                            _dbContext.SaveChanges();

                        }
                    }
                }
             
        }

        private void categorySearchTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterCategoriesOnName(categorySearchTextBox.Text);
        }
        private void FilterCategoriesOnName(string filter)
        {
            var filteredCategories = string.IsNullOrWhiteSpace(filter) ?
                _categories :
                _categories.Where(p => !string.IsNullOrWhiteSpace(p.Name) &&
                                    p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            var bindingList = new BindingList<Category>(filteredCategories);
            var source = new BindingSource(bindingList, null);
            CategoriesDataGridView.DataSource = source;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            if (OpenMode)
                GeneralFunctions.NavigateToIntroForm(_dbContext, this);
            else this.Hide();
        }
    }
}
