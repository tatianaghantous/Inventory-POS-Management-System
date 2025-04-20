using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.ViewModels;


namespace SM.Common_Functions
{
    public static class DataGridViewFunctions
    {

        public static void FilterInventories<T>(string filterValue, InventoryViewModel.FilterType filterType, DataGridView dgv, BindingList<T>? bindingList)
        {
            if (bindingList == null)
                return;
            switch (filterType)
            {
                case InventoryViewModel.FilterType.ProductName:
                    var newList = GetFilteredProducts<T>(p => (p as InventoryViewModel)?.ProductName, filterValue, bindingList);
                    var source = new BindingSource(newList, null);
                    dgv.DataSource = source;
                    break;
                case InventoryViewModel.FilterType.ProductDescription:
                    dgv.DataSource = GetFilteredProducts<T>(p => (p as InventoryViewModel)?.ProductDescription, filterValue, bindingList);
                    break;
                case InventoryViewModel.FilterType.BarcodeId:
                    dgv.DataSource = GetFilteredProducts<T>(p => (p as InventoryViewModel)?.BarcodeId, filterValue, bindingList);
                    break;
                case InventoryViewModel.FilterType.CategoryName:
                    dgv.DataSource = GetFilteredProducts<T>(p => (p as InventoryViewModel)?.CategoryName, filterValue, bindingList);
                    break;
                default:
                    break;
            }
        }
        public static void FilterProducts<T>(string filterValue, InventoryViewModel.FilterType filterType, DataGridView dgv, BindingList<T>? bindingList)
        {
            if (bindingList == null)
                return;
            switch (filterType)
            {
                case InventoryViewModel.FilterType.ProductName:
                    var newList = GetFilteredProducts<T>(p => (p as ProductViewModel)?.Name, filterValue, bindingList);
                    var source = new BindingSource(newList, null);
                    dgv.DataSource = source;
                    break;
                case InventoryViewModel.FilterType.ProductDescription:
                    dgv.DataSource = GetFilteredProducts<T>(p => (p as ProductViewModel)?.Description, filterValue, bindingList);
                    break;
                case InventoryViewModel.FilterType.BarcodeId:
                    dgv.DataSource = GetFilteredProducts<T>(p => (p as ProductViewModel)?.BarcodeId, filterValue, bindingList);
                    break;
                case InventoryViewModel.FilterType.CategoryName:
                    dgv.DataSource = GetFilteredProducts<T>(p => (p as ProductViewModel)?.CategoryName, filterValue, bindingList);
                    break;
                default:
                    break;
            }
        }

        private static List<T> GetFilteredProducts<T>(Func<T, string?> getProperty, string filterValue, BindingList<T> bindingList)
        {
            if (string.IsNullOrWhiteSpace(filterValue))
            {
                return bindingList.ToList();
            }
            else
            {
                string searchTermLower = filterValue.ToLower();
                return bindingList.Where(p => getProperty(p)?.ToLower()?.Contains(searchTermLower) ?? false).ToList();
            }
        }

        public static void DeleteRowFromDataGridView(int rowIndex, DataGridView dataGridView)
        {

                if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count)
                {

                    dataGridView.Rows.RemoveAt(rowIndex);

                    dataGridView.Refresh();
                }

        }
        public static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e, DataGridView dataGridView)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                e.Value = ApplicationCache.deleteImage;
            }
        }
        public static void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Check if the error is a formatting error
            if (e.Context == DataGridViewDataErrorContexts.Formatting ||
                e.Context == DataGridViewDataErrorContexts.PreferredSize)
            {
                MessageBox.Show("Formatting error: " + e.Exception.Message);
            }
            else
            {
                MessageBox.Show("Data Error occurred: " + e.Exception.Message);
            }

            // Prevent the error message from being thrown as an exception.
            e.ThrowException = false;
        }
        public static int? FormatIdToValidOne(object idCell)
        {
            if (idCell != null)
            {
                string idString = idCell.ToString();
                idString = idString.Replace(",", "").Replace(".", "").Replace(" ", "");

                int parsedId;
                if (int.TryParse(idString, out parsedId))
                {
                    return parsedId;
                }
            }
            return null; // Return null if parsing fails or cell value is null
        }


    }
}
