//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JudgeApps
{
    using System;
    using System.Collections.Generic;
    
    public partial class JudgeBoothMark
    {
        public int JudgeId { get; set; }
        public int BoothId { get; set; }
        public Nullable<int> MarkId { get; set; }
    
        public virtual Booth Booth { get; set; }
        public virtual Judge Judge { get; set; }
        public virtual Mark Mark { get; set; }
    }
}
