//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JOUHOU_T_App.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class GROUP_T
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GROUP_T()
        {
            this.JOUHOU_T = new HashSet<JOUHOU_T>();
        }
    
        public int ID { get; set; }
        public byte GROUP_NAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOUHOU_T> JOUHOU_T { get; set; }
    }
}