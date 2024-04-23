using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace FinanceApp.Pages.Mbshr
{
    public partial class Memberdetail
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        private string member_no { get; set; }
        private string deptno_format { get; set; }
        public List<Datalist> datalists;
        private async Task SearchOfGet()
        {
            // กรองข้อมูลตามคำค้นหา
            Console.WriteLine(member_no);
            try
            {
                var depOfGetAccount = new
                {
                    coop_id = "065001",
                    memcoop_id = "065001",
                    // member_no = "10-00051044",
                    deptno_format = deptno_format,
                    deptitem_group = "DEP",
                };
                var jsonReq = JsonConvert.SerializeObject(depOfGetAccount);
                // var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Console.WriteLine(json);
                var apiUrl = $"{ApiClient.API.ApibaseUrl}{ApiClient.Paths.DepOfInitDataOffline}";
                var response = await SendApiRequestAsync(apiUrl, depOfGetAccount);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonRes = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonRes);
                Console.WriteLine(apiResponse);


                datalists = new List<Datalist> { apiResponse.data };
                Console.WriteLine(value: $"API request failed: {datalists}");
                foreach (var items in datalists)
                {
                    var ItemdeptSlip = items.deptSlip;
                    Console.WriteLine(ItemdeptSlip.coop_id);

                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nException Caught!");
                Console.WriteLine($"Message :{e.Message}");
            }
        }

        private async Task<HttpResponseMessage> SendApiRequestAsync<T>(string apiUrl, T payload)
        {
            try
            {
                string bearerToken = await JSRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

                    var json = JsonConvert.SerializeObject(payload);
                    Console.WriteLine($"response: {payload}");
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // Console.WriteLine($"bearerToken :{httpClient.DefaultRequestHeaders.Authorization}");

                    return await httpClient.PostAsync(apiUrl, content);
                }
            }
            catch (Exception ex)
            {
                // จัดการ Exception ตามความเหมาะสม
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
        private int currentStep = 0;
        public class ApiResponse
        {
            public bool status { get; set; }
            public Datalist data { get; set; }
            public string message { get; set; }
        }
        public class Datalist
        {
            public DeptSlip deptSlip { get; set; }
        }
        public class DeptSlip
        {

            public string? coop_id { get; set; }
            public string? deptcoop_id { get; set; }
            public string? deptslip_no { get; set; }
            public string? member_no { get; set; }
            public string? deptno_format { get; set; }
            public string? deptaccount_no { get; set; }
            public string? membcat_code { get; set; }
            public string? depttype_code { get; set; }
            public string? deptgroup_code { get; set; }
            public string? recppaytype_code { get; set; }
            public string? moneytype_code { get; set; }
            public string? bank_code { get; set; }
            public string? bankbranch_code { get; set; }
            public string? entry_id { get; set; }
            public string? machine_id { get; set; }
            public string? tofrom_accid { get; set; }
            public string? operate_date { get; set; }
            public string? entry_date { get; set; }
            public string? calint_from { get; set; }
            public string? calint_to { get; set; }
            public string? sign_flag { get; set; }
            public string? laststmseq_no { get; set; }
            public string? dpstm_no { get; set; }
            public string? nobook_flag { get; set; }
            public string? prnc_no { get; set; }
            public string? deptslip_amt { get; set; }
            public string? deptslip_netamt { get; set; }
            public string? fee_amt { get; set; }
            public string? oth_amt { get; set; }
            public string? prncbal { get; set; }
            public string? withdrawable_amt { get; set; }
            public string? checkpend_amt { get; set; }
            public string? prncbal_bf { get; set; }
            public string? tax_amt { get; set; }
            public string? tax_return { get; set; }
            public string? int_amt { get; set; }
            public string? int_return { get; set; }
            public string? int_netamt { get; set; }
            public string? intbonus_amt { get; set; }
            public string? slipnetprncbal_amt { get; set; }
            public string? posttovc_flag { get; set; }
            public string? refer_slipno { get; set; }
            public string? deptaccount_name { get; set; }
            public string? depttype_desc { get; set; }
            public string? dept_objective { get; set; }
            public string? refer_app { get; set; }
            public string? prncbal_retire { get; set; }
            public string? remark { get; set; }
            public string? group_itemtype { get; set; }
            public string? deptslip_date { get; set; }
            List<Recppaytype> recppaytypes { get; set; }
            List<Tofromacc> tofromacc { get; set; }
            public string? depttype { get; set; }
            public string? trandepttype { get; set; }
            public string? acctype { get; set; }
            public string? bank { get; set; }
            public string? branch { get; set; }
            public string? tranDeptno { get; set; }
            public string? due_date { get; set; }
            public string? deptpassbook_no { get; set; }
            public string? condforwithdraw { get; set; }
            public string? passbook_flag { get; set; }
            public string? upint_time { get; set; }
            public string? deptaccount_ename { get; set; }
            public string? deptrequest_docno { get; set; }
            public string? account_type { get; set; }
            public string? monthintpay_meth { get; set; }
            public string? traninttype_code { get; set; }
            public string? tran_deptacc_no { get; set; }
            public string? tran_bankacc_no { get; set; }
            public string? dept_tranacc_name { get; set; }
            public string? deptmonth_status { get; set; }
            public string? deptmonth_amt { get; set; }
            public string? dept_status { get; set; }
            public string? monthint_status { get; set; }
            public string? f_tax_rate { get; set; }
            public string? adjdate_status { get; set; }
            public string? membcat_desc { get; set; }
            public string? reqappl_flag { get; set; }
            public string? spcint_rate_status { get; set; }
            public string? spcint_rate { get; set; }
            public string? payother_meth { get; set; }
            public string? payfee_meth { get; set; }

        }

        public class Recppaytype
        {
            public string? recppaytype_code { get; set; }
            public string? recppaytype_desc { get; set; }
            public string? cash_type { get; set; }
            public string? tofrom_accid { get; set; }
            public string? genvc_flag { get; set; }
            public string? adjdate_status { get; set; }
        }

        public class Tofromacc
        {
            public string? tofrom_accid { get; set; }
            public string? tofrom_accdesc { get; set; }
            public string? cash_type { get; set; }
        }

    }
}