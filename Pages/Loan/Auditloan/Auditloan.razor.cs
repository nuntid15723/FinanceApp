using Microsoft.AspNetCore.Components.Web;

namespace FinanceApp.Pages.Loan.Auditloan
{
    public partial class Auditloan
    {
        private int currentStep = 0;

        private void OnChange(int newStep)
        {
            currentStep = newStep;
            Console.WriteLine(newStep); // This will print the current step
            StateHasChanged();
        }
        private bool CanChange()
        {
            Console.WriteLine($"return true;{true}");
            return true;
        }
        private async Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Key == "F9")
            {
                currentStep = 1;
            }
        }
    }
}