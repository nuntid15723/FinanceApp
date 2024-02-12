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
    protected string selectedDatabase ="1";
    protected string errorMessage;
    protected LoginResult loginResponse;
    private bool isLoading = true;

    protected async Task SubmitForm()
    {
        string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
        var request = new HttpRequestMessage(HttpMethod.Get, bearerToken);
        // Add the Authorization header
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        Console.WriteLine($"request :{request.Headers.Authorization}");
        loginResponse = await LoginService.Login(user_name, password, selectedDatabase);
        if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(password))
        {
            errorMessage = "Username และ password ไม่สามารถเว้นว่างได้.";
            return;
        }
        if (loginResponse.Success)
        {
            ApiClient.authToken = loginResponse.accessToken;
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", loginResponse.accessToken);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "refreshToken", loginResponse.refreshToken);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "pin", loginResponse.PIN);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "user_name", user_name);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "coopControl", loginResponse.coopControl);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "coopId", loginResponse.coopId);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "fullName", loginResponse.fullName);
            var amsecUseappssJson = JsonConvert.SerializeObject(loginResponse.amsecUseappss);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "amsecUseappss", amsecUseappssJson);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "base_type", selectedDatabase);
            // await JSRuntime.InvokeVoidAsync("localStorage.setItem", "amsecUseappss", loginResponse.amsecUseappss);
            NavigationManager.NavigateTo("index", true);
        }
        else
        {
            errorMessage = loginResponse.RESPONSE_MESSAGE;
            Console.WriteLine($"loginResponse: {JsonConvert.SerializeObject(loginResponse)}");
        }

    }
    
}
