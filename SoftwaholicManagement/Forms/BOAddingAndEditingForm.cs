using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SM.Customization;
using SMDataLayer.Models;
using TextBox = System.Windows.Forms.TextBox;

namespace SM
{
    public partial class BOAddingAndEditingForm : Form
    {
        List<String> _ListOfFieldsNames;
        TableLayoutPanel fieldsTableLayoutPanel;
        Object _objectToEdit;
        bool _editMode = false;
        SMDataLayer.Models.ClothingStoreContext _dbContext;
        public delegate void DoneEventHandler(object sender, Object e);

        // Define the event based on the delegate
        public event DoneEventHandler Done;

        private Type _objectType;
        private object _entity;

        // Event that can be used by the caller to receive the created/edited entity
        public event Action<object> EntityCreatedOrModified;
        public BOAddingAndEditingForm(List<String>listOfFieldsNames, string title, Type objectType, ClothingStoreContext dbContext)
        {
            InitializeComponent();
            _ListOfFieldsNames = listOfFieldsNames;
            _objectType = objectType;
            _dbContext = dbContext;
            _entity = Activator.CreateInstance(_objectType);
            titleLabel.Text = title;
            this.Paint += new PaintEventHandler(FormPaint);
            InitializeFieldsOrder();
            InitializeDesign();

        }

        public BOAddingAndEditingForm(string title, ClothingStoreContext dbContext, Object objectToEdit)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _objectToEdit = objectToEdit;
            titleLabel.Text = title;
            this.Paint += new PaintEventHandler(FormPaint);
            _editMode = true;
            InitializeDesign(_objectToEdit);

        }
        protected virtual void OnDone(Object e)
        {
            Done?.Invoke(this, e);
        }
        private void InitializeFieldsOrder()
        {
            // To send it by parameters later on !!
            _ListOfFieldsNames = new List<string> { "Name", "FamilyName", "PhoneNumber", "DepartmentWorker", "BranchId" };
        }

        private void InitializeDesign()
        {
            InitializeFieldsTableLayoutpanel();
            fieldsTableLayoutPanel.RowCount = _ListOfFieldsNames.Count;

            // Set the height of the rows to a percentage based on the count
            float rowHeight = 100F / _ListOfFieldsNames.Count;
            foreach (string str in _ListOfFieldsNames)
            {
                fieldsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }
            int rowIndex = 0;

            foreach (string str in _ListOfFieldsNames)
            {
                // Common label setup for all types
                string formattedFieldName = FormatLabelText(str);
                CustomLabel label = new CustomLabel(formattedFieldName);
                label.AutoSize = true;
                label.Dock = DockStyle.Fill;
                label.Margin = new Padding(3);
                label.Anchor = AnchorStyles.None;

                fieldsTableLayoutPanel.Controls.Add(label, 0, rowIndex);

                Control inputControl; // This will hold the specific control based on the condition

                if (str == "DepartmentWorker")
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Name = str;
                    checkBox.Dock = DockStyle.Fill;
                    checkBox.Margin = new Padding(85, 0, 0, 0);
                    checkBox.Anchor = AnchorStyles.None;
                    inputControl = checkBox;
                }
                else if (str == "BranchId")
                {
                    System.Windows.Forms.ComboBox comboBox = new System.Windows.Forms.ComboBox();
                    comboBox.Name = str;
                    comboBox.Dock = DockStyle.Fill;
                    comboBox.Anchor = AnchorStyles.None;
                    var branches = _dbContext.Branches.OrderBy(b => b.BranchName).ToList();
                    comboBox.DisplayMember = "BranchName"; // The property to display
                    comboBox.ValueMember = "BranchId"; // The property to use as the value
                    comboBox.DataSource = branches;
                    inputControl = comboBox;
                }
                else
                {
                    CustomTextBox textBox = new CustomTextBox();
                    textBox.Name = str;
                    textBox.Dock = DockStyle.Fill;
                    textBox.Margin = new Padding(3);
                    textBox.Anchor = AnchorStyles.None;
                    textBox.Size = new Size(185, 27);
                    inputControl = textBox;
                }

                fieldsTableLayoutPanel.Controls.Add(inputControl, 1, rowIndex);
                rowIndex++;
            }

