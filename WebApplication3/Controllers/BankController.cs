using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    //public class BankController : Controller
    //{
    //    private readonly BankContext _context;

    //    public BankController(BankContext context)
    //    {
    //        _context = context;
    //    }



    //    public IActionResult Index()
    //    {
    //        BankContext bankContext = _context;
    //        var viewModel = new BankDashboard();
    //        viewModel.TotalBranches = bankContext.BankBranches.Count();
    //        viewModel.TotalEmployees = bankContext.Employees.Count();
    //        viewModel.BranchWithMostEmployees = bankContext.BankBranches
    //            .OrderByDescending(b => b.Employees.Count)
    //            .FirstOrDefault();
    //        viewModel.BranchList = bankContext.BankBranches
    //            .Include(b => b.Employees)
    //            .ToList();
    //        return View(viewModel);
    //    }
    //    public IActionResult Details(int id)
    //    {
    //        BankContext bankContext = _context;
    //        var branches = bankContext.BankBranches.Include(r => r.Employees).First(x => x.Id == id);


    //        if (branches == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(branches);
    //    }
    //    [HttpGet]
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public IActionResult Create(NewBranchForm form)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            BankContext bankContext = _context;

    //            var branch = new BankBranch
    //            {
    //               // branchName = form.branchName,
    //                location = form.location,
    //                branchManager = form.branchManager,
    //                employeeCount = form.employeeCount,
    //                locationURL = form.locationURL
    //            };
    //            bankContext.BankBranches.Add(branch);
    //            bankContext.SaveChanges();
    //            return RedirectToAction("Index", "Bank");
    //        }
    //        return View(form);

    //    }
    //    [HttpGet]
    //    public IActionResult Edit(int id)
    //    {
    //        BankContext bankContext = _context;

    //        var branch = bankContext.BankBranches.Find(id);

    //        if (branch == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(branch);
    //    }
    //    [HttpPost]
    //    public IActionResult Edit(int id, BankBranch branch)
    //    {
    //        BankContext bankContext = _context;

    //        if (id != branch.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                bankContext.Update(branch);
    //                bankContext.SaveChanges();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!BankBranchExists(branch.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction("Index");
    //        }
    //        return View(branch);
    //    }
    //    private bool BankBranchExists(int id)
    //    {
    //        BankContext bankContext = _context;

    //        return bankContext.BankBranches.Any(e => e.Id == id);
    //    }
    //    public IActionResult AddEmployee(int id)
    //    {

    //        //ViewBag.BranchId = id;
    //        return View();

    //    }
    //    [HttpPost]
    //    public IActionResult AddEmployee(int id, AddEmployeeForm employee)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var database = _context;
    //            var bankbranch = database.BankBranches.Find(id);
    //            var addEmployee = new Employee();

    //            addEmployee.Name = employee.Name;
    //            addEmployee.civilId = employee.civilId;
    //            addEmployee.Position = employee.position;
    //            bankbranch.Employees.Add(addEmployee);
    //            database.SaveChanges();
    //            return RedirectToAction("Details", new { id = id });
    //        }
    //        return View(employee);

    //    }
    //}

    public class BankController : Controller
    {
        private readonly BankContext _bankContext;
        // NEW code _bankContext is the injection :we place it all in >
        public BankController(BankContext Context)
        {
            _bankContext = Context;
        }

        private static List<BankBranch> branchlist = new List<BankBranch>()
    {
        new BankBranch{  location =" Faiha", Id = 1 , branchManager ="Aseel", employeeCount = 12,locationURL= "https://maps.app.goo.gl/i2xcu2BxyHR152iZ8"},
        new BankBranch{  location =" Qadsiya", Id = 2 , branchManager ="Razan", employeeCount = 17,locationURL= "https://maps.app.goo.gl/fbvbF41AFJs3JZ6J7"},


    };

        public IActionResult Index()
        {
            using (_bankContext)
            {
                var viewModel = new BankDashboard();
                viewModel.BranchList = _bankContext.BankBranches.ToList();
                viewModel.TotalBranches = _bankContext.BankBranches.Count();
                viewModel.TotalEmployees = _bankContext.BankBranches.Count();
                viewModel.BranchWithMostEmployees = _bankContext.BankBranches
                    .OrderByDescending(b => b.Employees.Count)
                    .FirstOrDefault();


                return View(viewModel);

        
            }
            return View(branchlist);
        }

        public IActionResult ChangeLanguage(string language = "en")
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName
                , CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language))
                , new CookieOptions { Expires = DateTime.Now.AddYears(1) });

            return RedirectToAction("Index");
        }



        public IActionResult Create(string LocationName)
        {
            List<BankBranch> branchlist = new List<BankBranch>()
            {
            new BankBranch() {
                location = "Kaifan",
                locationURL="https://maps.app.goo.gl/i2xcu2BxyHR152iZ8",
                Id =3 ,
                branchManager ="Bader",
                employeeCount= 72

            }, };

            var bankBranch = branchlist.SingleOrDefault(a => a.location == LocationName);
            if (bankBranch == null)
            {
                return RedirectToAction("Index");
            }
            return View(bankBranch);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(NewBranchForm form)
        {

            var locationname = form.location;
            var branchmanger = form.branchManager;
            var locationUrl = form.locationURL;
            var id = form.Id;
            var employeeCount = form.employeeCount;


            var newBank = new BankBranch();
            newBank.location = locationname;
            newBank.locationURL = locationUrl;
            newBank.branchManager = branchmanger;
            newBank.employeeCount = employeeCount;

            var DbContext = _bankContext;
            DbContext.BankBranches.Add(newBank);
            DbContext.SaveChanges();


            return RedirectToAction("Index");

        }

        public IActionResult Details(int id)
        {
            var db = _bankContext;
            var bankBranches = db.BankBranches.SingleOrDefault(b => b.Id == id);
            if (bankBranches == null)
            {
                return RedirectToAction("Index");
            }
            return View(bankBranches);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var db = _bankContext;
            var bankBranch = db.BankBranches.Find(id);
            if (bankBranch == null)
            {
                return RedirectToAction("Index");
            }
            var myForm = new NewBranchForm();
            myForm.location = bankBranch.location;
            myForm.locationURL = bankBranch.locationURL;
            myForm.branchManager = bankBranch.branchManager;
            myForm.employeeCount = bankBranch.employeeCount;

            return View(myForm);





        }
        [HttpPost]
        public IActionResult Edit(int id, NewBranchForm form)
        {
            if (ModelState.IsValid)
            {

                var db = _bankContext;
                var bankBranch = db.BankBranches.Find(id);
                bankBranch.location = form.location;
                bankBranch.locationURL = form.locationURL;
                bankBranch.branchManager = form.branchManager;
                bankBranch.employeeCount = form.employeeCount;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.View();
        }


        [HttpGet]
        public IActionResult AddNewEmployee(int id)
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(int id, AddEmployeeForm form)
        {
            if (!ModelState.IsValid)
            {
                var db = _bankContext;
                var bankBranches = db.BankBranches.Include(r => r.Employees).SingleOrDefault(v => v.Id == id);
                var newEmployee = new Employee();


                newEmployee.Name = form.Name;
                newEmployee.Position = form.position;
                newEmployee.civilId = form.civilId;
                bankBranches.Employees.Add(newEmployee);

                db.SaveChanges();

            }
            return View();
        }



    }

}