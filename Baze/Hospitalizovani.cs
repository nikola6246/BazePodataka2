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
    
    public partial class Hospitalizovani
    {
        public decimal Id { get; set; }
        public string Dijagnoza { get; set; }
    
        public virtual Pacijent Pacijent { get; set; }
        public virtual Sestra Sestra { get; set; }
    }
}