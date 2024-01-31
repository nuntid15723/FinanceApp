namespace FinanceApp.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components;

public class LoginService : IApiService
{

    private readonly IApiProvider _apiProvider;
    private readonly StateContainer _state;
    public List<AmsecUseappss>? getAmsecUseappss { get; set; }
    private readonly IHttpContextAccessor _accessor;
    public LoginService(IHttpContextAccessor accessor, IApiProvider apiProvider, StateContainer state)
    {
        _apiProvider = apiProvider;
        _accessor = accessor;
        _state = state;

    }
    [Inject]
    public IJSRuntime JSRuntime { get; set; }


    public async Task<LoginResult> Login(string user_name, string password, string selectedDatabase)
    {
        var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        var userAgent = _accessor.HttpContext.Request.Headers["User-Agent"];
        var payload = new
        {
            coop_control = "065001",
            coop_id = "065001",
            user_name = user_name,
            password = password,
            base_type = selectedDatabase,
        };
        var reqUrl = ApiClient.Paths.UserLogin;
        var response = await _apiProvider.PostAsync(reqUrl, payload);
        Console.WriteLine($"jsonData : {payload}");
        Console.WriteLine($"response.IsSuccessStatusCode :{response.IsSuccessStatusCode}");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResult>(jsonResponse);
            Console.WriteLine($"isSuccess: {loginResponse.isSuccess}");
            _state.SetAmsecUseappss(loginResponse.content.amsecUseappss);
            // getAmsecUseappss = new List<AmsecUseappss>();
            //     // getAmsecUseappss.AddRange(loginResponse.content.amsecUseappss);
            //     // foreach (var item in getAmsecUseappss)
            //     // {
            //     //     Console.WriteLine($"amsecUseappss: {item.application_name}");
            //     // }
            if (loginResponse != null)
            {
                if (loginResponse.isSuccess)
                {
                    Console.WriteLine($"isSuccess: {loginResponse.isSuccess}");
                    Console.WriteLine($"message: {loginResponse.message}");
                    Console.WriteLine($"accessToken: {loginResponse.content.accessToken}");
                    Console.WriteLine($"refreshToken: {loginResponse.content.refreshToken}");
                    return new LoginResult
                    {
                        isSuccess = true,
                        accessToken = loginResponse.content.accessToken,
                        refreshToken = loginResponse.content.refreshToken,
                        coopControl = loginResponse.content.coopControl,
                        coopId = loginResponse.content.coopId,
                        fullName = loginResponse.content.fullName,
                        amsecUseappss = loginResponse.content.amsecUseappss,
                        PIN = loginResponse.PIN,

                    };


                }
                else
                {
                    return new LoginResult
                    {
                        isSuccess = false,
                        RESPONSE_CODE = loginResponse.RESPONSE_CODE,
                        RESPONSE_MESSAGE = loginResponse.RESPONSE_MESSAGE
                    };
                }
            }
            else
            {
                Console.WriteLine($"Request failed with status code {response.StatusCode}.");
                return new LoginResult
                {
                    isSuccess = false,
                    RESPONSE_CODE = "500",
                    RESPONSE_MESSAGE = "Username หรือ password ไม่ถูกต้อง."
                };
            }
        }
        else
        {
            Console.WriteLine($"Request failed with status code {response.StatusCode}.");
            return new LoginResult
            {
                isSuccess = false,
                RESPONSE_CODE = "500",
                RESPONSE_MESSAGE = "Username หรือ password ไม่ถูกต้อง."
            };
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
                Console.WriteLine($"payload content :{json}");

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
}

