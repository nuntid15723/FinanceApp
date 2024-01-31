using System.Net;
using FinanceApp.Services;
using Newtonsoft.Json;
using FinanceApp.Models;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Text;

namespace FinanceApp.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        private List<GroupPermission> GetContent { get; set; }
        private List<AmsecUseapp> amsecUseappss;
        // void HandleItemClick(string application, string applicationName)
        // {
        //     // ทำอะไรกับค่า application ที่คุณได้รับ
        //     // ตัวอย่าง: ส่งค่าไปยัง C# method
        //     StateHasChanged();

        //     HandleApplicationClick(application, applicationName);

        // }
        // async Task HandleApplicationClick(string application ,string applicationName)
        // {
        //     await JSRuntime.InvokeVoidAsync("localStorage.setItem", "application", application);
        //     await JSRuntime.InvokeVoidAsync("localStorage.setItem", "applicationName", applicationName);
        //     string applicationValue = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "application");
        //     string applicationNames = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "applicationName");
        //     Console.WriteLine($"application :{applicationValue}");
        //     Console.WriteLine($"applicationNames :{applicationNames}");
        //     StateHasChanged();
        // }
        async Task HandleItemClick(string application, string applicationName)
        {
            // ทำอะไรกับค่า application ที่คุณได้รับ
            // ตัวอย่าง: ส่งค่าไปยัง C# method

            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "application", application);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "applicationName", applicationName);

            string applicationValue = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "application");
            string applicationNames = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "applicationName");

            Console.WriteLine($"application :{applicationValue}");
            Console.WriteLine($"applicationNames :{applicationNames}");

            StateHasChanged();

        }
        public async Task<(string coopControl, string userName, string fullName, string application)> GetUserData()
        {
            string coopControl = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "coopControl");
            string userName = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user_name");
            string fullName = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "fullName");
            string application = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "application");

            // Console.WriteLine($"coopControl: {coopControl}, userName: {userName}, fullName: {fullName}, application: {application}");

            return (coopControl, userName, fullName, application);
        }
        private async Task PagePermiss()
        {
            (string coop_id, string user_name, string full_name, string application) = await GetUserData();
            var depOfGetAccount = new
            {
                coop_control = coop_id,
                coop_id = coop_id,
                application = application,
                user_name = user_name,
            };
            var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.UseOfAuthPagePermiss}";
            try
            {
                var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);
                // Console.WriteLine($"depOfGetAccount :{response}");

                Console.WriteLine($"IsSuccessStatusCode :{response.IsSuccessStatusCode}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    // อัพเดท GetContent ด้วยข้อมูลใหม่ที่ได้จาก API
                    GetContent = responseData.Content;
                    // อัพเดท ContentList ด้วยข้อมูลใหม่
                    var ContentList = new List<WindowPermission>();
                    StateHasChanged();
                    foreach (var groupPermission in GetContent)
                    {
                        foreach (var windowPermission in groupPermission.Children)
                        {
                            // เพิ่ม PageDetails เข้าไปใน ContentList
                            ContentList.Add(windowPermission);
                        }
                    }
                    var winObject = ContentList.Select(x => x.win_object).ToList();
                    var windowIdData = new WindowIdData { winObject = winObject };
                    var json = JsonConvert.SerializeObject(windowIdData);
                    // Console.WriteLine($"json :{json}");
                    await JSRuntime.InvokeVoidAsync("localStorage.setItem", "winObject", json);
                    await JSRuntime.InvokeVoidAsync("localStorage.setItem", "application", application);

                }
                else
                {
                    await JSRuntime.InvokeVoidAsync("alert", "เกิดข้อผิดพลาด. โปรด login อีกครั้ง.");
                    await JSRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
                    // ถ้าไม่มี token ให้เด้งไปยังหน้า login
                    NavigationManager.NavigateTo("/login", true);
                    var errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error response: {errorResponse}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public class WindowIdData
        {
            public List<string> winObject { get; set; }
        }
        // private async Task<HttpResponseMessage> SendApiRequestAsync<T>(string apiUrl, T payload)
        // {
        //     try
        //     {
        //         string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

        //         using (var httpClient = new HttpClient())
        //         {
        //             httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        //             var json = JsonConvert.SerializeObject(payload);
        //             Console.WriteLine($"payload content :{json}");

        //             var content = new StringContent(json, Encoding.UTF8, "application/json");
        //             Console.WriteLine($"bearerToken :{httpClient.DefaultRequestHeaders.Authorization}");
        //             Console.WriteLine($"json content :{json},{content}");
        //             return await httpClient.PostAsync(apiUrl, content);
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Error: {ex.Message}");
        //         throw;
        //     }

        // }
        private async Task<HttpResponseMessage> SendApiRequestAsync<T>(string apiUrl, T payload)
        {
            try
            {
                string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    var json = JsonConvert.SerializeObject(payload);
                    Console.WriteLine($"Bearer Token: {httpClient.DefaultRequestHeaders.Authorization}");

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Console.WriteLine($"JSON Content: {json}");

                    return await httpClient.PostAsync(apiUrl, content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        private async Task LoadAmsecUseappssFromLocalStorage()
        {
            var jsons = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "amsecUseappss");
            // Console.WriteLine($"amsecUseappss JSON:{jsons}");
            amsecUseappss = JsonConvert.DeserializeObject<List<AmsecUseapp>>(jsons);

            // Check if the deserialization was successful
            if (amsecUseappss != null)
            {
                // Log the entire list to the console
                Console.WriteLine("amsecUseappss List:");

                foreach (var item in amsecUseappss)
                {
                    // Console.WriteLine($"coop_control: {item.coop_control}, coop_id: {item.coop_id}, application: {item.application}, user_name: {item.user_name}, application_name: {item.application_name}, permiss_flag: {item.permiss_flag}");
                }
            }
            else
            {
                // ทำการ redirect ไปที่ "/login"
                NavigationManager.NavigateTo("/login", true);
            }
        }
        public class AmsecUseapp
        {
            public string coop_control { get; set; }
            public string coop_id { get; set; }
            public string user_name { get; set; }
            public string application { get; set; }
            public string application_name { get; set; }
            public bool permiss_flag { get; set; }
        }

        public class ApiResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public List<GroupPermission> Content { get; set; }
        }

        public class WindowPermission
        {
            public string? coop_control { get; set; }
            public string? coop_id { get; set; }
            public string? application { get; set; }
            public string? window_id { get; set; }
            public string? user_name { get; set; }
            public string? win_object { get; set; }
            public string? icon_name { get; set; }
            public string? win_description { get; set; }
            public int check_flag { get; set; }
            public int save_status { get; set; }
            public bool isSuccess { get; set; }
            public string message { get; set; }
        }

        public class GroupPermission
        {
            public string? GroupCode { get; set; }
            public string? GroupDesc { get; set; }
            public string? IconName { get; set; }
            public List<WindowPermission> Children { get; set; }
        }
    }
}