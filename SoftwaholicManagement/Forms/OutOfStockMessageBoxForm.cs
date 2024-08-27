using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SM.Common_Functions;
using SMDataLayer.Models;

namespace SM
{
    public partial class OutOfStockMessageBoxForm : Form
    {
        private ClothingStoreContext _dbContext;
        List<Product>? outOfStockProducts;
        TextBox textBox = new TextBox();
        public OutOfStockMessageBoxForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            ProductsOutOfStockDgv.CellFormatting += new DataGridViewCellFormattingEventHandler(ProductsOutOfStockDgv_CellFormatting);
            GetOutOfStockProducts();
            if ( outOfStockProducts != null )
            ProductsForm.LoadProducts(outOfStockProducts, ProductsOutOfStockDgv);
        }

        private void GetOutOfStockProducts()
        {
            outOfStockProducts = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Inventories)
                .Where(p => p.Inventories.Any(i => i.QuantityInStock == 0))
                .ToList();

        }
        private void ProductsOutOfStockDgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, ProductsOutOfStockDgv);
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
