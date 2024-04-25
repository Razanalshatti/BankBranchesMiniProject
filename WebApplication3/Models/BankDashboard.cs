namespace WebApplication3.Models
{
    public class BankDashboard
    {
        public int TotalBranches { get; set; }
        public int TotalEmployees { get; set; }
        public BankBranch BranchWithMostEmployees { get; set; }
        public List<BankBranch> BranchList { get; set; }
    }
}


