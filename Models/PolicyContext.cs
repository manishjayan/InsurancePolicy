using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace InsurancePolicy.Models
{
    public partial class PolicyContext : DbContext
    {
        public PolicyContext()
            : base("name=PolicyDbConnection")
        {
        }

        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<ParticipantType> ParticipantTypes { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyType> PolicyTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Participant>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<ParticipantType>()
                .Property(e => e.ParticipantsTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Policy>()
                .Property(e => e.Insured)
                .IsUnicode(false);

            modelBuilder.Entity<Policy>()
                .Property(e => e.PolicyStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Policy>()
                .Property(e => e.PremiumMode)
                .IsUnicode(false);

            modelBuilder.Entity<Policy>()
                .Property(e => e.Beneficiary)
                .IsUnicode(false);

            modelBuilder.Entity<PolicyType>()
                .Property(e => e.PolicyName)
                .IsUnicode(false);
        }
    }
}
