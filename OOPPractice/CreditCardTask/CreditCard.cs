using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardTask
{
    public class CreditCard
    {
        private const decimal DefaultCreditLimit = 500_000m;
        private const decimal DefaultCashWithdrawalLimit = 50_000m;

        public string CardNumber { get; }
        public string CardHolderName { get; }
        public string BankName { get; }

        public decimal CreditLimit { get; }
        public decimal CashWithdrawalLimit { get; }

        public decimal OutstandingBalance { get; private set; }
        public decimal CreditBalance { get; private set; }

        public decimal AvailableCredit =>
            CreditLimit - OutstandingBalance + CreditBalance;

        public CreditCard(string cardNumber, string cardHolderName, string bankName)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                throw new ArgumentException("Card number is required.");

            if (string.IsNullOrWhiteSpace(cardHolderName))
                throw new ArgumentException("Card holder name is required.");

            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            BankName = bankName;

            CreditLimit = DefaultCreditLimit;
            CashWithdrawalLimit = DefaultCashWithdrawalLimit;
        }

        public void WithdrawCash(decimal amount)
        {
            ValidateAmount(amount);

            if (amount > CashWithdrawalLimit)
                throw new InvalidOperationException(
                    $"Cash withdrawal per transaction cannot exceed {CashWithdrawalLimit}.");

            EnsureCreditLimitNotExceeded(amount);

            ApplyCharge(amount);
        }

        public void PayBill(decimal amount, string merchantName)
        {
            ValidateAmount(amount);

            if (string.IsNullOrWhiteSpace(merchantName))
                throw new ArgumentException("Merchant name is required.");

            EnsureCreditLimitNotExceeded(amount);

            ApplyCharge(amount);
        }

        public void Repay(decimal amount)
        {
            ValidateAmount(amount);

            if (amount >= OutstandingBalance)
            {
                CreditBalance += amount - OutstandingBalance;
                OutstandingBalance = 0;
            }
            else
            {
                OutstandingBalance -= amount;
            }
        }

        private void ApplyCharge(decimal amount)
        {
            if (CreditBalance > 0)
            {
                var adjusted = Math.Min(CreditBalance, amount);
                CreditBalance -= adjusted;
                amount -= adjusted;
            }

            OutstandingBalance += amount;
        }

        private void ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
        }

        private void EnsureCreditLimitNotExceeded(decimal amount)
        {
            if (OutstandingBalance + amount > CreditLimit)
                throw new InvalidOperationException("Credit limit exceeded.");
        }
    }

}
