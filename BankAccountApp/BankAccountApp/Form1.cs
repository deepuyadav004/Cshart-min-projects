namespace BankAccountApp
{
    public partial class Form1 : Form
    {

        List<BankAccountDetails> accounts = new List<BankAccountDetails>();
        public Form1()
        {
            InitializeComponent();

            BankAccountDetails account1 = new BankAccountDetails("Alice", 1000, Guid.NewGuid());


            BankAccountDetails account2 = new BankAccountDetails("Deepu Yadav", 2345432, Guid.NewGuid());


            BankAccountDetails account3 = new BankAccountDetails("ok ok", 23, Guid.NewGuid());
            //account3.Owner = "ok ok";
            //account3.Balance = 23;
            //account3.AccountNumber = Guid.NewGuid();


            accounts.Add(account1);
            accounts.Add(account2);
            accounts.Add(account3);


            refreshGrid();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OwnerTxt.Text))
            {
                MessageBox.Show("Owner name cannot be empty.");
                return;
            }

            if (InterestRate.Value > 0)
            {
                BankAccountDetails accountDetails = new SavingsAccount(OwnerTxt.Text, 0, Guid.NewGuid(), InterestRate.Value);
                accounts.Add(accountDetails);
            }
            else
            {
                BankAccountDetails accountDetails = new BankAccountDetails(OwnerTxt.Text, 0, Guid.NewGuid());
                accounts.Add(accountDetails);
            }
            refreshGrid();
            OwnerTxt.Text = string.Empty;

        }

        private void refreshGrid()
        {
            BankAccountsGrid.DataSource = null;
            BankAccountsGrid.DataSource = accounts;
        }

        private void BankAccountsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            if (AmountNum.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.");
                return;
            }

            if (BankAccountsGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single account to withdraw from.");
                return;
            }

            accounts[BankAccountsGrid.CurrentCell.RowIndex].Deposit(Convert.ToDecimal(AmountNum.Value));

            //decimal newBalance = accounts[BankAccountsGrid.CurrentCell.RowIndex].Balance + Convert.ToDecimal(AmountNum.Value);
            //accounts[BankAccountsGrid.CurrentCell.RowIndex].Balance = newBalance;

            refreshGrid();
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if (AmountNum.Value <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.");
                return;
            }

            if (BankAccountsGrid.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a single account to withdraw from.");
                return;
            }

            if (accounts[BankAccountsGrid.CurrentCell.RowIndex].Balance < Convert.ToDecimal(AmountNum.Value))
            {
                MessageBox.Show("Insufficient balance.");
                return;
            }

            try
            {
                accounts[BankAccountsGrid.CurrentCell.RowIndex].WithDraw(Convert.ToDecimal(AmountNum.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            //decimal newBalance = accounts[BankAccountsGrid.CurrentCell.RowIndex].Balance - Convert.ToDecimal(AmountNum.Value);

            //accounts[BankAccountsGrid.CurrentCell.RowIndex].Balance = newBalance;

            refreshGrid();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
