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
    public partial class CustomersForm : Form
    {
        private ClothingStoreContext _dbContext;
        Image deleteImage;
        List<Customer> _customers;
        List<string> listOfTableFields;
        BindingList<Customer> bindingList;
        BindingSource source;

        public CustomersForm(ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _customers = _dbContext.Customers.ToList();
            LoadCustomers();
            var entityType = _dbContext.Model.FindEntityType(typeof(Customer).FullName);
            listOfTableFields = entityType.GetProperties()
                                              .Where(p => p.Name != "CustomerId")
                                              .Select(p => p.Name) 
                                              .ToList();
            customersDataGridView.CellContentClick += customersDataGridView_CellContentClick;
            customersDataGridView.CellClick += customersDataGridView_CellClick;
            customersDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(CustomersDataGridView_CellFormatting);
            //customersDataGridView.DataError += new DataGridViewDataErrorEventHandler(customersDataGridView_DataError);
        }

        public void LoadCustomers()
        {
            customersDataGridView.AutoGenerateColumns = false;

            customersDataGridView.Columns.Clear();

            customersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer ID",
                DataPropertyName = "CustomerId",
                Name = "CustomerId",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" },
                ReadOnly = true,
                Visible = false
            });
            customersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                Name = "Name",
                ReadOnly = true
            });
            customersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Family Name",
                DataPropertyName = "FamilyName",
                Name = "FamilyName",
                ReadOnly = true

            });
            customersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phone Number",
                DataPropertyName = "PhoneNumber",
                Name = "PhoneNumber",
                ReadOnly = true

            });
            customersDataGridView.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "Department Worker",
                DataPropertyName = "DepartmentWorker",
                Name = "DepartmentWorker",
                ReadOnly = true

            });
            customersDataGridView.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = " ",
                Name = "DeleteButtonColumn",
                Width = 100 // Adjust width as needed
            });

             bindingList = new BindingList<Customer>(_customers);
             source = new BindingSource(bindingList, null);

            customersDataGridView.DataSource = source;
        }
        private void CustomersDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewFunctions.DataGridView_CellFormatting(sender, e, customersDataGridView);
        }
        private void backButton_Click(object sender, EventArgs e)
        {
             IntroForm introForm = new IntroForm(_dbContext);
            introForm.Show();
            this.Hide();
        }
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == customersDataGridView.Columns["DeleteButtonColumn"].Index)
            {

                    var customerIdCell = customersDataGridView.Rows[e.RowIndex].Cells["CustomerId"].Value;
                    if (customerIdCell != null)
                    {
                        string customerIdString = customerIdCell.ToString();
                        customerIdString = customerIdString.Replace(",", "").Replace(".", "").Replace(" ", "");

                        if (int.TryParse(customerIdString, out int customerId))
                        {

                            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {

                                bool isCustomerReferenced = _dbContext.OrderSummaries.Any(os => os.BuyerId == customerId) ||
                                                           _dbContext.Services.Any(s => s.CustomerId == customerId) || _dbContext.Returns.Any(s => s.CustomerId == customerId);
                                if (isCustomerReferenced)
                                {
                                    MessageBox.Show("You can't delete this customer because it is referenced in OrderSummaries, Services, or Returns.");
                                }
                                else
                                {
                                    var customer = _dbContext.Customers.FirstOrDefault(p => p.CustomerId == customerId);
                                    if (customer != null)
                                    {
                                        _dbContext.Customers.Remove(customer);
                                        _dbContext.SaveChanges();
                                        DataGridViewFunctions.DeleteRowFromDataGridView(e.RowIndex, customersDataGridView);
                                        MessageBox.Show("Customer deleted successfully.");
                                    }
                                }
                            }
                        }
                    }
            }
        }
        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            OpenAddCustomerForm();

        }
        private void OpenAddCustomerForm()
        {
            BOAddingAndEditingForm dynamicForm = new BOAddingAndEditingForm(listOfTableFields, "New Customer", typeof(Customer), _dbContext);

            dynamicForm.Done += AddCustomer_Done;

            dynamicForm.Show();
        }
        private void AddCustomer_Done(object sender, Object e)
        {
            Customer newCustomer = (Customer)e;
            _dbContext.Customers.Add(newCustomer);
            _dbContext.SaveChanges();
            _customers = _dbContext.Customers.ToList();
            bindingList = new BindingList<Customer>(_customers);
            source = new BindingSource(bindingList, null);
            customersDataGridView.DataSource = source;
            ((BOAddingAndEditingForm)sender).Done -= AddCustomer_Done;

        }

        private void customersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != customersDataGridView.Columns["DeleteButtonColumn"].Index && customersDataGridView.CurrentRow != null)
            {
                Customer selectedCustomer = (Customer)customersDataGridView.CurrentRow.DataBoundItem;
                OpenEditCustomerForm(selectedCustomer);
            }
        }
        public void OpenEditCustomerForm(Customer selectedCustomer)
        {
            BOAddingAndEditingForm dynamicForm = new BOAddingAndEditingForm("Edit Customer", _dbContext, selectedCustomer);

            dynamicForm.Done += EditCustomer_Done;

            dynamicForm.Show();
        }
        private void EditCustomer_Done(object sender, Object e)
        {
            Customer newCustomer = (Customer)e;
            _dbContext.Customers.Update(newCustomer);
            _dbContext.SaveChanges();
            _customers = _dbContext.Customers.ToList();
             bindingList = new BindingList<Customer>(_customers);
             source = new BindingSource(bindingList, null);
            customersDataGridView.DataSource = source;
            ((BOAddingAndEditingForm)sender).Done -= EditCustomer_Done;

        }
    }
}
