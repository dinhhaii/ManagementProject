//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Management_Application.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Output
    {
        public string IDProduct { get; set; }
        public string Name { get; set; }
        public int IDOrder { get; set; }
        public Nullable<int> Amount { get; set; }
        public string IDCategory { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<float> Price { get; set; }
        public bool isSelected { get; set; }

        public virtual Category Category { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
