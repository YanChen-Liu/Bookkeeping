using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Accounting.Models;
using Accounting.Models.ViewModel;
using ServiceLab.Repositories;

namespace Accounting.Service
{    
    public class HomeworkService
    {
        private readonly IRepository<AccountBook> _homworkRep;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly SkillTreeHomeworkEntities _db;

        public HomeworkService(IUnitOfWork unitOfWork)
        {
            //_db = new SkillTreeHomeworkEntities();
            _unitOfWork = unitOfWork;
            _homworkRep = new Repository<AccountBook>(unitOfWork);
        }
        public IEnumerable<AccountBook> Lookup()
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
    }
}