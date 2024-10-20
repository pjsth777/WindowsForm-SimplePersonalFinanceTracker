using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{

    // ---------------------------------------------------------------------------------------

    /// <summary>
    /// The below defines a Form1 class that inherits from Form, which is 
    /// part of the Windows Form Library (System.Windows.Forms), The Form
    /// class represents a window or a dialog box in the application.
    /// The partial keyword indicates that this class can be split into
    /// multiple files (in this case, likely split between Form1.cs and 
    /// Form1.Designer.cs)
    /// </summary>
    /// 
    // ---------------------------------------------------------------------------------------
    public partial class Form1 : Form
    {
        // ---------------------------------------------------------------------------------------

        List<Transaction> transactions = new List<Transaction>();

        private TextBox txtAmount;
        private ComboBox cboCategory;
        private DateTimePicker dtpDate;
        private Button btnAdd;
        private DataGridView dgvTransactions;
        private Button btnSave;
        private Button btnLoad;

        // ---------------------------------------------------------------------------------------

        class Transaction
        {
            public double Amount { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
        }

        // ---------------------------------------------------------------------------------------

        public Form1()
        {
            /// <summary>
            /// The constructor initializes the Form1 object. When the form is 
            /// created, the InitializeComponent() method is called, which is 
            /// responsible to setting up the form and its control (e.g. buttons,
            /// text boxes, labels)
            /// </summary>
            InitializeComponent();
        }

        // ---------------------------------------------------------------------------------------

        private void InitializeComponent()
        {
            // ---------------------------------------------------------------------------------------

            this.txtAmount = new TextBox(); // A new TextBox control (txtAmount) is created.
            this.cboCategory = new ComboBox();
            this.dtpDate = new DateTimePicker();
            this.btnAdd = new Button();
            this.dgvTransactions = new DataGridView();
            this.btnSave = new Button();
            this.btnLoad = new Button();

            // ---------------------------------------------------------------------------------------

            this.SuspendLayout();

            // ---------------------------------------------------------------------------------------

            // TextBox for Amount
            this.txtAmount.Location = new System.Drawing.Point(12, 12);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.PlaceholderText = "Enter Amount";

            // ---------------------------------------------------------------------------------------

            // ComboBox for Category
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[]
            {
                "Food", "Bills", "Entertainment", "Salary", "Others"
            });
            this.cboCategory.Location = new System.Drawing.Point(12, 38);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 12);
            this.cboCategory.TabIndex = 1;

            // ---------------------------------------------------------------------------------------

            // DateTime Picker for Date
            this.dtpDate.Location = new System.Drawing.Point(12, 65);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 2;

            // ---------------------------------------------------------------------------------------

            // Add Button
            this.btnAdd.Location = new System.Drawing.Point(12, 91);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // ---------------------------------------------------------------------------------------

            // DataGridView for Transactions
            this.dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(12, 120);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(500, 150);
            this.dgvTransactions.TabIndex = 4;

            // ---------------------------------------------------------------------------------------

            // Save Button
            this.btnSave.Location = new System.Drawing.Point(12, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // ---------------------------------------------------------------------------------------

            // Load Button
            this.btnLoad.Location = new System.Drawing.Point(93, 280);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);

            // ---------------------------------------------------------------------------------------

            // Form1 Setup
            this.ClientSize = new System.Drawing.Size(534, 311);
            // The txtAmount control is added to the form's control collection, so it will
            // be displayed on the window.
            this.Controls.Add(this.txtAmount); 
            this.Controls.Add(this.cboCategory); 
            this.Controls.Add(this.dtpDate); 
            this.Controls.Add(this.btnAdd); 
            this.Controls.Add(this.dgvTransactions); 
            this.Controls.Add(this.btnSave); 
            this.Controls.Add(this.btnLoad); 
            this.Name = "Form1";
            this.Text = "Personal Finance Tracker";
            // The below two methods, manages layout suspension and resuming, ensuring
            // that layout calculations and positioning are handled properly.
            this.ResumeLayout(false);
            this.PerformLayout();

            // ---------------------------------------------------------------------------------------
        }

        // ---------------------------------------------------------------------------------------

        // Add Transaction
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double amount = double.Parse(txtAmount.Text);
            string Category = cboCategory.SelectedItem.ToString();
            DateTime date = dtpDate.Value;

            Transaction transaction = new Transaction
            {
                Amount = amount,
                Category = Category,
                Date = date
            };

            transactions.Add(transaction);
            UpdateDataGridView();
        }

        // ---------------------------------------------------------------------------------------

        // Save Transactions
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("transactions.txt"))
            {
                foreach (var transaction in transactions)
                {
                    sw.WriteLine($"{transaction.Amount},{transaction.Category},{transaction.Date}");
                }
            }
        }

        // ---------------------------------------------------------------------------------------

        // Load Transactions
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists("transactions.txt"))
            {
                transactions.Clear();
                string[] lines = File.ReadAllLines("transactions.txt");

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');
                    Transaction transaction = new Transaction
                    {
                        Amount = double.Parse(parts[0]),
                        Category = parts[1],
                        Date = DateTime.Parse(parts[2])
                    };
                    transactions.Add(transaction);
                }

                UpdateDataGridView();
            }
        }

        // ---------------------------------------------------------------------------------------

        // Update DataGridView
        private void UpdateDataGridView()
        {
            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = transactions;
        }


        // ---------------------------------------------------------------------------------------

    }
}