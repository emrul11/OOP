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

    }
}
