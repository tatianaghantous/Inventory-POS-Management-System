using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Customization;
using SMDataLayer.Models;

namespace SM
{
    public partial class CategoriesListForm : Form
    {
        private ClothingStoreContext _dbContext;
        private List<Category> categoriesList;
        TableLayoutPanel itemsTableLayoutPanel;
        NewOrderForm _newOrderForm;
        public CategoriesListForm(ClothingStoreContext dbContext, NewOrderForm newOrderForm)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _newOrderForm = newOrderForm;
            categoriesList = _dbContext.Categories.ToList();
            InitializeButtons();
            InitializeSearchTxtBox();
        }
        private void InitializeSearchTxtBox()
        {
            TextBox searchTextBox = new TextBox();
            searchTextBox.Dock = DockStyle.Top;
            searchTextBox.PlaceholderText = "Search..."; // For .NET 6.0 and above
            searchTextBox.TextChanged += SearchTextBox_TextChanged; // Event for text change
            tableLayoutPanel1.Controls.Add(searchTextBox,0,1);

        }
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox searchBox = sender as TextBox;
            if (searchBox != null)
            {
                var filteredCategories = categoriesList.Where(c => c.Name.ToLower().Contains(searchBox.Text.ToLower())).ToList();
                PopulateButtons(filteredCategories, itemsTableLayoutPanel);
            }
        }

        private void InitializeButtons()
        {
            itemsTableLayoutPanel = new TableLayoutPanel();
            itemsTableLayoutPanel.Dock = DockStyle.Fill;
            int numButtons = categoriesList.Count();
            itemsTableLayoutPanel.AutoSize = true; // Auto-size to accommodate all rows
            itemsTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            itemsTableLayoutPanel.ColumnCount = 6; // Set to 6 columns
            itemsTableLayoutPanel.ColumnStyles.Clear(); // Clear existing styles to start fresh

            // Set each column to have an equal percentage of the TableLayoutPanel's width
            for (int colIndex = 0; colIndex < itemsTableLayoutPanel.ColumnCount; colIndex++)
            {
                itemsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / itemsTableLayoutPanel.ColumnCount));
            }
            itemsTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            itemsTableLayoutPanel.AutoScroll = true;
            itemsTableLayoutPanel.SetColumnSpan(itemsTableLayoutPanel,2);
            tableLayoutPanel1.Controls.Add(itemsTableLayoutPanel,0,2);
            if (numButtons != 0)
                PopulateButtons(categoriesList, itemsTableLayoutPanel);
              
        }
        private void PopulateButtons(List<Category> categories, TableLayoutPanel panel)
        {
            panel.Controls.Clear();
            panel.RowStyles.Clear();
            panel.RowCount = categories.Count / panel.ColumnCount + (categories.Count % panel.ColumnCount > 0 ? 1 : 0);

            foreach (var category in categories)
            {
                CategoryButton button = new CategoryButton
                {
                    Text = category.Name,
                    Dock = DockStyle.Fill,
                    BackColor = Color.FloralWhite,
                    ForeColor = Color.FromArgb(55, 58, 81),
                    Font = new Font("Sylfaen", 21, FontStyle.Regular),
                    Width = 200,
                    Height = 200,
                    DisplayOnPOS = category.DisplayInPos == 1 ,
                    IsSelected = category.DisplayInPos == 1 ? true : false
                };

                button.Click += (sender, e) => {
                    var catButton = sender as CategoryButton;
                    catButton?.ToggleSelection();
                    Category modifiedCat = categories.Where(c => c.Name == button.Text).FirstOrDefault();
                    if (button.DisplayOnPOS == true)
                        modifiedCat.DisplayInPos = 1;
                    else
                        modifiedCat.DisplayInPos = 0;
                    _dbContext.Categories.Update(modifiedCat);
                    _dbContext.SaveChanges();

                };

                panel.Controls.Add(button);            }

            for (int i = 0; i < panel.RowCount; i++)
            {
                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            _newOrderForm.InitializeCategoriesTableLayoutPanel(categoriesList.Where(c => c.DisplayInPos == 1).ToList());
        }
    }
}
