using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace SimpleEcommerceWebsite.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int ProductID { get; set; }

        [Column("ProducerId")]
        public int ProducerId { get; set; }

        [Column("ProductTypeId")]
        public int ProductTypeId { get; set; }


        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("ProductStatusId")]
        public int ProductStatusId { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("LastModified")]
        public DateTime LastModified { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Price")]
        public System.Int64 Price { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("ImageURL")]
        public string ImageURL { get; set; }

        [Column("ColorId")]
        public int ColorId { get; set; }

        [Column("BrandId")]
        public int BrandId { get; set; }

        [Column("MaterialId")]
        public int MaterialId { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}