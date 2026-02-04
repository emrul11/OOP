using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardTask
{
    public class CreditCard
    {
        private const decimal DefaultCreditLimit = 500000;
        private const decimal DefaultCashWithdrawalLimit = 50000;

        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string BankName { get; set; }

        public decimal CreditLimit {  get; set; }
        public decimal CashWithdrawalLimit { get; set; }

        public decimal OutstandingBalance { get; set; }


        public CreditCard(string cardNumber, string cardHolderName, string bankName)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            BankName = bankName;

            CreditLimit = DefaultCreditLimit;
            CashWithdrawalLimit = DefaultCashWithdrawalLimit;
            OutstandingBalance = 0;
        }

        public void WithdrawCash(decimal amount)
        {
            ValidateAmount(amount);

            if (amount > CashWithdrawalLimit)
                throw new InvalidOperationException(
                    $"Cash withdrawal per transaction cannot exceed {CashWithdrawalLimit}.");

            EnsureCreditLimitNotExceeded(amount);

            OutstandingBalance += amount;
        }

        public void PayBill(decimal amount, string merchantName)
        {
            ValidateAmount(amount);

            if (string.IsNullOrWhiteSpace(merchantName))
                throw new ArgumentException("Merchant name is required.");

            EnsureCreditLimitNotExceeded(amount);

            OutstandingBalance += amount;
        }
        public void Repay(decimal amount)
        {
            ValidateAmount(amount);

            OutstandingBalance -= amount;
        }


        private void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");
        }

        private void EnsureCreditLimitNotExceeded(decimal amount)
        {
            if (OutstandingBalance + amount > CreditLimit)
                throw new InvalidOperationException("Credit limit exceeded.");
        }

    }
}
