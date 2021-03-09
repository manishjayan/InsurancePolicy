namespace InsurancePolicy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Policy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PolicyNumber { get; set; }

        public int? PlanNumber { get; set; }

        public double? InstallementPremium { get; set; }

        [StringLength(50)]
        public string Insured { get; set; }

        public double SumAssured { get; set; }

        [StringLength(10)]
        public string PolicyStatus { get; set; }

        [StringLength(10)]
        public string PremiumMode { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PremiumDueDate { get; set; }

        [StringLength(50)]
        public string Beneficiary { get; set; }

        [StringLength(50)]
        public string Owner { get; set; }

        public int PolicyTerm { get; set; }

        public virtual PolicyType PolicyType { get; set; }
    }
}
