//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductionPractice.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course_Tag
    {
        public int Id { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<int> TagId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
