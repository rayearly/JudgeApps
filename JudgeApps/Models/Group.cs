using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JudgeApps.Models
{
    public class Group
    {
        public int Id { get; set; }

        // Assign by counting the number of current participant and convert in string to display.
        public string ParticipantId { get; set; }

        public ICollection<Participant> Participants { get; set; }

        public int BoothId { get; set; }

        public Booth Booth { get; set; }

        public int MarkId { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}