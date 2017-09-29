using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudgeApps.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Affiliation { get; set; }

        public string Email { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}