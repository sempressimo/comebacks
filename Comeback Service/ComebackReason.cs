//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Comeback_Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComebackReason
    {
        public ComebackReason()
        {
            this.Comebacks = new HashSet<Comeback>();
            this.ComebackSubReasons = new HashSet<ComebackSubReason>();
        }
    
        public int ComebackReason_ID { get; set; }
        public string ReasonDescription { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<Comeback> Comebacks { get; set; }
        public virtual ICollection<ComebackSubReason> ComebackSubReasons { get; set; }
    }
}
