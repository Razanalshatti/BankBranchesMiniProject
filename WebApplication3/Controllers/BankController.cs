using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index()
        {
            return View(BankBranchData.BankBranches);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewBranchForm form)
        {
            if (ModelState.IsValid)
            {
                var branchName = form.branchName;
                var location = form.location;
                var locationURL = form.locationURL;
                var branchManager = form.branchMnager;
                var employeeCount = form.employeeCount;

                BankBranchData.BankBranches.Add(new BankBranch { branchName = branchName, location = location,locationURL = locationURL,branchManager = branchManager, employeeCount = employeeCount });
                return RedirectToAction("Index","Bank");
            }
            return View();
        }

            public IActionResult Details(int id)
        {
            var BankBranch = BankBranchData.BankBranches.FirstOrDefault(branch => branch.branchId == id);

            if (BankBranch == null)
            {
                return NotFound();
            }
            return View(BankBranch);
        }

    }
}
