using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JudgeApps.Models
{
    public class CashRecipientVm
    {
        public int? ID { get; set; }
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Please enter the name of the recipient")]
        public string Recipient { get; set; }
    }
}