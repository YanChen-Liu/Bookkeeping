using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Models.ViewModel
{
    public class BookkeepingViewModel
    {        
        [Display(Name = "類別")]
        [Required]
        [Range(0, 1)]
        public int Item { get; set; }//類別
        [Display(Name = "日期")]
        [Required]
        [Remote("Valid", "Accounting", ErrorMessage = "日期不可大於今天")]
        public DateTime Day { get; set; }//日期
        [Display(Name = "金額")]
        [Required]
        [Range(1, int.MaxValue)]
        public Decimal Money { get; set; }//金額
        [Display(Name = "備註")]
        [MaxLength(100)]
        [Required]
        public string Remarks { get; set; }//備註       
    }    
}