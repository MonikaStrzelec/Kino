//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kino.Properties
{
    using System;
    using System.Collections.Generic;
    
    public partial class PackPO
    {
        public int IDPackPO { get; set; }
        public Nullable<int> PackID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    
        public virtual Pack Pack { get; set; }
        public virtual Product Product { get; set; }
    }
}
