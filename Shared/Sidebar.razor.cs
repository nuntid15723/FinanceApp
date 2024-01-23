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
namespace FinanceApp.Shared
{
    public partial class Sidebar
    {
        [Parameter]
        public string Application { get; set; }
        private List<GroupPermission> GetContent { get; set; }
        public string coop_control { get; set; }
        public string coop_id { get; set; }
        public string application { get; set; }
        public string window_id { get; set; }
        public string user_name { get; set; }
        public string savedCheckFlag { get; set; }
        public string savedSaveStatus { get; set; }
        public string isSuccess { get; set; }
        public string message { get; set; }

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
                Console.WriteLine($"depOfGetAccount :{depOfGetAccount}");

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
                            // var WindowPermiss = new WindowPermission
                            // {
                            //     coop_control = windowPermission.coop_control,
                            //     coop_id = windowPermission.coop_id,
                            //     application = windowPermission.application,
                            //     window_id = windowPermission.window_id,
                            //     user_name = windowPermission.user_name,
                            //     check_flag = windowPermission.check_flag,
                            //     icon_name = windowPermission.icon_name,
                            //     win_object = windowPermission.win_object,
                            //     win_description = windowPermission.win_description,
                            //     save_status = windowPermission.save_status,
                            //     isSuccess = windowPermission.isSuccess,
                            //     message = windowPermission.message,
                            // };
                            // Console.WriteLine($"coop_control: {windowPermission.coop_control}");
                            // Console.WriteLine($"coop_id: {windowPermission.coop_id}");
                            // Console.WriteLine($"application: {windowPermission.application}");
                            // Console.WriteLine($"window_id: {windowPermission.window_id}");
                            // Console.WriteLine($"user_name: {windowPermission.user_name}");
                            // Console.WriteLine($"check_flag: {windowPermission.check_flag}");
                            // Console.WriteLine($"save_status: {windowPermission.save_status}");
                            // Console.WriteLine($"isSuccess: {windowPermission.isSuccess}"); 
                            // Console.WriteLine($"message: {windowPermission.message}"); 
                            // Console.WriteLine($"win_object: {windowPermission.win_object}");
                            Console.WriteLine($"win_description: {windowPermission.win_description}");
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
                    // ถ้าไม่มี token ให้เด้งไปยังหน้า login
                    NavigationManager.NavigateTo("/login", true);
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
            public string Application { get; set; }
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
                    Console.WriteLine($"payload content :{payload}");

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
        // public async Task HandleApplicationClick(string save_status, string check_flag)
        // {
        //     await JSRuntime.InvokeVoidAsync("localStorage.setItem", "save_status", save_status.ToString());
        //     await JSRuntime.InvokeVoidAsync("localStorage.setItem", "check_flag", check_flag.ToString());
        //     save_status = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "save_status");
        //     check_flag = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "check_flag");
        //     Console.WriteLine($"save_status :{save_status}");
        //     Console.WriteLine($"check_flag :{check_flag}");

        //     // StateHasChanged();
        // }
        public async Task HandleApplicationClick(int save_status, int check_flag)
        {
            // แปลง int เป็น string แล้วเรียกใช้ JavaScript function เพื่อเก็บค่าใน localStorage
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "save_status", save_status.ToString());
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "check_flag", check_flag.ToString());

            // ดึงค่าจาก localStorage และเก็บไว้ในตัวแปร
            savedSaveStatus = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "save_status");
            savedCheckFlag = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "check_flag");

            // แสดงผลลัพธ์ใน console ของเบราว์เซอร์
            Console.WriteLine($"Saved Save Status: {savedSaveStatus}");
            Console.WriteLine($"Saved Check Flag: {savedCheckFlag}");
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