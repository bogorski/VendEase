//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VendEase.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faktury
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faktury()
        {
            this.ZamowieniaZewnetrzne = new HashSet<ZamowieniaZewnetrzne>();
        }
    
        public int IDFaktury { get; set; }
        public string NIP { get; set; }
        public string NazwaSprzedawcy { get; set; }
        public string Ulica { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
        public decimal WartoscNetto { get; set; }
        public decimal WartoscBrutto { get; set; }
        public int VAT { get; set; }
        public System.DateTime DataWystawienia { get; set; }
        public string NumerFaktury { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZamowieniaZewnetrzne> ZamowieniaZewnetrzne { get; set; }
    }
}
