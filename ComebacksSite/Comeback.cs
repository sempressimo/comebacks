//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComebacksSite
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comeback
    {
        public int Comeback_ID { get; set; }
        public bool Is_Comeback { get; set; }
        public string RO_Number { get; set; }
        public string VIN { get; set; }
        public Nullable<System.DateTime> OpenDate { get; set; }
        public Nullable<int> ComebackReason_ID { get; set; }
        public string Notes { get; set; }
        public string CustomerName { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Model { get; set; }
        public string CarYear { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public string Complaint { get; set; }
        public Nullable<int> ComebackStatus { get; set; }
    
        public virtual ComebackReason ComebackReason { get; set; }
    }
}
