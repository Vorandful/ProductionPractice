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
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.BoughtCourse = new HashSet<BoughtCourse>();
            this.Course_Tag = new HashSet<Course_Tag>();
            this.SellHistory = new HashSet<SellHistory>();
        }
    
        public int Id { get; set; }
        public Nullable<double> Length { get; set; }
        public string Name { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public int Episodes { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<int> KnowledgeLevelId { get; set; }
        public string Description { get; set; }
        public string Software { get; set; }
        public Nullable<double> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoughtCourse> BoughtCourse { get; set; }
        public virtual KnowledgeLevel KnowledgeLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Tag> Course_Tag { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SellHistory> SellHistory { get; set; }
    }
}
