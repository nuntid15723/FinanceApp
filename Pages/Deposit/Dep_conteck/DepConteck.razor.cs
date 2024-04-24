using Newtonsoft.Json;
using FinanceApp.Models;
using System.Net;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Text;
using Newtonsoft.Json.Linq;
using Radzen;
using FinanceApp.Services;

using System.IO;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Headers;
using System.Globalization;
using Radzen.Blazor;


namespace FinanceApp.Pages.Deposit.Dep_conteck
{
    public partial class DepConteck
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        // [Inject]
        // public Api_Provider ApiProvider { get; set; }

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
        public string? bank { get; set; }
        public string? branch { get; set; }
        public string? due_date { get; set; }
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
        public string? dept_status { get; set; }
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

        private bool isLoading;
        private bool saveLoading;
        private bool slipLoading;
        private bool printLoading;
        bool isCurrentOptionSelected = false;
        private bool isUpdateExecuted = false;
        private bool isLoadingModals;

        /// <summary> 
        public string memcoop_id { get; set; }
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

        // public string? membcat_code { get; set; }

        public string? salary_id { get; set; }
        public string? fullgroup { get; set; }
        public List<GetBank>? getBank { get; set; }
        public List<BankBranch>? bankBranch { get; set; }
        private string BankBranchValues { get; set; }
        private string BankValues { get; set; }
        private int currentStep = 0;
        public string? SaveStatus { get; set; }
        public string? coop_control { get; set; }
        public string deptMaintype { get; set; }

        public string? deptaccount_No_fild { get; set; }
        public string? deptaccountNo_fild { get; set; }
        public string? deptaccount_name_fild { get; set; }
        public int deptclose_status { get; set; }

        int sequence = 1;
        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        private List<DataStatement> datadetails;
        public List<Statement>? dataStatementList { get; set; }
        public IEnumerable<Models.Statement> statementDetails { get; set; }
        private RadzenDataGrid<Models.Statement> grid;

        public List<GetDeptMaintype>? getDeptMaintype { get; set; }
        private List<AccountDetails> depOfGetAccDetails;
        public List<Print_book>? printbook_data { get; set; }
        public List<Print_detail>? printFrontbook_data { get; set; }

        private string LASTREC_NO_PB { get; set; }
        private string prnpbkto { get; set; }
        private string LASTPAGE_NO_PB { get; set; }
        private string LASTLINE_NO_PB { get; set; }
        private int PageSize = 10;
        private int? msg_seqno { get; set; }
        int select_printsum = 0;
        int totalPages = 0;
        private bool isChecked = false;

        private void ToggleCheckboxValue(ChangeEventArgs e)
        {
            isChecked = (bool)e.Value;
            select_printsum = isChecked ? 1 : 0;
            Console.WriteLine($"isChecked: {isChecked}");
            Console.WriteLine($"select_printsum: {select_printsum}");
        }
        // async Task GoToLastPage()
        // {
        //     int totalPages = (int)Math.Ceiling((double)statementDetails.Count() / PageSize); // Calculate the total pages
        //     int startIndex = (totalPages - 1) * PageSize;
        //     if (startIndex < statementDetails.Count())
        //     {
        //         statementDetails = statementDetails.Skip(startIndex).ToList();
        //         grid.CurrentPage = totalPages - 1;  // Go to the last page
        //         Console.WriteLine(totalPages);
        //         grid.PagerHorizontalAlign = HorizontalAlign.Left;
        //         grid.ShowPagingSummary = true;
        //         StateHasChanged();
        //     }
        //     StateHasChanged();
        // }

