using Microsoft.JSInterop;
using Newtonsoft.Json;
using FinanceApp.Models;
using Radzen;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using System.Text.Json;
using FinanceApp.Services;
using System.Text;
using Microsoft.AspNetCore.Components;
using System.Globalization;




namespace FinanceApp.Pages.Deposit
{
    public partial class DepDeposit
    {
        private readonly IApiProvider _apiProvider;
        // private async Task CallAlert(string message)
        // {
        //     await jsRuntime.InvokeVoidAsync("alert", message);
        // }
        private List<Models.Deposit> datadetail;
        private List<Models.Recppaytype> recppaytype;
        private List<Models.Tofromacc> tofromacc;
        private Models.Deptslip deptSlip;
        // private string deptaccount_no { get; set; }
        private string coop_id = "065001";
        // private string deptslip_netamt { get; set; }
        // private string memcoop_id { get; set; }
        // private string member_no { get; set; }
        // private string membcat_code { get; set; }
        // private string deptaccount_name { get; set; }
        // private string dept_objective { get; set; }
        // private string depttype_desc { get; set; }
        // private string deptgroup_code { get; set; }
        // private string moneytype_code { get; set; }
        // private string bank_code { get; set; }
        // private string entry_id { get; set; }
        // private string machine_id { get; set; }
        // private string cash_type { get; set; }
        // private string recppaytype_code { get; set; }
        // private string remark { get; set; }
        // private string entry_date { get; set; }
        // private string operate_code { get; set; }
        // private string sign_flag { get; set; }
        // private string laststmseq_no { get; set; }
        // private string deptitem_amt { get; set; }
        // private string fee_amt { get; set; }
        // private string oth_amt { get; set; }
        // private string prncbal { get; set; }
        // private string withdrawable_amt { get; set; }
        // private string prncbal_retire { get; set; }
        // private string tofrom_accid { get; set; }
        // private string depttype_code { get; set; }
        // private DateTime operate_date { get; set; }
        // public string genvc_flag { get; set; }
        // public int adjdate_status { get; set; }

        // public string coop_id { get; set; }
        public string? deptcoop_id { get; set; }
        public string? deptslip_no { get; set; }
        public string? member_no { get; set; }
        public string? membcat_code { get; set; }
        public string? deptno_format { get; set; }
        public string? deptaccount_no { get; set; }
        public string? depttype_code { get; set; }
        public string? deptgroup_code { get; set; }
        public string? recppaytype_code { get; set; }
        public string? moneytype_code { get; set; }
        public string? bank_code { get; set; }
        public string? bankbranch_code { get; set; }
        public string? entry_id { get; set; }
        public string? machine_id { get; set; }
        public string? tofrom_accid { get; set; }
        public DateTime operate_date { get; set; }
        public DateTime entry_date { get; set; }
        public DateTime calint_from { get; set; }
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
        public DateTime? due_date { get; set; }
        public string? deptpassbook_no { get; set; }
        public string? condforwithdraw { get; set; }
        public int? upint_time { get; set; }
        public string? deptaccount_ename { get; set; }
        public string? account_type { get; set; }
        public int? monthintpay_meth { get; set; }
        public string? traninttype_code { get; set; }
        public string? tran_deptacc_no { get; set; }
        public string? dept_tranacc_name { get; set; }
        public int? deptmonth_status { get; set; }
        public decimal? deptmonth_amt { get; set; }
        public int? dept_status { get; set; }
        public int? monthint_status { get; set; }
        public decimal? f_tax_rate { get; set; }
        public int? adjdate_status { get; set; }
        public string? membcat_desc { get; set; }

        /// <summary>
        public decimal? prnc_bal { get; set; }
        public decimal? prnc_amt { get; set; }
        public DateTime prnc_date { get; set; }
        public DateTime calint_to { get; set; }
        public DateTime prncdue_date { get; set; }
        public DateTime prncmindue_date { get; set; }
        public int? prncdue_nmonth { get; set; }
        public decimal? prncslip_amt { get; set; }
        public decimal? intarr_amt { get; set; }
        public decimal? intpay_amt { get; set; }
        public decimal? taxpay_amt { get; set; }
        public decimal? intbf_accyear { get; set; }
        public int? intcur_accyear { get; set; }
        public DateTime monthintdue_date { get; set; }
        public DateTime prncdeptdue_date { get; set; }
        public decimal? interest_rate { get; set; }
        public decimal? int_return { get; set; }
        public decimal? tax_return { get; set; }
        public decimal? other_amt { get; set; }
        public decimal? chequepend_amt { get; set; }
        public int? refer_prnc_no { get; set; }
        /// </summary>
        ////

