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
    
    public partial class Pacijent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pacijent()
        {
            this.Pregledas = new HashSet<Pregleda>();
            this.Hospitalizovanis = new HashSet<Hospitalizovani>();
        }
    
        public decimal JmbgPac { get; set; }
        public string ImePac { get; set; }
        public string PrezPac { get; set; }
        public int PregledaId { get; set; }
        public decimal GradPostanskiBr { get; set; }
        public decimal BolnicaBolnicaId { get; set; }
        public decimal DoktorJmbgZap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregleda> Pregledas { get; set; }
        public virtual Grad Grad { get; set; }
        public virtual Bolnica Bolnica { get; set; }
        public virtual Doktor Doktor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospitalizovani> Hospitalizovanis { get; set; }
    }
}
