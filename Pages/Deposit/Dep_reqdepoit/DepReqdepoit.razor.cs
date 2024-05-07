using Newtonsoft.Json;
using FinanceApp.Models;
using System.Net;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Text;
using Newtonsoft.Json.Linq;
using Radzen;
using System.IO;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Headers;
using System.Globalization;
using Radzen.Blazor;
using FinanceApp.Services;


namespace FinanceApp.Pages.Deposit.Dep_reqdepoit
{
    public partial class DepReqdepoit
    {

        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public Api_Provider ApiProvider { get; set; }

        public string? coop_id { get; set; }
        public int? reqappl_flag = 0;
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
        public DateTime? entry_date { get; set; }
        public string? operate_code { get; set; }
        public DateTime? calint_from { get; set; }
        public int? sign_flag { get; set; }
        public string? laststmseq_no { get; set; }
        public string? nobook_flag { get; set; }
        public string? prnc_no { get; set; }
        public decimal? deptslip_amt { get; set; }
        public decimal? deptslip_netamt { get; set; }
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
        public string? bank { get; set; }
        public string? branch { get; set; }
        public DateTime due_date { get; set; }
        public string? deptpassbook_no { get; set; }
        public string? condforwithdraw { get; set; }
        public string? passbook_flag { get; set; }
        public string? deptrequest_docno { get; set; }
        public int? upint_time { get; set; }
        public string? deptaccount_ename { get; set; }
        public string? account_type { get; set; }
        public int? monthintpay_meth { get; set; }
        public string? traninttype_code { get; set; }
        public string? tran_deptacc_no { get; set; }
        public string? dept_tranacc_name { get; set; }
        public int? deptmonth_status { get; set; }
        public string? deptmonth_amt { get; set; }
        public int? dept_status { get; set; } = 0;
        public int? monthint_status { get; set; }
        public int? f_tax_rate { get; set; }
        public int? adjdate_status { get; set; }
        public string? membcat_desc { get; set; }
        public string? spcint_rate_status { get; set; }
        public string? spcint_rate { get; set; }

        public List<Recppaytype> recppaytype { get; set; }
        public List<Depttype> depttype { get; set; }
        public List<Tofromacc> tofromacc { get; set; }
        public List<Acctype> acctype { get; set; }
        public List<TranDeptno> tranDeptno { get; set; }

        private bool isLoading;
        private bool saveLoading;
        private bool slipLoading;
        private bool printLoading;
        bool isCurrentOptionSelected = false;
        private bool isUpdateExecuted = false;
        private bool isLoadingModals;

        /// <summary> 
        public string? memcoop_id { get; set; }
        public string? member_No_fild { get; set; }
        public string? member_name { get; set; }
        public string? member_surname { get; set; }
        public string? memb_name { get; set; }
        public string? memb_surname { get; set; }
        public string? card_person { get; set; }
        public string? mem_telmobile { get; set; }
        public string? full_name { get; set; }
        public string? membgroup_code { get; set; }
        public string? membgroup_desc { get; set; }
        public string? deptitem_group { get; set; }
        public int? deptclose_status { get; set; }

        // public string? membcat_code { get; set; }
        public string? salary_id { get; set; }
        public string? fullgroup { get; set; }
        public string? SaveStatus { get; set; }
        public string? checkFlag { get; set; }
        public List<GetBank>? getBank { get; set; }
        public List<GetOfBookNo>? getOfBookNo { get; set; }
        public List<GetBookNo>? getBookNo { get; set; }
        public List<BankBranch>? bankBranch { get; set; }
        public List<Content>? statement_data { get; set; }
        public List<Book_data>? book_data { get; set; }
        public List<Slip_data>? slip_data { get; set; }
        public List<Statement_list>? statement_list { get; set; }
        public IEnumerable<Models.Statement_list> statementDetails { get; set; }
        public List<Print_book>? printbook_data { get; set; }
        public List<Row_detail>? rowdatadetail { get; set; }

        private string BankBranchValues { get; set; }
        private string BankValues { get; set; }
        private int currentStep = 0;

        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        public List<Models.DepReqdepoit> repReqdepoit;
        public List<DepReqdepoitDeails> depReqdepoitDeails;
        public List<DeptSlip> deptSlipOpe;
        private List<ReqAccDetails> depOfGetAccDetails;
        public List<Print_detail>? printFrontbook_data { get; set; }


