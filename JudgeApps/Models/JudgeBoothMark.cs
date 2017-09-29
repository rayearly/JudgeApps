using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JudgeApps.Models
{
    public class JudgeBoothMark
    {
        [Key, Column(Order = 0)]
        public int JudgeId { get; set; }

        [Key, Column(Order = 1)]
        public int BoothId { get; set; }

        public int MarkId { get; set; }

        public virtual Judge Judge { get; set; }
        public virtual Booth Booth { get; set; }
        public virtual Mark Mark { get; set; }
    }
}