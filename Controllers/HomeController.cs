using InsurancePolicy.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePolicy.Controllers
{
    public class HomeController : Controller
    {
        PolicyContext context = new PolicyContext();
        [HttpGet]
        public ActionResult Index()
        {
            var model = context.Policies.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddPolicy()
        {
            InitializeSelectList();
            return View();
        }
        [HttpPost]
        public ActionResult AddPolicy(Policy policy)
        {
            try
            {
                TempData["Message"] = "New Policy Added";
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
                var result = context.Database.ExecuteSqlCommand("USP_POLICIES_INSERT @policyno, @planno, @installement, @insured, @assured, @status, @mode, @due, @benfit, @owner, @policyterm",parameters);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpGet]
        public ActionResult EditPolicy(int id)
        {
            var policy = context.Policies.Find(id);
            InitializeSelectList();
            return View(policy);
        }
        [HttpPost]
        public ActionResult EditPolicy(Policy policy)
        {
            return View();
        }

        public ActionResult DeletePolicy(int id)
        {
            try
            {
                TempData["Message"] = id+" Policy is Successfully deleted";
                SqlParameter parameter = new SqlParameter("policyno", id);
                var result = context.Database.ExecuteSqlCommand("USP_POLICIES_DELETE @policyno", parameter);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }




        public void InitializeSelectList()
        {
            ViewBag.PlanNumber = new SelectList(context.PolicyTypes, "PlanNumber", "PolicyName");
            var owner = context.Participants.Where(p => p.ParticipantType.ParticipantsTypeName == "Owner");
            ViewBag.Owner = new SelectList(owner, "FirstName", "FirstName");
            var insured = context.Participants.Where(p => p.ParticipantType.ParticipantsTypeName == "Insured");
            ViewBag.insured = new SelectList(insured, "FirstName", "FirstName");
            var beneficiary = context.Participants.Where(p => p.ParticipantType.ParticipantsTypeName == "Beneficiary");
            ViewBag.Beneficiary = new SelectList(beneficiary, "FirstName", "FirstName");
        }

        //public void CalculatePremium(int planNumber,string premiumMode,string sumAssured,string term)
        //{

        //}
    }
}