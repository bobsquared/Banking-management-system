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
        protected float balance;
        protected string transactionDate;
        protected float transactionAmount;
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


        public void SetTransactionAmount(float amount)
        {
            transactionAmount = amount;
        }

        public float getTransactionAmount()
        {
            return transactionAmount;
        }


        public float GetBalance()
        {
            return balance;
        }

        public void SetBalance(float balanceTotal)
        {
            balance = balanceTotal;
        }


    }


    class Chequing : UserAccounts
    {
          
    }

    class Savings : UserAccounts
    {
        float primeRate;

        public float annualInterestRate()
        {
            return (balance * (primeRate / 100));
        }
    }
}