using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.SimpleEcomerceDbContext;
using System.Collections.Generic;
using System.Linq;

namespace SimpleEcommerceWebsite
{
    public static class AllcodeService
    {
        private static List<Allcode> GetAll()
        {
            var allCodes = new List<Allcode>();

            using (var context = new EcommerceDbContext())
            {
                allCodes = context.Allcodes.Select(x => x).ToList();
            }

            return allCodes;
        }

        public static List<Allcode> GetAllCodeByTable(string spaceName,string scopeName = "")
        {
            var allCodes = new List<Allcode>();

            allCodes = GetAll().Where(al => al.IdentitySpace == spaceName).ToList();

            if (!string.IsNullOrEmpty(scopeName))
            {
                allCodes = allCodes.Where(al => al.IdentityScope == scopeName).ToList();
            }

            return allCodes;
        }
    }
}