using Microsoft.JSInterop;
using Newtonsoft.Json;
using FinanceApp.Models;
using Radzen;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;
using FinanceApp.Services;
using System.Text;
using System.Globalization;
using System.Net;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net.Http.Headers;
using Radzen.Blazor;


namespace FinanceApp.Pages.Deposit.Dep_slip_withdraw
{
    public partial class DepWithdraw
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        // [Inject]
        // public Api_Provider ApiProvider { get; set; }

        public List<Models.Deposit> datadetail;
        private List<Recppaytype> recppaytype;
        private List<Tofromacc> tofromacc;
        private Deptslip? deptSlip;
        private DeptSlipdet? deptSlipdet;
        private DeptSlipCheque? deptSlipCheque;
        private DepOfGetAccount? depOfGetAccount;
        private List<AccountDetails> depOfGetAccDetails;
        /// <deptSlip>
        public string? coopControl { get; set; }
        private string? coop_id { get; set; }
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
        public DateTime? operate_date { get; set; }
        public DateTime? entry_date { get; set; }
        public DateTime? calint_from { get; set; }
        public int? operate_code { get; set; }
        public int? sign_flag { get; set; }
        public int? laststmseq_no { get; set; }
        public int? nobook_flag { get; set; } = 0;
        public int? prnc_no { get; set; }
        public decimal? deptslip_amt { get; set; }
        public decimal? deptslip_netamt { get; set; }
        public decimal? fee_amt { get; set; } = 5.00m;
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
        public int? dept_status { get; set; } = 0;
        public int? monthint_status { get; set; }
        public decimal? f_tax_rate { get; set; }
        public int? adjdate_status { get; set; }
        public string? membcat_desc { get; set; }
        public string? deptmax_amt { get; set; }
        public int? sequest_amont { get; set; }
        public int? checkpend_amt { get; set; }
        public decimal? intbonus_amt { get; set; }
        // public int? int_return { get; set; }
        // public int? tax_return { get; set; }
        public decimal? int_netamt { get; set; }
        public int? payfee_meth { get; set; }


        /// < deptSlipdet>  
        public decimal? prnc_bal { get; set; }
        public decimal? prnc_amt { get; set; }
        public DateTime? prnc_date { get; set; }
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
        public decimal? other_amt { get; set; }
        public decimal? chequepend_amt { get; set; }
        public int? refer_prnc_no { get; set; }
        public int? f_startprn_bfdue { get; set; }
        /// <deptSlipCheque>
        public string? cheque_no { get; set; }
        public DateTime? cheque_date { get; set; }
        public DateTime? entry_time { get; set; }
        public DateTime? chequedue_date { get; set; }
        public string? cheque_type { get; set; }
        public decimal? cheque_amt { get; set; }
        [DefaultValue(0)]
        public int? seq_no { get; set; }
        [DefaultValue(0)]
        public int? checkclear_status { get; set; }
        /// <summary> 
        // public string coop_id { get; set; }
        // public string memcoop_id { get; set; }
        public string memcoop_id { get; set; }
        public string? deptaccount_No_fild { get; set; }
        public string? deptaccountNo_fild { get; set; }
        public string? deptaccount_name_fild { get; set; }
        // public string? member_no { get; set; }
        // public string? depttype_code { get; set; }
        public int deptclose_status { get; set; }
        public string? memb_name { get; set; }
        public string? memb_surname { get; set; }
        public string? card_person { get; set; }
        public string? mem_telmobile { get; set; }
        public string? full_name { get; set; }
        public string? salary_id { get; set; }
        public string? membgroup_code { get; set; }
        public string? membgroup_desc { get; set; }
        public string? deptitem_group { get; set; }
        public int? reqappl_flag { get; set; }


        /// </summary>        
        private bool isLoading;
        private bool saveLoading;
        private bool slipLoading;
        private bool printLoading;
        private bool isLoadingModals;
        bool isCurrentOptionSelected = false;
        private bool isUpdateExecuted = false;
        private bool success_status = false;
        private int currentStep = 0;
        public string? SaveStatus { get; set; }
        public string? group_itemtype { get; set; }
        public List<GetBank>? getBank { get; set; }
        public List<GetDeptMaintype>? getDeptMaintype { get; set; }
        public List<BankBranch>? bankBranch { get; set; }
        public string deptMaintype { get; set; }
        public List<Models.DepOfInitDataOffline> depOfInitDataOffline;
        public List<PrintResponse> connections = new List<PrintResponse>();
        public List<Book_data>? book_data { get; set; }
        public List<Statement_list>? statement_list { get; set; }
        public List<Content>? statement_data { get; set; }
        public List<Slip_data>? slip_data { get; set; }
        public IEnumerable<Models.Statement_list> statementDetails { get; set; }
        public List<Print_book>? printbook_data { get; set; }
        public List<Row_detail>? rowdatadetail { get; set; }
        private bool allowRowSelectOnRowClick = false;
        public bool isOptionSelected;
        // public IEnumerable<DeptSlipdet> deptSlipdetDetails { get; set; }
        public List<DeptSlipdet> deptSlipdetDetails { get; set; } = new List<DeptSlipdet>();
        IList<DeptSlipdet> selectedEmployees;
        private RadzenDataGrid<Models.DeptSlipdet> grid;

