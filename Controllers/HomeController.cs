using InsurancePolicy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePolicy.Controllers
{
    public class HomeController : Controller
    {
        // All model operations in repository
        PolicyRepository policyRepository = new PolicyRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var model = policyRepository.ListPolicy();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddPolicy()
        {
            // select list from repository
            ViewBag.PlanNumber = policyRepository.InitializeSelectListForPlanNumber();
            ViewBag.Owner = policyRepository.InitializeSelectListForOwner();
            ViewBag.Insured = policyRepository.InitializeSelectListForInsured();
            ViewBag.Beneficiary = policyRepository.InitializeSelectListForBeneficiary();
            return View();
        }
        [HttpPost]
        public ActionResult AddPolicy(Policy policy)
        {
            try
            {
                if (policyRepository.AddNewPolicy(policy)==1)
                {
                    TempData["Success"] = "New Policy Added";
                }
                else
                {
                    TempData["Error"] = "Error Adding New Policy";
                }
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
            var policy = policyRepository.FindPolicy(id);
            ViewBag.PlanNumber = policyRepository.InitializeSelectListForPlanNumber();
            ViewBag.Owner = policyRepository.InitializeSelectListForOwner();
            ViewBag.Insured = policyRepository.InitializeSelectListForInsured();
            ViewBag.Beneficiary = policyRepository.InitializeSelectListForBeneficiary();
            return View(policy);
        }
        [HttpPost]
        public ActionResult EditPolicy(Policy policy)
        {
            if (policyRepository.EditPolicy(policy)==1)
            {
                TempData["Success"] = policy.PolicyNumber + " Policy is Successfully Edited";
            }
            else
            {
                TempData["Error"] = "Policy Editing Error";
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeletePolicy(int id)
        {
            try
            {
                if (policyRepository.DeletePolicy(id) == 1)
                {
                    TempData["Success"] = id + " Policy is Successfully deleted";
                }
                else
                {
                    TempData["Error"] = "Policy Deleting Error";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
            
        }




        

        //public void CalculatePremium(int planNumber,string premiumMode,string sumAssured,string term)
        //{

        //}
    }
}