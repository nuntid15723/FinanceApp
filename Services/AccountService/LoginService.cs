namespace FinanceApp.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using System.Text;
using System.Net.Http;



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
    public async Task<LoginResult> Login(string user_name, string password)
    {
        var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        var userAgent = _accessor.HttpContext.Request.Headers["User-Agent"];
        var payload = new
        {
            coop_control = "065001",
            coop_id = "065001",
            user_name = user_name,
            password = password,
        };
        var reqUrl = ApiClient.Paths.UserLogin;
        var response = await _apiProvider.PostAsync(reqUrl, payload);
        Console.WriteLine($"jsonData : {payload}");
        // Console.WriteLine($"response.IsSuccessStatusCode :{response.IsSuccessStatusCode}");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResult>(jsonResponse);
            Console.WriteLine($"isSuccess: {loginResponse.isSuccess}");
            _state.SetAmsecUseappss(loginResponse.content.amsecUseappss);
            // getAmsecUseappss = new List<AmsecUseappss>();
            // getAmsecUseappss.AddRange(loginResponse.content.amsecUseappss);
            // foreach (var item in getAmsecUseappss)
            // {
            //     Console.WriteLine($"amsecUseappss: {item.application_name}");
            // }
            if (loginResponse != null)
            {
                if (loginResponse.isSuccess)
                {
                    // Console.WriteLine($"amsecUseappssList: {getAmsecUseappss}");
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
}

