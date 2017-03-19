using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accounting.Models.ViewModel;
using Accounting.Models;
using Accounting.Service;
using System.Net;
using ServiceLab.Repositories;
using PagedList;
using PagedList.Mvc;

namespace Accounting.Controllers
{
    public class AccountingController : Controller
    {
        private readonly AccountingService _homeworkSvc;

        public AccountingController()
        {
            var unitOfWork = new EFUnitOfWork();
            _homeworkSvc = new AccountingService(unitOfWork);
        }
        // GET: Accounting
        public ActionResult Index(int page = 1)
        {
            var source = _homeworkSvc.Lookup(page);
            return View(source);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookkeepingViewModel data)
        {
            if (ModelState.IsValid)
            {
                _homeworkSvc.Add(data);
                _homeworkSvc.Save();

                return RedirectToAction("Index");
            }
                        
            return View(data);
        }

        public ActionResult Valid(DateTime day)
        {
            bool isValidate = day < DateTime.Now;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}