        private async Task GoToLastPage()
        {
            totalPages = (int)Math.Ceiling((double)statementDetails.Count() / PageSize); // Calculate the total pages
            // int startIndex = (totalPages - 1) * PageSize;
            int lastPageIndex = totalPages - 1;
            Console.WriteLine($"totalPages :{totalPages}");
            await grid.Reload();
            if (lastPageIndex >= 0)
            {
                // Update the grid's CurrentPage property เพื่อแสดงหน้าสุดท้าย
                grid.CurrentPage = lastPageIndex;

                // statementDetails = LoadAllData();

                // Notify Blazor that the state has changed and the UI needs to be updated
                StateHasChanged();
            }
        }
        public async Task PrintBook()
        {
            try
            {

                foreach (var Item in datadetails)
                {
                    foreach (var item in intibookdata)
                    {


                        var depOfGetAccount = new
                        {
                            deptaccount_no = Item.deptaccount_no,
                            lastrec_no = item.laststmseq_no,
                            laststmseq_no = item.lastrec_no,
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
                foreach (var Item in datadetails)
                {
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfPostFrontbook}?deptaccount_no={Item.deptaccount_no}";
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
            catch (System.Exception)
            {

                throw;
            }
        }
        private List<Book_data> intibookdata = new List<Book_data>();
        private async Task InitPrintBook()
        {
            try
            {
                foreach (var Item in datadetails)
                {
                    var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Print.DepOfGetInitPrintBook}?deptaccount_no={Item.deptaccount_no}";
                    var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                    {
                        // อ่าน response string
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<InitPrintBookResponse>(jsonResponse);
                        Console.WriteLine(apiResponse.success);
                        if (apiResponse.success)
                        {
                            intibookdata = new List<Book_data> { apiResponse.content };
                            foreach (var item in intibookdata)
                            {
                                var inti_list = item.statement_list;
                                foreach (var subItem in inti_list)
                                {
                                    Console.WriteLine(subItem.seq_no);
                                }
                            }
                            Console.WriteLine($"{apiResponse.message})");

                        }
                        else
                        {
                            ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = apiResponse.message, Duration = 5000 });
                        }
                    }
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public class InitPrintBookResponse
        {
            public bool success { get; set; }
            public Book_data content { get; set; }
            public string message { get; set; }
        }
        public class PrintBookResponse
        {
            public bool success { get; set; }
            public Print_book content { get; set; }
            public string message { get; set; }
        }
        public class PrintFrontBookResponse
        {
            public bool success { get; set; }
            public Print_detail content { get; set; }
            public string message { get; set; }
        }
        private string DepttypeValue;
        private string Valueselecte;
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
            coop_control = coopControl;
            return (coopControl, coop_id, name, email, actort, apvlevelId, workDate, application, save_status, checkFlag);
        }
        private async Task HandleEnterKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {

                // await PerformSearch();
            }

        }
        private async Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "F9")
            {
                currentStep = 1;
            }
        }
        private async Task GetBank()
        {
            try
            {
                var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{Paths.DepOfGetBank}?coop_control={coop_id}");
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
            try
            {
                var response = await httpClient.GetAsync($"{ApiClient.API.ApibaseUrl}{Paths.DepOfGetBankBranch}?coop_control={coop_id}&bank_code=006");
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
        private async Task DeptMaintype(ChangeEventArgs e)
        {
            deptMaintype = e.Value.ToString();
            if (deptMaintype == "null")
            {
                deptMaintype = null;
            }
            Console.WriteLine($"Depttype Code: {deptMaintype}");
        }
        private async Task DepttypeChanged(ChangeEventArgs e)
        {
            string[] values = e.Value.ToString().Split('|');
            DepttypeValue = e.Value.ToString();
            depttype_code = values[1];
            Console.WriteLine($"Recp Pay Type Code: {DepttypeValue},Depttype Code: {depttype_code}");
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
        // private async void UpdateAccountDetails(Models.AccountDetails data)
        // {
        //     try
        //     {
        //         isLoading = true;
        //         deptno_format = data.deptaccount_no?.Trim();
        //         Console.WriteLine($"Clicked on deptaccount_no: {data.deptaccount_no}");
        //         await JSRuntime.InvokeVoidAsync("alert", $"เลือก {data.deptaccount_no}, {data.deptaccount_name}");
        //         var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfDataStatement}={deptno_format}";
        //         var response = await SendApiRequestAsyncGet(apiUrl);
        //         response.EnsureSuccessStatusCode();
        //         var jsonRes = await response.Content.ReadAsStringAsync();
        //         var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
        //         if (response.IsSuccessStatusCode)
        //         {
        //             if (apiResponse.success)
        //             {
        //                 var content = apiResponse.content;
        //                 datadetails = new List<DataStatement> { apiResponse.content };
        //                 var statements = content.statement;

        //                 var dataStatementList = ProcessStatements(statements);
        //                 statementDetails = dataStatementList;
        //             }
        //             else
        //             {
        //                 ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = apiResponse.message, Duration = 5000 });
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"An error occurred: {ex.Message}");
        //     }
        //     finally
        //     {
        //         isLoading = false;
        //     }
        // }
        private async Task UpdateAccountDetails(Models.AccountDetails data)
        {
            try
            {
                isLoading = true;
                deptno_format = data.deptaccount_no?.Trim();
                Console.WriteLine($"Clicked on deptaccount_no: {data.deptaccount_no}");

                // Show notification instead of using JavaScript alert
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Info, Summary = "Success", Detail = $"เลือก {data.deptaccount_no}, {data.deptaccount_name}", Duration = 2000 });
                await JSRuntime.InvokeVoidAsync("alert", $"เลือก {data.deptaccount_no}, {data.deptaccount_name}");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfDataStatement}={deptno_format}";
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                response.EnsureSuccessStatusCode();
                var jsonRes = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
                if (response.IsSuccessStatusCode)
                {
                    if (apiResponse.success)
                    {
                        var content = apiResponse.content;
                        datadetails = new List<DataStatement> { apiResponse.content };
                        var statements = content.statement;

                        var dataStatementList = ProcessStatements(statements);
                        statementDetails = dataStatementList;
                    }
                    else
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = apiResponse.message, Duration = 5000 });
                    }
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }

        private bool table;
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
            try
            {
                isLoading = true;
                (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
                deptno_format = (deptno_format ?? deptaccount_no)?.Trim().Replace("-", "");
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.App.Deposit}{ApiClient.Paths.DepOfDataStatement}={deptno_format}";
                // var response = await SendApiRequestAsyncGet(apiUrl);
                var response = await ApiProvider.SendApiRequestAsyncGet(apiUrl);
                {
                    // อ่าน response string
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    Console.WriteLine(apiResponse.success);
                    if (apiResponse.success)
                    {
                        var content = apiResponse.content;
                        datadetails = new List<DataStatement> { apiResponse.content };
                        var statements = content.statement;

                        var dataStatementList = ProcessStatements(statements);
                        statementDetails = dataStatementList;
                        await GetDeptMaintype();
                    }
                    else
                    {
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = apiResponse.message, Duration = 5000 });
                    }
                    // if (dataStatementList != null)
                    // {
                    //     await GoToLastPage();
                    //     StateHasChanged();

                    // }
                }
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
                // Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                isLoading = false;
            }
            // }
        }
        private List<Statement> ProcessStatements(List<Statement> statements)
        {
            dataStatementList = new List<Statement>();
            foreach (var item in statements)
            {
                // DateTime operatedate = item.operate_date.GetValueOrDefault(DateTime.MinValue);
                // string operatedate_TH = operatedate.ToString("dd/MM/yyyy", new CultureInfo("th-TH"));
                // DateTime? operate_date_TH = null;
                // if (DateTime.TryParseExact(operatedate_TH, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                // {
                //     operate_date_TH = parsedDate;
                // }

                var statementDetails = new Statement
                {
                    number_no = sequence++,
                    coop_id = item.coop_id,
                    deptaccount_no = deptaccount_no,
                    seq_no = item.seq_no,
                    deptitemtype_code = item.deptitemtype_code + " - " + item.deptitemtype_desc,
                    operate_date = item.operate_date,
                    entry_date = item.entry_date,
                    prncbal = item.prncbal,
                    entry_id = item.entry_id,
                    item_status = item.item_status,
                    sign_flag = item.sign_flag,
                    print_code = item.print_code,
                    prnc_no = item.prnc_no,
                    tax_amt = item.tax_amt,
                    accuint_amt = item.accuint_amt,
                    int_amt = item.int_amt,
                    printbook_status = item.printbook_status,
                    deptslip_no = item.deptslip_no,
                    deptitem_amt = item.deptitem_amt,
                    deptint_amt = item.deptint_amt,
                    deposit_amt = item.deposit_amt,
                    withdraw_amt = item.withdraw_amt,
                };
                // Console.WriteLine($"coop_id: {item.coop_id}, deptaccount_no: {item.deptaccount_no}");
                dataStatementList.Add(statementDetails);
            }
            return dataStatementList;
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
        private async Task UpdatePrintBook(Statement data)
        {
            Console.WriteLine($"SEQ_NO :{data.seq_no}");
            msg_seqno = data.seq_no;
        }
        private async Task Clar()
        {
            msg_seqno = 0;
        }
        public async Task SaveDataAsync()
        {
            try
            {

                string hostName = Dns.GetHostName();
                var hostEntry = Dns.GetHostEntry(hostName);
                isLoading = true;
                foreach (var item in datadetails)
                {
                    // var ItemdeptSlip = item.deptSlip;
                    // var ItemdeptSlipdet = item.deptSlipdet;
                    // var ItemdeptSlipCheque = item.deptSlipCheque;
                    var DepReqdepoit = new DepReqdepoit
                    {
                        //coop_id = item.coop_id,
                        //deptcoop_id = item.deptcoop_id,
                        //deptslip_no = item.deptslip_no,
                        //member_no = item.member_no,
                        //deptno_format = item.deptno_format,
                        //deptaccount_no = item.deptaccount_no,
                        //membcat_code = item.membcat_code,
                        //depttype_code = item.depttype_code,
                        //deptgroup_code = item.deptgroup_code,
                        //recppaytype_code = item.recppaytype_code,
                        //moneytype_code = item.moneytype_code,
                        //bank_code = (BankValues == null) ? item.bank_code : BankValues,
                        //bankbranch_code = (BankBranchValues == null) ? item.bankbranch_code : BankBranchValues,
                        //entry_id = item.entry_id,
                        //machine_id = item.machine_id,
                        //tofrom_accid = item.tofrom_accid,
                        //operate_date = item.operate_date,
                        //entry_date = item.entry_date,
                        //calint_from = item.calint_from,
                        //sign_flag = item.sign_flag,
                        //laststmseq_no = item.laststmseq_no,
                        //nobook_flag = item.nobook_flag,
                        //prnc_no = item.prnc_no,
                        //deptslip_amt = item.deptslip_amt,
                        //deptslip_netamt = item.deptslip_netamt ?? 0,
                        //fee_amt = item.fee_amt ?? 0,
                        //oth_amt = item.oth_amt ?? 0,
                        //prncbal = item.prncbal ?? 0,
                        //withdrawable_amt = item.withdrawable_amt ?? 0,
                        //prncbal_bf = item.prncbal_bf,
                        //tax_amt = item.tax_amt ?? 0,
                        //int_amt = item.int_amt ?? 0,
                        //slipnetprncbal_amt = item.slipnetprncbal_amt ?? 0,
                        //posttovc_flag = item.posttovc_flag ?? 0,
                        //refer_slipno = item.refer_slipno,
                        //deptaccount_name = item.deptaccount_name,
                        //depttype_desc = item.depttype_desc,
                        //dept_objective = item.dept_objective,
                        //prncbal_retire = item.prncbal_retire ?? 0,
                        //remark = item.remark,
                        //bank = item.bank,
                        //branch = item.branch,
                        //due_date = item.due_date,
                        //deptpassbook_no = item.deptpassbook_no,
                        //condforwithdraw = item.condforwithdraw,
                        //passbook_flag = item.passbook_flag,
                        //upint_time = item.upint_time ?? 0,
                        //deptaccount_ename = item.deptaccount_ename,
                        //deptrequest_docno = item.deptrequest_docno,
                        //account_type = item.account_type,
                        //monthintpay_meth = item.monthintpay_meth ?? 0,
                        //traninttype_code = item.traninttype_code,
                        //tran_deptacc_no = item.tran_deptacc_no,
                        //dept_tranacc_name = item.dept_tranacc_name,
                        //deptmonth_status = item.deptmonth_status,
                        //deptmonth_amt = item.deptmonth_amt,
                        //dept_status = item.dept_status,
                        //monthint_status = item.monthint_status,
                        //f_tax_rate = item.f_tax_rate,
                        //adjdate_status = item.adjdate_status,
                        //membcat_desc = item.membcat_desc,
                        //reqappl_flag = item.reqappl_flag,
                        //spcint_rate_status = item.spcint_rate_status,
                        //spcint_rate = item.spcint_rate,
                    };
                    var json = JsonConvert.SerializeObject(DepReqdepoit);
                    // Console.WriteLine("JsonData:" + json);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{ApiClient.API.ApibaseUrl}DepOfPostDeptSaving", content);
                    var responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("JsonData:" + json);

                    if (response.IsSuccessStatusCode)
                    {
                        // var responseData = await response.Content.ReadAsStringAsync();
                        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseData);

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

        public class ApiResponse
        {
            public bool success { get; set; }
            public Models.DataStatement content { get; set; }
            public string message { get; set; }
        }

    }
}