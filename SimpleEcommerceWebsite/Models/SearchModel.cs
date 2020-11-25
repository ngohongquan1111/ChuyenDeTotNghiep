using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEcommerceWebsite.Models
{
    public class SearchModel
    {
        public int ProductId { get; set; }

        public int ProductTypeId { get; set; }

        public string ProductName { get; set; }

        public int OrderBy { get; set; }

    }

    public class SearchOrder
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public SearchOrder(int value, string name)
        {
            this.Value = value;

            this.Name = Name;
        }
    }

   

}