using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace FinanceApp.Services;
public class Api_Provider
{
    private readonly IJSRuntime _jsRuntime;

    public Api_Provider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public async Task<HttpResponseMessage> SendApiRequestAsync<T>(string apiUrl, T payload)
    {
        try
        {
            string bearerToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                var json = JsonConvert.SerializeObject(payload);
                Console.WriteLine($"response: {payload}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Console.WriteLine($"bearerToken :{httpClient.DefaultRequestHeaders.Authorization}");

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
    public async Task<HttpResponseMessage> SendApiRequestAsyncPut<T>(string apiUrl, T payload)
    {
        try
        {
            string bearerToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                var json = JsonConvert.SerializeObject(payload);
                Console.WriteLine($"response: {payload}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Console.WriteLine($"bearerToken :{httpClient.DefaultRequestHeaders.Authorization}");

                return await httpClient.PutAsync(apiUrl, content);
            }
        }
        catch (Exception ex)
        {
            // จัดการ Exception ตามความเหมาะสม
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
    public async Task<HttpResponseMessage> SendApiRequestAsyncGet(string apiUrl)
    {
        try
        {
            string bearerToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            Console.WriteLine($"bearerToken: {bearerToken}");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                return await httpClient.GetAsync(apiUrl);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error11: {ex.Message}");
            throw;
        }
    }
}