        public async Task<(string coopControl, string coop_id, string user_name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag)> GetDataList()
        {
            var bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
            string accessToken = bearerToken;
            string application = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "application");
            string save_status = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "save_status");
            string checkFlag = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "check_flag");


            var (coopControl, coop_id, name, email, actort, apvlevelId, workDate) = TokenHelper.DecodeToken(accessToken);
            Console.WriteLine($"coopControl: {coopControl}, userName: {name}, SaveStatus: {SaveStatus}, checkFlag: {checkFlag}");
            SaveStatus = save_status;
            return (coopControl, coop_id, name, email, actort, apvlevelId, workDate, application, save_status, checkFlag);
        }
        // (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        // private async Task PrintPdf()
        // {
        //     (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //     try
        //     {
        //         deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
        //         foreach (var item in datadetail)
        //         {
        //             var Item = item.deptSlip;
        //             var depOfGetAccount = new
        //             {
        //                 coop_id = coop_id,
        //                 memcoop_id = coop_id,
        //                 deptaccount_no = deptno_format,
        //                 deptaccount_name = Item.deptaccount_name,
        //                 recppaytype_code = (selectedValue == null) ? Item.recppaytype_code : selectedValue,
        //                 deptslip_amt = deptslipAmt,
        //                 deptslip_tdate = DateTime.Today,
        //                 printter_name = "Bullzip PDF Printer",
        //             };
        //             var json = JsonConvert.SerializeObject(depOfGetAccount);
        //             Console.WriteLine($"depOfGetAccount{json}");
        //             var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfPrintSlip}";
        //             Console.WriteLine($"apiUrl {apiUrl}");
        //             var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);

        //             Console.WriteLine(response.IsSuccessStatusCode);
        //             if (response.IsSuccessStatusCode)
        //             {
        //                 var jsonResponse = await response.Content.ReadAsStringAsync();
        //                 PrintResponse responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
        //                 responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
        //                 if (responseObj.Success)
        //                 {
        //                     ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = responseObj.Message, Duration = 5000 });
        //                 }
        //                 else
        //                 {

        //                     var errorResponse = await response.Content.ReadAsStringAsync();
        //                     ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorResponse, Duration = 5000 });
        //                 }
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
        //         Console.WriteLine(ex.Message.ToString());
        //     }
        // }
        private async Task DeptMaintype(ChangeEventArgs e)
        {
            deptMaintype = e.Value.ToString();
            if (deptMaintype == "null")
            {
                deptMaintype = null;
            }
            Console.WriteLine($"Depttype Code: {deptMaintype}");
        }
        private async Task GetDeptMaintype()
        {
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetDeptMaintype}?coop_control={coop_id}";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("IsSuccessStatusCode : " + response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var GetDeptMaintype = JsonConvert.DeserializeObject<List<GetDeptMaintype>>(json);
                    getDeptMaintype = new List<GetDeptMaintype>();
                    getDeptMaintype.AddRange(GetDeptMaintype);
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
        private async Task GetBank()
        {
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBank}?coop_control={coop_id}";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();
                // var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBank}?coop_control={coop_id}");
                // response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var GetBank = JsonConvert.DeserializeObject<List<GetBank>>(json);
                    getBank = new List<GetBank>();
                    getBank.AddRange(GetBank);
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
        private async Task BankBranch()
        {
            try
            {
                Console.WriteLine($"BankValues: {BankValues}");
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBankBranch}?coop_control={coop_id}&bank_code={BankValues}";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var BankBranch = JsonConvert.DeserializeObject<List<BankBranch>>(json);
                bankBranch = new List<BankBranch>();
                bankBranch.AddRange(BankBranch);
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
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        private async void SummaryTotle(DeptSlipdet data)
        {
            foreach (var item in deptSlipdetDetails)
            {
                if (data.select_flag == 1)
                {
                    data.prncslipAmt_String = data.prncslipAmt_String;
                    CalculateTotal();
                }
                else
                {
                    CalculateTotal();
                    DeptslipAmt = "0.00";
                }
                if (decimal.TryParse(data.prncslipAmt_String, out decimal result))
                {
                    if (item.select_flag == 1)
                    {
                        if (item.IsChecked == true)
                        {
                            data.prncslipAmt_String += item.prnc_bal ?? 0; // หรือใช้ค่าเริ่มต้นเมื่อ null
                        }
                        else
                        {
                            data.prncslipAmt_String += item.prnc_bal ?? 0;
                        }
                        DeptslipAmt = data.prncslipAmt_String;
                    }
                    data.prncslipAmt_String = result.ToString("N2");
                    DeptslipAmt = totalSum.ToString("N2");
                    // data.prncslipAmt_String= DeptslipAmt;

                    // นำค่าที่ได้มา round และกำหนดให้กับตัวแปร result
                    result = Math.Round(result, 2);
                    data.prncslip_amt = result;

                }
                Console.WriteLine($"DeptslipAmt:{deptslip_amt}");
                Console.WriteLine($"prncslip_amt:{data.prncslip_amt}");
                Console.WriteLine($"prncslipAmt_String:{data.prncslipAmt_String}");
                StateHasChanged();

            }

        }

        decimal totalSum = 0;
        // private void PostTotolFix(DeptSlipdet data)
        // {
        //     decimal itemAmt;
        //     decimal slipAmt = deptslipAmt;
        //     int RowCount = deptSlipdetDetails.Count;
        //     for (int i = RowCount; i > 0; i--)
        //     {
        //         itemAmt = deptSlipdetDetails[i - 1].prnc_bal ?? 0;
        //         if (slipAmt > itemAmt && itemAmt > 0)
        //         {
        //             data.select_flag = 1;
        //             data.prncslip_amt = itemAmt;
        //         }
        //         else
        //         {

        //             if (slipAmt == 0 || itemAmt == 0)
        //             {
        //                 data.select_flag = 0;
        //                 data.prncslip_amt = 0;
        //                 data.taxpay_amt = 0;
        //                 data.fee_amt = 0;
        //                 data.other_amt = 0;
        //                 data.int_return = 0;
        //                 data.intcur_accyear = 0;
        //                 data.intarr_amt = 0;
        //             }
        //             else
        //             {
        //                 data.select_flag = 1;
        //                 data.prncslip_amt = slipAmt;
        //                 Console.WriteLine("TotalssSum : " + slipAmt);

        //             }
        //         }
        //         slipAmt -= itemAmt;
        //         if (slipAmt <= 0) { slipAmt = 0; }
        //         IsChecked = false;
        //     }
        //     // PostCheckAmount();
        // }
        private void CalculateTotal()
        {
            totalSum = 0;
            // decimal deptslipAmtDecimal = decimal.Parse(DeptslipAmt);
            foreach (var item in deptSlipdetDetails)
            {
                decimal prncslip_amt = decimal.Parse(item.prncslipAmt_String);

                // เพิ่มค่าของแต่ละรายการลงในผลรวม
                if (item.select_flag == 1)
                {
                    if (item.IsChecked == true)
                    {
                        totalSum += prncslip_amt; // หรือใช้ค่าเริ่มต้นเมื่อ null
                    }
                    else
                    {
                        totalSum += prncslip_amt;
                    }
                }
                StateHasChanged();
                // prncslip_amt = totalSum;
            }
            // totalSum += deptslipAmtDecimal;
            DeptslipAmt = totalSum.ToString("N2");
            // prncslip_amt = totalSum;
            Console.WriteLine("totalSum : " + DeptslipAmt);
        }
        // private async void SummaryTotle(IEnumerable<DeptSlipdet> dataList)
        // {
        //     // วนลูปผ่านทุกๆ รายการในคอลเลคชัน
        //     foreach (var data in dataList)
        //     {
        //         Console.WriteLine($"data.prnc_bal:{data.prnc_bal}");
        //         Console.WriteLine($"prncslip_amt:{data.prncslip_amt}");
        //         Console.WriteLine($"prncslipAmt_String:{data.prncslipAmt_String}");

        //         // ตรวจสอบ select_flag และทำงานตามเงื่อนไข
        //         if (data.select_flag == 1)
        //         {
        //             if (decimal.TryParse(data.prncslipAmt_String, out decimal prncslipAmt))
        //             {
        //                 data.prncslipAmt_String += prncslipAmt;
        //             }
        //         }
        //     }
        // }

        private void FormatNumber()
        {

            if (decimal.TryParse(DeptslipAmt, out decimal result))
            {
                // CalculateTotal();
                // DeptslipAmt = prncslip_amtt + DeptslipAmt;
                DeptslipAmt = result.ToString("N2");
                // data.prncslipAmt_String = DeptslipAmt;
                Console.WriteLine("DeptslipAmt:" + DeptslipAmt);

                // นำค่าที่ได้มา round และกำหนดให้กับตัวแปร result
                result = Math.Round(result, 2);

                // นำค่าที่ได้มากำหนดให้กับตัวแปร deptslipAmt (หาก deptslipAmt เป็นตัวแปรที่ถูกประกาศแล้ว)
                deptslipAmt = result;

                // แสดงค่าใน Console
                Console.WriteLine(deptslipAmt);


            }

        }
        private void UpdateIsChecked(DeptSlipdet item, ChangeEventArgs e)
        {
            item.IsChecked = (bool)e.Value;
            //CalculateTotal();
        }
        private void OnBlurHandler()
        {
            FormatNumber();
            // SplitMoney();
            // MoneyDetail();
        }
        // private void FormatNumberr(string prncslipAmt_String)
        // {
        //     if (decimal.TryParse(prncslipAmt_String, out decimal result))
        //     {
        //         prncslipAmt_String = result.ToString("N2");

        //         // นำค่าที่ได้มา round และกำหนดให้กับตัวแปร result
        //         result = Math.Round(result, 2);

        //         // นำค่าที่ได้มากำหนดให้กับตัวแปร deptslipAmt (หาก deptslipAmt เป็นตัวแปรที่ถูกประกาศแล้ว)
        //         prncslip_amtt = result;

        //         // แสดงค่าใน Console
        //         Console.WriteLine("OnBlurHandler" + prncslip_amtt);
        //     }
        // }
        private decimal? prncslip_amtt { get; set; }
        private string prncslipAmt_String { get; set; }
        private void UpdatePrncslipAmt(ChangeEventArgs e)
        {
            // ตรวจสอบว่าค่าที่ป้อนเข้ามาไม่ใช่ค่าว่าง
            if (!string.IsNullOrEmpty(e.Value?.ToString()))
            {
                // กำหนดค่าใหม่ให้กับ prncslipAmt_String เพื่อให้มีค่าเท่ากับค่าที่ป้อนเข้ามาใน input
                prncslipAmt_String = e.Value.ToString();
            }
            else
            {
                // ถ้าค่าว่าง กำหนดให้ prncslipAmt_String เป็นค่าว่างเพื่อให้ input แสดงผลเป็นค่าว่าง
                prncslipAmt_String = "";
            }
        }

        //RetriveDataFromDeptNo
        private async void UpdateAccountDetails(Models.AccountDetails data)
        {

            try
            {
                isLoading = true;
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                deptno_format = data.deptaccount_no?.Trim();
                Console.WriteLine($"Clicked on coop_id: {coop_id}");
                Console.WriteLine($"Clicked on deptaccount_no: {data.deptaccount_no}");
                // await JSRuntime.InvokeVoidAsync("alert", $"เลือก {data.deptaccount_no}, {data.deptaccount_name}");
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Success", Detail = $"เลือก {data.deptaccount_no}, {data.deptaccount_name}", Duration = 2000 });

                var depOfGetAccount = new DepOfInitDataOffline
                {
                    coop_id = coop_id,
                    memcoop_id = coop_id,
                    deptno_format = data.deptaccount_no,
                    entry_date = null,
                    deptitem_group = "WID",
                };
                var jsonReq = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(jsonReq);
                var content = new StringContent(jsonReq, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfInitDataOffline}";
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
                // var response = await httpClient.PostAsync(apiUrl, content);

                response.EnsureSuccessStatusCode();
                var jsonRes = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
                if (apiResponse.status == true)
                {
                    datadetail = new List<Models.Deposit> { apiResponse.data };
                    await GetBank();
                    await GetDeptMaintype();
                    await InvokeAsync(() => StateHasChanged());
                    Console.WriteLine($"API request failed: {datadetail}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }
        private void AnotherFunction()
        {
            GetBank();
            // BankBranch();
            GetDeptMaintype();

        }
        //ค้นหา

        private async Task Search()
        {
            AnotherFunction();
            deptno_format = deptno_format?.Trim().Replace("-", "");
            if (deptno_format == null || deptno_format == "")
            {

                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขที่บัญชี", Duration = 1500 });
            }
            else
            {
                try
                {
                    isLoading = true;
                    var depOfGetAccount = new DepOfInitDataOffline
                    {
                        coop_id = coop_id,
                        memcoop_id = coop_id,
                        deptno_format = deptno_format,
                        entry_date = entry_date,
                        deptitem_group = deptitem_group ?? "WID",
                        reqappl_flag = reqappl_flag ?? 0,
                    };
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    Console.WriteLine(json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfInitDataOffline}";
                    var response = await httpClient.PostAsync(apiUrl, content);

                    Console.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        // อ่าน response string
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                        // Console.WriteLine(apiResponse.status == true);
                        if (apiResponse.status == true)
                        {
                            datadetail = new List<Models.Deposit> { apiResponse.data };
                            Console.WriteLine($"API request failed: {datadetail}");
                            foreach (var item in datadetail)
                            {
                                var Item = item.deptSlip;
                                Console.WriteLine($"Item.condforwithdraw :{Item.condforwithdraw}");
                            }
                            AnotherFunction();
                        }
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
        private async Task HandleEnterKeyPress(KeyboardEventArgs e)
        {
            if (e.Code == "Enter")
            {
                await PerformSearch();
            }
        }
        private async Task PerformSearch()
        {
            isLoading = true;
            if (string.IsNullOrEmpty(deptno_format))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                await CallApi();
            }
            isLoading = false;
        }
        private async Task CallApi()
        {
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            Console.WriteLine($"GetDataList: {coopControl}, {coop_id}, {name},  {email}, {actort}, {apvlevelId}, {workDate}, {application}, {save_status}, {check_flag}");
            // Console.WriteLine($"allowRowSelectOnRowClick :{allowRowSelectOnRowClick}");

            try
            {
                deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
                var depOfGetAccount = new
                {
                    coop_id = coop_id,
                    memcoop_id = coop_id,
                    deptno_format = deptno_format,
                    entry_date = DateTime.Today,
                    deptitem_group = deptitem_group ?? "WID",
                    reqappl_flag = reqappl_flag ?? 0,
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(json);
                // var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfInitDataOffline}";
                // var response = await httpClient.PostAsync(apiUrl, content);
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
                // var response = await ApiProvider.ApiProvider.SendApiRequestAsyncGet(apiUrl);

                Console.WriteLine(response.IsSuccessStatusCode);
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    // Console.WriteLine(apiResponse.status == true);
                    if (apiResponse.status == true)
                    {
                        datadetail = new List<Models.Deposit> { apiResponse.data };
                        foreach (var item in datadetail)
                        {
                            if (item.deptSlipdet != null)
                            {
                                List<DeptSlipdet> deptSlipdetList = item.deptSlipdet;
                                foreach (var deptSlipdetItem in deptSlipdetList)
                                {
                                    var SlipdetItem = new DeptSlipdet
                                    {
                                        select_flag = deptSlipdetItem.select_flag,
                                        coop_id = deptSlipdetItem.coop_id,
                                        deptslip_no = deptSlipdetItem.deptslip_no,
                                        deptaccount_no = deptSlipdetItem.deptaccount_no,
                                        prnc_no = deptSlipdetItem.prnc_no,
                                        prnc_bal = deptSlipdetItem.prnc_bal,
                                        prnc_amt = deptSlipdetItem.prnc_amt,
                                        prncslipAmt_String = deptSlipdetItem.prnc_bal?.ToString("#,##0.0"),
                                        prnc_date = deptSlipdetItem.prnc_date,
                                        calint_from = deptSlipdetItem.calint_from,
                                        calint_to = deptSlipdetItem.calint_to,
                                        prncdue_date = deptSlipdetItem.prncdue_date,
                                        prncmindue_date = deptSlipdetItem.prncmindue_date,
                                        prncdue_nmonth = deptSlipdetItem.prncdue_nmonth,
                                        prncslip_amt = deptSlipdetItem.prncslip_amt,
                                        intarr_amt = deptSlipdetItem.intarr_amt,
                                        intpay_amt = deptSlipdetItem.intpay_amt,
                                        taxpay_amt = deptSlipdetItem.taxpay_amt,
                                        intbf_accyear = deptSlipdetItem.intbf_accyear,
                                        intcur_accyear = deptSlipdetItem.intcur_accyear,
                                        monthintdue_date = deptSlipdetItem.monthintdue_date,
                                        prncdeptdue_date = deptSlipdetItem.prncdeptdue_date,
                                        interest_rate = deptSlipdetItem.interest_rate,
                                        preint_rate = deptSlipdetItem.preint_rate,
                                        int_return = deptSlipdetItem.int_return,
                                        int_return_default = deptSlipdetItem.int_return_default,
                                        tax_return = deptSlipdetItem.tax_return,
                                        fee_amt = deptSlipdetItem.fee_amt,
                                        other_amt = deptSlipdetItem.other_amt,
                                        chequepend_amt = deptSlipdetItem.chequepend_amt,
                                        refer_prnc_no = deptSlipdetItem.refer_prnc_no,
                                        upint_time = deptSlipdetItem.upint_time,
                                        day_calint = deptSlipdetItem.day_calint,
                                        f_startprn_bfdue = deptSlipdetItem.f_startprn_bfdue,
                                        depttype_code = deptSlipdetItem.depttype_code,
                                        interest_rate_desc = deptSlipdetItem.interest_rate_desc,
                                        preinterest_rate_desc = deptSlipdetItem.preinterest_rate_desc
                                    };
                                    deptSlipdetDetails.Add(SlipdetItem);
                                }
                            }
                            // Console.WriteLine($"API request deptSlipItem: {deptSlipItem}");


                        }
                        await GetBank();
                        // await BankBranch();
                        await GetDeptMaintype();
                    }
                    else
                    {
                        var Error = JsonConvert.SerializeObject(apiResponse.message);

                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });

                    }
                }
                // โค้ดเกี่ยวกับการเรียก API ที่เหมือนเดิม
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private async Task TypeChanged(ChangeEventArgs e)
        {

            deptitem_group = e.Value.ToString();
            if (string.IsNullOrEmpty(deptno_format))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                try
                {
                    isLoading = true;
                    await CallApi();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                }
                finally
                {
                    isLoading = false;

                }
            }
            await InvokeAsync(() => StateHasChanged());
            Console.WriteLine($"TypeChanged: {deptitem_group}");


        }
        private async Task SearchOfGetAcc()
        {
            isLoadingModals = true;
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            var depOfGetAccount = new AccountDetails
            {
                coop_id = coop_id,
                memcoop_id = coop_id,
                deptaccount_no = deptaccount_No_fild,
                deptaccount_name = deptaccount_name_fild,
                member_no = member_no,
                depttype_code = deptMaintype,
                deptclose_status = deptclose_status,
                memb_name = memb_name,
                memb_surname = memb_surname,
                card_person = card_person,
                mem_telmobile = mem_telmobile,
                full_name = full_name,
                salary_id = salary_id,
                entry_date = entry_date ?? null
            };
            var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetAccountSaving}";
            try
            {
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse1 = JObject.Parse(jsonResponse);
                    depOfGetAccDetails = jsonResponse1["content"].ToObject<List<AccountDetails>>();
                }
                var accountDetailsList = new List<Models.AccountDetails>();
                if (depOfGetAccDetails != null)
                {
                    foreach (var accDetails in depOfGetAccDetails)
                    {
                        var accountDetails = new Models.AccountDetails
                        {
                            deptaccount_no = accDetails.deptaccount_no,
                            deptaccount_name = accDetails.deptaccount_name,
                            member_no = accDetails.member_no,
                            full_name = accDetails.full_name
                        };
                        accountDetailsList.Add(accountDetails);
                    }
                }
                // Assign the list to dataaccDetails
                dataaccDetails = accountDetailsList;

                // รายละเอียดอื่น ๆ ที่คุณต้องการทำ
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                isLoadingModals = false;
            }
        }
        public async Task PrintBook()
        {
            try
            {

                foreach (var Item in statement_data)
                {
                    var item = JsonConvert.DeserializeObject<Book_data>(Item.book_data.ToString());

                    var depOfGetAccount = new
                    {
                        deptaccount_no = item.deptaccount_no,
                        lastrec_no = item.lastrec_no,
                        laststmseq_no = item.laststmseq_no,
                        lastpage_no = item.lastpage_no,
                        lastline_no = item.lastline_no,
                    };
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfPostPrintBook}";
                    var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
                    Console.WriteLine($"response.IsSuccessStatusCode:{response.IsSuccessStatusCode}");
                    if (response.IsSuccessStatusCode)
                    {
                        // อ่าน response string
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var responseData = JsonConvert.DeserializeObject<PrintBookResponse>(jsonResponse);
                        if (responseData.success)
                        {
                            printbook_data = new List<Print_book> { responseData.content };
                            var printbookdata = responseData.content;
                            var printdetail = printbookdata.print_detail;
                        }
                        else
                        {
                            var error = JsonConvert.SerializeObject(responseData.message);
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = error, Duration = 5000 });

                        }
                    }
                }
                // โค้ดเกี่ยวกับการเรียก API ที่เหมือนเดิม
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
        }        public class PrintBookResponse
        {
            public bool success { get; set; }
            public Print_book content { get; set; }
            public string message { get; set; }
        }
        public class SaveResponse
        {
            public bool success { get; set; }
            public Content content { get; set; }
            public string message { get; set; }
        }
        public class ApiResponse
        {
            public bool status { get; set; }
            public Models.Deposit data { get; set; }
            public string? message { get; set; }
        }
        public class Response
        {
            public bool success { get; set; }
            public Models.Deposit content { get; set; }
            public string message { get; set; }
        }
        private string selectedValue;
        private string moneytypeCode;

        private string cashTypeValue;
        private string Valueselecte;
        private string Recppaytype_code;
        private string selectedRecppaytype;
        private string recpPayTypeCode { get; set; }
        private string bankaccount_name { get; set; }
        private string check_no { get; set; }
        private string valuetoFromaccId { get; set; }
        private string toFromaccId2 { get; set; }
        private string bookCode { get; set; }
        private string deptslipNetamt { get; set; }
        private string DeptslipAmt { get; set; }
        private decimal deptslipAmt { get; set; }
        private decimal book_balance { get; set; }
        public bool IsChecked { get; set; }

        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('_');
            selectedValue = values[0];
            recpPayTypeCode = values[1];
            selectedRecppaytype = values[1] + " - " + values[2];
            bookCode = selectedValue;
            string[] toFromaccId1 = bookCode.Split('|');
            cashTypeValue = toFromaccId1[0];
            valuetoFromaccId = toFromaccId1[1];
            Console.WriteLine($"Cash Type: {cashTypeValue}, Recp Pay Type Code: {recpPayTypeCode},toFromaccId:{valuetoFromaccId},selectedRecppaytype:{selectedRecppaytype}");
            if (recpPayTypeCode == "DEN")
            {
                GetBank();
                BankBranch();
            }
        }
        private async Task OnToFromAccChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            Valueselecte = values[0];
            toFromaccId2 = values[1];
            Console.WriteLine($"Cash Typee: {bookCode}, Recp Pay Type Code: {Valueselecte},toFromaccId:{valuetoFromaccId}");

        }
        private async Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "F9")
            {
                currentStep = 1;
            }
        }
        private async Task CheckNumber()
        {
            deptslipNetamt = "50";
            Console.WriteLine($"input: {deptslipNetamt}");
        }

        // private async Task SaveDataAsync()
        // {
        //     try
        //     {
        //         (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //         string hostName = Dns.GetHostName();
        //         var hostEntry = Dns.GetHostEntry(hostName);
        //         isLoading = true;
        //         foreach (var item in datadetail)
        //         {
        //             var ItemdeptSlip = item.deptSlip;
        //             var ItemdeptSlipdet = item.deptSlipdet;
        //             var ItemdeptSlipCheque = item.deptSlipCheque;
        //             var Deptslip = new Deptslip
        //             {
        //                 coop_id = ItemdeptSlip.coop_id,
        //                 deptcoop_id = ItemdeptSlip.deptcoop_id,
        //                 deptslip_no = ItemdeptSlip.deptslip_no,
        //                 member_no = ItemdeptSlip.member_no,
        //                 membcat_code = ItemdeptSlip.membcat_code,
        //                 deptno_format = ItemdeptSlip.deptno_format,
        //                 deptaccount_no = ItemdeptSlip.deptaccount_no,
        //                 depttype_code = ItemdeptSlip.depttype_code,
        //                 deptgroup_code = ItemdeptSlip.deptgroup_code,
        //                 recppaytype_code = recpPayTypeCode ?? ItemdeptSlip.recppaytype_code,
        //                 moneytype_code = (cashTypeValue == null) ? ItemdeptSlip.moneytype_code : cashTypeValue,
        //                 bank_code = ItemdeptSlip.bank_code,
        //                 bankbranch_code = ItemdeptSlip.bankbranch_code,
        //                 entry_id = "admin",
        //                 machine_id = hostName,
        //                 tofrom_accid = (toFromaccId2 ?? valuetoFromaccId) ?? ItemdeptSlip.tofrom_accid,
        //                 operate_date = DateTime.Today,
        //                 entry_date = DateTime.Today,
        //                 operate_code = operate_code,
        //                 sign_flag = -1,
        //                 laststmseq_no = ItemdeptSlip.laststmseq_no ?? 0,
        //                 deptslip_amt = deptslipAmt,
        //                 deptslip_netamt = deptslipAmt,
        //                 fee_amt = ItemdeptSlip.fee_amt,
        //                 oth_amt = ItemdeptSlip.oth_amt,
        //                 prncbal = ItemdeptSlip.prncbal,
        //                 withdrawable_amt = ItemdeptSlip.withdrawable_amt,
        //                 calint_from = DateTime.Today,
        //                 prncbal_bf = ItemdeptSlip.prncbal_bf,
        //                 remark = ItemdeptSlip.remark,
        //                 tofromacc = tofromacc,
        //                 depttype_desc = ItemdeptSlip.depttype_desc,
        //                 dept_objective = ItemdeptSlip.dept_objective,
        //                 deptaccount_name = ItemdeptSlip.deptaccount_name,
        //                 recppaytype = recppaytype,

        //                 tax_amt = ItemdeptSlip.tax_amt ?? 0,
        //                 int_amt = ItemdeptSlip.int_amt ?? 0,
        //                 slipnetprncbal_amt = ItemdeptSlip.slipnetprncbal_amt ?? 0,
        //                 prncbal_retire = ItemdeptSlip.prncbal_retire ?? 0,
        //                 monthint_status = ItemdeptSlip.monthint_status,
        //                 // nobook_flag = ItemdeptSlip.nobook_flag,
        //                 // prnc_no = ItemdeptSlip.prnc_no,
        //                 // posttovc_flag = ItemdeptSlip.posttovc_flag,
        //                 // refer_slipno = ItemdeptSlip.refer_slipno,
        //                 // due_date = DateTime.Today,
        //                 // deptpassbook_no = ItemdeptSlip.deptpassbook_no,
        //                 condforwithdraw = ItemdeptSlip.condforwithdraw,
        //                 // passbook_flag = ItemdeptSlip.passbook_flag,
        //                 // upint_time = ItemdeptSlip.upint_time,
        //                 // deptaccount_ename = ItemdeptSlip.deptaccount_ename,
        //                 // deptrequest_docno = ItemdeptSlip.deptrequest_docno,
        //                 // account_type = ItemdeptSlip.account_type,
        //                 // monthintpay_meth = ItemdeptSlip.monthintpay_meth,
        //                 // traninttype_code = ItemdeptSlip.traninttype_code,
        //                 // tran_deptacc_no = ItemdeptSlip.tran_deptacc_no,
        //                 // dept_tranacc_name = ItemdeptSlip.dept_tranacc_name,
        //                 // deptmonth_status = ItemdeptSlip.deptmonth_status,
        //                 // deptmonth_amt = ItemdeptSlip.deptmonth_amt,
        //                 // dept_status = ItemdeptSlip.dept_status,
        //                 // f_tax_rate = ItemdeptSlip.f_tax_rate,
        //                 // adjdate_status = ItemdeptSlip.adjdate_status,
        //                 // membcat_desc = ItemdeptSlip.membcat_desc,
        //                 // reqappl_flag = ItemdeptSlip.reqappl_flag,
        //                 // spcint_rate_status = ItemdeptSlip.spcint_rate_status,
        //                 // spcint_rate = ItemdeptSlip.spcint_rate,
        //             };
        //             var DeptSlipdet = new DeptSlipdet();
        //             //{
        //             //    coop_id = (coop_id == null) ? ItemdeptSlipdet.coop_id : null,
        //             //    deptslip_no = (deptslip_no == null) ? ItemdeptSlipdet.deptslip_no : null,

        //             //    deptaccount_no = (deptaccount_no == null) ? ItemdeptSlipdet.deptaccount_no : null,
        //             //    prnc_no = (prnc_no == null) ? ItemdeptSlipdet.prnc_no : null,

        //             //    prnc_bal = (prnc_bal == null) ? ItemdeptSlipdet.prnc_bal : null,
        //             //    prnc_amt = (prnc_amt == null) ? ItemdeptSlipdet.prnc_amt : null,
        //             //    prnc_date = (prnc_date == null) ? ItemdeptSlipdet.prnc_date : null,
        //             //    calint_from = (calint_from == null) ? ItemdeptSlipdet.calint_from : null,
        //             //    calint_to = (calint_to == null) ? ItemdeptSlipdet.calint_to : null,
        //             //    prncdue_date = (prncdue_date == null) ? ItemdeptSlipdet.prncdue_date : null,
        //             //    prncmindue_date = (prncmindue_date == null) ? ItemdeptSlipdet.prncmindue_date : null,
        //             //    prncdue_nmonth = (prncdue_nmonth == null) ? ItemdeptSlipdet.prncdue_nmonth : null,
        //             //    prncslip_amt = (prncslip_amt == null) ? ItemdeptSlipdet.prncslip_amt : null,

        //             //    intarr_amt = (intarr_amt == null) ? ItemdeptSlipdet.intarr_amt : null,
        //             //    intpay_amt = (intpay_amt == null) ? ItemdeptSlipdet.intpay_amt : null,
        //             //    taxpay_amt = (taxpay_amt == null) ? ItemdeptSlipdet.taxpay_amt : null,
        //             //    intbf_accyear = (intbf_accyear == null) ? ItemdeptSlipdet.intbf_accyear : null,
        //             //    intcur_accyear = (intcur_accyear == null) ? ItemdeptSlipdet.intcur_accyear : null,

        //             //    monthintdue_date = (monthintdue_date == null) ? ItemdeptSlipdet.monthintdue_date : null,
        //             //    prncdeptdue_date = (prncdeptdue_date == null) ? ItemdeptSlipdet.prncdeptdue_date : null,

        //             //    interest_rate = (interest_rate == null) ? ItemdeptSlipdet.interest_rate : null,
        //             //    int_return = (int_return == null) ? ItemdeptSlipdet.int_return : null,
        //             //    tax_return = (tax_return == null) ? ItemdeptSlipdet.tax_return : null,
        //             //    fee_amt = (fee_amt == null) ? ItemdeptSlipdet.fee_amt : null,
        //             //    other_amt = (other_amt == null) ? ItemdeptSlipdet.other_amt : null,
        //             //    chequepend_amt = (chequepend_amt == null) ? ItemdeptSlipdet.chequepend_amt : null,
        //             //    refer_prnc_no = (refer_prnc_no == null) ? ItemdeptSlipdet.refer_prnc_no : null,
        //             //    upint_time = (upint_time == null) ? ItemdeptSlipdet.upint_time : null,
        //             //};
        //             var DeptSlipCheque = new DeptSlipCheque();
        //             // {
        //             // coop_id = (coop_id == null) ? ItemdeptSlipCheque.coop_id : null,
        //             // deptslip_no = (deptslip_no == null) ? ItemdeptSlipCheque.deptslip_no : null,
        //             // deptaccount_no = (deptaccount_no == null) ? ItemdeptSlipCheque.deptaccount_no : null,
        //             // cheque_no = (cheque_no == null) ? ItemdeptSlipCheque.cheque_no : null,
        //             // bank_code = (bank_code == null) ? ItemdeptSlipCheque.bank_code : null,
        //             // bankbranch_code = (bankbranch_code == null) ? ItemdeptSlipCheque.bankbranch_code : null,
        //             // cheque_date = (cheque_date == null) ? ItemdeptSlipCheque.cheque_date : null,
        //             // entry_date = (entry_date == null) ? ItemdeptSlipCheque.entry_date : null,
        //             // entry_time = (entry_time == null) ? ItemdeptSlipCheque.entry_time : null,
        //             // chequedue_date = (chequedue_date == null) ? ItemdeptSlipCheque.chequedue_date : null,
        //             // cheque_type = (cheque_type == null) ? ItemdeptSlipCheque.cheque_type : null,
        //             // cheque_amt = (cheque_amt == null) ? ItemdeptSlipCheque.cheque_amt : null,
        //             // seq_no = (seq_no == null) ? ItemdeptSlipCheque.seq_no : null,
        //             // checkclear_status = (checkclear_status == null) ? ItemdeptSlipCheque.checkclear_status : null,
        //             // entry_id = (entry_id == null) ? ItemdeptSlipCheque.entry_id : null,
        //             // depttype_code = (depttype_code == null) ? ItemdeptSlipCheque.depttype_code : null,
        //             // };
        //             // foreach (var rowsItem in rows)
        //             // {
        //             //     DeptSlipCheque = new DeptSlipCheque
        //             //     {
        //             //         coop_id = coop_id,
        //             //         deptslip_no = deptslip_no,

        //             //         deptaccount_no = deptaccount_no,
        //             //         cheque_no = rowsItem.cheque_no,

        //             //         bank_code = rowsItem.bank_code,
        //             //         bankbranch_code = rowsItem.branch_id,
        //             //         cheque_date = DateTime.Now,
        //             //         entry_date = DateTime.Now,
        //             //         entry_time = DateTime.Now,
        //             //         chequedue_date = chequedue_date,

        //             //         cheque_type = rowsItem.cheque_type,

        //             //         cheque_amt = rowsItem.cheque_amt ?? 0,
        //             //         seq_no = rowsItem.seq_no ?? 0,
        //             //         checkclear_status = rowsItem.checkclear_status,
        //             //         entry_id = "Admin_id",
        //             //         depttype_code = ItemdeptSlip.depttype_code,
        //             //     };
        //             // };
        //             var Deposit = new Models.Deposit
        //             {
        //                 deptSlip = Deptslip,
        //                 deptSlipdet = null,
        //                 deptSlipCheque = null,

        //             };
        //             // var json = JsonConvert.SerializeObject(Deposit);
        //             // Console.WriteLine("JsonData:" + json);
        //             // var content = new StringContent(json, Encoding.UTF8, "application/json");
        //             // var response = await httpClient.PostAsync($"{ApiClient.API.ApibaseUrl}DepOfPostWithSaving", content);
        //             // var responseData = await response.Content.ReadAsStringAsync();
        //             // Console.WriteLine("JsonData:" + responseData);
        //             var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostWithSaving}";
        //             var response = await SendApiRequestAsync(apiUrl, Deposit);
        //             var responseData = await response.Content.ReadAsStringAsync();

        //             if (response.IsSuccessStatusCode)
        //             {
        //                 // var responseData = await response.Content.ReadAsStringAsync();
        //                 var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

        //                 Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
        //                 var notificationDetail = apiResponse != null ? apiResponse.message : responseData;
        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = notificationDetail, Duration = 2500 });
        //             }
        //             else
        //             {
        //                 // Console.WriteLine(responseData);
        //                 var jsonResponse = JObject.Parse(responseData);
        //                 var errorsProperty = jsonResponse["errors"];
        //                 Console.WriteLine(errorsProperty);
        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorsProperty + "ตรวจสอบข้อมูลให้ครบถ้วน", Duration = 2500 });
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 2500 });
        //         Console.WriteLine(ex.ToString());
        //     }
        //     finally
        //     {
        //         isLoading = false;
        //     }
        // }
        private async Task CalIntPrncfix()
        {
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                // หาที่อยู่ IP ของเครื่อง
                string machine_address = GetMachineAddress();

                isLoading = true;
                var tempDeptSlipdetDetails = new List<DeptSlipdet>(); //
                foreach (var item in datadetail)
                {
                    var DeptSlipdet = CreateDeptSlipdet(coop_id, name, machine_address, item);
                    foreach (var deptSlipdetItem in deptSlipdetDetails)
                    {
                        var deptDeposit = new
                        {
                            deptaccount_no = item.deptSlip.deptaccount_no,
                            depttype_code = "01",
                            membcat_code = item.deptSlip.membcat_code,
                            calint_to = item.deptSlipdet.FirstOrDefault()?.calint_to ?? DateTime.Now,
                            deptSlipdet = DeptSlipdet,
                        };
                        var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfCalIntPrncfix}";
                        Console.WriteLine("deptDeposit: " + Newtonsoft.Json.JsonConvert.SerializeObject(deptDeposit));
                        var response = await ApiProvider.SendApiRequestAsync(apiUrl, deptDeposit);
                        var responseData = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            // Console.WriteLine($"jsonResponse {jsonResponse}");
                            var Response = JsonConvert.DeserializeObject<PersonCollection>(responseData);
                            Console.WriteLine($"PersonCollection:{Response}");
                            foreach (var items in Response)
                            {
                                var SlipdetItem = new DeptSlipdet
                                {
                                    select_flag = items.select_flag,
                                    coop_id = items.coop_id,
                                    deptslip_no = items.deptslip_no,
                                    deptaccount_no = items.deptaccount_no,
                                    prnc_no = items.prnc_no,
                                    prnc_bal = items.prnc_bal,
                                    prnc_amt = items.prnc_amt,
                                    prncslipAmt_String = items.prnc_bal?.ToString("#,##0.0"),
                                    prnc_date = items.prnc_date,
                                    calint_from = items.calint_from,
                                    calint_to = items.calint_to,
                                    prncdue_date = items.prncdue_date,
                                    prncmindue_date = items.prncmindue_date,
                                    prncdue_nmonth = items.prncdue_nmonth,
                                    prncslip_amt = items.prncslip_amt,
                                    intarr_amt = items.intarr_amt,
                                    intpay_amt = items.intpay_amt,
                                    taxpay_amt = items.taxpay_amt,
                                    intbf_accyear = items.intbf_accyear,
                                    intcur_accyear = items.intcur_accyear,
                                    monthintdue_date = items.monthintdue_date,
                                    prncdeptdue_date = items.prncdeptdue_date,
                                    interest_rate = items.interest_rate,
                                    preint_rate = items.preint_rate,
                                    int_return = items.int_return,
                                    int_return_default = items.int_return_default,
                                    tax_return = items.tax_return,
                                    fee_amt = items.fee_amt,
                                    other_amt = items.other_amt,
                                    chequepend_amt = items.chequepend_amt,
                                    refer_prnc_no = items.refer_prnc_no,
                                    upint_time = items.upint_time,
                                    day_calint = items.day_calint,
                                    f_startprn_bfdue = items.f_startprn_bfdue,
                                    depttype_code = items.depttype_code,
                                    interest_rate_desc = items.interest_rate_desc,
                                    preinterest_rate_desc = items.preinterest_rate_desc
                                };
                                tempDeptSlipdetDetails.Add(SlipdetItem);
                            }
                            // var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                            // Console.WriteLine($"Response.message {Response.message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error {ex.Message}");
                isLoading = false;
            }
            finally
            {
                isLoading = false;
            }
        }
        public async Task SaveDataAsync()
        {
            try
            {
                saveLoading = true;
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();

                // หาที่อยู่ IP ของเครื่อง
                string machine_address = GetMachineAddress();

                foreach (var item in datadetail)
                {
                    var Deptslip = CreateDeptSlip(coop_id, name, machine_address, item);
                    var DeptSlipdet = CreateDeptSlipdet(coop_id, name, machine_address, item);
                    var DeptSlipCheque = CreateDeptSlipCheque(coop_id, deptslip_no, deptaccount_no, item);
                    var deptDeposit = new Models.Deposit
                    {
                        deptSlip = Deptslip,
                        // deptSlipdet = DeptSlipdet,
                        deptSlipdet = null,
                        deptSlipCheque = (recpPayTypeCode == "DEN") ? new DeptSlipCheque() : null,
                    };

                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostWithSaving}";
                    var response = await ApiProvider.SendApiRequestAsync(apiUrl, deptDeposit);
                    var responseData = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                        var Response = JsonConvert.DeserializeObject<SaveResponse>(jsonResponse);
                        success_status = true;
                        if (Response.success)
                        {

                            statement_data = new List<Models.Content> { Response.content };
                            foreach (var content in statement_data)
                            {
                                var statementDetailsList = new List<Models.Statement_list>();
                                if (content.book_data != null)
                                {
                                    var printbookData = JsonConvert.DeserializeObject<Book_data>(content.book_data.ToString());
                                    if (printbookData != null)
                                    {
                                        foreach (var statement in printbookData.statement_list)
                                        {
                                            var deptaccountNo = statement.deptaccount_no.Replace(" ", "");
                                            var statementDetails = new Models.Statement_list
                                            {
                                                coop_id = statement.coop_id,
                                                deptaccount_no = deptaccountNo,
                                                seq_no = statement.seq_no,
                                                deptitemtype_code = statement.deptitemtype_code,
                                                operate_date = statement.operate_date,
                                                entry_date = statement.entry_date,
                                                prncbal = statement.prncbal,
                                                entry_id = statement.entry_id,
                                                item_status = statement.item_status,
                                                sign_flag = statement.sign_flag,
                                                print_code = statement.print_code,
                                                prnc_no = statement.prnc_no,
                                                tax_amt = statement.tax_amt,
                                                accuint_amt = statement.accuint_amt,
                                                int_amt = statement.int_amt,
                                                printbook_status = statement.printbook_status,
                                                deptslip_no = statement.deptslip_no,
                                                deptitem_amt = statement.deptitem_amt,
                                                deptint_amt = statement.deptint_amt,
                                                deposit_amt = statement.deposit_amt,
                                                withdraw_amt = statement.withdraw_amt,
                                            };
                                            Console.WriteLine($"coop_id: {statement.coop_id}, deptaccount_no: {statement.deptaccount_no}");
                                            statementDetailsList.Add(statementDetails);
                                        }
                                    }else{
                                        printbookData = null;
                                    }
                                    statementDetails = statementDetailsList;
                                }
                                else
                                {
                                    statementDetailsList = null;
                                }
                            }
                            currentStep = 2;
                            await PrintPdf();
                            await PrintBook();
                            await InvokeAsync(() => StateHasChanged());

                            Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = Response.message, Duration = 2500 });
                        }
                        else
                        {
                            this.currentStep = 0;
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Response.message, Duration = 2500 });
                        }
                        // Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
                        // ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = apiResponse.message, Duration = 2500 });
                    }
                    else
                    {
                        HandleErrorResponse(responseData);
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = responseData, Duration = 2500 });
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 2500 });
                saveLoading = false;
            }
            finally
            {
                saveLoading = false;
            }
        }

        private Deptslip CreateDeptSlip(string coop_id, string name, string machine_address, Models.Deposit item)
        {
            var deptSlip = new Deptslip
            {
                coop_id = coop_id,
                // deptcoop_id = item.deptSlip.deptcoop_id ?? coop_id,
                deptcoop_id =  coop_id,
                deptslip_no = item.deptSlip.deptslip_no,
                member_no = item.deptSlip.member_no,
                membcat_code = item.deptSlip.membcat_code,
                deptno_format = item.deptSlip.deptno_format,
                deptaccount_no = item.deptSlip.deptaccount_no,
                depttype_code = item.deptSlip.depttype_code,
                deptgroup_code = item.deptSlip.deptgroup_code,
                recppaytype_code = (recpPayTypeCode == null) ? item.deptSlip.recppaytype_code : recpPayTypeCode,
                moneytype_code = (cashTypeValue == null) ? item.deptSlip.moneytype_code : cashTypeValue,
                bank_code = item.deptSlip.bank_code,
                bankbranch_code = item.deptSlip.bankbranch_code,
                entry_id = name,
                machine_id = machine_address,
                tofrom_accid = (toFromaccId2 ?? valuetoFromaccId) ?? item.deptSlip.tofrom_accid,
                operate_date = DateTime.Today,
                entry_date = DateTime.Today,
                calint_from = DateTime.Today,
                operate_code = item.deptSlip.operate_code,
                sign_flag = 1,
                laststmseq_no = item.deptSlip.laststmseq_no,
                nobook_flag = nobook_flag ?? 0,
                prnc_no = item.deptSlip.prnc_no,
                deptslip_amt = deptslipAmt,
                deptslip_netamt = deptslipAmt,
                fee_amt = item.deptSlip.fee_amt,
                oth_amt = item.deptSlip.oth_amt,
                intbonus_amt = item.deptSlip.intbonus_amt,
                int_return = item.deptSlip.int_return,
                tax_return = item.deptSlip.tax_return,
                int_netamt = item.deptSlip.int_netamt,
                prncbal = item.deptSlip.prncbal,
                withdrawable_amt = item.deptSlip.withdrawable_amt,
                prncbal_bf = item.deptSlip.prncbal_bf,
                tax_amt = item.deptSlip.tax_amt,
                int_amt = item.deptSlip.int_amt,
                slipnetprncbal_amt = item.deptSlip.slipnetprncbal_amt,
                posttovc_flag = item.deptSlip.posttovc_flag,
                refer_slipno = item.deptSlip.refer_slipno,
                deptaccount_name = item.deptSlip.deptaccount_name,
                depttype_desc = item.deptSlip.depttype_desc,
                dept_objective = item.deptSlip.dept_objective,
                prncbal_retire = item.deptSlip.prncbal_retire,
                remark = item.deptSlip.remark,
                due_date = DateTime.Today,
                deptpassbook_no = item.deptSlip.deptpassbook_no,
                condforwithdraw = item.deptSlip.condforwithdraw,
                upint_time = item.deptSlip.upint_time,
                deptaccount_ename = item.deptSlip.deptaccount_ename,
                account_type = item.deptSlip.account_type,
                monthintpay_meth = item.deptSlip.monthintpay_meth,
                traninttype_code = item.deptSlip.traninttype_code,
                tran_deptacc_no = item.deptSlip.tran_deptacc_no,
                dept_tranacc_name = item.deptSlip.dept_tranacc_name,
                deptmonth_status = item.deptSlip.deptmonth_status,
                deptmonth_amt = item.deptSlip.deptmonth_amt,
                dept_status = item.deptSlip.dept_status,
                monthint_status = item.deptSlip.monthint_status,
                f_tax_rate = item.deptSlip.f_tax_rate,
                adjdate_status = item.deptSlip.adjdate_status,
                membcat_desc = item.deptSlip.membcat_desc,
                reqappl_flag = item.deptSlip.reqappl_flag,
                spcint_rate_status = item.deptSlip.spcint_rate_status,
                spcint_rate = item.deptSlip.spcint_rate,
                payfee_meth = item.deptSlip.payfee_meth,
            };
            string json = JsonConvert.SerializeObject(deptSlip, Formatting.Indented);
            Console.WriteLine(json);
            return deptSlip;
        }
        private List<DeptSlipdet> CreateDeptSlipdet(string coop_id, string name, string machine_address, Models.Deposit item)
        {
            var deptSlipdet = new List<DeptSlipdet>();

            foreach (var deptSlipdetItem in deptSlipdetDetails)
            {
                var deptSlipdetlist = new DeptSlipdet
                {
                    // select_flag = deptSlipdetItem.select_flag,
                    // coop_id = deptSlipdetItem.coop_id,
                    // deptslip_no = deptSlipdetItem.deptslip_no,
                    // deptaccount_no = deptSlipdetItem.deptaccount_no,
                    // prnc_no = deptSlipdetItem.prnc_no,
                    // prnc_bal = deptSlipdetItem.prnc_bal,
                    // prnc_amt = deptSlipdetItem.prnc_amt,
                    // prnc_date = deptSlipdetItem.prnc_date,
                    // calint_from = deptSlipdetItem.calint_from,
                    // calint_to = deptSlipdetItem.calint_to,
                    // prncdue_date = deptSlipdetItem.prncdue_date,
                    // prncmindue_date = deptSlipdetItem.prncmindue_date,
                    // prncdue_nmonth = deptSlipdetItem.prncdue_nmonth,
                    // prncslip_amt = prncslip_amt,
                    // intarr_amt = deptSlipdetItem.intarr_amt,
                    // intpay_amt = deptSlipdetItem.intpay_amt,
                    // taxpay_amt = deptSlipdetItem.taxpay_amt,
                    // intbf_accyear = deptSlipdetItem.intbf_accyear,
                    // intcur_accyear = deptSlipdetItem.intcur_accyear,
                    // monthintdue_date = deptSlipdetItem.monthintdue_date,
                    // prncdeptdue_date = deptSlipdetItem.prncdeptdue_date,
                    // interest_rate = deptSlipdetItem.interest_rate,
                    // int_return = deptSlipdetItem.int_return,
                    // preint_rate = deptSlipdetItem.preint_rate,
                    // int_return_default = deptSlipdetItem.int_return_default,
                    // tax_return = deptSlipdetItem.tax_return,
                    // fee_amt = deptSlipdetItem.fee_amt,
                    // other_amt = deptSlipdetItem.other_amt,
                    // chequepend_amt = deptSlipdetItem.chequepend_amt,
                    // refer_prnc_no = deptSlipdetItem.refer_prnc_no,
                    // upint_time = deptSlipdetItem.upint_time,
                    // interest_rate_desc = deptSlipdetItem.interest_rate_desc,
                    // day_calint = deptSlipdetItem.day_calint,
                    // f_startprn_bfdue = deptSlipdetItem.f_startprn_bfdue
                    select_flag = deptSlipdetItem.select_flag,
                    coop_id = deptSlipdetItem.coop_id,
                    deptslip_no = deptSlipdetItem.deptslip_no,
                    deptaccount_no = deptSlipdetItem.deptaccount_no,
                    prnc_no = deptSlipdetItem.prnc_no,
                    prnc_bal = deptSlipdetItem.prnc_bal,
                    prnc_amt = deptSlipdetItem.prnc_amt,
                    prnc_date = deptSlipdetItem.prnc_date,
                    calint_from = deptSlipdetItem.calint_from,
                    calint_to = deptSlipdetItem.calint_to,
                    prncdue_date = deptSlipdetItem.prncdue_date,
                    prncmindue_date = deptSlipdetItem.prncmindue_date,
                    prncdue_nmonth = deptSlipdetItem.prncdue_nmonth,
                    prncslip_amt = deptSlipdetItem.prncslip_amt,
                    intarr_amt = deptSlipdetItem.intarr_amt,
                    intpay_amt = deptSlipdetItem.intpay_amt,
                    taxpay_amt = deptSlipdetItem.taxpay_amt,
                    intbf_accyear = deptSlipdetItem.intbf_accyear,
                    intcur_accyear = deptSlipdetItem.intcur_accyear,
                    monthintdue_date = deptSlipdetItem.monthintdue_date,
                    prncdeptdue_date = deptSlipdetItem.prncdeptdue_date,
                    interest_rate = deptSlipdetItem.interest_rate,
                    preint_rate = deptSlipdetItem.preint_rate,
                    int_return = deptSlipdetItem.int_return,
                    int_return_default = deptSlipdetItem.int_return_default,
                    tax_return = deptSlipdetItem.tax_return,
                    fee_amt = deptSlipdetItem.fee_amt,
                    other_amt = deptSlipdetItem.other_amt,
                    chequepend_amt = deptSlipdetItem.chequepend_amt,
                    refer_prnc_no = deptSlipdetItem.refer_prnc_no,
                    upint_time = deptSlipdetItem.upint_time,
                    day_calint = deptSlipdetItem.day_calint,
                    f_startprn_bfdue = deptSlipdetItem.f_startprn_bfdue,
                    depttype_code = deptSlipdetItem.depttype_code,
                    interest_rate_desc = deptSlipdetItem.interest_rate_desc,
                    preinterest_rate_desc = deptSlipdetItem.preinterest_rate_desc


                };
                deptSlipdet.Add(deptSlipdetlist);
            }
            string json = JsonConvert.SerializeObject(deptSlipdet);
            Console.WriteLine(json);
            return deptSlipdet;
        }

        private DeptSlipCheque CreateDeptSlipCheque(string coop_id, string deptslip_no, string deptaccount_no, Models.Deposit item)
        {
            var deptSlipCheque = new DeptSlipCheque();

            foreach (var rowsItem in rows)
            {
                // Create new DeptSlipCheque for each rowsItem
                var newDeptSlipCheque = new DeptSlipCheque
                {
                    coop_id = coop_id,
                    deptslip_no = deptslip_no,
                    deptaccount_no = deptaccount_no,
                    cheque_no = rowsItem.cheque_no,
                    bank_code = rowsItem.bank_code,
                    bankbranch_code = rowsItem.branch_id,
                    cheque_date = DateTime.Now,
                    entry_date = DateTime.Now,
                    entry_time = DateTime.Now,
                    chequedue_date = chequedue_date,
                    cheque_type = rowsItem.cheque_type,
                    cheque_amt = rowsItem.cheque_amt ?? 0,
                    seq_no = rowsItem.seq_no ?? 0,
                    checkclear_status = rowsItem.checkclear_status,
                    entry_id = "Admin_id",
                    depttype_code = item.deptSlip.depttype_code, // Assuming depttype_code is accessible from item
                };

                // Assign the new DeptSlipCheque to deptSlipCheque
                deptSlipCheque = newDeptSlipCheque;
            }

            return deptSlipCheque;
        }
        private string GetMachineAddress()
        {
            string hostName = Dns.GetHostName();
            var hostEntry = Dns.GetHostEntry(hostName);
            string machine_address = null;

            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    machine_address = address.ToString();
                    break;
                }
            }

            return machine_address;
        }
        private void HandleErrorResponse(string responseData)
        {
            Console.WriteLine(responseData);
            var jsonResponse = JObject.Parse(responseData);
            var errorsProperty = jsonResponse["errors"];
            Console.WriteLine(errorsProperty);
            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorsProperty + "ตรวจสอบข้อมูลให้ครบถ้วน", Duration = 2500 });
        }

        private void HandleException(Exception ex)
        {
            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 2500 });
            Console.WriteLine(ex.ToString());
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