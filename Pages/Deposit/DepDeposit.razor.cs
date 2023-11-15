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
using System.Net;
using Newtonsoft.Json.Linq;




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
        private Models.DeptSlipdet deptSlipdet;
        private Models.DeptSlipCheque deptSlipCheque;
        /// <deptSlip>
        private string coop_id = "065001";
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

        /// < deptSlipdet>
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
        /// <deptSlipCheque>
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
        //ค้นหาใน dlg
        private async Task SearchOfGetAcc()
        {

            try
            {
                isLoading = true;
                var response = await
                httpClient.GetAsync($"{Apiurl.ApibaseUrl}DepOfGetAccountSaving");
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
        private string valuetoFromaccId { get; set; }
        private string toFromaccId2 { get; set; }
        private string bookCode { get; set; }
        private string deptslipNetamt { get; set; }
        private DateTime testDateTime = DateTime.Now;
        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('_');
            string[] valuestoFo = e.Value.ToString().Split('|');
            selectedValue = values[0];
            recpPayTypeCode = values[1];
            cashTypeValue = values[2];
            bookCode = selectedValue;
            string[] toFromaccId1 = bookCode.Split('|');
            valuetoFromaccId = toFromaccId1[1];
            Console.WriteLine($"Cash Type: {selectedValue}, Recp Pay Type Code: {recpPayTypeCode},toFromaccId:{valuetoFromaccId}");
        }
        private async Task OnToFromAccChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            Valueselecte = values[0];
            toFromaccId2 = values[1];
            Console.WriteLine($"Cash Typee: {bookCode}, Recp Pay Type Code: {Valueselecte},toFromaccId:{valuetoFromaccId}");

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

                string hostName = Dns.GetHostName();
                var hostEntry = Dns.GetHostEntry(hostName);
                isLoading = true;
                foreach (var item in datadetail)
                {
                    var ItemdeptSlip = item.deptSlip;
                    var ItemdeptSlipdet = item.deptSlipdet;
                    var ItemdeptSlipCheque = item.deptSlipCheque;
                    var Deptslip = new Deptslip
                    {
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
                        moneytype_code = (cashTypeValue == null) ? ItemdeptSlip.moneytype_code : cashTypeValue,
                        bank_code = ItemdeptSlip.bank_code,
                        bankbranch_code = ItemdeptSlip.bankbranch_code,
                        entry_id = "Admin_id",
                        machine_id = Dns.GetHostByName(hostName).AddressList[0].ToString(),
                        // tofrom_accid = (toFromaccId2 == null) ? valuetoFromaccId : toFromaccId2,
                        tofrom_accid = (toFromaccId2 ?? valuetoFromaccId) ?? ItemdeptSlip.tofrom_accid,
                        operate_date = DateTime.Today,
                        entry_date = DateTime.Today,
                        calint_from = DateTime.Today,
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
                    };

                    var Deposit = new Models.Deposit
                    {
                        deptSlip = Deptslip,
                        deptSlipdet = null,
                        deptSlipCheque = null,
                    };
                    var json = JsonConvert.SerializeObject(Deposit);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{Apiurl.ApibaseUrl}DepOfPostDeptSaving", content);
                    var responseData = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine("JsonData:" + json);
                    if (response.IsSuccessStatusCode)
                    {
                        // var responseData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<Models.ApiResponse>(responseData);

                        Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
                        var notificationDetail = apiResponse != null ? apiResponse.message : responseData;

                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = notificationDetail, Duration = 2500 });
                    }
                    else
                    {
                        // Console.WriteLine(responseData);
                        var jsonResponse = JObject.Parse(responseData);
                        var errorsProperty = jsonResponse["errors"];
                        Console.WriteLine(errorsProperty);
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorsProperty + "ตรวจสอบข้อมูลให้ครบถ้วน", Duration = 2500 });
                    }
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 2500 });
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                isLoading = false;
            }
        }
        public class ErrorResponse
        {
            public string? Type { get; set; }
            public string? Title { get; set; }
            public bool? Status { get; set; }
            public string? TraceId { get; set; }
            public Errors Errors { get; set; }
        }
        public class Errors
        {
            // public string errors { get; set; }
            public Dictionary<string, List<string>> errors { get; set; }
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