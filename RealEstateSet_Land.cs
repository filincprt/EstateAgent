//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EstateAgent
{
    using System;
    using System.Collections.Generic;
    
    public partial class RealEstateSet_Land
    {
        public int Id { get; set; }
        public Nullable<double> TotalArea { get; set; }
    
        public virtual RealEstateSet RealEstateSet { get; set; }
    }
}
