// // สร้างไฟล์ ApiRequestService.cs หรือตามชื่อที่คุณต้องการ
// using System.Net.Http.Headers;
// using System.Text;
// using Microsoft.JSInterop;
// using Newtonsoft.Json;

// public class ApiRequestService
// {
//     private readonly IJSRuntime _jsRuntime;

//     public ApiRequestService(IJSRuntime jsRuntime)
//     {
//         _jsRuntime = jsRuntime;
//     }

//     public async Task<HttpResponseMessage> SendApiRequestAsync<T>(string apiUrl, T payload)
//     {
//         try
//         {
//             string bearerToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

//             using (var httpClient = new HttpClient())
//             {
//                 httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

//                 var json = JsonConvert.SerializeObject(payload);
//                 var content = new StringContent(json, Encoding.UTF8, "application/json");

//                 return await httpClient.PostAsync(apiUrl, content);
//             }
//         }
//         catch (Exception ex)
//         {
//             // จัดการ Exception ตามความเหมาะสม
//             Console.WriteLine($"Error: {ex.Message}");
//             throw;
//         }
//     }
// }
