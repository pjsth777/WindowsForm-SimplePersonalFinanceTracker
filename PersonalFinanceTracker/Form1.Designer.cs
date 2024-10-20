namespace PersonalFinanceTracker
{
    // ---------------------------------------------------------------------------------------

    partial class Form1
    {

        private TextBox txtAmount;
        private ComboBox cboCategory;
        private ComboBox cboCategoryFilter;
        private DataGridView dgvTransactions;
        private DateTimePicker dtpDate;
        private Button btnAdd;
        private Button btnGenerateReport;
        private Button btnFilterCategory;
        private Button btnSave;



        // ---------------------------------------------------------------------------------------

        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // ---------------------------------------------------------------------------------------

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // ---------------------------------------------------------------------------------------

        // ---------------------------------------------------------------------------------------

        private void InitializeComponent()
        {
            // ---------------------------------------------------------------------------------------

            this.txtAmount = new TextBox(); // A new TextBox control (txtAmount) is created.
            this.cboCategory = new ComboBox();
            this.cboCategoryFilter = new ComboBox();
            this.dtpDate = new DateTimePicker();
            this.dgvTransactions = new DataGridView();
            this.btnAdd = new Button();
            this.btnGenerateReport = new Button();
            this.btnFilterCategory = new Button();
            this.btnSave = new Button();

            // ---------------------------------------------------------------------------------------
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();


            this.SuspendLayout();

            // ---------------------------------------------------------------------------------------

            // TextBox for Amount
            this.txtAmount.Location = new System.Drawing.Point(20, 20);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(120, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.PlaceholderText = "Enter Amount";

            // ---------------------------------------------------------------------------------------

            // ComboBox for Category
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[]
            {
                "Food", "Bills", "Entertainment", "Salary", "Others"
            });
            this.cboCategory.Location = new System.Drawing.Point(160, 20);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 21);
            this.cboCategory.TabIndex = 1;

            // ---------------------------------------------------------------------------------------

            // ComboBox for CategoryFilter
            this.cboCategoryFilter.FormattingEnabled = true;
            this.cboCategoryFilter.Items.AddRange(new object[]
            {
                "Food", "Bills", "Entertainment", "Salary", "Others"
            });
            this.cboCategoryFilter.Location = new System.Drawing.Point(20, 120);
            this.cboCategoryFilter.Name = "cboCategory";
            this.cboCategoryFilter.Size = new System.Drawing.Size(121, 21);
            this.cboCategoryFilter.TabIndex = 2;

            // ---------------------------------------------------------------------------------------

            // DateTime Picker for Date
            this.dtpDate.Location = new System.Drawing.Point(300, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 3;

            // ---------------------------------------------------------------------------------------

            // DataGridView for Transactions
            this.dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(20, 150);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(600, 200);
            this.dgvTransactions.TabIndex = 4;

            // ---------------------------------------------------------------------------------------

            // Add Button
            this.btnAdd.Location = new System.Drawing.Point(520, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 25);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            // ---------------------------------------------------------------------------------------

            // btnGenerateReport
            this.btnGenerateReport.Location = new System.Drawing.Point(160, 120);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(120, 25);
            this.btnGenerateReport.TabIndex = 6;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new EventHandler(this.btnGenerateReport_Click);

            // ---------------------------------------------------------------------------------------

            // btnFilterCategory
            this.btnFilterCategory.Location = new System.Drawing.Point(300, 120);
            this.btnFilterCategory.Name = "btnFilterCategory";
            this.btnFilterCategory.Size = new System.Drawing.Size(100, 25);
            this.btnFilterCategory.TabIndex = 7;
            this.btnFilterCategory.Text = "Filter By Category";
            this.btnFilterCategory.UseVisualStyleBackColor = true;
            this.btnFilterCategory.Click += new EventHandler(this.btnFilterCategory_Click);

            // ---------------------------------------------------------------------------------------

            // Save Button
            this.btnSave.Location = new System.Drawing.Point(420, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // ---------------------------------------------------------------------------------------

            // Form1 Setup
            this.ClientSize = new System.Drawing.Size(650, 400);
            // The txtAmount control is added to the form's control collection, so it will
            // be displayed on the window.
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.cboCategoryFilter);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnFilterCategory);
            this.Controls.Add(this.btnSave);
            this.Name = "Form1";
            this.Text = "Personal Finance Tracker";
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            // The below two methods, manages layout suspension and resuming, ensuring
            // that layout calculations and positioning are handled properly.
            this.ResumeLayout(false);
            this.PerformLayout();

            // ---------------------------------------------------------------------------------------
        }

    }
}