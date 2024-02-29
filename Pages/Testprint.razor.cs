using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace FinanceApp.Pages
{
    public partial class Testprint
    {
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected async Task CreateAndPrintPDF(string htmlData)
        {
            await JSRuntime.InvokeVoidAsync("blazorCreateAndPrintPDF", htmlData);
        }

    }
}