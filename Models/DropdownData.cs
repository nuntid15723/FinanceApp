namespace FinanceApp.Models
{
	public class DropdownData
	{
		public BankBranch bankBranch { get; set; }
		public GetBank getBank { get; set; }
	}
	public class BankBranch
	{
		public string bank_code { get; set; }
		public string branch_id { get; set; }
		public string branch_name { get; set; }
	}
	public class GetBank
	{
		public string bank_code { get; set; }
		public string bank_desc { get; set; }
		public string bank_name_e { get; set; }
		public string bank_shortname_t { get; set; }
	}
}
