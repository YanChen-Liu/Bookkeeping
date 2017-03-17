using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models.ViewModel
{
    public class BookkeepingViewModel
    {
        public int ID { get; set; }//流水號
        [Display(Name = "類別")]
        public string Item { get; set; }//類別
        [Display(Name = "日期")]
        public DateTime Day { get; set; }//日期
        [Display(Name = "金額")]
        public Decimal Money { get; set; }//金額
        [Display(Name = "備註")]
        public string Remarks { get; set; }//備註       
    }    
}