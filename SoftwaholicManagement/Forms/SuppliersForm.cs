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
    public partial class SuppliersForm : Form
    {
        private ClothingStoreContext _dbContext;
        public string? SelectedSupplierName { get; private set; }
        public string? SelectedSupplierId { get; private set; }
        private bool OpenMode = true;

        // Method to retrieve selected supplier data
        public SuppliersForm(ClothingStoreContext dbContext, bool openMode)
        {
            InitializeComponent();
            _dbContext = dbContext;
            OpenMode = openMode;
            LoadSuppliers();
            SuppliersDataGridView.CellEndEdit += SuppliersDataGridView_CellEndEdit;
            if (!openMode)
            SuppliersDataGridView.CellClick += supplierDataGridView_CellClick;
            Image cellImage = Image.FromFile("Assets\\bin.png");
            int columnIndex = 4;
            foreach (DataGridViewRow row in SuppliersDataGridView.Rows)
            {
                row.Cells[columnIndex].Value = cellImage;
            }
            SuppliersDataGridView.DefaultCellStyle.SelectionBackColor = SuppliersDataGridView.DefaultCellStyle.BackColor;
            SuppliersDataGridView.DefaultCellStyle.SelectionForeColor = SuppliersDataGridView.DefaultCellStyle.ForeColor;

        }

        private void LoadSuppliers()
        {

                string imagePath = "Assets\\bin.png";
                var suppliers = _dbContext.Suppliers.ToList();
                foreach (var supplier in suppliers)
                {
                    SuppliersDataGridView.Rows.Add(supplier.SupplierId, supplier.Name, supplier.ContactInformation, supplier.Location, System.Drawing.Image.FromFile(imagePath));
                }

        }
        private void supplierDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure a valid row is clicked and it's not a header row
            if (e.RowIndex >= 0 && e.RowIndex < SuppliersDataGridView.Rows.Count - 1)
            {
                DataGridViewRow selectedRow = SuppliersDataGridView.Rows[e.RowIndex];

                // Extract data from the selected row
                SelectedSupplierName = selectedRow.Cells["SupplierName"].Value.ToString();
                SelectedSupplierId = selectedRow.Cells["SupplierId"].Value.ToString();

                // Close the SupplierForm when the user clicks on a row
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void SuppliersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                var supplierIdCell = SuppliersDataGridView.Rows[e.RowIndex].Cells["SupplierId"].Value;
                if (e.ColumnIndex == SuppliersDataGridView.Columns["DeleteButtonColumn"].Index && e.RowIndex >= 0 && supplierIdCell != null)
                {

                    DialogResult result = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (supplierIdCell != null)
                        {
                            int? supplierId = DataGridViewFunctions.FormatIdToValidOne(supplierIdCell);

                            bool hasInventory = _dbContext.Inventories.Any(oi => oi.SupplierId == supplierId);
                            if (hasInventory)
                            {
                                MessageBox.Show("You can't delete this supplier because there is an Inventory referencing it.");
                            }
                            else
                            {
                                var supplier = _dbContext.Suppliers.FirstOrDefault(o => o.SupplierId == supplierId);
                                if (supplier != null)
                                {
                                    _dbContext.Suppliers.Remove(supplier);
                                    _dbContext.SaveChanges();
                                    DataGridViewFunctions.DeleteRowFromDataGridView(e.RowIndex, SuppliersDataGridView);
                                }
                            }
                        }
                    }
                }
        }

        private void SuppliersDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
 
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                var supplierIdCell = SuppliersDataGridView.Rows[rowIndex].Cells["SupplierId"].Value;
                string columnName = SuppliersDataGridView.Columns[columnIndex].Name;
                DataGridViewCell editedCell = SuppliersDataGridView.Rows[rowIndex].Cells[columnIndex];
                object cellValue = editedCell.Value;
                if (supplierIdCell == null)
                {
                    Supplier newSupplier = new Supplier();
                    switch (columnName)
                    {
                        case "SupplierName": newSupplier.Name = cellValue.ToString(); break;
                        case "ContactInformation": newSupplier.ContactInformation = cellValue.ToString(); break;
                        case "supplierLocation": newSupplier.Location = cellValue.ToString(); break;
                    }
                    _dbContext.Suppliers.Add(newSupplier);
                    _dbContext.SaveChanges();
                    SuppliersDataGridView.Rows[rowIndex].Cells["SupplierId"].Value = newSupplier.SupplierId;
                }
                else
                {
                    if (supplierIdCell.ToString() != "")
                    {
                        int? supplierId = DataGridViewFunctions.FormatIdToValidOne(supplierIdCell);
                        var selectedSupplier = _dbContext.Suppliers.Where(s => s.SupplierId == supplierId).FirstOrDefault();
                        if (selectedSupplier != null)
                        {
                            switch (columnName)
                            {
                                case "SupplierName": selectedSupplier.Name = cellValue.ToString(); break;
                                case "ContactInformation": selectedSupplier.ContactInformation = cellValue.ToString(); break;
                                case "supplierLocation": selectedSupplier.Location = cellValue.ToString(); break;
                            }
                            _dbContext.SaveChanges();
                        }
                    }
                }
                Image cellImage = Image.FromFile("Assets\\bin.png");
                int columnIn = 4;
                foreach (DataGridViewRow row in SuppliersDataGridView.Rows)
                {
                    row.Cells[columnIn].Value = cellImage;
                }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (OpenMode)
                GeneralFunctions.NavigateToIntroForm(_dbContext, this);
            else this.Hide();
        }

    }
}
