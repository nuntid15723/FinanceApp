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
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;


namespace FinanceApp.Pages.Deposit.Dep_slip_deposit
{
    public partial class DepDeposit

    {
        // public DepDeposit depDeposit = new DepDeposit();
        private readonly IApiProvider _apiProvider;
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public Api_Provider ApiProvider { get; set; }

        // private async Task CallAlert(string message)
        // {
        //     await jsRuntime.InvokeVoidAsync("alert", message);
        // }
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
        private bool saveLoading;
        private bool slipLoading;
        private bool printLoading;
        private bool isLoadingModals;
        bool isCurrentOptionSelected = false;
        private bool isUpdateExecuted = false;
        public string deptMaintype { get; set; }
        private bool success_status = false;
        private int currentStep = 0;
        public string? SaveStatus { get; set; }
        public List<GetDeptMaintype>? getDeptMaintype { get; set; }
        public List<GetBank>? getBank { get; set; }
        public List<BankBranch>? bankBranch { get; set; }
        public List<Content>? statement_data { get; set; }
        public List<Book_data>? book_data { get; set; }
        public List<Slip_data>? slip_data { get; set; }
        public List<Statement_list>? statement_list { get; set; }
        public List<Models.DepOfInitDataOffline> depOfInitDataOffline;
        public List<Print_book>? printbook_data { get; set; }
        public List<Row_detail>? rowdatadetail { get; set; }
        public List<PrintResponse> connections = new List<PrintResponse>();
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
        // private async Task PrintPdf(string deptslip_no)
        // {
        //     Console.WriteLine($"deptslip_no {deptslip_no}");
        //     (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //     try
        //     {
        //         // deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
        //         // foreach (var item in datadetail)
        //         // {
        //         //     var Item = item.deptSlip;
        //         //     var depOfGetAccount = new
        //         //     {
        //         //         coop_id = coop_id,
        //         //         memcoop_id = coop_id,
        //         //         deptaccount_no = deptno_format,
        //         //         deptaccount_name = Item.deptaccount_name,
        //         //         recppaytype_code = (selectedValue == null) ? Item.recppaytype_code : selectedValue,
        //         //         deptslip_amt = deptslipAmt,
        //         //         deptslip_tdate = DateTime.Today,
        //         //         printter_name = "Bullzip PDF Printer",
        //         //     };
        //         //     var json = JsonConvert.SerializeObject(depOfGetAccount);
        //         //     Console.WriteLine($"depOfGetAccount{json}");
        //         //     var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfPrintSlip}";
        //         //     Console.WriteLine($"apiUrl {apiUrl}");
        //         //     var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);

        //         //     Console.WriteLine(response.IsSuccessStatusCode);
        //         //     if (response.IsSuccessStatusCode)
        //         //     {
        //         //         var jsonResponse = await response.Content.ReadAsStringAsync();
        //         //         PrintResponse responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
        //         //         responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
        //         //         if (responseObj.Success)
        //         //         {
        //         //             ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = responseObj.Message, Duration = 5000 });
        //         //         }
        //         //         else
        //         //         {

        //         //             var errorResponse = await response.Content.ReadAsStringAsync();
        //         //             ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorResponse, Duration = 5000 });
        //         //         }
        //         //     }
        //         var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DeptOfGetPrintSlip}={deptslip_no}";
        //         Console.WriteLine($"apiUrl {apiUrl}");
        //         var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);

