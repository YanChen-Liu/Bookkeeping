using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accounting.Models;
using Accounting.Models.ViewModel;
using ServiceLab.Repositories;
using PagedList;

namespace Accounting.Service
{    
    public class AccountingService
    {
        private readonly IRepository<AccountBook> _homworkRep;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly SkillTreeHomeworkEntities _db;

        public AccountingService(IUnitOfWork unitOfWork)
        {
            //_db = new SkillTreeHomeworkEntities();
            _unitOfWork = unitOfWork;
            _homworkRep = new Repository<AccountBook>(unitOfWork);
        }
        public AccountingToPagedListViewModel Lookup(int page)
        {
            var source = _homworkRep.LookupAll();
            source = source.OrderBy(x => x.Id);
            int currentPage = page < 1 ? 1 : page;
            var PageList = new AccountingToPagedListViewModel()
            {
                Bookkeeping = source.ToPagedList(currentPage, 10),
                PageIndex = currentPage
            };
            return PageList;
        }

        public IEnumerable<AccountBook> List()
        {
            var source = _homworkRep.LookupAll();

            return source;
        }

        public AccountBook GetSingle(Guid orderId)
        {
            return _homworkRep.GetSingle(x => x.Id == orderId);
        }

        public void Add(BookkeepingViewModel data)
        {
            var newaccountbook = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = (int)data.Money,
                Dateee = data.Day,
                Remarkkk = data.Remarks
            };
            if (data.Item == "支出")
            {
                newaccountbook.Categoryyy = 0;
            }
            else if (data.Item == "收入")
            {
                newaccountbook.Categoryyy = 1;
            }

            _homworkRep.Create(newaccountbook);
        }

        public void Delete(AccountBook data)
        {
            _homworkRep.Remove(data);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public static List<BookkeepingViewModel> AllData(BookkeepingViewModel bookkeeping)
        {
            //實體化列表
            List<BookkeepingViewModel> Data = new List<BookkeepingViewModel>();

            //加入三筆預設資料
            Data.Add(new BookkeepingViewModel
            {
                ID = 1,
                Item = "支出",
                Day = new DateTime(2016, 1, 1),
                Money = 300,
                Remarks = "第一筆"
            });
            Data.Add(new BookkeepingViewModel
            {
                ID = 2,
                Item = "支出",
                Day = new DateTime(2016, 1, 2),
                Money = 1600,
                Remarks = "第二筆"
            });
            Data.Add(new BookkeepingViewModel
            {
                ID = 3,
                Item = "支出",
                Day = new DateTime(2016, 1, 3),
                Money = 800,
                Remarks = "第三筆"
            });
            Data.Add(new BookkeepingViewModel
            {
                ID = 4,
                Item = bookkeeping.Item,
                Day = bookkeeping.Day,
                Money = bookkeeping.Money,
                Remarks = bookkeeping.Remarks
            });
            return Data;
        }
    }
}