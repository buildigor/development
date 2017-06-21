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
        [Required]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Must be only letters")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The length of the string must be greater than 1 character")]
        [Display(Name = "Manager")]
        public string ManagerName { get; set; }
        [Required]
        [Display(Name = "Client")]
        public string ClientName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        [Display(Name = "Cost")]
        public double Cost { get; set; }
    }
}