        private string DepttypeValue;
        private string selectedValue;
        private string AcctypeValue;
        private string selectAcctype;
        private string TofromaccValue;
        private string selectTofromacc;

        private string recpPayTypeCode;
        private string selectRecpPayType;
        private bool success_status = false;
        // public string deptaccount_No { get; set; }
        public int lastrec_no { get; set; }
        // public int laststmseq_no { get; set; }
        public int lastpage_no { get; set; }
        public int lastline_no { get; set; }
        // private async Task PrintPdf()
        // {
        //     (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //     try
        //     {
        //         deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
        //         foreach (var item in repReqdepoit)
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
        //             var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);

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
        //ดึงข้อมูลผู้ใช้และเก็บไว้ใน Token
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
        // ดึงข้อมูลธนาคาร
        private async Task GetBank()
        {
            // ดึงข้อมูลผู้ใช้
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            try
            {
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetBank}?coop_control={coop_id}";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();

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
        // ดึงข้อมูลสาขาธนาคา
        private async Task BankBranch()
        {
            // ดึงข้อมูลผู้ใช้
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            try
            {
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
        private async Task RecpPayTypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            recpPayTypeCode = values[0];
            selectRecpPayType = values[0] + "-" + values[1];
            Console.WriteLine($" Recp Pay Type Code: {recpPayTypeCode}");
            // if (recpPayTypeCode == "DEN")
            // {
            //     GetBabk();
            //     BankBranch();
            // }
        }
        private async Task DepttypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            DepttypeValue = values[0];
            selectedValue = values[1];
            // DepttypeValue = e.Value.ToString();
            depttype_code = DepttypeValue.Trim();
            Console.WriteLine($"selectedValue : {selectedValue},DepttypeValue:'{depttype_code}'");
            await GetBookNo();
            await InvokeAsync(() => StateHasChanged());
        }
        private async Task AcctypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            AcctypeValue = values[0];
            selectAcctype = values[0] + "-" + values[1];
            account_type = AcctypeValue;
            DepttypeValue = e.Value.ToString();
            Console.WriteLine($"selectAcctype : {selectAcctype}");
        }
        private async Task TofromaccChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            TofromaccValue = values[0];
            selectTofromacc = values[0] + "-" + values[1];
            Console.WriteLine($" Recp Pay Type Code: {selectTofromacc}");
            // if (recpPayTypeCode == "DEN")
            // {
            //     GetBabk();
            //     BankBranch();
            // }
        }
        private void AnotherFunction()
        {
            GetBank();
            BankBranch();
            // GetBookNo();
            // FormatDate(operate_date);
            // FormatDate(due_date);
            FormatDate();
        }
        private void FormatDate()
        {
            // Get the current user's culture
            CultureInfo userCulture = CultureInfo.CurrentCulture;

            // Format the date using the user's culture
            formattedDate = operate_date.ToString("d", userCulture);
            Console.WriteLine("operate_date");
        }
        private string formattedDate;
        private string formattedOperateDate;
        private string formattedDueDate;
        private decimal deptslipAmt { get; set; }
        private string deptslipNetamt { get; set; }
        private string DeptslipAmt { get; set; }
        //รูปแบบเงิน format money
        private void FormatNumber()
        {
            if (decimal.TryParse(DeptslipAmt, out decimal result))
            {
                DeptslipAmt = result.ToString("N2");
                // นำค่าที่ได้มา round และกำหนดให้กับตัวแปร result
                result = Math.Round(result, 2);
                // นำค่าที่ได้มากำหนดให้กับตัวแปร deptslipAmt (หาก deptslipAmt เป็นตัวแปรที่ถูกประกาศแล้ว)
                deptslipAmt = result;
                // แสดงค่าใน Console
                Console.WriteLine(deptslipAmt);
            }
        }
        //ดึงข้อมูลจากที่เลือกใน Models หรือ dlg
        public async Task UpdateAccountDetails(Models.ReqAccDetails data)
        {


            try
            {
                isLoading = true;
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                AnotherFunction();
                member_no = data.member_no;
                Console.WriteLine($"Clicked on coop_id: {coop_id}");
                Console.WriteLine($"Clicked on member_no: {data.member_no}");
                await jsRuntime.InvokeVoidAsync("alert", $"เลือก {data.member_no}, {data.memb_name}  {data.memb_surname}");
                var depOfGetAccount = new ReqAccDetails
                {
                    coop_id = coop_id,
                    memcoop_id = coop_id,
                    deptaccount_no = deptaccount_no,
                    member_no = member_no,
                    depttype_code = depttype_code,
                    salary_id = salary_id,
                    deptclose_status = 0,
                    memb_name = memb_name,
                    memb_surname = memb_surname,
                    card_person = card_person,
                    mem_telmobile = mem_telmobile,
                    full_name = full_name,
                    membgroup_code = membgroup_code,
                    membgroup_desc = membgroup_desc,
                    entry_date = entry_date,
                    deptitem_group = deptitem_group,
                    reqappl_flag = reqappl_flag,
                };
                var json = JsonConvert.SerializeObject(depOfGetAccount);
                Console.WriteLine(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitOpenAccount}";
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response.IsSuccessStatusCode);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                if (apiResponse.success == true)
                {
                    repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.content };

                    await InvokeAsync(() => StateHasChanged());
                    await GetBookNo();
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

        private async Task Search()
        {
            AnotherFunction();
            if (member_no == null || member_no == "")
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                try
                {
                    isLoading = true;
                    var depOfGetAccount = new ReqAccDetails
                    {
                        coop_id = coop_id,
                        memcoop_id = coop_id,
                        deptaccount_no = deptaccount_no,
                        member_no = member_no,
                        depttype_code = depttype_code,
                        salary_id = salary_id,
                        deptclose_status = 0,
                        memb_name = memb_name,
                        memb_surname = memb_surname,
                        card_person = card_person,
                        mem_telmobile = mem_telmobile,
                        full_name = full_name,
                        membgroup_code = membgroup_code,
                        membgroup_desc = membgroup_desc,
                        entry_date = DateTime.Today,
                        deptitem_group = deptitem_group,
                        reqappl_flag = reqappl_flag,
                        membcat_code = "10"
                    };
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    Console.WriteLine(json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitOpenAccount}";
                    var response = await httpClient.PostAsync(apiUrl, content);

                    Console.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        // อ่าน response string
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                        Console.WriteLine(apiResponse.success == true);
                        if (apiResponse.success == true)
                        {
                            repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.content };
                            Console.WriteLine($"API request failed: {repReqdepoit}");
                        }
                        else
                        {

                            var Error = JsonConvert.SerializeObject(apiResponse.message);
                            // Console.WriteLine(Error);
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Error, Duration = 5000 });
                        }
                    }
                }
                // var repReqdepoitDetails = new List<Models.DepReqdepoit>();

                catch (Exception ex)
                {
                    ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                    Console.WriteLine(ex.Message.ToString());
                    isLoading = false;
                }
                finally
                {
                    isLoading = false;
                }
            }
        }


        //ดึงข้อมูลใน models หรือ dlg
        private async Task SearchOfGetAcc()
        {
            isLoadingModals = true;
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            var depOfGetAccount = new ReqAccDetails
            {
                coop_id = coop_id,
                memcoop_id = coop_id,
                deptaccount_no = null,
                deptaccount_name = null,
                member_no = member_No_fild,
                depttype_code = null,
                deptclose_status = 0,
                memb_name = null,
                memb_surname = null,
                card_person = null,
                mem_telmobile = null,
                full_name = null,
                salary_id = null,
                membgroup_code = null,
                membgroup_desc = null,
                entry_date = null,
                deptitem_group = null,
                reqappl_flag = 0,
                membcat_code = null
            };
            var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfGetMemberOpenAccount}";
            try
            {
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jsonResponse1 = JObject.Parse(jsonResponse);
                    depOfGetAccDetails = jsonResponse1["content"].ToObject<List<ReqAccDetails>>();
                }
                var accountDetailsList = new List<Models.ReqAccDetails>();
                if (depOfGetAccDetails != null)
                {
                    foreach (var accDetails in depOfGetAccDetails)
                    {
                        var accountDetails = new Models.ReqAccDetails
                        {
                            coop_id = accDetails.coop_id,
                            memcoop_id = accDetails.memcoop_id,
                            deptaccount_no = accDetails.deptaccount_no,
                            deptaccount_name = accDetails.deptaccount_name,
                            member_no = accDetails.member_no,
                            depttype_code = accDetails.depttype_code,
                            deptclose_status = accDetails.deptclose_status,
                            memb_name = accDetails.memb_name,
                            memb_surname = accDetails.memb_surname,
                            card_person = accDetails.card_person,
                            mem_telmobile = accDetails.mem_telmobile,
                            full_name = accDetails.full_name,
                            salary_id = accDetails.salary_id,
                            membgroup_code = accDetails.membgroup_code,
                            membgroup_desc = accDetails.membgroup_desc,
                            entry_date = DateTime.Today,
                            deptitem_group = accDetails.deptitem_group,
                            reqappl_flag = accDetails.reqappl_flag,
                            membcat_code = accDetails.membcat_code,
                            membcat_desc = accDetails.membcat_desc

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
        //ส่งข้อมูลพร้อม Token Post Method
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
                    Console.WriteLine($"json content :{json},{content}");
                    return await httpClient.PostAsync(apiUrl, content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        //ส่งข้อมูลพร้อม Token Get Method
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

        private async Task HandleEnterKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await PerformSearch();
            }
        }
        private async Task PerformSearch()
        {
            isLoading = true;

            AnotherFunction();

            if (string.IsNullOrEmpty(member_no))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                await CallApi();
                await GetBookNo();
            }

            isLoading = false;
        }
        //ดึงข้อมูลเปิดบัญชี
        private async Task CallApi()
        {
            (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
            try
            {
                var depOfGetAccount = new ReqAccDetails
                {
                    coop_id = coop_control,
                    memcoop_id = coop_control,
                    deptaccount_no = deptaccount_no,
                    member_no = member_no,
                    depttype_code = depttype_code,
                    salary_id = salary_id,
                    deptclose_status = 0,
                    memb_name = memb_name,
                    memb_surname = memb_surname,
                    card_person = card_person,
                    mem_telmobile = mem_telmobile,
                    full_name = full_name,
                    membgroup_code = membgroup_code,
                    membgroup_desc = membgroup_desc,
                    entry_date = DateTime.Today,
                    deptitem_group = deptitem_group,
                    reqappl_flag = reqappl_flag,
                    membcat_code = "10"
                };
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitOpenAccount}";
                var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetAccount);
                Console.WriteLine($"IsSuccessStatusCode {response.IsSuccessStatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    // Console.WriteLine($"jsonResponse:{apiResponse.message}");
                    // Console.WriteLine($"apiResponse.status {apiResponse.status}");
                    // repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.data };
                    // Console.WriteLine("API request failed. Data received: " + JsonConvert.SerializeObject(repReqdepoit));
                    if (apiResponse.success)
                    {
                        repReqdepoit = new List<Models.DepReqdepoit> { apiResponse.content };
                        Console.WriteLine($"API request failed: {repReqdepoit}");
                    }
                    else
                    {
                        var error = JsonConvert.SerializeObject(apiResponse.message);
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = error, Duration = 5000 });

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
        //ดึงข้อมูลเลขสมุด
        private async Task GetBookNo()
        {
            try
            {
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                string book_no;
                // if (repReqdepoit != null)
                // {
                foreach (var item in repReqdepoit)
                {
                    if (depttype_code == null)
                    {
                        depttype_code = item.depttype_code;
                    }
                    var depOfGetBookNo = new
                    {
                        coop_id = coop_id,
                        depttype_code = depttype_code,
                        membcat_code = item.membcat_code,
                    };
                    Console.WriteLine(depOfGetBookNo);
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDeptPassbook}";
                    var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetBookNo);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.IsSuccessStatusCode);
                    if (response.IsSuccessStatusCode)
                    {
                        // อ่าน response string
                        var OfBookNoJson = await response.Content.ReadAsStringAsync();
                        var OfBookNoList = JsonConvert.DeserializeObject<List<GetOfBookNo>>(OfBookNoJson);
                        getOfBookNo = new List<GetOfBookNo>();
                        getOfBookNo.AddRange(OfBookNoList);
                        await InvokeAsync(() => StateHasChanged());

                    }
                    else
                    {
                        getOfBookNo = new List<GetOfBookNo>();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine(ex.Message.ToString());
                getOfBookNo = new List<GetOfBookNo>();
            }
            finally
            {
                isLoading = false;
            }

        }
        private int type_monthintpay;
        //เรียกใช้ฟังก์ชันบันทึกข้อมูล
        private async Task BookNo(ChangeEventArgs e)
        {
            var type_Value = e.Value.ToString();
            type_monthintpay = int.Parse(type_Value);
            Console.WriteLine($"type_monthintpay: {type_monthintpay}");
            if (type_monthintpay == 1)
            {
                await GetBookNo();
                // foreach (var item in getOfBookNo)
                // {
                //     Console.WriteLine($"book_no: {item.book_no}");
                // }
            }
        }
        //เรียกใช้ฟังก์ชันบันทึกข้อมูล
        public async Task SaveDataAsync()
        {
            try
            {
                saveLoading = true;
                // ดึงข้อมูลผู้ใช้
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                // หาที่อยู่ IP ของเครื่อง
                string machine_address = GetMachineAddress();
                string hostName = Dns.GetHostName();
                var hostEntry = Dns.GetHostEntry(hostName);
                int MonthintpayMeth = type_monthintpay;
                Console.WriteLine("dept_status : " + dept_status);
                isLoading = true;
                foreach (var item in repReqdepoit)
                {
                    var SlipOpen = item.deptSlip;
                    var ItemdeptSlipdet = item.deptSlipdet;
                    var ItemdeptSlipCheque = item.deptSlipCheque;
                    var DeptSlip = new DeptSlip
                    {
                        coop_id = coop_id,
                        deptcoop_id = coop_id,
                        deptslip_no = item.deptslip_no,
                        member_no = item.member_no,
                        depttype_code = DepttypeValue ?? item.depttype_code,
                        membcat_code = item.membcat_code,
                        deptgroup_code = item.deptgroup_code,
                        recppaytype_code = recpPayTypeCode ?? item.recppaytype_code,
                        deptno_format = item.deptno_format ?? "null",
                        deptaccount_no = item.deptaccount_no ?? "null",

                        moneytype_code = item.moneytype_code,
                        bank_code = item.bank_code,
                        bankbranch_code = item.bankbranch_code,
                        entry_id = name,
                        machine_id = machine_id,
                        tofrom_accid = TofromaccValue ?? item.tofrom_accid,
                        operate_date = DateTime.Today,
                        entry_date = DateTime.Today,
                        operate_code = item.operate_code,
                        sign_flag = 1,

                        nobook_flag = item.nobook_flag,
                        deptslip_amt = deptslipAmt,
                        deptslip_netamt = deptslipAmt,
                        fee_amt = item.fee_amt,
                        oth_amt = item.oth_amt,
                        deptaccount_name = item.deptaccount_name,
                        depttype_desc = DepttypeValue ?? item.depttype_desc,
                        dept_objective = item.dept_objective,
                        prncbal_retire = item.prncbal_retire,
                        remark = item.remark,

                        deptpassbook_no = deptpassbook_no,
                        condforwithdraw = item.condforwithdraw,
                        upint_time = item.upint_time,
                        deptaccount_ename = item.deptaccount_ename,
                        account_type = item.account_type,
                        monthintpay_meth = (type_monthintpay != null) ? type_monthintpay : item.monthintpay_meth,
                        traninttype_code = item.traninttype_code,
                        tran_deptacc_no = item.tran_deptacc_no,
                        dept_tranacc_name = item.dept_tranacc_name,
                        deptmonth_status = item.deptmonth_status,

                        deptmonth_amt = item.deptmonth_amt,
                        dept_status = item.dept_status,
                        monthint_status = item.monthint_status,
                        f_tax_rate = item.f_tax_rate,
                        adjdate_status = item.adjdate_status,
                        membcat_desc = item.membcat_desc,

                        prncbal = item.prncbal,
                        withdrawable_amt = item.withdrawable_amt,
                        tax_amt = item.tax_amt,
                        int_amt = item.int_amt,
                        slipnetprncbal_amt = item.slipnetprncbal_amt,
                        prnc_no = item.prnc_no,


                        calint_from = DateTime.Today,
                        laststmseq_no = item.laststmseq_no,
                        prncbal_bf = item.prncbal_bf,
                        posttovc_flag = item.posttovc_flag,
                        refer_slipno = item.refer_slipno,
                        due_date = item.due_date,
                        passbook_flag = item.passbook_flag,
                        deptrequest_docno = item.deptrequest_docno,
                        reqappl_flag = item.reqappl_flag,
                        spcint_rate_status = item.spcint_rate_status,
                        spcint_rate = item.spcint_rate



                    };
                    var DeptSlipdet = new DeptSlipdet();
                    var DeptSlipCheque = new DeptSlipCheque();
                    var Reqdepoit = new Models.DepReqdepoit
                    {
                        deptSlip = DeptSlip,
                        deptSlipdet = null,
                        deptSlipCheque = null,

                    };
                    var json = JsonConvert.SerializeObject(Reqdepoit);
                    Console.WriteLine("JsonData:" + json);
                    // var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // var response = await httpClient.PostAsync($"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostOpenAccount}", content);
                    // var responseData = await response.Content.ReadAsStringAsync();
                    // Console.WriteLine("JsonData:" + responseData);
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfPostOpenAccount}";
                    var response = await ApiProvider.SendApiRequestAsync(apiUrl, Reqdepoit);
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var Response = JsonConvert.DeserializeObject<SaveResponse>(responseData);
                    if (response.IsSuccessStatusCode)
                    {
                        if (response.IsSuccessStatusCode)
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
                                            DateTime operatedate = statement.operate_date.GetValueOrDefault(DateTime.MinValue);
                                            string operatedate_TH = operatedate.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
                                            DateTime? operate_datee_TH = null;
                                            if (DateTime.TryParseExact(operatedate_TH, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                            {
                                                operate_datee_TH = parsedDate;
                                            }
                                            Console.WriteLine($"deptaccount_noo :{deptaccountNo}");
                                            var statementDetails = new Models.Statement_list
                                            {
                                                coop_id = statement.coop_id,
                                                deptaccount_no = deptaccountNo,
                                                seq_no = statement.seq_no,
                                                deptitemtype_code = statement.deptitemtype_code,
                                                operate_date = operate_datee_TH,
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
                            Console.WriteLine($"Response.message {Response.message}");
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = Response.message, Duration = 2500 });
                            success_status = true;
                            if (Response.success)
                            {
                                currentStep = 2;
                                await PrintPdf();
                                StateHasChanged();
                            }
                        }
                    }
                    else
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = Response.message + "ตรวจสอบข้อมูลให้ครบถ้วน", Duration = 2500 });
                    }
                }
            }
            catch (Exception ex)
            {
                success_status = true;
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 2500 });
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                isLoading = false;
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
                        Console.WriteLine($"jsonResponse:{jsonResponse}");

                        var responseData = JsonConvert.DeserializeObject<PrintBookResponse>(jsonResponse);
                        Console.WriteLine("------------------------------");

                        if (responseData.success)
                        {
                            Console.WriteLine("------------------------------");
                            printbook_data = new List<Print_book> { responseData.content };
                            var printbookdata = responseData.content;
                            var printdetail = printbookdata.print_detail;
                            foreach (var items in printdetail)
                            {
                                var rowdetail = items.row_detail;
                                foreach (var itemsl in rowdetail)
                                {
                                    Console.WriteLine($"print_detail :{itemsl.column_name}");
                                }
                            }
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

        private async Task Print_Frontbook()
        {
            try
            {
                foreach (var statement in statement_data)
                {
                    if (statement.book_data != null)
                    {
                        var printbookData = JsonConvert.DeserializeObject<Book_data>(statement.book_data.ToString());
                        if (printbookData != null)
                        {
                            foreach (var Item in printbookData.statement_list)
                            {

                                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfGetFrontbook}?deptaccount_no={Item.deptaccount_no}";
                                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                                {
                                    // อ่าน response string
                                    var jsonResponse = await response.Content.ReadAsStringAsync();
                                    var apiResponse = JsonConvert.DeserializeObject<PrintFrontBookResponse>(jsonResponse);
                                    Console.WriteLine(apiResponse.success);
                                    if (apiResponse.success)
                                    {
                                        printFrontbook_data = new List<Print_detail> { apiResponse.content };
                                        foreach (var item in printFrontbook_data)
                                        {

                                            var row_detaill = item.result_data;
                                            foreach (var item_row in row_detaill)
                                            {
                                                Console.WriteLine($"row_detaill:{item_row.column_name}");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = apiResponse.message, Duration = 5000 });
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
            }
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

        public class ApiResponse
        {
            public bool success { get; set; }
            public Models.DepReqdepoit content { get; set; }
            public string message { get; set; }
        }
        public class PrintFrontBookResponse
        {
            public bool success { get; set; }
            public Print_detail content { get; set; }
            public string message { get; set; }
        }
        public class PrintBookResponse
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
    }
}