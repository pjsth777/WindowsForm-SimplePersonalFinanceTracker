using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

        private SQLiteConnection dbConnection;

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
            InitializeDatabase();
            UpdateDataGridView();
        }

        // ---------------------------------------------------------------------------------------

        private void InitializeDatabase()
        {
            // Establish database connection
            dbConnection = new SQLiteConnection("Data Source=Transactions.db;Version=3;");
            dbConnection.Open();

            // Create a table if it doesnt exists
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Transactions(
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        Amount Real,
                                        Category TEXT,
                                        Date TEXT)";
            SQLiteCommand command = new SQLiteCommand(createTableQuery, dbConnection);
            command.ExecuteNonQuery();
            
        }

        // ---------------------------------------------------------------------------------------

        // Add Transaction
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtAmount.Text, out double amount))
            {
                MessageBox.Show("Please enter a valid number for the amount.");
                return;
            }

            if (cboCategory.SelectedIndex == null) 
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            string category = cboCategory.SelectedItem.ToString();
            DateTime date = dtpDate.Value;

            // Insert into database
            string insertQuery = "INSERT INTO Transactions (Amount, Category, Date) VALUES (@amount, @category, @date)";
            SQLiteCommand command = new SQLiteCommand(insertQuery, dbConnection);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@category", category);
            command.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
            command.ExecuteNonQuery();

            UpdateDataGridView();
        }

        // ---------------------------------------------------------------------------------------

        // Update DataGridView
        private void UpdateDataGridView()
        {
            dgvTransactions.DataSource = null;

            string selectQuery = "SELECT * FROM Transactions";
            SQLiteCommand command = new SQLiteCommand(selectQuery, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<Transaction> transactions = new List<Transaction>();
            while (reader.Read())
            {
                transactions.Add(new Transaction
                {
                    Amount = reader.GetDouble(1),
                    Category = reader.GetString(2),
                    Date = DateTime.Parse(reader.GetString(3))
                });
            }

            dgvTransactions.DataSource = transactions;

        }

        // ---------------------------------------------------------------------------------------

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string incomeQuery = "SELECT SUM(Amount) FROM Transactions WHERE Amount > 0";
            string expenseQuery = "SELECT SUM(Amount) FROM Transactions WHERE AMOUNT < 0";

            SQLiteCommand incomeCmd = new SQLiteCommand(incomeQuery, dbConnection);
            SQLiteCommand expenseCmd = new SQLiteCommand(expenseQuery, dbConnection);

            double totalIncome = (incomeCmd.ExecuteScalar() != DBNull.Value) ? Convert.ToDouble(incomeCmd.ExecuteScalar()) : 0;
            double totalExpense = (expenseCmd.ExecuteScalar() != DBNull.Value) ? Convert.ToDouble(expenseCmd.ExecuteScalar()) : 0;

            double balance = totalIncome + totalExpense; // Expenses are negative

            MessageBox.Show($"Total Income: {totalIncome}\nTotal Expense: {totalExpense}\nBalance: {balance}");
        }

        // ---------------------------------------------------------------------------------------

        private void btnFilterCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = cboCategoryFilter.SelectedItem.ToString();

            string filterQuery = "SELECT * FROM Transactions WHERE Category = @category";
            SQLiteCommand command = new SQLiteCommand(filterQuery, dbConnection);
            command.Parameters.AddWithValue("@category", selectedCategory);

            SQLiteDataReader reader = command.ExecuteReader();
            List<Transaction> filteredTransactions = new List<Transaction>();
            while (reader.Read())
            {
                filteredTransactions.Add(new Transaction
                {
                    Amount = reader.GetDouble(1),
                    Category = reader.GetString(2),
                    Date = DateTime.Parse(reader.GetString(3))
                });
            }

            dgvTransactions.DataSource = filteredTransactions;
        }

        // ---------------------------------------------------------------------------------------

        // Save Transactions
        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transactions are automatically saved to the database.");
        }

        // ---------------------------------------------------------------------------------------

        // Load Transactions
        private void btnLoad_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        // ---------------------------------------------------------------------------------------

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConnection.Close();
        }

        // ---------------------------------------------------------------------------------------


    }
}