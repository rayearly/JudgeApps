using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JudgeApps.Models;

namespace JudgeApps.ViewModel
{
    public class JudgeBoothMarkViewModel
    {
        public Judge Judge { get; set; }
        public IEnumerable<Booth> Booths { get; set; }
        public Mark Mark { get; set; }
        public IEnumerable<JudgeBoothMark> JudgeBoothMarks { get; set; }
    }
}