using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePolicy.Models
{
    public class PolicyRepository
    {
        PolicyContext context = new PolicyContext();

        public IEnumerable<Policy> ListPolicy()
        {
            var list = context.Policies.ToList();
            return list;
        }

        public Policy FindPolicy(int id)
        {
            var result = context.Policies.Find(id);
            return result;
        }


        public int AddNewPolicy(Policy policy)
        {
            //var result = context.Database.ExecuteSqlCommand("User_Insert @UserName, @Password",
            //    new SqlParameter("@UserName", user.UserName),
            //    new SqlParameter("@Password", user.Password));
            //policy.InstallementPremium = CalculatePremium(policy.PlanNumber,policy.PremiumMode,policy.SumAssured,policy.PolicyTerm);
            SqlParameter[] parameters = {
                        new SqlParameter("policyno", policy.PolicyNumber),
                        new SqlParameter("planno", policy.PlanNumber),
                        new SqlParameter("installement", policy.InstallementPremium),
                        new SqlParameter("insured", policy.Insured),
                        new SqlParameter("assured", policy.SumAssured),
                        new SqlParameter("status", policy.PolicyStatus),
                        new SqlParameter("mode", policy.PremiumMode),
                        new SqlParameter("due", policy.PremiumDueDate),
                        new SqlParameter("benfit", policy.Beneficiary),
                        new SqlParameter("owner", policy.Owner),
                        new SqlParameter("policyterm", policy.PolicyTerm)
                };
            //{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}
            var result = context.Database.ExecuteSqlCommand("USP_POLICIES_INSERT @policyno, @planno, @installement, @insured, @assured, @status, @mode, @due, @benfit, @owner, @policyterm", parameters);
            return result;
        }

        public int EditPolicy(Policy policy)
        {
            SqlParameter[] parameters = {
                        new SqlParameter("policyno", policy.PolicyNumber),
                        new SqlParameter("planno", policy.PlanNumber),
                        new SqlParameter("installement", policy.InstallementPremium),
                        new SqlParameter("insured", policy.Insured),
                        new SqlParameter("assured", policy.SumAssured),
                        new SqlParameter("status", policy.PolicyStatus),
                        new SqlParameter("mode", policy.PremiumMode),
                        new SqlParameter("due", policy.PremiumDueDate),
                        new SqlParameter("benfit", policy.Beneficiary),
                        new SqlParameter("owner", policy.Owner),
                        new SqlParameter("policyterm", policy.PolicyTerm)
                };
            //{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}
            var result = context.Database.ExecuteSqlCommand("USP_POLICIES_EDIT @policyno, @planno, @installement, @insured, @assured, @status, @mode, @due, @benfit, @owner, @policyterm", parameters);
            return result;
        }

        public int DeletePolicy(int id)
        {
            SqlParameter parameter = new SqlParameter("policyno", id);
            var result = context.Database.ExecuteSqlCommand("USP_POLICIES_DELETE @policyno", parameter);
            return result;
        }

        public SelectList InitializeSelectListForPlanNumber()
        {
            return new SelectList(context.PolicyTypes, "PlanNumber", "PolicyName");          
        }

        public SelectList InitializeSelectListForOwner()
        {
            var owner = context.Participants.Where(p => p.ParticipantType.ParticipantsTypeName == "Owner");
            return new SelectList(owner, "FirstName", "FirstName");
        }

        public SelectList InitializeSelectListForInsured()
        {
            var insured = context.Participants.Where(p => p.ParticipantType.ParticipantsTypeName == "Insured");
            return new SelectList(insured, "FirstName", "FirstName");
        }

        public SelectList InitializeSelectListForBeneficiary()
        {
            var beneficiary = context.Participants.Where(p => p.ParticipantType.ParticipantsTypeName == "Beneficiary");
            return new SelectList(beneficiary, "FirstName", "FirstName");
        }
    }
}