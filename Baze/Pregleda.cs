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
    
    public partial class Pregleda
    {
        public int Id { get; set; }
        public decimal PacijentJmbgPac { get; set; }
        public decimal SpecijalistaJmbgZap { get; set; }
        public string Anamneza { get; set; }
    
        public virtual Pacijent Pacijent { get; set; }
        public virtual Specijalista Specijalista { get; set; }
    }
}