        public string? cheque_no { get; set; }
        public DateTime cheque_date { get; set; }
        public DateTime entry_time { get; set; }
        public DateTime chequedue_date { get; set; }
        public string? cheque_type { get; set; }
        public decimal? cheque_amt { get; set; }
        public int? seq_no { get; set; }
        public int? checkclear_status { get; set; }
        ///
		private bool isLoading;
        bool isCurrentOptionSelected = false;
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        //ค้นหา
        private async Task Search()
        {
            if (deptaccount_no == null || deptaccount_no == "")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขที่บัญชี", Duration = 1500 });
            }
            else
            {
                try
                {
                    isLoading = true;
                    var response = await
                    httpClient.GetAsync($"{Apiurl.ApibaseUrl}DepOfInitDataOffline?coop_control={coop_id}&deptaccount_no={deptaccount_no}");
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<Models.ApiResponse>(json);
                    Console.WriteLine(apiResponse.status == true);
                    if (apiResponse.status)
                    {
                        datadetail = new List<Models.Deposit> { apiResponse.data };
                        Console.WriteLine($"API request failed: {datadetail}");
                    }
                    else
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "ตรวจสอบเลขที่กรอกให้ถูกต้อง", Duration = 2500 });
                        datadetail = null;
                        Console.WriteLine($"API request failed: {apiResponse.message}");
                    }
                }
                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    isLoading = false;
                }
            }
        }

        //  public class ApiResponse
        // {
        // 		public bool status { get; set; }
        // 		public Models.Deposit data { get; set; }
        // 	public string message { get; set; }
        // } 
        // public class Recppaytype
        // {
        // 		public string recppaytype_code { get; set; }
        // 	public string recppaytype_desc { get; set; }
        // 	public string cash_type { get; set; }
        // } 
        // public class Tofromacc
        // {
        // 	public string tofromacc_id { get; set; }
        // 	public string tofromacc_desc { get; set; }
        // 	public string cash_type { get; set; }
        // }

        // public class Detail
        // {
        // 	public Deptslip deptSlip { get; set; }
        // } 

        // public class Deptslip
        // {
        // 	public string coop_id { get; set; }
        // 	public string memcoop_id { get; set; }
        // 	public string member_no { get; set; }
        // 		public string membcat_code { get; set; }
        // 		public string deptaccount_no { get; set; }
        // 		public string deptaccount_name { get; set; }
        // 		public string dept_objective { get; set; }
        // 		public string depttype_desc { get; set; }
        // 		public string deptgroup_code { get; set; }
        // 		public string moneytype_code { get; set; }
        // 		public string bank_code { get; set; }
        // 		public string entry_id { get; set; }
        // 		public string machine_id { get; set; }
        // 		public string cash_type { get; set; }
        // 		public List<Recppaytype> recppaytype { get; set; }
        // 		public List<Tofromacc> tofromacc { get; set; }
        // 		public DateTime operate_date { get; set; }
        // 		public string remark { get; set; }
        // 		public string entry_date { get; set; }
        // 		public string operate_code { get; set; }
        // 		public string sign_flag { get; set; }
        // 		public string laststmseq_no { get; set; }
        // 		public string deptitem_amt { get; set; }
        // 		public string fee_amt { get; set; }
        // 		public string oth_amt { get; set; }
        // 		public string prncbal { get; set; }
        // 		public string withdrawable_amt { get; set; }
        // 		public string prncbal_retire { get; set; }
        // 		public string recppaytype_code { get; set; }
        // 		public string tofromacc_id { get; set; }
        // 	} 

        //ตาราง
        IList<IDictionary<string, object>> selectedItems;
        int selectedIndex = 0;

        public IEnumerable<IDictionary<string, object>> data { get; set; }

        public IDictionary<string, Type> columns { get; set; }

        public string GetColumnPropertyExpression(string name, Type type)
        {
            var expression = $@"it[""{name}""].ToString()";

            if (type == typeof(int))
            {
                return $"int.Parse({expression})";
            }
            else if (type == typeof(DateTime))
            {
                return $"DateTime.Parse({expression})";
            }

            return expression;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            columns = new Dictionary<string, Type>()
        {
        { "ต้นเงิน", typeof(int) },
        { "ต้นเงินคงเหลือ", typeof(string) },
        { "ยอดเงินทำรายการ", typeof(string) },
        { "วันที่ต้นเงิน", typeof(DateTime) },
        { "วันครบกำหนด", typeof(DateTime) },
        { "วันเริ่มคิดด/บถึง", typeof(DateTime) },
        { "วันคิดด/บถึง", typeof(DateTime) },
        { "ด/บ จ่าย", typeof(DateTime) },
        { "ภาษี", typeof(string) },
        { "ด/บ.หลังหักภาษี", typeof(DateTime) },
        { "ด/บค้าง", typeof(DateTime) },
        { "ค่าปรับ", typeof(string) },
        { "ด/บ เรียกคืน", typeof(DateTime) },
        { "ภาษี เรียกคืน", typeof(string) },
        { "อัตราดอกเบี้ย", typeof(string) },
        { "จำนวนวัน", typeof(string) },
        };

            //  foreach (var i in Enumerable.Range(0, 5))
            //     {
            //         columns.Add($"Column{i}", typeof(string));
            //     }


            data = Enumerable.Range(0, 20).Select(i =>
            {
                var row = new Dictionary<string, object>();

                foreach (var column in columns)
                {
                    row.Add(column.Key, column.Value == typeof(int) ? i :
        column.Value == typeof(DateTime) ? DateTime.Now.AddMonths(i) : $"{column.Key}{i}");
                }

                return row;
            });
        }
        private string selectedValue;
        private string moneytypeCode;

        private string cashTypeValue;
        private string Valueselecte;
        private string recpPayTypeCode { get; set; }
        private string toFromaccId { get; set; }
        private string bookCode { get; set; }
        private string deptslipNetamt { get; set; }
        private DateTime testDateTime = DateTime.Now;

        // Event handler สำหรับ dropdown แรก
        // private void RecpPayTypeChanged(ChangeEventArgs e )
        // {
        //     selectedValue = e.Value.ToString();
        //     ShowCashType();
        //     Console.WriteLine($"Selected Value: {selectedValue}, Custom Value: ");
        // }
        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('_');
            selectedValue = values[0];
            recpPayTypeCode = values[1];
            cashTypeValue = values[2];
            bookCode = selectedValue;
            Console.WriteLine($"Cash Type: {selectedValue}, Recp Pay Type Code: {recpPayTypeCode},toFromaccId:{toFromaccId}");
        }
        private async Task OnToFromAccChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            Valueselecte = values[0];
            toFromaccId = values[1];
            Console.WriteLine($"Cash Type: {selectedValue}, Recp Pay Type Code: {Valueselecte},toFromaccId:{toFromaccId}");

        }
        private async Task CheckNumber()
        {
            deptslipNetamt = "50";
            Console.WriteLine($"input: {deptslipNetamt}");
        }
        private async Task CheckNumber(KeyboardEventArgs e)
        {
            int e_k = e.Key[0]; // ดึงค่า char แรกจาก Key

            // 13 = Enter, 46 = .
            if (e_k != 13 && e_k != 46 && (e_k < 48 || e_k > 57))
            {
                // ไม่ให้ผ่านค่าเข้ามา
                await jsRuntime.InvokeVoidAsync("alert", "กรุณากรอกเฉพาะตัวเลขเท่านั้น!");
            }
        }
        private async Task SaveDataAsync()
        {
            try
            {
                isLoading = true;
                foreach (var item in datadetail)
                {
                    var ItemdeptSlip = item.deptSlip;
                    var ItemdeptSlipdet = item.deptSlipdet;
                    var ItemdeptSlipCheque = item.deptSlipCheque;
                    var Deptslip = new Deptslip
                    {
                        // coop_id = ItemdeptSlip.coop_id,
                        // deptcoop_id = ItemdeptSlip.deptcoop_id,
                        // member_no = ItemdeptSlip.member_no,
                        // membcat_code = ItemdeptSlip.membcat_code,
                        // deptaccount_no = ItemdeptSlip.deptaccount_no,
                        // deptaccount_name = ItemdeptSlip.deptaccount_name,
                        // dept_objective = ItemdeptSlip.dept_objective,
                        // depttype_desc = ItemdeptSlip.depttype_desc,
                        // deptgroup_code = ItemdeptSlip.deptgroup_code,
                        // moneytype_code = (cashTypeValue == null) ? ItemdeptSlip.moneytype_code : cashTypeValue,
                        // bank_code = ItemdeptSlip.bank_code,
                        // entry_id = ItemdeptSlip.entry_id,
                        // machine_id = ItemdeptSlip.machine_id,
                        // recppaytype_code = (recpPayTypeCode == null) ? ItemdeptSlip.recppaytype_code : recpPayTypeCode,
                        // remark = ItemdeptSlip.remark,
                        // entry_date = ItemdeptSlip.entry_date,
                        // operate_code = ItemdeptSlip.operate_code,
                        // sign_flag = ItemdeptSlip.sign_flag,
                        // laststmseq_no = ItemdeptSlip.laststmseq_no,
                        // deptslip_amt = ItemdeptSlip.deptslip_amt,
                        // fee_amt = ItemdeptSlip.fee_amt,
                        // oth_amt = ItemdeptSlip.oth_amt,
                        // prncbal = ItemdeptSlip.prncbal,
                        // withdrawable_amt = ItemdeptSlip.withdrawable_amt,
                        // prncbal_retire = ItemdeptSlip.prncbal_retire,
                        // tofrom_accid = (toFromaccId == null) ? ItemdeptSlip.tofrom_accid : toFromaccId,
                        // operate_date = ItemdeptSlip.operate_date,
                        // depttype_code = ItemdeptSlip.depttype_code,
                        // deptslip_netamt = (deptslipNetamt == null) ? ItemdeptSlip.deptslip_netamt : deptslipNetamt,

                        coop_id = coop_id,
                        deptcoop_id = ItemdeptSlip.deptcoop_id,
                        deptslip_no = ItemdeptSlip.deptslip_no,
                        member_no = ItemdeptSlip.member_no,
                        membcat_code = ItemdeptSlip.membcat_code,
                        deptno_format = ItemdeptSlip.deptno_format,
                        deptaccount_no = ItemdeptSlip.deptaccount_no,
                        depttype_code = ItemdeptSlip.depttype_code,
                        deptgroup_code = ItemdeptSlip.deptgroup_code,
                        recppaytype_code = (recpPayTypeCode == null) ? ItemdeptSlip.recppaytype_code : recpPayTypeCode,
                        moneytype_code = ItemdeptSlip.moneytype_code,
                        bank_code = ItemdeptSlip.bank_code,
                        bankbranch_code = ItemdeptSlip.bankbranch_code,
                        entry_id = "ItemdeptSlip.entry_id",
                        machine_id = ItemdeptSlip.machine_id,
                        tofrom_accid = (toFromaccId == null) ? ItemdeptSlip.tofrom_accid : toFromaccId,
                        operate_date = testDateTime,
                        entry_date = testDateTime,
                        calint_from = testDateTime,
                        operate_code = ItemdeptSlip.operate_code,
                        sign_flag = ItemdeptSlip.sign_flag,
                        laststmseq_no = ItemdeptSlip.laststmseq_no,
                        nobook_flag = ItemdeptSlip.nobook_flag,
                        prnc_no = ItemdeptSlip.prnc_no,
                        // deptslip_amt = (deptslip_amt==null) ? ItemdeptSlip.deptslip_amt: deptslip_amt,
                        deptslip_amt = ItemdeptSlip.deptslip_amt,
                        deptslip_netamt = ItemdeptSlip.deptslip_netamt,
                        fee_amt = ItemdeptSlip.fee_amt,
                        oth_amt = ItemdeptSlip.oth_amt,
                        prncbal = ItemdeptSlip.prncbal,
                        withdrawable_amt = ItemdeptSlip.withdrawable_amt,
                        prncbal_bf = ItemdeptSlip.prncbal_bf,
                        tax_amt = ItemdeptSlip.tax_amt,
                        int_amt = ItemdeptSlip.int_amt,
                        slipnetprncbal_amt = ItemdeptSlip.slipnetprncbal_amt,
                        posttovc_flag = ItemdeptSlip.posttovc_flag,
                        refer_slipno = ItemdeptSlip.refer_slipno,
                        deptaccount_name = ItemdeptSlip.deptaccount_name,
                        depttype_desc = ItemdeptSlip.depttype_desc,
                        dept_objective = ItemdeptSlip.dept_objective,
                        prncbal_retire = ItemdeptSlip.prncbal_retire,
                        remark = ItemdeptSlip.remark,
                        due_date = DateTime.Today,
                        deptpassbook_no = ItemdeptSlip.deptpassbook_no,
                        condforwithdraw = ItemdeptSlip.condforwithdraw,
                        upint_time = ItemdeptSlip.upint_time,
                        deptaccount_ename = ItemdeptSlip.deptaccount_ename,
                        account_type = ItemdeptSlip.account_type,
                        monthintpay_meth = ItemdeptSlip.monthintpay_meth,
                        traninttype_code = ItemdeptSlip.traninttype_code,
                        tran_deptacc_no = ItemdeptSlip.tran_deptacc_no,
                        dept_tranacc_name = ItemdeptSlip.dept_tranacc_name,
                        deptmonth_status = ItemdeptSlip.deptmonth_status,
                        deptmonth_amt = ItemdeptSlip.deptmonth_amt,
                        dept_status = ItemdeptSlip.dept_status,
                        monthint_status = ItemdeptSlip.monthint_status,
                        f_tax_rate = ItemdeptSlip.f_tax_rate,
                        adjdate_status = ItemdeptSlip.adjdate_status,
                        membcat_desc = ItemdeptSlip.membcat_desc,

                    };
                    var DeptSlipdet = new DeptSlipdet
                    {
                        // coop_id = ItemdeptSlipdet.coop_id,
                        // deptslip_no = ItemdeptSlipdet.deptslip_no,
                        // deptaccount_no = ItemdeptSlipdet.deptaccount_no,
                        // prnc_no = ItemdeptSlipdet.prnc_no,
                        // prnc_bal = ItemdeptSlipdet.prnc_bal,
                        // prnc_amt = ItemdeptSlipdet.prnc_amt,
                        // prnc_date = ItemdeptSlipdet.prnc_date,
                        // calint_from = ItemdeptSlipdet.calint_from,
                        // calint_to = ItemdeptSlipdet.calint_to,
                        // prncdue_date = ItemdeptSlipdet.prncdue_date,
                        // prncmindue_date = ItemdeptSlipdet.prncmindue_date,
                        // prncdue_nmonth = ItemdeptSlipdet.prncdue_nmonth,
                        // prncslip_amt = ItemdeptSlipdet.prncslip_amt,
                        // intarr_amt = ItemdeptSlipdet.intarr_amt,
                        // intpay_amt = ItemdeptSlipdet.intpay_amt,
                        // taxpay_amt = ItemdeptSlipdet.taxpay_amt,
                        // intbf_accyear = ItemdeptSlipdet.intbf_accyear,
                        // intcur_accyear = ItemdeptSlipdet.intcur_accyear,
                        // monthintdue_date = ItemdeptSlipdet.monthintdue_date,
                        // prncdeptdue_date = ItemdeptSlipdet.prncdeptdue_date,
                        // interest_rate = ItemdeptSlipdet.interest_rate,
                        // int_return = ItemdeptSlipdet.int_return,
                        // tax_return = ItemdeptSlipdet.tax_return,
                        // fee_amt = ItemdeptSlipdet.fee_amt,
                        // other_amt = ItemdeptSlipdet.other_amt,
                        // chequepend_amt = ItemdeptSlipdet.chequepend_amt,
                        // refer_prnc_no = ItemdeptSlipdet.refer_prnc_no,
                        // upint_time = ItemdeptSlipdet.upint_time,
                        coop_id = coop_id,
                        deptslip_no = deptslip_no,
                        deptaccount_no = deptaccount_no,
                        prnc_no = 0,
                        prnc_bal = 0,
                        prnc_amt = 0,
                        prnc_date = DateTime.Today,
                        calint_from = DateTime.Today,
                        calint_to = DateTime.Today,
                        prncdue_date = DateTime.Today,
                        prncmindue_date = DateTime.Today,
                        prncdue_nmonth = 0,
                        prncslip_amt = 0,
                        intarr_amt = 0,
                        intpay_amt = 0,
                        taxpay_amt = 0,
                        intbf_accyear = 0,
                        intcur_accyear = 0,
                        monthintdue_date = DateTime.Today,
                        prncdeptdue_date = DateTime.Today,
                        interest_rate = 0,
                        int_return = 0,
                        tax_return = 0,
                        fee_amt = 0,
                        other_amt = 0,
                        chequepend_amt = 0,
                        refer_prnc_no = 0,
                        upint_time = 0,
                    };
                    var DeptSlipCheque = new DeptSlipCheque
                    {
                        // coop_id = ItemdeptSlipCheque.coop_id,
                        // deptslip_no = ItemdeptSlipCheque.deptslip_no,
                        // deptaccount_no = ItemdeptSlipCheque.deptaccount_no,
                        // cheque_no = ItemdeptSlipCheque.cheque_no,
                        // bank_code = ItemdeptSlipCheque.bank_code,
                        // bankbranch_code = ItemdeptSlipCheque.bankbranch_code,
                        // cheque_date = ItemdeptSlipCheque.cheque_date,
                        // entry_date = ItemdeptSlipCheque.entry_date,
                        // entry_time = ItemdeptSlipCheque.entry_time,
                        // chequedue_date = ItemdeptSlipCheque.chequedue_date,
                        // cheque_type = ItemdeptSlipCheque.cheque_type,
                        // cheque_amt = ItemdeptSlipCheque.cheque_amt,
                        // seq_no = ItemdeptSlipCheque.seq_no,
                        // checkclear_status = ItemdeptSlipCheque.checkclear_status,
                        // entry_id = ItemdeptSlipCheque.entry_id,
                        // depttype_code = ItemdeptSlipCheque.depttype_code,
                        coop_id = coop_id,
                        deptslip_no = deptslip_no,
                        deptaccount_no = deptaccount_no,
                        cheque_no = cheque_no,
                        bank_code = bank_code,
                        bankbranch_code = bankbranch_code,
                        cheque_date = DateTime.Today,
                        entry_date = DateTime.Today,
                        entry_time = DateTime.Today,
                        chequedue_date = DateTime.Today,
                        cheque_type = cheque_type,
                        cheque_amt = 0,
                        seq_no = 0,
                        checkclear_status = 0,
                        entry_id = entry_id,
                        depttype_code = depttype_code,
                    };

                    var Deposit = new Models.Deposit
                    {
                        deptSlip = Deptslip,
                        deptSlipdet = DeptSlipdet,
                        deptSlipCheque = DeptSlipCheque,
                    };

                    var json = JsonConvert.SerializeObject(Deposit);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // var response = await httpClient.PostAsync($"{Apiurl.ApibaseUrl}DepOfPostDeptSaving", content);

                    var response = await httpClient.PostAsJsonAsync($"{Apiurl.ApibaseUrl}DepOfPostDeptSaving", Deposit);
					//convert response data to JsonElement which can handle any JSON data
					if (response.IsSuccessStatusCode)
					{
						// Read the response content as JsonElement
						var data = await response.Content.ReadFromJsonAsync<JsonElement>();
						Console.WriteLine(data);
					}
					else
					{
						// Handle the case where the request was not successful
						Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
					}
					//var data = await response.Content.ReadFromJsonAsync<JsonElement>();
                    Console.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                //ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "ตรวจสอบเลขที่กรอกให้ถูกต้อง", Duration = 2500 });
                // Console.WriteLine(ex.Message.ToString()); 
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }
        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
        {
            uri = Apiurl.ApibaseUrl + uri;
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(uri, content);
        }

    }
}