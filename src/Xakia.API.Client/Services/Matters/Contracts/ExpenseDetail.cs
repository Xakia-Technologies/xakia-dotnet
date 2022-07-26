using NodaTime;
using System;

namespace Xakia.API.Client.Services.Matters.Contracts
{
    public class ExpenseDetail
    {
        public Guid ExpenseId { get; set; }

        public LocalDate InvoiceDate { get; set; }

        public string InvoiceNumber { get; set; }

        public string Currency { get; set; }

        public double ExchangeRate { get; set; }

        public decimal Total { get; set; }

        public string Notes { get; set; }

    }
}
