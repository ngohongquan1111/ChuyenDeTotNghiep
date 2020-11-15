using SimpleEcommerceWebsite.SimpleEcomerceDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleEcommerceWebsite.Repository
{
    public class ContextRepository<T> where T : class
    {
        private EcommerceDbContext GetContext<T>(T context)
        {
            return new EcommerceDbContext();
        }

        public int Add<T1>()
        {
            using (var dbcontext = GetContext())
            {
                dbcontext.T1
            }
        }

        public int FindById<T1>()
        {
            throw new NotImplementedException();
        }

        public int Update<T1>()
        {
            throw new NotImplementedException();
        }
    }
}