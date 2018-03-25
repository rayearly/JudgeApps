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
        public IList<Booth> Booths { get; set; }
        public Mark Mark { get; set; }
        public IList<JudgeBoothMark> JudgeBoothMarks { get; set; }
    }
}