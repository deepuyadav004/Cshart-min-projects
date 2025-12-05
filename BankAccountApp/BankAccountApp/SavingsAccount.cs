using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    public class SavingsAccount : BankAccountDetails
    {
        decimal interestRate;

        public SavingsAccount(string Owner, decimal Balance, Guid AccoundNumber, decimal interestRate = 0)
            : base(Owner + "(" + interestRate + "%)", Balance, AccoundNumber)
        {
            this.interestRate = interestRate;
        }

        override
        public void Deposit(decimal amount)
        {
            decimal interest = (amount * interestRate) / 100;
            base.Deposit(amount + interest);
        }
    }
}
