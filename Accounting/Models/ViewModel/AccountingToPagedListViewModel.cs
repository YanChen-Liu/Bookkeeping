using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Accounting.Models.ViewModel
{
    public class AccountingToPagedListViewModel
    {
        public IPagedList<AccountBook> Bookkeeping { get; set; }
        public int PageIndex { get; set; }
    }
}