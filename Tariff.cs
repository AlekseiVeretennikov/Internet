//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Интернет
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tariff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tariff()
        {
            this.C_Application = new HashSet<C_Application>();
        }
    
        public int TariffID { get; set; }
        public Nullable<int> Amount { get; set; }
        public int InternetID { get; set; }
        public Nullable<int> EquipmentID { get; set; }
        public Nullable<int> SaleID { get; set; }
        public Nullable<int> TVID { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Internet Internet { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual TV TV { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<C_Application> C_Application { get; set; }
    }
}
