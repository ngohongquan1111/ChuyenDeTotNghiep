namespace SimpleEcommerceWebsite.Service.Resource.Enum
{
    public class ProductEnum
    {
        public enum Status
        {
            Sale,
            Suspended,
            OutOfStock,
            Deleted
        }

        public enum ProductCodes
        {
            ProductStatus,
            Producer,
            ProductType,
            Marterial,
            Color,
            Brand
        }
    }

    public enum PriceOrderEnum
    {
        Default,
        Increase,
        Decrease
    }
}