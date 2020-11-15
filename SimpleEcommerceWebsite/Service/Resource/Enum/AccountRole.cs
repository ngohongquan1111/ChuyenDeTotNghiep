using System.ComponentModel;

namespace SimpleEcommerceWebsite.Service.Resource.Enum
{
    public enum AccountRole
    {
        [Description("Account for Administrator")]
        Administrator = 0,

        [Description("Account for Customer")]
        Customer  = 1
    }
}