//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Simulados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Simulados()
        {
            this.Simulados_Questoes = new HashSet<Simulados_Questoes>();
        }
    
        public int Id { get; set; }
        public int Usuario { get; set; }
        public System.DateTime Data { get; set; }
        public int Cat { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Simulados_Questoes> Simulados_Questoes { get; set; }
        public virtual Users Users { get; set; }
    }
}
