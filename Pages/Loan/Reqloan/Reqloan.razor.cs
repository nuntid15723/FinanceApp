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

using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Newtonsoft.Json;


namespace FinanceApp.Pages.Loan.Reqloan
{
    public partial class Reqloan
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private int currentStep = 0;
        private DateTime operate_date;
        private DateTime working_date;
        private DateTime member_date;
        private DateTime retirement_date;
        private DateTime retire_date;
        private DateTime birthday;
        private DateTime deptaccount_no;
        private DateTime payment_date;
        private DateTime posted_date;

        private bool isLoading;
        private bool isLoadingModals;
        private string phone;
        public string? member_no { get; set; }
        public string? loanmember_no { get; set; }
        public string? loanno_format { get; set; }
        public string loanType { get; set; }
        public List<GetLoanType>? getLoanType { get; set; }

        // public List<GetOfLoanType>? getOfLoanType { get; set; }
        bool isCurrentOptionSelected = false;

        private string LoantypeValue;
        private string selectedValue;
        public string? loantype_code { get; set; }
        private string formattedDate;
        private void AnotherFunction()
        {
            // GetBank();
            // BankBranch();
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
            formattedDate = member_date.ToString("d", userCulture);
            formattedDate = retire_date.ToString("d", userCulture);
            Console.WriteLine("operate_date");
        }

