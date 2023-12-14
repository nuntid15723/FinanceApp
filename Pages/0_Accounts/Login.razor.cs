// namespace FinanceApp;
// using Microsoft.AspNetCore.Components;
// using Microsoft.JSInterop;
// using FinanceApp.Services;
// using System.Threading.Tasks;

// public partial class LoginBase : ComponentBase
// {
//     [Inject]
//     protected LoginService LoginService { get; set; }

//     [Inject]
//     public IJSRuntime JSRuntime { get; set; }

//     [Inject]
//     protected NavigationManager NavigationManager { get; set; }



//     protected string username;
//     protected string password;
//     protected string selectedDatabase;

//     protected string errorMessage;
//     protected LoginResult loginResponse;

//     protected async Task SubmitForm()
//     {
//         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//         {
//             errorMessage = "Username และ password ไม่สามารถเว้นว่างได้.";
//             return;
//         }
//         loginResponse = await LoginService.Login(username, password, selectedDatabase);

//         if (loginResponse.RESULT)
//         {
//             Constants.authToken = loginResponse.ACCESS_TOKEN;
//             await JSRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", loginResponse.ACCESS_TOKEN);
//             await JSRuntime.InvokeVoidAsync("localStorage.setItem", "refreshToken", loginResponse.REFRESH_TOKEN);
//             await JSRuntime.InvokeVoidAsync("localStorage.setItem", "pin", loginResponse.PIN);
//             await JSRuntime.InvokeVoidAsync("localStorage.setItem", "username", username);
//             NavigationManager.NavigateTo("/dashboard");
//         }
//         else
//         {
//             errorMessage = loginResponse.RESPONSE_MESSAGE;
//         }
//     }
// }
