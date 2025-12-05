using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    public class BankAccountDetails
    {
        public string Owner { get; set; }
        public decimal Balance { get; private set; }
        public Guid AccountNumber { get; set; }

        public BankAccountDetails(string Owner, decimal Balance, Guid AccountNumber)
        {
            this.Owner = Owner;
            this.Balance = Balance;
            this.AccountNumber = AccountNumber;
        }

        virtual public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            Balance += amount;
        }

        public void WithDraw(decimal amount)
        {
            if(amount > Balance)
            {
                throw new Exception("Insufficient balance");
            }

            Balance -= amount;
        }

    }
}
