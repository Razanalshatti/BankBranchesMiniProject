using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class BankBranch
    {
        public int branchId { get; set; }
        public string branchName { get; set; }
        public string location { get; set; }
        public string locationURL { get; set; }
        public string branchManager { get; set; }
        public int employeeCount { get; set; }
    }

    public static class BankBranchData
    {
        public static List<BankBranch> BankBranches = new List<BankBranch>
        {
            new BankBranch {branchId = 1, branchName = "KFH" , location = "Qadsiya" , locationURL = "https://maps.app.goo.gl/CTtbQcN6Swd68SF56" , branchManager = "Razan" , employeeCount = 12},
            new BankBranch {branchId = 2, branchName = "KFH" , location = "Kaifan" , locationURL = "https://maps.app.goo.gl/AGVK5VHgT2Ggaehx6" , branchManager = "Nada" , employeeCount = 35}
        };
    }
}