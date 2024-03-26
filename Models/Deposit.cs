using System.ComponentModel;

namespace FinanceApp.Models
{
    public class Deposit
    {
        public Deptslip deptSlip { get; set; }
        public DeptSlipdet deptSlipdet { get; set; }
        public DeptSlipCheque deptSlipCheque { get; set; }
        public DepOfInitDataOffline depOfInitDataOffline { get; set; }

    }
    public class Deptslip
    {
        // public string? coop_id { get; set; }
        // public string? deptcoop_id { get; set; }
        // public string? deptslip_no { get; set; }
        // public string? member_no { get; set; }
        // public string? membcat_code { get; set; }
        // public string? deptno_format { get; set; }
        // public string? deptaccount_no { get; set; }
        // public string? depttype_code { get; set; }
        // public string? deptgroup_code { get; set; }
        // public string? recppaytype_code { get; set; }
        // public string? moneytype_code { get; set; }
        // public string? bank_code { get; set; }
        // public string? bankbranch_code { get; set; }
        // public string? entry_id { get; set; }
        // public string? machine_id { get; set; }
        // public string? tofrom_accid { get; set; }
        // public DateTime? operate_date { get; set; }
        // public DateTime? entry_date { get; set; }
        // public DateTime? calint_from { get; set; }
        // public int? operate_code { get; set; }
        // public int? sign_flag { get; set; }
        // public int? laststmseq_no { get; set; }
        // public int? nobook_flag { get; set; }
        // public int? prnc_no { get; set; }
        // public decimal? deptslip_amt { get; set; }
        // public decimal? deptslip_netamt { get; set; }
        // public decimal? fee_amt { get; set; }
        // public decimal? oth_amt { get; set; }
        // public decimal? prncbal { get; set; }
        // public decimal? withdrawable_amt { get; set; }
        // public decimal? prncbal_bf { get; set; }
        // public decimal? tax_amt { get; set; }
        // public decimal? int_amt { get; set; }
        // public decimal? slipnetprncbal_amt { get; set; }
        // public int? posttovc_flag { get; set; }
        // public string? refer_slipno { get; set; }
        // public string? deptaccount_name { get; set; }
        // public string? depttype_desc { get; set; }
        // public string? dept_objective { get; set; }
        // public int? prncbal_retire { get; set; }
        // public string? remark { get; set; }
        // public List<Recppaytype> recppaytype { get; set; }
        // public List<Tofromacc> tofromacc { get; set; }
        // public DateTime? due_date { get; set; }
        // public string? deptpassbook_no { get; set; }
        // public string? condforwithdraw { get; set; }
        // public string? passbook_flag { get; set; }
        // public int? upint_time { get; set; }
        // public string? deptaccount_ename { get; set; }
        // public string? deptrequest_docno { get; set; }
        // public string? account_type { get; set; }
        // public int? monthintpay_meth { get; set; }
        // public string? traninttype_code { get; set; }
        // public string? tran_deptacc_no { get; set; }
        // public string? dept_tranacc_name { get; set; }
        // public int? deptmonth_status { get; set; }
        // public decimal? deptmonth_amt { get; set; }
        // public int? dept_status { get; set; }
        // public int? monthint_status { get; set; }
        // public int? f_tax_rate { get; set; }
        // public int? adjdate_status { get; set; }
        // public string? membcat_desc { get; set; }
        // public string? reqappl_flag { get; set; }
        // public string? spcint_rate_status { get; set; }
        // public string? spcint_rate { get; set; }
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
        public DateTime? calint_from { get; set; }
        public int? operate_code { get; set; }
        public int? sign_flag { get; set; }
        public int? laststmseq_no { get; set; }
        public int? nobook_flag { get; set; }
        public int? prnc_no { get; set; }
        public decimal? deptslip_amt { get; set; }
        public decimal? deptslip_netamt { get; set; }
        public decimal? fee_amt { get; set; }
        public decimal? oth_amt { get; set; }
        public decimal? prncbal { get; set; }
        public decimal? withdrawable_amt { get; set; }
        public decimal? prncbal_bf { get; set; }
        public decimal? tax_amt { get; set; }
        public decimal? int_amt { get; set; }
        public decimal? slipnetprncbal_amt { get; set; }
        public int? posttovc_flag { get; set; }
        public string? refer_slipno { get; set; }
        public string? deptaccount_name { get; set; }
        public string? depttype_desc { get; set; }
        public string? dept_objective { get; set; }
        public int? prncbal_retire { get; set; }
        public string? remark { get; set; }
        public List<Recppaytype> recppaytype { get; set; }
        public List<Tofromacc> tofromacc { get; set; }
        public DateTime? due_date { get; set; }
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
        public decimal? deptmonth_amt { get; set; }
        public int? dept_status { get; set; }
        public int? monthint_status { get; set; }
        public int? f_tax_rate { get; set; }
        public int? adjdate_status { get; set; }
        public int? membcat_desc { get; set; }
        public int? reqappl_flag { get; set; }
        public int? spcint_rate_status { get; set; }
        public decimal? spcint_rate { get; set; }
        public decimal? deptslipAmt { get; set; }


    }
    public class DeptSlipdet
    {
        public string? coop_id { get; set; }
        public string? deptslip_no { get; set; }
        public string? deptaccount_no { get; set; }
        public int? prnc_no { get; set; }
        public decimal? prnc_bal { get; set; }
        public decimal? prnc_amt { get; set; }
        public DateTime? prnc_date { get; set; }
        public DateTime? calint_from { get; set; }
        public DateTime? calint_to { get; set; }
        public DateTime? prncdue_date { get; set; }
        public DateTime? prncmindue_date { get; set; }
        public int? prncdue_nmonth { get; set; }
        public decimal? prncslip_amt { get; set; }
        public decimal? intarr_amt { get; set; }
        public decimal? intpay_amt { get; set; }
        public decimal? taxpay_amt { get; set; }
        public decimal? intbf_accyear { get; set; }
        public int? intcur_accyear { get; set; }
        public DateTime? monthintdue_date { get; set; }
        public DateTime? prncdeptdue_date { get; set; }
        public decimal? interest_rate { get; set; }
        public decimal? int_return { get; set; }
        public decimal? tax_return { get; set; }
        public decimal? fee_amt { get; set; }
        public decimal? other_amt { get; set; }
        public decimal? chequepend_amt { get; set; }
        public int? refer_prnc_no { get; set; }
        public int? upint_time { get; set; }
    }
    public class DeptSlipCheque
    {
        public string? coop_id { get; set; }
        public string? deptslip_no { get; set; }
        public string? deptaccount_no { get; set; }
        public string? cheque_no { get; set; }
        [DefaultValue(0)]
        public string? bank_code { get; set; }
        public string? bankbranch_code { get; set; }
        public DateTime? cheque_date { get; set; }
        public DateTime? entry_date { get; set; }
        public DateTime? entry_time { get; set; }
        public DateTime? chequedue_date { get; set; }
        public string? cheque_type { get; set; }
        public decimal? cheque_amt { get; set; }
        [DefaultValue(0)]
        public int? seq_no { get; set; }
        [DefaultValue(0)]
        public int? checkclear_status { get; set; }
        public string? entry_id { get; set; }
        public string? depttype_code { get; set; }
    }
    public class Tofromacc
    {
        public string tofrom_accid { get; set; }
        public string tofrom_accdesc { get; set; }
        public string cash_type { get; set; }
    }
    public class Recppaytype
    {
        public string recppaytype_code { get; set; }
        public string recppaytype_desc { get; set; }
        public string cash_type { get; set; }
        public string tofrom_accid { get; set; }
        public int genvc_flag { get; set; }
        public int adjdate_status { get; set; }
    }
    public class ErrorResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public string Errors { get; set; }
    }
    public class Errors
    {
        public string errors { get; set; }
    }
    public class ApiResponseModal
    {
        public bool status { get; set; }
        public AccountDetails data { get; set; }
        public string message { get; set; }
    }
    public class DepOfGetAccount
    {
        public AccountDetails accountDetails { get; set; }
    }
    public class AccountDetails
    {
        public string coop_id { get; set; }
        public string memcoop_id { get; set; }
        public string? deptaccount_no { get; set; }
        public string? deptaccount_name { get; set; }
        public string? member_no { get; set; }
        public string? depttype_code { get; set; }
        public int deptclose_status { get; set; }
        public string? memb_name { get; set; }
        public string? memb_surname { get; set; }
        public string? card_person { get; set; }
        public string? mem_telmobile { get; set; }
        public string? full_name { get; set; }
        public string? salary_id { get; set; }
        public DateTime? entry_date { get; set; }
        public string? deptaccountNo_fild { get; set; }
        public string? membgroup_code { get; set; }
        public string? membgroup_desc { get; set; }
        public string? deptno_format { get; set; }
        // public int? reqappl_flag { get; set; }
    }
    public class DepOfInitDataOffline
    {
        public string coop_id { get; set; }
        public string? memcoop_id { get; set; }
        public string? deptno_format { get; set; }
        public string? deptaccount_no { get; set; }
        public string? deptaccount_name { get; set; }
        public string? member_no { get; set; }
        public string? depttype_code { get; set; }
        [DefaultValue(0)]
        public int deptclose_status { get; set; }
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
        [DefaultValue(0)]
        public int reqappl_flag { get; set; }
        public string? membcat_code { get; set; } = null;
    }
    public class DataStatement
    {
        public string? coop_id { get; set; }
        public string? deptaccount_no { get; set; }
        public string? deptaccount_name { get; set; }
        public string? member_no { get; set; }
        public string? depttype_code { get; set; }
        public string? depttype_desc { get; set; }
        public string? deptpassbook_no { get; set; }
        public decimal? prncbal { get; set; }
        public decimal? withdrawable_amt { get; set; }
        public List<Statement> statement { get; set; }


    }
    public class Statement
    {
        public int? number_no { get; set; }
        public string? coop_id { get; set; }
        public string? deptaccount_no { get; set; }
        public int? seq_no { get; set; }
        public string? deptitemtype_code { get; set; }
        public string? deptitemtype_desc { get; set; }
        public DateTime? operate_date { get; set; }
        public DateTime? entry_date { get; set; }
        public decimal? prncbal { get; set; }
        public string? entry_id { get; set; }
        public int? item_status { get; set; }
        public int? sign_flag { get; set; }
        public string? print_code { get; set; }
        public int? prnc_no { get; set; }
        public int? tax_amt { get; set; }
        public decimal? accuint_amt { get; set; }
        public decimal? int_amt { get; set; }
        public int? printbook_status { get; set; }
        public string? deptslip_no { get; set; }
        public int? deptitem_amt { get; set; }
        public int? deptint_amt { get; set; }
        public decimal deposit_amt { get; set; }
        public decimal? withdraw_amt { get; set; }
    }

}
