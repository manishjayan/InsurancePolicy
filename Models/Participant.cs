namespace InsurancePolicy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participant
    {
        [Key]
        public int ParticipantNo { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string MiddleName { get; set; }

        public DateTime? DOB { get; set; }

        public int? ParticipantTypeNo { get; set; }

        public virtual ParticipantType ParticipantType { get; set; }
    }
}
