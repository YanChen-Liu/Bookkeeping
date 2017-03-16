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

namespace Accounting.Controllers
{
    public class AccountingController : Controller
    {
        private readonly HomeworkService _homeworkSvc;

        public AccountingController()
        {
            var unitOfWork = new EFUnitOfWork();
            _homeworkSvc = new HomeworkService(unitOfWork);
        }
        // GET: Accounting
        public ActionResult Index()
        {
            var source = _homeworkSvc.Lookup();
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
                data.ID = 0;
                _homeworkSvc.Add(data);
                _homeworkSvc.Save();

                return RedirectToAction("Index");
            }
            var result = new BookkeepingViewModel()
            {
                ID = 0,
                Item = data.Item,
                Day = data.Day,
                Money = data.Money,
                Remarks = data.Remarks
            };
            return View(result);
        }
    }
}