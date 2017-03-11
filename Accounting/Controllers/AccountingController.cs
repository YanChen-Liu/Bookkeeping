using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookkeeping.Models.ViewModel;

namespace Accounting.Controllers
{
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var ReData = BookkeepingViewModel.AllData();

            return View(ReData);
        }
    }
}