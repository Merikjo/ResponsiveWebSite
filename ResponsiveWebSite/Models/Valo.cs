//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResponsiveWebSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Valo
    {
        public int ValoID { get; set; }
        public Nullable<int> HuoneID { get; set; }
        public bool ValoOff { get; set; }
        public bool ValoOn33 { get; set; }
        public bool ValoOn66 { get; set; }
        public bool ValoOn100 { get; set; }
        public Nullable<System.DateTime> ValoDate33 { get; set; }
        public Nullable<System.DateTime> ValoDate66 { get; set; }
        public Nullable<System.DateTime> ValoDate100 { get; set; }
        public Nullable<System.DateTime> ValoDateOff { get; set; }
        public string ValoTila { get; set; }
        public string ValonNimi { get; set; }
        public string HuoneenNimi { get; set; }

        public virtual Huone Huone { get; set; }
    }
}
