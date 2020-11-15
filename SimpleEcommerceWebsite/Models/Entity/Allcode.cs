using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerceWebsite.Models
{
    [Table("Allcode")]
    public class Allcode
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdentitySpace")]
        public string IdentitySpace { get; set; }
        [Column("IdentityScope")]
        public string IdentityScope { get; set; }
        [Column("IdentityValueName")]
        public string IdentityValueName { get; set; }
        [Column("IdentityValue")]
        public int IdentityValue { get; set; }
    }
}