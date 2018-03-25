using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace JudgeApps.Models
{
    public class Judge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Affiliation { get; set; }

        public IList<JudgeBoothMark> JudgeBoothMark { get; set; }
    }
}