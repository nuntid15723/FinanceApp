namespace FinanceApp.Models
{
	public class DepReqdepoit
	{
		public DeptSlip deptSlip { get; set; }
		public DeptSlipdet deptSlipdet { get; set; }
		public DeptSlipCheque deptSlipCheque { get; set; }
		public string? coop_id { get; set; }
		public string? deptcoop_id { get; set; }
		public string? deptslip_no { get; set; }
		public string? member_no { get; set; }
		public string? deptno_format { get; set; }
		public string? deptaccount_no { get; set; }
		public string? membcat_code { get; set; }
		public string? depttype_code { get; set; }
		public string? deptgroup_code { get; set; }
		public string? recppaytype_code { get; set; }
		public string? moneytype_code { get; set; }
		public string? bank_code { get; set; }
		public string? bankbranch_code { get; set; }
		public string? entry_id { get; set; }
		public string? machine_id { get; set; }
		public string? tofrom_accid { get; set; }
		public DateTime? operate_date { get; set; }
		public DateTime? entry_date { get; set; }
		public string? calint_from { get; set; }
		public int? sign_flag { get; set; }
		public string? laststmseq_no { get; set; }
		public string? nobook_flag { get; set; }
		public string? prnc_no { get; set; }
		public string? deptslip_amt { get; set; }
		public int? deptslip_netamt { get; set; }
		public decimal? fee_amt { get; set; }
		public decimal? oth_amt { get; set; }
		public decimal? prncbal { get; set; }
		public decimal? withdrawable_amt { get; set; }
		public string? prncbal_bf { get; set; }
		public decimal? tax_amt { get; set; }
		public decimal? int_amt { get; set; }
		public int? slipnetprncbal_amt { get; set; }
		public int? posttovc_flag { get; set; }
		public string? refer_slipno { get; set; }
		public string? deptaccount_name { get; set; }
		public string? depttype_desc { get; set; }
		public string? dept_objective { get; set; }
		public int? prncbal_retire { get; set; }
		public string? remark { get; set; }
		public List<Recppaytype> recppaytype { get; set; }
		public List<Tofromacc> tofromacc { get; set; }
		public List<Depttype> depttype { get; set; }
		public string trandepttype { get; set; }
		public List<Acctype> acctype { get; set; }
		public string? bank { get; set; }
		public string? branch { get; set; }
		public string? due_date { get; set; }
		public string? deptpassbook_no { get; set; }
		public string? condforwithdraw { get; set; }
		public string? passbook_flag { get; set; }
		public int? upint_time { get; set; }
		public string? deptaccount_ename { get; set; }
		public string? deptrequest_docno { get; set; }
		public string? account_type { get; set; }
		public int? monthintpay_meth { get; set; }
		public string? traninttype_code { get; set; }
		public string? tran_deptacc_no { get; set; }
		public string? dept_tranacc_name { get; set; }
		public int? deptmonth_status { get; set; }
		public string? deptmonth_amt { get; set; }
		public string? dept_status { get; set; }
		public int? monthint_status { get; set; }
		public int? f_tax_rate { get; set; }
		public int? adjdate_status { get; set; }
		public string? membcat_desc { get; set; }
		public int? reqappl_flag { get; set; }
		public string? spcint_rate_status { get; set; }
		public string? spcint_rate { get; set; }
	}

	public class DeptSlip
	{
		public string? coop_id { get; set; }
		public string? deptcoop_id { get; set; }
		public string? deptslip_no { get; set; }
		public string? member_no { get; set; }
		public string? deptno_format { get; set; }
		public string? deptaccount_no { get; set; }
		public string? membcat_code { get; set; }
		public string? depttype_code { get; set; }
		public string? deptgroup_code { get; set; }
		public string? recppaytype_code { get; set; }
		public string? moneytype_code { get; set; }
		public string? bank_code { get; set; }
		public string? bankbranch_code { get; set; }
		public string? entry_id { get; set; }
		public string? machine_id { get; set; }
		public string? tofrom_accid { get; set; }
		public DateTime? operate_date { get; set; }
		public DateTime? entry_date { get; set; }
		public string? calint_from { get; set; }
		public int? sign_flag { get; set; }
		public string? laststmseq_no { get; set; }
		public string? nobook_flag { get; set; }
		public string? prnc_no { get; set; }
		public string? deptslip_amt { get; set; }
		public int? deptslip_netamt { get; set; }
		public decimal? fee_amt { get; set; }
		public decimal? oth_amt { get; set; }
		public decimal? prncbal { get; set; }
		public decimal? withdrawable_amt { get; set; }
		public string? prncbal_bf { get; set; }
		public decimal? tax_amt { get; set; }
		public decimal? int_amt { get; set; }
		public int? slipnetprncbal_amt { get; set; }
		public int? posttovc_flag { get; set; }
		public string? refer_slipno { get; set; }
		public string? deptaccount_name { get; set; }
		public string? depttype_desc { get; set; }
		public string? dept_objective { get; set; }
		public int? prncbal_retire { get; set; }
		public string? remark { get; set; }
		public List<Recppaytype> recppaytype { get; set; }
		public List<Tofromacc> tofromacc { get; set; }
		public List<Depttype> depttype { get; set; }
		public string trandepttype { get; set; }
		public List<Acctype> acctype { get; set; }
		public string? bank { get; set; }
		public string? branch { get; set; }
		public string? due_date { get; set; }
		public string? deptpassbook_no { get; set; }
		public string? condforwithdraw { get; set; }
		public string? passbook_flag { get; set; }
		public int? upint_time { get; set; }
		public string? deptaccount_ename { get; set; }
		public string? deptrequest_docno { get; set; }
		public string? account_type { get; set; }
		public int? monthintpay_meth { get; set; }
		public string? traninttype_code { get; set; }
		public string? tran_deptacc_no { get; set; }
		public string? dept_tranacc_name { get; set; }
		public int? deptmonth_status { get; set; }
		public string? deptmonth_amt { get; set; }
		public string? dept_status { get; set; }
		public int? monthint_status { get; set; }
		public int? f_tax_rate { get; set; }
		public int? adjdate_status { get; set; }
		public string? membcat_desc { get; set; }
		public int? reqappl_flag { get; set; }
		public string? spcint_rate_status { get; set; }
		public string? spcint_rate { get; set; }
	}

	public class Depttype
	{
		public string deptmain_type { get; set; }
		public string deptmain_desc { get; set; }
		public string deptgroup_code { get; set; }
	}
	public class Acctype
	{
		public string account_type { get; set; }
		public string account_desc { get; set; }
	}
	public class DepOfInitOpenAccount
	{
		public ReqAccDetails accountDetails { get; set; }
	}
	//Search
	public class ReqAccDetails
	{
		public string? coop_id{get; set;}
		public string? memcoop_id{get; set;}
		public string? deptaccount_no { get; set; }
		public string? deptaccount_name { get; set; }
		public string? member_no { get; set; }
		public string? memberNo_fild { get; set; }
		public string? depttype_code { get; set; }
		public int? deptclose_status { get; set; }
		public string? memb_name { get; set; }
		public string? memb_surname { get; set; }
		public string? card_person { get; set; }
		public string? mem_telmobile { get; set; }
		public string? full_name { get; set; }
		public string? salary_id { get; set; }
		public string? membgroup_code { get; set; }
		public string? membgroup_desc { get; set; }
		public DateTime? entry_date { get; set; }
		public string? deptitem_group { get; set; }
		public int? reqappl_flag { get; set; }
		public string? membcat_code { get; set; }
		// public string? membcat_desc { get; set; }
	}

}
