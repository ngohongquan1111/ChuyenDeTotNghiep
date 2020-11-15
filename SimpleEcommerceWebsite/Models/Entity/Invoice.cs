using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceWebsite.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        [Column("InvoiceId")]
        public int InvoiceId { get; set; }

        [Column("ContactId")]
        public int ContactId { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("InvoiceStatusId")]
        public int InvoiceStatusId { get; set; }

        [Column("PaymentMenthodId")]
        public int PaymentMenthodId { get; set; }
    }
}