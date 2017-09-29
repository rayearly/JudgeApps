using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudgeApps.Models
{
    public class Booth
    {
        public int Id { get; set; }

        public string BoothId { get; set; }

        public ICollection<Group> Group { get; set; }

        public ICollection<JudgeBoothMark> JudgeBoothMark { get; set; }
    }
}