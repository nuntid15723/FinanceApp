using System.Net;
using FinanceApp.Services;
using Newtonsoft.Json;
using FinanceApp.Models;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace FinanceApp.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        void HandleItemClick(string application, string applicationName)
        {
            // ทำอะไรกับค่า application ที่คุณได้รับ
            // ตัวอย่าง: ส่งค่าไปยัง C# method
            StateHasChanged();

            HandleApplicationClick(application, applicationName);
            
        }
        async Task HandleApplicationClick(string application ,string applicationName)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "application", application);
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", "applicationName", applicationName);
            string applicationValue = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "application");
            string applicationNames = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "applicationName");
            Console.WriteLine($"application :{applicationValue}");
            Console.WriteLine($"applicationNames :{applicationNames}");
            StateHasChanged();
        }

    }
}