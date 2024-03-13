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


namespace FinanceApp.Pages.Deposit.Dep_slip_withdraw
{
    public partial class DepWithdraw
    {
        private readonly IApiProvider _apiProvider;
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
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
        public List<Content>? Listcontent { get; set; }
        public List<Printbook_data>? printbook_data { get; set; }
        public List<Statement_list>? statement_list { get; set; }

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
        private async Task PrintPdf()
        {
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            try
            {
                deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
                foreach (var item in datadetail)
                {
                    var Item = item.deptSlip;
                    var depOfGetAccount = new
                    {
                        coop_id = coop_id,
                        memcoop_id = coop_id,
                        deptaccount_no = deptno_format,
                        deptaccount_name = Item.deptaccount_name,
                        recppaytype_code = (selectedValue == null) ? Item.recppaytype_code : selectedValue,
                        deptslip_amt = deptslipAmt,
                        deptslip_tdate = DateTime.Today,
                        printter_name = "Bullzip PDF Printer",
                    };
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    Console.WriteLine($"depOfGetAccount{json}");
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfPrintSlip}";
                    Console.WriteLine($"apiUrl {apiUrl}");
                    var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);

                    Console.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        PrintResponse responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
                        responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
                        if (responseObj.Success)
                        {
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = responseObj.Message, Duration = 5000 });
                        }
                        else
                        {

                            var errorResponse = await response.Content.ReadAsStringAsync();
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorResponse, Duration = 5000 });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
            }
        }
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
                var response = await SendApiRequestAsyncGet(apiUrl);
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
                var response = await SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();
                // var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBank}?coop_control={coop_id}");
                // response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var GetBank = JsonConvert.DeserializeObject<List<GetBank>>(json);
                getBank = new List<GetBank>();
                getBank.AddRange(GetBank);
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
        private string bank_code_fild;
        private async Task BankBranch()
        {
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBankBranch}?coop_control={coop_id}&bank_code=006";
                var response = await SendApiRequestAsyncGet(apiUrl);
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
        //RetriveDataFromDeptNo
        private async void UpdateAccountDetails(Models.AccountDetails data)
        {
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();

            try
            {

                deptno_format = data.deptaccount_no?.Trim();

                Console.WriteLine($"Clicked on coop_id: {coop_id}");
                Console.WriteLine($"Clicked on deptaccount_no: {data.deptaccount_no}");
                await JSRuntime.InvokeVoidAsync("alert", $"เลือก {data.deptaccount_no}, {data.deptaccount_name}");
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
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
                var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);
                // var response = await httpClient.PostAsync(apiUrl, content);

                response.EnsureSuccessStatusCode();
                var jsonRes = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
                if (apiResponse.status == true)
                {
                    datadetail = new List<Models.Deposit> { apiResponse.data };
                    StateHasChanged();
                    Console.WriteLine($"API request failed: {datadetail}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void AnotherFunction()
        {
            GetBank();
            BankBranch();
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
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
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
            try
            {
                deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
                var depOfGetAccount = new DepOfInitDataOffline
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
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
                // var response = await httpClient.PostAsync(apiUrl, content);
                var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);

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
                        await GetBank();
                        await BankBranch();
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

        // private async Task CallApi()
        // {
        //     (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //      Console.WriteLine($"GetDataList:, {coop_id}, {name},  {email}, {actort}, {apvlevelId}, {workDate}, {application}, {save_status}, {check_flag}");
        //     try
        //     {
        //         deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
        //         isLoading = true;
        //         var depOfGetAccount = new DepOfInitDataOffline
        //         {
        //             coop_id = coop_id,
        //             memcoop_id = coop_id,
        //             deptno_format = deptno_format,
        //             entry_date = DateTime.Today,
        //             deptitem_group = deptitem_group ?? "WID",
        //             reqappl_flag = reqappl_flag ?? 0,
        //         };
        //         var json = JsonConvert.SerializeObject(depOfGetAccount);
        //         Console.WriteLine(json);
        //         // var content = new StringContent(json, Encoding.UTF8, "application/json");
        //         var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
        //         // var response = await httpClient.PostAsync(apiUrl, content);
        //         var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);

        //         Console.WriteLine(response.IsSuccessStatusCode);
        //         if (response.IsSuccessStatusCode)
        //         {
        //             // อ่าน response string
        //             var jsonResponse = await response.Content.ReadAsStringAsync();
        //             var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
        //             // Console.WriteLine(apiResponse.status == true);
        //             if (apiResponse.status == true)
        //             {
        //                 datadetail = new List<Models.Deposit> { apiResponse.data };
        //                 Console.WriteLine($"API request failed: {datadetail}");
        //             }
        //             else
        //             {
        //                 var Error = JsonConvert.SerializeObject(apiResponse.message);

        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });

        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
        //         Console.WriteLine(ex.Message.ToString());
        //     }
        // }
        //ค้นหาใน dlg
        // private async Task SearchOfGetAcc()
        // {
        //     try
        //     {
        //         isLoadingModals = true;
        //         (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //         var depOfGetAccount = new AccountDetails
        //         {
        //             coop_id = coop_id,
        //             memcoop_id = coop_id,
        //             deptaccount_no = deptaccount_No_fild,

        //             deptaccount_name = deptaccount_name_fild,
        //             member_no = member_no,
        //             depttype_code = depttype_code,
        //             deptclose_status = deptclose_status,
        //             memb_name = memb_name,
        //             memb_surname = memb_surname,
        //             card_person = card_person,
        //             mem_telmobile = mem_telmobile,
        //             full_name = full_name,
        //             salary_id = salary_id,
        //             entry_date = entry_date ?? null
        //         };
        //         var json = JsonConvert.SerializeObject(depOfGetAccount);
        //         Console.WriteLine(json);
        //         var content = new StringContent(json, Encoding.UTF8, "application/json");
        //         var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetAccountSaving}";
        //         var response = await httpClient.PostAsync(apiUrl, content);

        //         Console.WriteLine(response.IsSuccessStatusCode);
        //         if (response.IsSuccessStatusCode)
        //         {
        //             // อ่าน response string
        //             var jsonResponse = await response.Content.ReadAsStringAsync();
        //             var jsonResponse1 = JObject.Parse(jsonResponse);
        //             depOfGetAccDetails = jsonResponse1["data"].ToObject<List<AccountDetails>>();
        //             //Console.WriteLine("depOfGetAccDetails:" + depOfGetAccDetails);
        //         }
        //         // dataaccDetails = accountDetailsList;
        //         var accountDetailsList = new List<Models.AccountDetails>();
        //         if (depOfGetAccDetails != null)
        //         {
        //             foreach (var accDetails in depOfGetAccDetails)
        //             {
        //                 var accountDetails = new Models.AccountDetails
        //                 {
        //                     deptaccount_no = accDetails.deptaccount_no,
        //                     deptaccount_name = accDetails.deptaccount_name,
        //                     member_no = accDetails.member_no,
        //                     full_name = accDetails.full_name
        //                 };

        //                 // Optional: You might want to add this to the list
        //                 accountDetailsList.Add(accountDetails);

        //                 // Console.WriteLine($"Coop ID: {accDetails.coop_id}, Member Name: {accDetails.memb_name}");
        //                 // Add other properties as needed
        //             }
        //         }
        //         // Assign the list to dataaccDetails
        //         dataaccDetails = accountDetailsList;
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
        //         Console.WriteLine(ex.Message.ToString());
        //     }
        //     finally
        //     {
        //         isLoadingModals = false;
        //     }

        // }
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
                var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse1 = JObject.Parse(jsonResponse);
                    depOfGetAccDetails = jsonResponse1["data"].ToObject<List<AccountDetails>>();
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
        private async Task<HttpResponseMessage> SendApiRequestAsync<T>(string apiUrl, T payload)
        {
            try
            {
                string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    var json = JsonConvert.SerializeObject(payload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine($"bearerToken :{httpClient.DefaultRequestHeaders.Authorization}");
                    return await httpClient.PostAsync(apiUrl, content);
                }
            }
            catch (Exception ex)
            {
                // จัดการ Exception ตามความเหมาะสม
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        private async Task<HttpResponseMessage> SendApiRequestAsyncGet(string apiUrl)
        {
            try
            {
                var bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    return await httpClient.GetAsync(apiUrl);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        public class SaveResponse
        {
            public bool success { get; set; }
            public Models.Content content { get; set; }
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
        private void FormatNumber()
        {

            if (decimal.TryParse(DeptslipAmt, out decimal result))
            {
                DeptslipAmt = result.ToString("0.00");
                result = Math.Round(result, 2);
                deptslipAmt = result;
                Console.WriteLine(deptslipAmt);


            }
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

        public async Task SaveDataAsync()
        {
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();

                // หาที่อยู่ IP ของเครื่อง
                string machine_address = GetMachineAddress();

                isLoading = true;

                foreach (var item in datadetail)
                {
                    var Deptslip = CreateDeptSlip(coop_id, name, machine_address, item);
                    var DeptSlipdet = CreateDeptSlip(coop_id, name, machine_address, item);
                    var DeptSlipCheque = CreateDeptSlipCheque(coop_id, deptslip_no, deptaccount_no, item);


                    var deptDeposit = new Models.Deposit
                    {
                        deptSlip = Deptslip,
                        deptSlipdet = null,
                        deptSlipCheque = (recpPayTypeCode == "DEN") ? new DeptSlipCheque() : null,
                    };

                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostWithSaving}";
                    var response = await SendApiRequestAsync(apiUrl, deptDeposit);
                    var responseData = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var Response = JsonConvert.DeserializeObject<SaveResponse>(jsonResponse);
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                        success_status = true;
                        if (response.IsSuccessStatusCode)
                        {

                            Listcontent = new List<Models.Content> { Response.content };
                            foreach (var content in Listcontent)
                            {
                                Console.WriteLine($"deptslip_no: {content.deptslip_no}");
                            }
                            currentStep = 2;
                            PrintPdf();
                            StateHasChanged();

                            Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = apiResponse.message, Duration = 2500 });
                        }
                        else
                        {
                            this.currentStep = 0;
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = apiResponse.message, Duration = 2500 });
                        }
                        // Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
                        // ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = apiResponse.message, Duration = 2500 });
                    }
                    else
                    {
                        HandleErrorResponse(responseData);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                isLoading = false;
            }
        }

        private Deptslip CreateDeptSlip(string coop_id, string name, string machine_address, Models.Deposit item)
        {
            var deptSlip = new Deptslip
            {
                coop_id = coop_id,
                deptcoop_id = item.deptSlip.deptcoop_id,
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
            };
            string json = JsonConvert.SerializeObject(deptSlip, Formatting.Indented);
            Console.WriteLine(json);
            return deptSlip;
        }
        private DeptSlipdet CreateDeptSlipdet(string coop_id, string name, string machine_address, Models.Deposit item)
        {
            var deptSlipdet = new DeptSlipdet
            {
                coop_id = item.deptSlipdet.coop_id,
                deptslip_no = item.deptSlipdet.deptslip_no,
                deptaccount_no = item.deptSlipdet.deptaccount_no,
                prnc_no = item.deptSlipdet.prnc_no,
                prnc_bal = item.deptSlipdet.prnc_bal,
                prnc_amt = item.deptSlipdet.prnc_amt,
                prnc_date = item.deptSlipdet.prnc_date,
                calint_from = item.deptSlipdet.calint_from,
                calint_to = item.deptSlipdet.calint_to,
                prncdue_date = item.deptSlipdet.prncdue_date,
                prncmindue_date = item.deptSlipdet.prncmindue_date,
                prncdue_nmonth = item.deptSlipdet.prncdue_nmonth,
                prncslip_amt = item.deptSlipdet.prncslip_amt,
                intarr_amt = item.deptSlipdet.intarr_amt,
                intpay_amt = item.deptSlipdet.intpay_amt,
                taxpay_amt = item.deptSlipdet.taxpay_amt,
                intbf_accyear = item.deptSlipdet.intbf_accyear,
                intcur_accyear = item.deptSlipdet.intcur_accyear,
                monthintdue_date = item.deptSlipdet.monthintdue_date,
                prncdeptdue_date = item.deptSlipdet.prncdeptdue_date,
                interest_rate = item.deptSlipdet.interest_rate,
                int_return = item.deptSlipdet.int_return,
                tax_return = item.deptSlipdet.tax_return,
                fee_amt = item.deptSlipdet.fee_amt,
                other_amt = item.deptSlipdet.other_amt,
                chequepend_amt = item.deptSlipdet.chequepend_amt,
                refer_prnc_no = item.deptSlipdet.refer_prnc_no,
                upint_time = item.deptSlipdet.upint_time
            };

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