using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service.Resource;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using SimpleEcommerceWebsite.SimpleEcomerceDbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleEcommerceWebsite.Service.BaseService
{
    public class AccountService
    {
        private Account FindAccount(Account account)
        {
            var accountResult = new Account();

            if (account.AccountId != 0 || !string.IsNullOrEmpty(account.EmailLogin))
            {
                using (var dbContext = new EcommerceDbContext())
                {
                    accountResult = dbContext.Accounts.Where(a => a.AccountId == account.AccountId || a.EmailLogin == account.EmailLogin).FirstOrDefault();
                }
            }
            else
            {
                return null;
            }

            return accountResult;
        }

        private IEnumerable<Contact> GetContactsByEmail(string email)
        {
            using (var dbContext = new EcommerceDbContext())
            {
                return dbContext.Contacts.Where(c => c.ContactEmail == email).ToList();
            }
        }

        public bool RegisterAccount(Account account, out string message)
        {
            message = string.Empty;

            if (FindAccount(account) != null)
            {
                throw new Exception("Email is registered, Forgot your pass word?");
            }

            var newAccountRegister = new Account();

            newAccountRegister.AccountId = 0;

            newAccountRegister.EmailLogin = account.EmailLogin;

            newAccountRegister.PassWordSalt = DateTime.UtcNow.ToString().EncriptString();

            newAccountRegister.Password = account.Password.EncriptString() + newAccountRegister.PassWordSalt;

            newAccountRegister.CreatedDate = DateTime.Now;

            newAccountRegister.AccountRoleId = account.AccountRoleId;

            newAccountRegister.AccountStatusID = account.AccountStatusID;

            using (var dbContext = new EcommerceDbContext())
            {
                dbContext.Accounts.Add(newAccountRegister);

                newAccountRegister.AccountId = dbContext.SaveChanges();
            }

            return true;
        }

        public static bool IsLogin()
        {
            return SessionManager.GetSessionObject(SessionObjectEnum.SessionEnum.UserInfo) != null; 
        }
    }
}
