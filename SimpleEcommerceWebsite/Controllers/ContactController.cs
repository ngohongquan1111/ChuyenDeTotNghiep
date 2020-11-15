﻿using SimpleEcommerceWebsite.Models;
using SimpleEcommerceWebsite.Service.BaseService;
using SimpleEcommerceWebsite.Service.Resource.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleEcommerceWebsite.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Account account)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterAccount(Account account)
        {
            try
            {
                var accountService = new AccountService();

                account.AccountRoleId = (int)AccountRole.Customer;

                account.AccountStatusID = (int)AccountStatusId.Default;

                accountService.RegisterAccount(account, out string mess);

                return Json(new { success = "true", messages = "Register successfull" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, messages = ex.Message});
            }
        }
    }
}