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
    
    public partial class Bolnica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bolnica()
        {
            this.Zaposlenis = new HashSet<Zaposleni>();
            this.Pacijents = new HashSet<Pacijent>();
        }
    
        public decimal BolnicaId { get; set; }
        public string NazivBolnice { get; set; }
        public decimal GradPostanskiBr { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zaposleni> Zaposlenis { get; set; }
        public virtual Direktor Direktor { get; set; }
        public virtual Grad Grad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pacijent> Pacijents { get; set; }
    }
}
