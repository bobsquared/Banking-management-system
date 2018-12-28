using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_finance
{
    class UserAccounts
    {
        protected string accountName;
        protected int balance;
        protected string transactionDate;
        protected int transactionAmount;
        protected string transactionName;

       
        public void SetAccountName(string name)
        {
            accountName = name;
        }
        public string account_name()
        {
            return accountName;
        }
        
        public void SetTransactionName(string name)
        {
            transactionName = name;
        }

        public string getTransactionName()
        {
            return transactionName;
        }

        public void SetTransactionDate(string date)
        {
            transactionDate = date;
        }

        public string getTransactionDate()
        {
            return transactionDate;
        }


        public void SetTransactionAmount(string amount)
        {
            transactionDate = amount;
        }

        public int getTransactionAmount()
        {
            return transactionAmount;
        }

        public int GetBalance()
        {
            return balance;
        }

    }


    class Chequing : UserAccounts
    {
          
    }

    class Savings : UserAccounts
    {
        int primeRate;

        public int annualInterestRate()
        {
            return (balance * (primeRate / 100));
        }
    }
}