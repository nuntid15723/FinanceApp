namespace FinanceApp;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using FinanceApp.Services;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

public partial class LoginBase : ComponentBase
{
    [Inject]
    protected LoginService LoginService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    protected NavigationManager NavigationManager { get; set; }



    protected string user_name;
    protected string password;
    protected string selectedDatabase;

    protected string errorMessage;
    protected LoginResult loginResponse;
    protected async Task SubmitForm()
    {

        // string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        // string apiEndpoint = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        // var request = new HttpRequestMessage(HttpMethod.Get, apiEndpoint);

        // Add the Authorization header
        // request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

        if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))
        {
            errorMessage = "Username และ password ไม่สามารถเว้นว่างได้.";
            return;
        }

        loginResponse = await LoginService.Login(user_name, password);
        Console.WriteLine($"RESULT :{JsonConvert.SerializeObject(loginResponse)}");

        if (loginResponse.isSuccess)
        {
            Console.WriteLine("SubmitForm method invoked");
            Console.WriteLine($"user_name: {user_name}, password: {password}");
            ApiClient.authToken = loginResponse.accessToken;
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", loginResponse.accessToken);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "refreshToken", loginResponse.refreshToken);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "pin", loginResponse.PIN);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "user_name", user_name);
            // NavigationManager.NavigateTo("/dashboard");

            var authToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "user_name");
            Console.WriteLine($"authTokenmnmnn: {user_name}");
            //     Console.WriteLine($"authToken: {loginResponse.accessToken}");

            NavigationManager.NavigateTo("index", true);
        }
        else
        {
            errorMessage = loginResponse.RESPONSE_MESSAGE;
            Console.WriteLine($"loginResponse: {JsonConvert.SerializeObject(loginResponse)}");
        }
    }
}