        //         Console.WriteLine(response.IsSuccessStatusCode);
        //         if (response.IsSuccessStatusCode)
        //         {
        //             var jsonResponse = await response.Content.ReadAsStringAsync();
        //             PrintResponse responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
        //             responseObj = JsonConvert.DeserializeObject<PrintResponse>(jsonResponse);
        //             if (responseObj.Success)
        //             {
        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = responseObj.Message, Duration = 5000 });
        //             }
        //             else
        //             {

        //                 var errorResponse = await response.Content.ReadAsStringAsync();
        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = errorResponse, Duration = 5000 });
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
        //         Console.WriteLine(ex.Message.ToString());
        //     }
        // }

        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        private async void UpdateAccountDetails(Models.AccountDetails data)
        {
            try
            {
                isLoading = true;
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                deptno_format = data.deptaccount_no?.Trim();
                Console.WriteLine($"Clicked on coop_id: {coop_id}");
                Console.WriteLine($"Clicked on deptaccount_no: {deptaccount_no}");
                await JSRuntime.InvokeVoidAsync("alert", $"เลือก {deptaccount_no}, {data.deptaccount_name}");
                var depOfGetAccount = new DepOfInitDataOffline
                {
                    coop_id = coop_id,
                    memcoop_id = coop_id,
                    deptaccount_no = data.deptaccount_no,
                    deptno_format = data.deptaccount_no,
                    entry_date = null,
                    deptitem_group = "DEP",
                };
                var jsonReq = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(jsonReq);
                var content = new StringContent(jsonReq, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfInitDataOffline}";
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
                response.EnsureSuccessStatusCode();
                var jsonRes = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
                if (apiResponse.status == true)
                {
                    datadetail = new List<Models.Deposit> { apiResponse.data };
                    // await GetBank();
                    await BankBranch();
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

        //ค้นหา
        private async Task Search()
        {

            if (deptno_format == null || deptno_format == "")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขที่บัญชี", Duration = 1500 });
            }
            else
            {
                deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
                try
                {
                    isLoading = true;
                    var depOfGetAccount = new DepOfInitDataOffline
                    {
                        coop_id = coop_id,
                        memcoop_id = coop_id,
                        deptaccount_no = deptaccountNo_fild,
                        deptaccount_name = deptaccount_name,
                        member_no = member_no,
                        depttype_code = depttype_code,
                        deptclose_status = 0,
                        memb_name = memb_name,
                        memb_surname = memb_surname,
                        card_person = card_person,
                        mem_telmobile = mem_telmobile,
                        full_name = full_name,
                        salary_id = salary_id,
                        membgroup_code = membgroup_code,
                        membgroup_desc = membgroup_desc,
                        deptno_format = deptno_format,
                        entry_date = entry_date,
                        deptitem_group = deptitem_group ?? "DEP",
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
                        }
                        else
                        {
                            var Error = JsonConvert.SerializeObject(apiResponse.message);

                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });

                        }
                    }
                }
                // var repReqdepoitDetails = new List<Models.DepReqdepoit>();

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
        bool chkSerach = false;
        private async Task HandleEnterKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {

                await PerformSearch();
            }

        }
        private async Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "F9")
            {
                currentStep = 1;
            }
        }
        private async Task PerformSearch()
        {
            isLoading = true;
            if (string.IsNullOrEmpty(deptno_format ?? deptaccount_no))
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

            try
            {
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                Console.WriteLine($"GetDataList: {coopControl}, {coop_id}, {name},  {email}, {actort}, {apvlevelId}, {workDate}, {application}, {save_status}, {check_flag}");
                deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
                var depOfGetAccount = new DepOfInitDataOffline
                {
                    coop_id = coop_id,
                    memcoop_id = coop_id,
                    deptno_format = deptno_format,
                    entry_date = DateTime.Today,
                    deptitem_group = deptitem_group ?? "DEP",
                    reqappl_flag = reqappl_flag ?? 0,
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(json);
                // var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfInitDataOffline}";
                // var response = await httpClient.PostAsync(apiUrl, content);
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);

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
                        chkSerach = true;
                        Console.WriteLine($"API request failed: {datadetail}");
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
        //             // Console.WriteLine("depOfGetAccDetails:" + depOfGetAccDetails);

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
                        // deptaccount_no = "1000051044",
                        // deptpassbook_no = "0100051155",
                        // lastrec_no = 8,
                        // laststmseq_no = 144,
                        // lastpage_no = 1,
                        // lastline_no = 8
                    };
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfPostPrintBook}";
                    var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
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
                            // foreach (var items in printdetail)
                            // {
                            //     var rowdetail = items.row_detail;
                            //     foreach (var itemsl in rowdetail)
                            //     {
                            //         Console.WriteLine($"print_detail :{itemsl.column_name}");
                            //     }
                            // }
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
        }

        public class PrintBookResponse
        {
            public bool success { get; set; }
            public Print_book content { get; set; }
            public string message { get; set; }
        }
        public class ApiResponse
        {
            public bool status { get; set; }
            public Models.Deposit data { get; set; }
            public string message { get; set; }
        }
        public class SaveResponse
        {
            public bool success { get; set; }
            public Models.Content content { get; set; }
            public string message { get; set; }
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
        private string recpPayTypeCode { get; set; }
        private string selectedRecppaytype { get; set; }
        private string selectedToFromAcc { get; set; }
        private string valuetoFromaccId { get; set; }
        private string toFromaccId2 { get; set; }
        private string bookCode { get; set; }
        private decimal deptslipAmt { get; set; }
        private string deptslipNetamt { get; set; }
        private string DeptslipAmt { get; set; }


        private void FormatNumber()
        {

            if (decimal.TryParse(DeptslipAmt, out decimal result))
            {
                // DeptslipAmt = result.ToString("0.00");
                // result = Math.Round(result, 2);
                // deptslipAmt = result;
                // Console.WriteLine(deptslipAmt);

                DeptslipAmt = result.ToString("N2");

                // นำค่าที่ได้มา round และกำหนดให้กับตัวแปร result
                result = Math.Round(result, 2);

                // นำค่าที่ได้มากำหนดให้กับตัวแปร deptslipAmt (หาก deptslipAmt เป็นตัวแปรที่ถูกประกาศแล้ว)
                deptslipAmt = result;

                // แสดงค่าใน Console
                Console.WriteLine(deptslipAmt);


            }
        }
        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('_');
            selectedValue = values[0];
            recpPayTypeCode = values[1];
            selectedRecppaytype = values[1] + " - " + values[3];
            bookCode = selectedValue;
            string[] toFromaccId1 = bookCode.Split('|');
            cashTypeValue = toFromaccId1[0];
            valuetoFromaccId = toFromaccId1[1];
            Console.WriteLine($"Cash Type: {selectedValue}, Recp Pay Type Code: {valuetoFromaccId},cashTypeValue:{cashTypeValue},selectedRecppaytype:{selectedRecppaytype},");
            await OnToFromAccChanged(e);
            if (recpPayTypeCode == "DEN")
            {
                GetBabk();
                BankBranch();
            }
        }
        private async Task OnToFromAccChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            string[] csahValue = e.Value.ToString().Split('_');
            if (values != null && values.Length >= 2)
            {
                Valueselecte = values[0];
                toFromaccId2 = values[1];
                // selectedToFromAcc = values[2];
                // selectedToFromAcc = values[0] + " - " + values[1];
                selectedToFromAcc = csahValue[0];
                Console.WriteLine($"Cash Typee: {bookCode}, Recp Pay Type Code: {Valueselecte},toFromaccId:{toFromaccId2},selectedToFromAcc:{selectedToFromAcc}");
            }

        }
        private async Task CheckNumber()
        {
            deptslipNetamt = "50";
            Console.WriteLine($"input: {deptslipNetamt}");
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
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var GetDeptMaintype = JsonConvert.DeserializeObject<List<GetDeptMaintype>>(json);
                getDeptMaintype = new List<GetDeptMaintype>();
                getDeptMaintype.AddRange(GetDeptMaintype);
                Console.WriteLine("Icon clicked!");
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

        private async Task GetBabk()
        {
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();

                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBank}?coop_control={coop_id}";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var GetBank = JsonConvert.DeserializeObject<List<GetBank>>(json);
                getBank = new List<GetBank>();
                getBank.AddRange(GetBank);
                // foreach (var item in GetBank)
                // {
                //     Console.WriteLine($"bank_code: {item.bank_code},bank_desc: {item.bank_desc},bank_name_e: {item.bank_name_e},bank_shortname_t: {item.bank_shortname_t},");
                // }
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
            foreach (var item in datadetail)
            {
                var Item = item.deptSlip;
                bank_code_fild = Item.bank_code;
                Console.WriteLine($"bank_code_fild :{bank_code_fild}");
            }
            try
            {
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();

                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBankBranch}?coop_control={coop_id}&bank_code=006";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var BankBranch = JsonConvert.DeserializeObject<List<BankBranch>>(json);
                bankBranch = new List<BankBranch>();
                bankBranch.AddRange(BankBranch);
                // foreach (var item in BankBranch)
                // {
                //     Console.WriteLine($"bank_code: {item.bank_code},branch_id: {item.branch_id},branch_name: {item.branch_name}");
                // }
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
        // public async Task SaveDataAsync()
        // {
        //     try
        //     {
        //         (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();

        //         Console.WriteLine($"deptslipAmt:{deptslipAmt}");
        //         string hostName = Dns.GetHostName();
        //         var hostEntry = Dns.GetHostEntry(hostName);
        //         string machine_address = GetMachineAddress();
        //         isLoading = true;

        //         foreach (var item in datadetail)
        //         {
        //             var ItemdeptSlip = item.deptSlip;
        //             var ItemdeptSlipdet = item.deptSlipdet;
        //             var ItemdeptSlipCheque = item.deptSlipCheque;
        //             var Deptslip = new Deptslip
        //             {
        //                 coop_id = coop_id,
        //                 deptcoop_id = ItemdeptSlip.deptcoop_id,
        //                 deptslip_no = ItemdeptSlip.deptslip_no,
        //                 member_no = ItemdeptSlip.member_no,
        //                 membcat_code = ItemdeptSlip.membcat_code,
        //                 deptno_format = ItemdeptSlip.deptno_format,
        //                 deptaccount_no = ItemdeptSlip.deptaccount_no,
        //                 depttype_code = ItemdeptSlip.depttype_code,
        //                 deptgroup_code = ItemdeptSlip.deptgroup_code,
        //                 recppaytype_code = (recpPayTypeCode == null) ? ItemdeptSlip.recppaytype_code : recpPayTypeCode,
        //                 moneytype_code = (cashTypeValue == null) ? ItemdeptSlip.moneytype_code : cashTypeValue,
        //                 bank_code = ItemdeptSlip.bank_code,
        //                 bankbranch_code = ItemdeptSlip.bankbranch_code,
        //                 entry_id = full_name,
        //                 machine_id = machine_address,
        //                 // tofrom_accid = (toFromaccId2 == null) ? valuetoFromaccId : toFromaccId2,
        //                 tofrom_accid = (toFromaccId2 ?? valuetoFromaccId) ?? ItemdeptSlip.tofrom_accid,
        //                 operate_date = DateTime.Today,
        //                 entry_date = DateTime.Today,
        //                 calint_from = DateTime.Today,
        //                 operate_code = ItemdeptSlip.operate_code,
        //                 sign_flag = 1,
        //                 laststmseq_no = ItemdeptSlip.laststmseq_no,
        //                 nobook_flag = nobook_flag ?? 0,
        //                 prnc_no = ItemdeptSlip.prnc_no,
        //                 deptslip_amt = deptslipAmt,
        //                 // deptslip_amt = deptslipAmt ?? ItemdeptSlip.deptslip_amt,
        //                 deptslip_netamt = deptslipAmt,
        //                 fee_amt = ItemdeptSlip.fee_amt,
        //                 oth_amt = ItemdeptSlip.oth_amt,
        //                 prncbal = ItemdeptSlip.prncbal,
        //                 withdrawable_amt = ItemdeptSlip.withdrawable_amt,
        //                 prncbal_bf = ItemdeptSlip.prncbal_bf,
        //                 tax_amt = ItemdeptSlip.tax_amt,
        //                 int_amt = ItemdeptSlip.int_amt,
        //                 slipnetprncbal_amt = ItemdeptSlip.slipnetprncbal_amt,
        //                 posttovc_flag = ItemdeptSlip.posttovc_flag,
        //                 refer_slipno = ItemdeptSlip.refer_slipno,
        //                 deptaccount_name = ItemdeptSlip.deptaccount_name,
        //                 depttype_desc = ItemdeptSlip.depttype_desc,
        //                 dept_objective = ItemdeptSlip.dept_objective,
        //                 prncbal_retire = ItemdeptSlip.prncbal_retire,
        //                 remark = ItemdeptSlip.remark,
        //                 due_date = DateTime.Today,
        //                 deptpassbook_no = ItemdeptSlip.deptpassbook_no,
        //                 condforwithdraw = ItemdeptSlip.condforwithdraw,
        //                 upint_time = ItemdeptSlip.upint_time,
        //                 deptaccount_ename = ItemdeptSlip.deptaccount_ename,
        //                 account_type = ItemdeptSlip.account_type,
        //                 monthintpay_meth = ItemdeptSlip.monthintpay_meth,
        //                 traninttype_code = ItemdeptSlip.traninttype_code,
        //                 tran_deptacc_no = ItemdeptSlip.tran_deptacc_no,
        //                 dept_tranacc_name = ItemdeptSlip.dept_tranacc_name,
        //                 deptmonth_status = ItemdeptSlip.deptmonth_status,
        //                 deptmonth_amt = ItemdeptSlip.deptmonth_amt,
        //                 dept_status = ItemdeptSlip.dept_status,
        //                 monthint_status = ItemdeptSlip.monthint_status,
        //                 f_tax_rate = ItemdeptSlip.f_tax_rate,
        //                 adjdate_status = ItemdeptSlip.adjdate_status,
        //                 membcat_desc = ItemdeptSlip.membcat_desc,
        //                 reqappl_flag = ItemdeptSlip.reqappl_flag,
        //                 spcint_rate_status = ItemdeptSlip.spcint_rate_status,
        //                 spcint_rate = ItemdeptSlip.spcint_rate,
        //             };
        //             var DeptSlipdet = new DeptSlipdet
        //             {
        //                 // coop_id = (coop_id == null) ? ItemdeptSlipdet.coop_id : null,
        //                 // deptslip_no = (deptslip_no == null) ? ItemdeptSlipdet.deptslip_no : null,
        //                 // deptaccount_no = (deptaccount_no == null) ? ItemdeptSlipdet.deptaccount_no : null,
        //                 // prnc_no = (prnc_no == null) ? ItemdeptSlipdet.prnc_no : null,
        //                 // prnc_bal = (prnc_bal == null) ? ItemdeptSlipdet.prnc_bal : null,
        //                 // prnc_amt = (prnc_amt == null) ? ItemdeptSlipdet.prnc_amt : null,
        //                 // prnc_date = (prnc_date == null) ? ItemdeptSlipdet.prnc_date : null,
        //                 // calint_from = (calint_from == null) ? ItemdeptSlipdet.calint_from : null,
        //                 // calint_to = (calint_to == null) ? ItemdeptSlipdet.calint_to : null,
        //                 // prncdue_date = (prncdue_date == null) ? ItemdeptSlipdet.prncdue_date : null,
        //                 // prncmindue_date = (prncmindue_date == null) ? ItemdeptSlipdet.prncmindue_date : null,
        //                 // prncdue_nmonth = (prncdue_nmonth == null) ? ItemdeptSlipdet.prncdue_nmonth : null,
        //                 // prncslip_amt = (prncslip_amt == null) ? ItemdeptSlipdet.prncslip_amt : null,
        //                 // intarr_amt = (intarr_amt == null) ? ItemdeptSlipdet.intarr_amt : null,
        //                 // intpay_amt = (intpay_amt == null) ? ItemdeptSlipdet.intpay_amt : null,
        //                 // taxpay_amt = (taxpay_amt == null) ? ItemdeptSlipdet.taxpay_amt : null,
        //                 // intbf_accyear = (intbf_accyear == null) ? ItemdeptSlipdet.intbf_accyear : null,
        //                 // intcur_accyear = (intcur_accyear == null) ? ItemdeptSlipdet.intcur_accyear : null,
        //                 // monthintdue_date = (monthintdue_date == null) ? ItemdeptSlipdet.monthintdue_date : null,
        //                 // prncdeptdue_date = (prncdeptdue_date == null) ? ItemdeptSlipdet.prncdeptdue_date : null,
        //                 // interest_rate = (interest_rate == null) ? ItemdeptSlipdet.interest_rate : null,
        //                 // int_return = (int_return == null) ? ItemdeptSlipdet.int_return : null,
        //                 // tax_return = (tax_return == null) ? ItemdeptSlipdet.tax_return : null,
        //                 // fee_amt = (fee_amt == null) ? ItemdeptSlipdet.fee_amt : null,
        //                 // other_amt = (other_amt == null) ? ItemdeptSlipdet.other_amt : null,
        //                 // chequepend_amt = (chequepend_amt == null) ? ItemdeptSlipdet.chequepend_amt : null,
        //                 // refer_prnc_no = (refer_prnc_no == null) ? ItemdeptSlipdet.refer_prnc_no : null,
        //                 // upint_time = (upint_time == null) ? ItemdeptSlipdet.upint_time : null,
        //             };
        //             var DeptSlipCheque = new DeptSlipCheque();
        //             foreach (var rowsItem in rows)
        //             {
        //                 DeptSlipCheque = new DeptSlipCheque
        //                 {
        //                     coop_id = coop_id,
        //                     deptslip_no = deptslip_no,
        //                     deptaccount_no = deptaccount_no,
        //                     cheque_no = rowsItem.cheque_no,
        //                     bank_code = rowsItem.bank_code,
        //                     bankbranch_code = rowsItem.branch_id,
        //                     cheque_date = DateTime.Now,
        //                     entry_date = DateTime.Now,
        //                     entry_time = DateTime.Now,
        //                     chequedue_date = chequedue_date,
        //                     cheque_type = rowsItem.cheque_type,
        //                     cheque_amt = rowsItem.cheque_amt ?? 0,
        //                     seq_no = rowsItem.seq_no ?? 0,
        //                     checkclear_status = rowsItem.checkclear_status,
        //                     entry_id = "Admin_id",
        //                     depttype_code = ItemdeptSlip.depttype_code,
        //                 };
        //             };
        //             var deptDeposit = new Models.Deposit
        //             {
        //                 deptSlip = Deptslip,
        //                 deptSlipdet = null,
        //                 deptSlipCheque = (recpPayTypeCode == "DEN") ? DeptSlipCheque : null,

        //             };
        //             // var json = JsonConvert.SerializeObject(deptDeposit);
        //             // datadetailSave.AddRange(deptDeposit);
        //             // Console.WriteLine("JsonData:" + json);
        //             // var content = new StringContent(json, Encoding.UTF8, "application/json");
        //             // var response = await httpClient.PostAsync($"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostDeptSaving}", content);
        //             // var responseData = await response.Content.ReadAsStringAsync();
        //             // Console.WriteLine("JsonData:" + responseData);
        //             var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostWithSaving}";
        //             var response = await ApiProvider.SendApiRequestAsync(apiUrl, deptDeposit);
        //             var responseData = await response.Content.ReadAsStringAsync();


        //             if (response.IsSuccessStatusCode)
        //             {
        //                 // var responseData = await response.Content.ReadAsStringAsync();
        //                 var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

        //                 Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
        //                 var notificationDetail = apiResponse != null ? apiResponse.message : responseData;
        //                 Console.WriteLine($"{apiResponse.message}");
        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = notificationDetail, Duration = 2500 });
        //             }
        //             else
        //             {
        //                 Console.WriteLine(responseData);
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
                saveLoading = true;
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                // หาที่อยู่ IP ของเครื่อง
                string machine_address = GetMachineAddress();
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
                    // แสดงข้อมูลเพิ่มเติมตามที่ต้องการ

                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostDeptSaving}";
                    var response = await ApiProvider.SendApiRequestAsync(apiUrl, deptDeposit);
                    var responseData = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        // Console.WriteLine($"jsonResponse {jsonResponse}");
                        var Response = JsonConvert.DeserializeObject<SaveResponse>(responseData);
                        // var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);
                        Console.WriteLine($"Response.message {Response.message}");
                        success_status = true;
                        if (Response.success)
                        {
                            statement_data = new List<Models.Content> { Response.content };
                            // string deptslip_no;
                            foreach (var content in statement_data)
                            {
                                // Console.WriteLine($"deptslip_no: {content.slip_data}");
                                // var slipdata = JsonConvert.DeserializeObject<Slip_data>(content.slip_data.ToString());
                                var slipdatalist = content.slip_data;
                                // deptslip_no = content.deptslip_no;
                                var statementDetailsList = new List<Models.Statement_list>();
                                if (content.book_data != null)
                                {
                                    var printbookData = JsonConvert.DeserializeObject<Book_data>(content.book_data.ToString());
                                    if (printbookData != null)
                                    {
                                        foreach (var statement in printbookData.statement_list)
                                        {
                                            var deptaccountNo = statement.deptaccount_no.Replace(" ", "");
                                            Console.WriteLine($"deptaccount_noo :{deptaccountNo}");
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
                                    }
                                    statementDetails = statementDetailsList;
                                }
                            }
                            this.currentStep = 2;
                            await PrintPdf();
                            await PrintBook();
                            await CheckDeptslipAmt();
                            await InvokeAsync(() => StateHasChanged());
                            Console.WriteLine($"IsSuccessStatusCode: {response.IsSuccessStatusCode}");
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = Response.message, Duration = 2500 });
                        }
                        else
                        {
                            this.currentStep = 0;
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Response.message, Duration = 2500 });
                        }

                    }
                    else
                    {
                        HandleErrorResponse(responseData);
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = responseData, Duration = 2500 });
                        Console.WriteLine($"responseData {responseData}");
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
                // deptcoop_id = item.deptSlip.deptcoop_id,
                deptcoop_id = coop_id,
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

            // // Print JSON string to console
            Console.WriteLine(json);

            return deptSlip;
        }
        private List<DeptSlipdet> CreateDeptSlipdet(string coop_id, string name, string machine_address, Models.Deposit item)
        {
            var deptSlipdetList = new List<DeptSlipdet>();

            foreach (var deptSlipdetItem in item.deptSlipdet)
            {
                var deptSlipdet = new DeptSlipdet
                {
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
                    int_return = deptSlipdetItem.int_return,
                    tax_return = deptSlipdetItem.tax_return,
                    fee_amt = deptSlipdetItem.fee_amt,
                    other_amt = deptSlipdetItem.other_amt,
                    chequepend_amt = deptSlipdetItem.chequepend_amt,
                    refer_prnc_no = deptSlipdetItem.refer_prnc_no,
                    upint_time = deptSlipdetItem.upint_time
                };
                deptSlipdetList.Add(deptSlipdet);
            }

            return deptSlipdetList;
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

        string CH_B1000 { get; set; }
        string amount_1000 { get; set; }
        string CH_B500 { get; set; }
        string amount_500 { get; set; }
        string CH_B100 { get; set; }
        string amount_100 { get; set; }
        string CH_B50 { get; set; }
        string amount_50 { get; set; }
        string CH_B20 { get; set; }
        string amount_20 { get; set; }
        string CH_C10 { get; set; }
        string amount_10 { get; set; }
        string CH_C5 { get; set; }
        string amount_5 { get; set; }
        string CH_C2 { get; set; }
        string amount_2 { get; set; }
        string CH_C1 { get; set; }
        string amount_1 { get; set; }
        string CH_C50 { get; set; }
        string amount_050 { get; set; }
        string CH_C25 { get; set; }
        string amount_025 { get; set; }
        decimal adj_total { get; set; }
        decimal adj_amount { get; set; }
        decimal adj_amountt { get; set; }
        decimal AMOUNT_BALANCE { get; set; }

        decimal amount_1000T { get; set; }
        decimal amount_500T { get; set; }
        decimal amount_100T { get; set; }
        decimal amount_50T { get; set; }
        decimal amount_20T { get; set; }
        decimal amount_10T { get; set; }
        decimal amount_5T { get; set; }
        decimal amount_2T { get; set; }
        decimal amount_1T { get; set; }
        decimal amount_050T { get; set; }
        decimal amount_025T { get; set; }
        decimal AMOUNT_BALANCET { get; set; }
        string AMOUNT_BALANCEE { get; set; }
        private void OnBlurHandler()
        {
            FormatNumber();
            SplitMoney();
            MoneyDetail();
        }
        private void SplitMoney()
        {
            decimal amount = deptslipAmt;
            double amountt = Convert.ToDouble(amount);
            decimal[] per = { 1000, 500, 100, 50, 20, 10, 5, 2, 1, 0.5M, 0.25M };
            foreach (var item in per)
            {
                int count = (int)(amountt / (double)item);
                if (count > 0)
                {
                    if (item < 1)
                    {
                        if (item == 0.50m)
                        {
                            CH_C50 += count;
                        }
                        else if (item == 0.25m)
                        {
                            CH_C25 += count;
                        }
                    }
                    else
                    {
                        if (item == 1000)
                        {
                            CH_B1000 += count;
                        }
                        else if (item == 500)
                        {
                            CH_B500 += count;
                        }
                        else if (item == 100)
                        {
                            CH_B100 += count;
                        }
                        else if (item == 50)
                        {
                            CH_B50 += count;
                        }
                        else if (item == 20)
                        {
                            CH_B20 += count;
                        }
                        else if (item == 10)
                        {
                            CH_C10 += count;
                        }
                        else if (item == 5)
                        {
                            CH_C5 += count;
                        }
                        else if (item == 2)
                        {
                            CH_C2 += count;
                        }
                        else if (item == 1)
                        {
                            CH_C1 += count;
                        }
                    }

                    amountt %= (double)item;
                }
            }
        }

        private void MoneyDetail()
        {
            if (decimal.TryParse(CH_B1000, out decimal chB1000))
            {
                amount_1000T = chB1000 * 1000;
                amount_1000 = amount_1000T.ToString("N2");
            }
            if (decimal.TryParse(CH_B500, out decimal chB500))
            {
                amount_500T = chB500 * 500;
                amount_500 = amount_500T.ToString("N2");
            }
            if (decimal.TryParse(CH_B100, out decimal chB100))
            {
                amount_100T = chB100 * 100;
                amount_100 = amount_100T.ToString("N2");
            }
            if (decimal.TryParse(CH_B50, out decimal chB50))
            {
                amount_50T = chB50 * 50;
                amount_50 = amount_50T.ToString("N2");
            }
            if (decimal.TryParse(CH_B20, out decimal chB20))
            {
                amount_20T = chB20 * 20;
                amount_20 = amount_20T.ToString("N2");
            }
            if (decimal.TryParse(CH_C10, out decimal chC10))
            {
                amount_10T = chC10 * 10;
                amount_10 = amount_10T.ToString("N2");
            }
            if (decimal.TryParse(CH_C5, out decimal chC5))
            {
                amount_5T = chC5 * 5;
                amount_5 = amount_5T.ToString("N2");
            }
            if (decimal.TryParse(CH_C2, out decimal chC2))
            {
                amount_2T = chC2 * 2;
                amount_2 = amount_2T.ToString("N2");
            }
            if (decimal.TryParse(CH_C1, out decimal chC1))
            {
                amount_1T = chC1 * 1;
                amount_1 = amount_1T.ToString("N2");
            }
            if (decimal.TryParse(CH_C50, out decimal chC50))
            {
                amount_050T = chC50 * 0.50m;
                amount_050 = amount_050T.ToString("N2");
            }
            if (decimal.TryParse(CH_C25, out decimal chC25))
            {
                amount_025T = chC25 * 0.25m;
                amount_025 = amount_025T.ToString("N2");
            }
            AMOUNT_BALANCET = amount_1000T + amount_500T + amount_100T + amount_50T + amount_20T + amount_10T + amount_5T + amount_2T + amount_1T + amount_050T + amount_025T;
            if (AMOUNT_BALANCET == deptslipAmt)
            {
                decimal sumamount = deptslipAmt - AMOUNT_BALANCET;
                adj_amount = (sumamount - Math.Floor(sumamount));
                Console.WriteLine($"adj_amount: {adj_amount}");

                adj_total = Math.Truncate(sumamount);
                Console.WriteLine("AMOUNT_BALANCET == deptslipAmt");
            }
            else
            {
                decimal sumamount = deptslipAmt - AMOUNT_BALANCET;
                var adj_amountt = sumamount - Math.Floor(sumamount);
                // adj_amount = adj_amountt + Math.Floor(sumamount);
                // Console.WriteLine($"adj_amount: {adj_amount}");
                // adj_total = Math.Truncate(adj_amountt);
                if (sumamount % 1 == 0) // ถ้า sumamount เป็นจำนวนเต็ม
                {
                    adj_total = Math.Truncate(sumamount);
                    adj_amountt = sumamount - adj_total;
                }
                else
                {
                    adj_total = Math.Truncate(sumamount);
                    adj_amount = sumamount < 0 ? -adj_amountt : adj_amountt;
                }

                Console.WriteLine($"adj_total: {adj_total}");
                Console.WriteLine($"adj_amount: {adj_amount}");
                Console.WriteLine("AMOUNT_BALANCET != deptslipAmt");



            }
            // AMOUNT_BALANCET = amount_1000T + amount_500T + amount_100T + amount_50T + amount_20T + amount_10T + amount_5T + amount_2T + amount_1T + amount_050T + amount_025T;
            // decimal sumamount = deptslipAmt - AMOUNT_BALANCET;



            AMOUNT_BALANCE = deptslipAmt;
            AMOUNT_BALANCEE = AMOUNT_BALANCE.ToString("N2");
            Console.WriteLine($"AMOUNT_BALANCE: {AMOUNT_BALANCET}");
        }
        private void ClearInputValues()
        {
            CH_B1000 = "";
            amount_1000 = "";
            CH_B500 = "";
            amount_500 = "";
            CH_B100 = "";
            amount_100 = "";
            CH_B50 = "";
            amount_50 = "";
            CH_B20 = "";
            amount_20 = "";
            CH_C10 = "";
            amount_10 = "";
            CH_C5 = "";
            amount_5 = "";
            CH_C2 = "";
            amount_2 = "";
            CH_C1 = "";
            amount_1 = "";
            CH_C50 = "";
            amount_050 = "";
            CH_C25 = "";
            amount_025 = "";
            adj_total = 0;
            adj_amount = 0;
            adj_amountt = 0;
            AMOUNT_BALANCE = 0;
            StateHasChanged();
        }
    }
}