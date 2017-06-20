using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStatistic.Models.WorkModels
{
    public class SellingModels
    {
        public int Id { get; set; }
        [Display(Name = "Manager")]
        public string ManagerName { get; set; }
        [Display(Name = "Client")]
        public string ClientName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }
        [Display(Name = "Cost")]
        public double Cost { get; set; }
    }
}