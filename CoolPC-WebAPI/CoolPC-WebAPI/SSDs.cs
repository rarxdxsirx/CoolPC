//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoolPC_WebAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class SSDs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SSDs()
        {
            this.Components = new HashSet<Components>();
        }
    
        public long ssd_id { get; set; }
        public string type { get; set; }
        public string capacity { get; set; }
        public string max_read_speed { get; set; }
        public string max_write_speed { get; set; }
        public long device_type_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Components> Components { get; set; }
    }
}
