//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTicketHistory
    {
        public int idsTicketHistory { get; set; }
        public System.DateTime dtmEdit { get; set; }
        public int idsUser { get; set; }
        public bool blnResolved { get; set; }
        public int idsTicket { get; set; }
    
        public virtual tblTicket tblTicket { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}