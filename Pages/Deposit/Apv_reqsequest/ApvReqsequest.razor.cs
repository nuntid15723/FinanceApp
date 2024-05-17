using System.Text.RegularExpressions;

namespace FinanceApp.Pages.Deposit.Apv_reqsequest
{
    public partial class ApvReqsequest
    {
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        private string? deptno_format { get; set; }
        public IEnumerable<Models.Statement_list> statementDetails { get; set; }
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