using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BankController : Controller
    {
        private readonly BankContext _context;

        public BankController(BankContext context)
        {
            _context = context;
        }
      


        public IActionResult Index()
        {
            BankContext bankContext = _context;
            var viewModel = new BankDashboard();
            viewModel.TotalBranches = bankContext.BankBranches.Count();
            viewModel.TotalEmployees = bankContext.Employees.Count();
            viewModel.BranchWithMostEmployees = bankContext.BankBranches
                .OrderByDescending(b => b.Employees.Count)
                .FirstOrDefault();
            viewModel.BranchList = bankContext.BankBranches
                .Include(b => b.Employees)
                .ToList();
            return View(viewModel);
        }
        public IActionResult Details(int id)
        {
            BankContext bankContext = _context;
            var branches = bankContext.BankBranches.Include(r => r.Employees).First(x => x.Id == id);


            if (branches == null)
            {
                return NotFound();
            }
            return View(branches);
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
                BankContext bankContext = _context;

                var branch = new BankBranch
                {
                   // branchName = form.branchName,
                    location = form.location,
                    branchManager = form.branchManager,
                    employeeCount = form.employeeCount,
                    locationURL = form.locationURL
                };
                bankContext.BankBranches.Add(branch);
                bankContext.SaveChanges();
                return RedirectToAction("Index", "Bank");
            }
            return View(form);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            BankContext bankContext = _context;

            var branch = bankContext.BankBranches.Find(id);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
        [HttpPost]
        public IActionResult Edit(int id, BankBranch branch)
        {
            BankContext bankContext = _context;

            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bankContext.Update(branch);
                    bankContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankBranchExists(branch.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(branch);
        }
        private bool BankBranchExists(int id)
        {
            BankContext bankContext = _context;

            return bankContext.BankBranches.Any(e => e.Id == id);
        }
        public IActionResult AddEmployee(int id)
        {

            //ViewBag.BranchId = id;
            return View();

        }
        [HttpPost]
        public IActionResult AddEmployee(int id, AddEmployeeForm employee)
        {
            if (ModelState.IsValid)
            {
                var database = _context;
                var bankbranch = database.BankBranches.Find(id);
                var addEmployee = new Employee();

                addEmployee.Name = employee.Name;
                addEmployee.civilId = employee.civilId;
                addEmployee.Position = employee.position;
                bankbranch.Employees.Add(addEmployee);
                database.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            return View(employee);

        }
    }

}