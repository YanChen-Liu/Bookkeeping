using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Models.ViewModel
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

        public static List<BookkeepingViewModel> AllData()
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

            return Data;
        }
    }
}