using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceWebsite.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [Column("OrderId")]
        public int OrderId { get; set; }

        [Column("ProductId")]
        public int ProductId { get; set; }

        [Column("InvoiceId")]
        public int InvoiceId { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

    }
}