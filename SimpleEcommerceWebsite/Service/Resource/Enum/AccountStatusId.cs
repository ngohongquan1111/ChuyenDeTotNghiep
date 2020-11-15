using System.ComponentModel;

namespace SimpleEcommerceWebsite.Service.Resource.Enum
{
    public enum AccountStatusId
    {
        [Description("Not Verified")]
        Default = 0,

        [Description("Verified Account")]
        Verified = 1,

        [Description("Deleted Account")]
        Deleted = 2,

        [Description("Locked Account")]
        Locked = 3
    }
}