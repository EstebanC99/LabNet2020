namespace PruebaMock.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TEST.EMPLOYEES")]
    public partial class EMPLOYEES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEES()
        {
            EMPLOYEES1 = new HashSet<EMPLOYEES>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string LAST_NAME { get; set; }

        public decimal? SALARY { get; set; }

        public int? DEPARTMENT_ID { get; set; }

        [StringLength(6)]
        public string JOB_ID { get; set; }

        public DateTime HIRE_DATE { get; set; }

        public int? MANAGER_ID { get; set; }

        public virtual DEPARTMENTS DEPARTMENTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEES> EMPLOYEES1 { get; set; }

        public virtual EMPLOYEES EMPLOYEES2 { get; set; }

        public virtual JOBS JOBS { get; set; }
    }
}
