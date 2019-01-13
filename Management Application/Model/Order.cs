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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.Outputs = new HashSet<Output>();
        }
    
        public int IDOrder { get; set; }
        public string IDCustomer { get; set; }
        public Nullable<int> Discount { get; set; }
        public System.DateTime DateSale { get; set; }
        public Nullable<float> Deposite { get; set; }
        public int IDStatus { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Output> Outputs { get; set; }
    }
}
