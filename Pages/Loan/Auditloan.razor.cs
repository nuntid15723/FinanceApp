namespace FinanceApp.Pages.Loan
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
    }
}