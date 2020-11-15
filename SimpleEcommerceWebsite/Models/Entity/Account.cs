using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceWebsite.Models
{    
    [Table("Account")]
    public class Account
    {
        [Key]
        [Column("AccountId")]
        public int AccountId { get; set; }

        [Column("EmailLogin")]
        public string EmailLogin { get; set; }

        [Column("AccountStatusID")]
        public int AccountStatusID { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("PassWordSalt")]
        public string PassWordSalt { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("LastLoginDate")]
        public DateTime LastLoginDate { get; set; }

        [Column("AccountRoleId")]
        public int AccountRoleId { get; set; }

        [NotMapped]
        public List<Contact> Contacts { get; set; }
    }
}