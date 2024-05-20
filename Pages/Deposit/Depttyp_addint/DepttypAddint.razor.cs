using System.Text.RegularExpressions;

namespace FinanceApp.Pages.Deposit.Depttyp_addint
{
    public partial class DepttypAddint
    {
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        private string? deptaccount_no { get; set; }
        private string? member_no { get; set; }
        
        public IEnumerable<Models.Statement_list> statementDetails { get; set; }
        public IEnumerable<Models.AccountDetails> dataaccDetails { get; set; }
        int selectedIndex = 0;
        bool isLoadingModals;
        bool isLoading;
        private async Task PerformSearch()
        {
            isLoading = true;
            // if (string.IsNullOrEmpty(deptno_format))
            // {
            //     ShowNotification(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error", Detail = "กรุณากรอกเลขทะเบียนสมาชิก", Duration = 1500 });
            // }
            // else
            // {
            //     await CallApi();
            //     await CheckDeptslipAmt();


            // }
            // isLoading = false;
        }

    }
}