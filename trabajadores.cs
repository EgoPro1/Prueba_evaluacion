//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pruebatec
{
    using System;
    using System.Collections.Generic;
    
    public partial class trabajadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trabajadores()
        {
            this.trabajadores1 = new HashSet<trabajadores>();
        }
    
        public int id { get; set; }
        public string fullname { get; set; }
        public Nullable<int> dni { get; set; }
        public Nullable<int> idboss { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trabajadores> trabajadores1 { get; set; }
        public virtual trabajadores trabajadores2 { get; set; }
    }
}