using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceWebsite.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [Column("ContactID")]
        public int ContactId { get; set; }

        [Column("ContactPerson")]
        public string ContactPerson { get; set; }

        [Column("ContactType")]
        public int ContactType { get; set; }

        [Column("ContactEmail")]
        public string ContactEmail { get; set; }

        [Column("ContactCreated")]
        public  DateTime ContactCreated { get; set; }
    }
}