            mainTableLayoutPanel.Controls.Add(fieldsTableLayoutPanel, 0, 1);
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        }

        public void InitializeDesign(Object objectToEdit)
        {
            // Ordered property names
            string[] orderedProperties = { "Name", "FamilyName", "PhoneNumber", "DepartmentWorker", "BranchId" };
            InitializeFieldsTableLayoutpanel();
            // Adjust the TableLayoutPanel based on the number of properties
            fieldsTableLayoutPanel.RowCount = orderedProperties.Length;
            float rowHeight = 100F / orderedProperties.Length;
            foreach (string str in orderedProperties)
            {
                fieldsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeight));
            }
            fieldsTableLayoutPanel.ColumnCount = 2;
            fieldsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            fieldsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            int rowIndex = 0;
            foreach (var propertyName in orderedProperties)
            {
                PropertyInfo propertyInfo = objectToEdit.GetType().GetProperty(propertyName);
                if (propertyInfo != null)
                {
                    CustomLabel label = new CustomLabel
                    {
                        Text = FormatLabelText(propertyName),
                        //Dock = DockStyle.Fill,
                        AutoSize = true,
                        ForeColor = Color.FloralWhite,
                        Anchor = AnchorStyles.None

                    };
                    fieldsTableLayoutPanel.Controls.Add(label, 0, rowIndex);

                    // Determine and add the appropriate input control
                    Control inputControl = CreateInputControlForProperty(propertyInfo, objectToEdit);
                    fieldsTableLayoutPanel.Controls.Add(inputControl, 1, rowIndex);

                    rowIndex++;
                }
            }

            mainTableLayoutPanel.Controls.Add(fieldsTableLayoutPanel, 0, 1);
            mainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Ensure that main panel row also fills its space
        }
        private Control CreateInputControlForProperty(PropertyInfo property, Object objectToEdit)
        {
            Control inputControl = null;
            var value = property.GetValue(objectToEdit);

            switch (property.Name)
            {
                case "DepartmentWorker":
                    var checkBox = new CheckBox
                    {
                        Checked = Convert.ToBoolean(value),
                        Dock = DockStyle.Fill,
                        Margin = new Padding(85, 0, 0, 0),
                        Name = property.Name,
                        Anchor = AnchorStyles.None
                    };
                    inputControl = checkBox;
                    break;
                case "BranchId":
                    var comboBox = new ComboBox
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(3),
                        Name = property.Name,
                        Anchor = AnchorStyles.None
                        // Add additional ComboBox setup, e.g., DataSource
                    };
                    // Assuming branches are available and Branch has properties BranchId and BranchName
                    comboBox.DataSource = _dbContext.Branches.ToList();
                    comboBox.DisplayMember = "BranchName";
                    comboBox.ValueMember = "BranchId";
                    comboBox.SelectedValue = value;
                    inputControl = comboBox;
                    break;
                default:
                    CustomTextBox textBox = new CustomTextBox
                    {
                        Text = value?.ToString(),
                        Dock = DockStyle.Fill,
                        Margin = new Padding(3),
                        Name = property.Name,
                        Anchor = AnchorStyles.None,
                    };
                    inputControl = textBox;
                    break;
            }
            return inputControl ?? new Control(); // Fallback to an empty control if none match
        }



        private void InitializeFieldsTableLayoutpanel()
        {
            fieldsTableLayoutPanel = new TableLayoutPanel();
            fieldsTableLayoutPanel.Controls.Clear();
            fieldsTableLayoutPanel.RowStyles.Clear();
            fieldsTableLayoutPanel.ColumnStyles.Clear();
            fieldsTableLayoutPanel.Dock = DockStyle.Fill;
            fieldsTableLayoutPanel.ColumnCount = 2; // Set the number of columns
            fieldsTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            // Configure the columns to fill the available space
            fieldsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fieldsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            fieldsTableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            fieldsTableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize; // Use FixedSize since we are setting the row count
        }

        string FormatLabelText(string original)
        {
            // Remove "Id" from the end if it exists
            string modified = original.EndsWith("Id") ? original.Substring(0, original.Length - 2) : original;

            return Regex.Replace(modified, "([a-z])([A-Z])", "$1 $2");
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            //// The width of the 3D border
            //int borderWidth = 10;

            //// Draw the border larger than the client rectangle to ensure it is visible
            //Rectangle clientRect = this.ClientRectangle;
            //clientRect.Inflate(borderWidth / 2, borderWidth / 2);

            //// Color for the border (could be set to any color needed)
            //Color darkColor = Color.Gray; // Darker shade for the shadow
            //Color lightColor = Color.White; // Lighter shade for the highlight

            //// Shadow pen
            //using (Pen darkPen = new Pen(darkColor, borderWidth / 2))
            //{
            //    // Bottom shadow line
            //    e.Graphics.DrawLine(darkPen, clientRect.Left, clientRect.Bottom, clientRect.Right, clientRect.Bottom);
            //    // Right shadow line
            //    e.Graphics.DrawLine(darkPen, clientRect.Right, clientRect.Top, clientRect.Right, clientRect.Bottom);
            //}

            //// Highlight pen
            //using (Pen lightPen = new Pen(lightColor, borderWidth / 2))
            //{
            //    // Top highlight line
            //    e.Graphics.DrawLine(lightPen, clientRect.Left, clientRect.Top, clientRect.Right, clientRect.Top);
            //    // Left highlight line
            //    e.Graphics.DrawLine(lightPen, clientRect.Left, clientRect.Top, clientRect.Left, clientRect.Bottom);
            //}
        }
        public void UpdateObjectFromControls(Object objectToEdit)
        {
            foreach (Control control in fieldsTableLayoutPanel.Controls)
            {
                PropertyInfo propertyInfo = objectToEdit.GetType().GetProperty(control.Name);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    if (control is TextBox textBox)
                    {
                        Type targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                            object value = (textBox.Text == string.Empty && targetType != typeof(string)) ? null : Convert.ChangeType(textBox.Text, targetType);
                            propertyInfo.SetValue(objectToEdit, value);

                    }
                    else if (control is ComboBox comboBox && comboBox.SelectedValue != null)
                    {
                        object value = (propertyInfo.PropertyType != typeof(int)) ? null : Convert.ChangeType(comboBox.SelectedValue, propertyInfo.PropertyType);
                        propertyInfo.SetValue(objectToEdit, value);
                    }
                    else if (control is CheckBox checkBox)
                    {

                        propertyInfo.SetValue(objectToEdit, checkBox.Checked ? 1 : 0);
                    }

                }
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {   if (_editMode)
            {
                UpdateObjectFromControls(_objectToEdit);
                OnDone(_objectToEdit);
            }
            else
            {
                foreach (Control control in fieldsTableLayoutPanel.Controls)
                {
                    PropertyInfo propertyInfo = null;
                    object valueToSet = null;

                    // Handle TextBox
                    if (control is TextBox textBox)
                    {
                        propertyInfo = _entity.GetType().GetProperty(textBox.Name);
                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            Type targetType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;

                                valueToSet = (textBox.Text == string.Empty && targetType != typeof(string)) ? null : Convert.ChangeType(textBox.Text, targetType);
                            
                        }
                    }
                    // Handle ComboBox
                    else if (control is ComboBox comboBox && !string.IsNullOrEmpty(comboBox.Name))
                    {
                        propertyInfo = _entity.GetType().GetProperty(comboBox.Name);
                        if (propertyInfo != null && propertyInfo.CanWrite)
                        {
                            valueToSet = (int)comboBox.SelectedValue;
                        }
                    }
                    // Handle CheckBox
                    else if (control is CheckBox checkBox && !string.IsNullOrEmpty(checkBox.Name))
                    {
                        propertyInfo = _entity.GetType().GetProperty(checkBox.Name);
                        if (propertyInfo != null && propertyInfo.CanWrite && propertyInfo.PropertyType == typeof(bool))
                        {
                            valueToSet = checkBox.Checked;
                        }
                    }

                    // Set the property value if applicable
                    if (propertyInfo != null && valueToSet != null)
                    {

                            propertyInfo.SetValue(_entity, valueToSet, null);

                    }
                }
                OnDone(_entity);
            }

            this.Close();
        }
    }
}
