//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kino
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int id { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> taskId { get; set; }
        public Nullable<System.DateTime> dateFrom { get; set; }
        public Nullable<System.DateTime> dateTo { get; set; }
        public Nullable<int> statusId { get; set; }
    
        public virtual ScheduleStatu ScheduleStatu { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
