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
    
    public partial class ZamowieniaZewnetrzne
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ZamowieniaZewnetrzne()
        {
            this.DostawaTowary = new HashSet<DostawaTowary>();
        }
    
        public int IDZamowienieZewnetrzne { get; set; }
        public int IDMagazynu { get; set; }
        public int IDDostawcy { get; set; }
        public int IDFaktury { get; set; }
        public System.DateTime Data { get; set; }
        public string Opis { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DostawaTowary> DostawaTowary { get; set; }
        public virtual Dostawcy Dostawcy { get; set; }
        public virtual Faktury Faktury { get; set; }
        public virtual Magazyny Magazyny { get; set; }
    }
}
