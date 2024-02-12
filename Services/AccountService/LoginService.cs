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
            coop_control = selectedDatabase == "1" ? "065001" : "079001",
            coop_id = selectedDatabase == "1" ? "065001" : "079001",
            user_name = user_name,
            password = password,
            base_id = selectedDatabase,
        };
        var reqUrl = ApiClient.Paths.UserLogin;
        var json = JsonConvert.SerializeObject(payload);
        Console.WriteLine($"reqUrl:{reqUrl}");
        Console.WriteLine($"payload content :{json}");
        var response = await _apiProvider.PostAsync(reqUrl, payload);
        Console.WriteLine($"presponse:{response}");

        Console.WriteLine($"response.IsSuccessStatusCode :{response.IsSuccessStatusCode}");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResult>(jsonResponse);
            Console.WriteLine($"isSuccess: {loginResponse.Success}");
            _state.SetAmsecUseappss((List<AmsecUseappss>)loginResponse.Content.Content);
            // getAmsecUseappss = new List<AmsecUseappss>();
            //     // getAmsecUseappss.AddRange(loginResponse.content.amsecUseappss);
            //     // foreach (var item in getAmsecUseappss)
            //     // {
            //     //     Console.WriteLine($"amsecUseappss: {item.application_name}");
            //     // }
            if (loginResponse != null)
            {
                if (loginResponse.Success)
                {
                    Console.WriteLine($"isSuccess: {loginResponse.Success}");
                    Console.WriteLine($"message: {loginResponse.Message}");
                    Console.WriteLine($"accessToken: {loginResponse.Content.AccessToken}");
                    Console.WriteLine($"refreshToken: {loginResponse.Content.RefreshToken}");
                    return new LoginResult
                    {
                        Success = true,
                        accessToken = loginResponse.Content.AccessToken,
                        refreshToken = loginResponse.Content.RefreshToken,
                        //coopControl = loginResponse.content.coopControl,
                        //coopId = loginResponse.content.coopId,
                        //fullName = loginResponse.content.fullName,
                        amsecUseappss = (List<AmsecUseappss>)loginResponse.Content.Content,
                        PIN = loginResponse.PIN,

                    };


                }
                else
                {
                    return new LoginResult
                    {
                        Success = false,
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
                    Success = false,
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
                Success = false,
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

