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

        public AccountingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _homworkRep = new Repository<AccountBook>(unitOfWork);
        }
        public AccountingToPagedListViewModel Lookup(int page)
        {
            var source = _homworkRep.LookupAll();
            source = source.OrderByDescending(x => x.Dateee);
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
                Categoryyy=data.Item,
                Dateee = data.Day,
                Remarkkk = data.Remarks
            };
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