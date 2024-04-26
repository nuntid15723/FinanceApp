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
        private DateTime birthday;
        private DateTime deptaccount_no;
        private DateTime payment_date;
        private DateTime posted_date;

        private bool isLoading;
        private bool isLoadingModals;
        private string phone;
        public string? member_no { get; set; }

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

            //AnotherFunction();

            if (string.IsNullOrEmpty(member_no))
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

        private async Task SearchOfGet()
        {
            // กรองข้อมูลตามคำค้นหา
            Console.WriteLine(searchTerm);
            isLoading = true;

            //AnotherFunction();

            if (string.IsNullOrEmpty(searchTerm))
            {
                ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            }else{
                try
                {
                    var depOfGetAccount = new
                    {
                        coop_id = "931201",
                        member_no = "01708114",
                        loantype = "20",
                    };

                    // Console ดู
                    var json = JsonConvert.SerializeObject(depOfGetAccount);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine(json);
                    
                    //var apiUrl = $"https://localhost:7214/api/Loan/PostMemeber?coop_id=065001&member_no={searchTerm}&loantype=20";
                    //var apiUrl = $"https://localhost:7214/api/Loan/PostMemeber?coop_id=065001&member_no=00000574&loantype=20";
                    //var apiUrl = $"{ApiClient.API.LoanbaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
                    var apiUrl = $"{ApiClient.API.ApibaseUrl2}{ApiClient.App.Loan}{ApiClient.Paths.PostMemeber}";
                    var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<Datalist>(jsonResponse);
                    var readableJson = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                    Console.WriteLine(readableJson);

                    datalists = new List<Datalist> { apiResponse };
                    Console.WriteLine(value: $"API request failed: {datalists}");
                    foreach (var items in datalists)
                    {
                        Console.WriteLine(items.coop_id);
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

        }

        private void search(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }



}

