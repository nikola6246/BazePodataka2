//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Baze
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zaposleni
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zaposleni()
        {
            this.Bolnicas = new HashSet<Bolnica>();
        }
    
        public decimal JmbgZap { get; set; }
        public string ImeZap { get; set; }
        public string PrezZap { get; set; }
        public string PlataZap { get; set; }
        public string GodineZap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bolnica> Bolnicas { get; set; }
    }
}