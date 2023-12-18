namespace FinanceApp.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


public class LoginService : IApiService
{

    private readonly IApiProvider _apiProvider;
    private readonly IHttpContextAccessor _accessor;

    public LoginService(IHttpContextAccessor accessor, IApiProvider apiProvider)
    {
        _apiProvider = apiProvider;
        _accessor = accessor;
    }

    public async Task<LoginResult> Login(string username, string password, string selectedDatabase)
    {

        var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        var userAgent = _accessor.HttpContext.Request.Headers["User-Agent"];

        var payload = new
        {
            app_version = userAgent,
            channel = "web_app",
            device_name = "Desktop",
            ip_address = ip,
            is_root = "0",
            platform = "android",
            unique_id = Constants.UniqueId,
            api_token = Constants.API.ApiKey,
            fcm_token = "",
            hms_token = "",
            member_no = username,
            password = password,
            username = username,
        };
        Console.WriteLine(username);
        Console.WriteLine(password);
        var reqUrl = Constants.Paths.UserLogin;
        var response = await _apiProvider.PostAsync(reqUrl, payload);


        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResult>(jsonResponse);
            if (loginResponse != null)
            {
                if (loginResponse.RESULT)
                {
                    return new LoginResult
                    {
                        RESULT = true,
                        ACCESS_TOKEN = loginResponse.ACCESS_TOKEN,
                        REFRESH_TOKEN = loginResponse.REFRESH_TOKEN,
                        PIN = loginResponse.PIN
                    };
                }
                else
                {
                    return new LoginResult
                    {
                        RESULT = false,
                        RESPONSE_CODE = loginResponse.RESPONSE_CODE,
                        RESPONSE_MESSAGE = loginResponse.RESPONSE_MESSAGE
                    };
                }
            }
            else
            {
                return new LoginResult
                {
                    RESULT = false,
                    RESPONSE_CODE = "500",
                    RESPONSE_MESSAGE = "Fecth API Error."
                };
            }
        }
        else
        {
            Console.WriteLine($"Request failed with status code {response.StatusCode}.");
            return new LoginResult
            {
                RESULT = false,
                RESPONSE_CODE = "500",
                RESPONSE_MESSAGE = "Fecth API Error."
            };
        }

    }


}