        void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
        private async Task HandleEnterKeyPress(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await SearchOfGet();
            }
        }
        private async Task PerformSearch()
        {
            isLoading = true;

            AnotherFunction();

            if (string.IsNullOrEmpty(loanno_format ?? loanmember_no))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                //await CallApi();
            }

            isLoading = false;
        }

        private void OnChange(int newStep)
        {
            currentStep = newStep;
            Console.WriteLine(newStep); // This will print the current step
        }
        private bool CanChange()
        {
            Console.WriteLine($"return true;{true}");
            return true;
        }
        private async Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "F9")
            {
                currentStep = 1;
            }
        }
        //List<Datalist> Reqloan;
        private string searchTerm { get; set; }
        private IEnumerable<Reqloan>? filteredProducts;
        private List<Datalist> datalists;
        private List<Objectivetype> objectivetype ;
        private List<Moneytype> moneytype ;

        // private async Task getLoanType(ChangeEventArgs e)
        // {
        //     loanType = e.Value.ToString();
        //     if (loanType == "null")
        //     {
        //         loanType = null;
        //     }
        //     Console.WriteLine($"Depttype Code: {loanType}");
        // }

        // private async Task DepttypeChanged(ChangeEventArgs e)
        // {
        //     string[] values = e.Value.ToString().Split('|');
        //     LoantypeValue = values[0];
        //     selectedValue = values[1];
        //     // DepttypeValue = e.Value.ToString();
        //     loantype_code = LoantypeValue.Trim();
        //     Console.WriteLine($"selectedValue : {selectedValue},LoantypeValue:'{loantype_code}'");
        //     await GetLoanType();
        //     await InvokeAsync(() => StateHasChanged());
        // }

        //ดึงข้อมูลเลขสมุด
        // private async Task GetLoanType()
        // {
        //     try
        //     {
        //         (string coop_control, string coop_id, string name, string email, string actort, string apvlevelId, string workDate, string application, string save_status, string check_flag) = await GetDataList();
        //         string book_no;
        //         // if (repReqdepoit != null)
        //         // {
        //         foreach (var item in repReqdepoit)
        //         {
        //             if (depttype_code == null)
        //             {
        //                 depttype_code = item.depttype_code;
        //             }
        //             var depOfGetBookNo = new
        //             {
        //                 coop_id = coop_id,
        //                 depttype_code = depttype_code,
        //                 membcat_code = item.membcat_code,
        //             };
        //             Console.WriteLine(depOfGetBookNo);
        //             var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDeptPassbook}";
        //             var response = await ApiProvider.SendApiRequestAsync(apiUrl, depOfGetBookNo);
        //             response.EnsureSuccessStatusCode();
        //             Console.WriteLine(response.IsSuccessStatusCode);
        //             if (response.IsSuccessStatusCode)
        //             {
        //                 // อ่าน response string
        //                 var OfBookNoJson = await response.Content.ReadAsStringAsync();
        //                 var OfBookNoList = JsonConvert.DeserializeObject<List<GetOfBookNo>>(OfBookNoJson);
        //                 getOfBookNo = new List<GetOfBookNo>();
        //                 getOfBookNo.AddRange(OfBookNoList);
        //                 await InvokeAsync(() => StateHasChanged());

        //             }
        //             else
        //             {
        //                 getOfBookNo = new List<GetOfBookNo>();
        //             }
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = ex.Message, Duration = 5000 });
        //         Console.WriteLine(ex.Message.ToString());
        //         getOfBookNo = new List<GetOfBookNo>();
        //     }
        //     finally
        //     {
        //         isLoading = false;
        //     }

        // }

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
        
        //ค้นหาข้อมูลผู่ใช้
        private async Task SearchOfGet()
        {
            // กรองข้อมูลตามคำค้นหา
            Console.WriteLine(searchTerm);
            isLoading = true;

            AnotherFunction();

            if (string.IsNullOrEmpty(searchTerm))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }
            else
            {
                try
                {
                    var depOfGetAccount = new
                    {
                        coop_id = "931201",
                        member_no = "00000574",
                        loantype = "20",
                    };

                    // Console ดู
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    //Console.WriteLine(json);

                    //var apiUrl = $"https://localhost:7214/api/Loan/PostMemeber?coop_id=065001&member_no={searchTerm}&loantype=20";
                    //var apiUrl = $"https://localhost:7214/api/Loan/PostMemeber?coop_id=065001&member_no=00000574&loantype=20";
                    //var apiUrl = $"{ApiClient.API.LoanbaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
                    var apiUrl = $"{ApiClient.API.ApibaseUrl2}{ApiClient.App.Loan}{ApiClient.Paths.PostMemeber}?coop_id=065001&member_no={searchTerm}&loantype=20";
                    var response = await SendApiRequestAsyncGet(apiUrl);
                    Console.WriteLine(response.IsSuccessStatusCode);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    if(response.IsSuccessStatusCode){
                        Console.WriteLine(jsonResponse);
                    var apiResponse = JsonConvert.DeserializeObject<Datalist>(jsonResponse);
                    var readableJson = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);


                    datalists = new List<Datalist> { apiResponse };
                    await GetLoanobjective();
                    await GetMoneyType();
                    Console.WriteLine(value: $"API request failed: {datalists}");
                    foreach (var items in datalists)
                    {
                        Console.WriteLine(items.coop_id);
                    }
                    }else{
                        ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "เกิดข้อผิดพลาด", Duration = 1500 });
                    }
                    
                    
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"\nException Caught!");
                    Console.WriteLine($"Message :{e.Message}");
                }
            }
            isLoading = false;
        }

        //GetLoanobjective (วัตถุประสงค์การกู้)
        private async Task GetLoanobjective()
        {
            try
                {
                    var Loanobjective = new
                    {
                        moneytype_code = "",
                        moneytype_desc = ""
                    };
                    //Console ดู
                    var json = JsonConvert.SerializeObject(Loanobjective);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(json);

                    var apiUrl = $"{ApiClient.API.ApibaseUrl2}{ApiClient.App.Loan}{ApiClient.Paths.GetLoanobjective}?coop_id=065001&loantype=20";
                    var response = await SendApiRequestAsyncGet(apiUrl);
                    Console.WriteLine(response.IsSuccessStatusCode);
                    // var jsonResponse = await response.Content.ReadAsStringAsync();
                    // // Console.WriteLine(jsonResponse);
                    // var apiResponse = JsonConvert.DeserializeObject<Objectivetype>(jsonResponse);
                    // var readableJson = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                        var objectResponse = JsonConvert.DeserializeObject<List<Objectivetype>>(jsonResponse);
                        objectivetype = new List<Objectivetype>();
                        objectivetype.AddRange(objectResponse);
                        Console.WriteLine("==================================================");
                        Console.WriteLine("objectResponse"+objectResponse);


                    // objectivetype = new List<Objective> { apiResponse };
                    Console.WriteLine(value: $"API request failed: {objectResponse}");
                    // foreach (var items in objectivetype)
                    // {
                    //     Console.WriteLine(items.loanobjective_code);
                    // }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"\nException Caught!");
                    Console.WriteLine($"Message :{e.Message}");
                }
        }
        //GetMoneyType (จ่ายเงินกู้เป็น)
        private async Task GetMoneyType()
        {
            try
                {
                    var Loanmoney = new
                    {
                        moneytype_code = "",
                        moneytype_desc = ""
                    };
                    // Console ดู
                    var json = JsonConvert.SerializeObject(Loanmoney);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(json);

                    var apiUrl = $"{ApiClient.API.ApibaseUrl2}{ApiClient.App.Loan}{ApiClient.Paths.GetMoneyType}";
                    var response = await SendApiRequestAsyncGet(apiUrl);
                    Console.WriteLine(response.IsSuccessStatusCode);
                    // var jsonResponse = await response.Content.ReadAsStringAsync();
                    // // Console.WriteLine(jsonResponse);
                    // var apiResponse = JsonConvert.DeserializeObject<Objectivetype>(jsonResponse);
                    // var readableJson = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var moneyResponse = JsonConvert.DeserializeObject<List<Moneytype>>(jsonResponse);
                    moneytype = new List<Moneytype>();
                    moneytype.AddRange(moneyResponse);
                    Console.WriteLine("==================================================");
                    Console.WriteLine("moneyResponse"+moneyResponse);

                    // objectivetype = new List<Objective> { apiResponse };
                    Console.WriteLine(value: $"API request failed: {moneyResponse}");
                    // foreach (var items in objectivetype)
                    // {
                    //     Console.WriteLine(items.loanobjective_code);
                    // }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"\nException Caught!");
                    Console.WriteLine($"Message :{e.Message}");
                }
        }


        public class Receiptlist
        {
            public string? num { get; set; }
            public string? member_no { get; set; }
            public string? details { get; set; }
            public string? amount_money { get; set; }
            public string? loan_rights { get; set; }
            public string? deduct_internal { get; set; }
            public string? deduct_external { get; set; }
            public string? delete { get; set; }
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

        public class Response
        {

        }

        // public class Datalist
        // {
        //     public string? coop_id { get; set; }
        //     public string? member_no { get; set; }
        //     public string? member_name { get; set; }
        //     public int resign_status { get; set; }
        //     public int droploanall_flag { get; set; }
        //     public string? membtype_code { get; set; }
        //     public string? membtype_desc { get; set; }
        //     public string? membgroup_code { get; set; }
        //     public string? membgroup_desc { get; set; }
        //     public DateTime loanrequest_date { get; set; }
        //     public DateTime loanrcvfix_date { get; set; }
        //     public string? loantype_code { get; set; }
        //     public string? loanrequest_docno { get; set; }
        //     public DateTime birth_date { get; set; }
        //     public DateTime retire_date { get; set; }
        //     public DateTime member_date { get; set; }
        //     public DateTime work_date { get; set; }
        //     public DateTime tranmem_date { get; set; }
        //     public decimal? biath_ageshow { get; set; }
        //     public decimal? retire_ageshow { get; set; }
        //     public decimal? member_ageshow { get; set; }
        //     public decimal? work_ageshow { get; set; }
        //     public decimal? tranmem_ageshow { get; set; }
        //     public int share_periodvalue { get; set; }
        //     public int share_balance { get; set; }
        //     public int od_flag { get; set; }
        //     public int loancredit_amt { get; set; }
        //     public int loanpermiss_amt { get; set; }
        //     public int loanrequest_amt { get; set; }
        //     public int loanreqregis_amt { get; set; }
        //     public int period_payment { get; set; }
        //     public int period_payamt { get; set; }
        //     public int period_lastpayment { get; set; }
        //     public int loanpayment_type { get; set; }
        //     public int identifycont_intrate { get; set; }
        //     public int maxsend_payamt { get; set; }
        //     public int maxperiod_payamt { get; set; }
        //     public int apvimmediate_status { get; set; }
        //     public int totalday_int { get; set; }
        //     public string? loanobjective_code { get; set; }
        //     public string? loanobjective_desc { get; set; }
        //     public string? expense_code { get; set; }
        //     public string? expense_bank { get; set; }
        //     public string? expense_bankdesc { get; set; }
        //     public string? expense_branch { get; set; }
        //     public string? expense_branchdesc { get; set; }
        //     public string? expense_accid { get; set; }
        //     public int share_lastperiod { get; set; }
        //     public int salary_amount { get; set; }
        //     public int paymonth_coop { get; set; }
        //     public int paymonth_lnreq { get; set; }
        //     public int paymonth_exp { get; set; }
        //     public int paymonth_other { get; set; }
        //     public int incomemonth_fix { get; set; }
        //     public int incomemonth_other { get; set; }
        //     public int minsalary_perc { get; set; }
        //     public int minsalary_amt { get; set; }
        //     public int salary_perc { get; set; }
        //     public int salary_amt { get; set; }
        //     public int loanpayment_from { get; set; }
        //     public int int_continttype { get; set; }
        //     public int int_contintrate { get; set; }
        //     public string? int_continttabcode { get; set; }
        //     public int int_intsteptype { get; set; }
        //     public int kpshr_flag { get; set; }

        // }

        public class Moneytype{
            public string? moneytype_code { get; set; }
            public string? moneytype_desc { get; set; }
        }
        public class Money{
            public List<Moneytype> moneytype { get; set; }
        }
        public class Objectivetype{
            public string? loanobjective_code { get; set; }
            public string? loanobjective_desc { get; set; }
        }
        public class Objective{
            public List<Objectivetype> objectivetype { get; set; }
        }
        public class Datalist
        {
            public string? coop_id { get; set; }
            public string? member_no { get; set; }
            public string? fullname { get; set; }
            public string? resign_status { get; set; }
            public string? droploanall_flag { get; set; }
            public string? membtype_code { get; set; }
            public string? membtype_desc { get; set; }
            public string? membgroup_code { get; set; }
            public string? membgroup_desc { get; set; }
            public DateTime loanrequest_date { get; set; }
            public DateTime birth_date { get; set; }
            public string? biath_ageshow { get; set; }
            public DateTime member_date { get; set; }
            public string? member_ageshow { get; set; }
            public DateTime work_date { get; set; }
            public string? work_ageshow { get; set; }
            public DateTime retire_date { get; set; }
            public string? retire_ageshow { get; set; }
            public DateTime tranmem_date { get; set; }
            public string? tranmem_ageshow { get; set; }
            public int period_payamt { get; set; }
            public int apvimmediate_status { get; set; }
            public string? loanobjective_code { get; set; }
            public string? moneytype_code { get; set; }

        }

        private void search(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }



}

