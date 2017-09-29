using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudgeApps.Models
{
    public class Mark
    {
        public int MarkId { get; set; }

        public int ANovelty { get; set; }

        public int ACreativity { get; set; }

        public int AReflects { get; set; }

        public int BOptimal { get; set; }

        public int BContribution { get; set; }

        public int CPosterOral { get; set; }

        public int CDesignDisplay { get; set; }

        public int DTargetMarket { get; set; }

        public int DCompetitiveness { get; set; }

        public double TotalMarks { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public ICollection<JudgeBoothMark> JudgeBoothMarks { get; set; }
    }
}