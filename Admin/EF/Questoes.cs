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
    
    public partial class Questoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Questoes()
        {
            this.Simulados_Questoes = new HashSet<Simulados_Questoes>();
            this.Simulados_Questoes1 = new HashSet<Simulados_Questoes>();
            this.Alternativas1 = new HashSet<Alternativas>();
        }
    
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string Imagem { get; set; }
        public int Correta { get; set; }
        public int Cat { get; set; }
    
        public virtual Alternativas Alternativas { get; set; }
        public virtual Subcategorias Subcategorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Simulados_Questoes> Simulados_Questoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Simulados_Questoes> Simulados_Questoes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alternativas> Alternativas1 { get; set; }
    }
}
